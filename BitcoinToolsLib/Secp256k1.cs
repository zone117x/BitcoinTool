using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


/* 
 * Elliptic curve math ported from bitcoinjs-lib https://github.com/bitcoinjs/bitcoinjs-lib
 */


namespace BitcoinTools
{
    public class Secp256k1
    {

        static class Parameters
        {
            public readonly static ECCurve curve;
            public readonly static ECPoint g;
            public readonly static BigInteger n;
            public readonly static BigInteger h = 1;

            static Parameters()
            {
                n = BigInteger.Parse("115792089237316195423570985008687907852837564279074904382605163141518161494337");
                curve = new ECCurve(
                    BigInteger.Parse("115792089237316195423570985008687907853269984665640564039457584007908834671663"),
                    0,
                    7
                );
                g = new ECPoint(curve,
                    curve.FromBigInteger(BigInteger.Parse("55066263022277343669578718895168534326250603453777594175500187360389116729240")),
                    curve.FromBigInteger(BigInteger.Parse("32670510020758816978083085130507043184471273380659243275938904335757337482424")),
                    1
                );
            }
        }

        ECPoint point;
        byte[] privateKey;

        public Secp256k1(byte[] privateKey)
        {
            this.privateKey = privateKey;
            point = Parameters.g.Multiply(new BigInteger(privateKey.Reverse().Concat(new byte[] { 0 }).ToArray()));
        }

        public byte[] GetPublicKey(bool compressed)
        {
            return GetEncoded(point, compressed);
        }

        byte[] GetEncoded(ECPoint point, bool compressed)
        {
            var x = point.GetX().ToInt();
            var y = point.GetY().ToInt();

            var enc = ToReversedBytes(x);

            if (compressed)
            {
                if (y.IsEven)
                    enc = new byte[] { 2 }.Concat(enc).ToArray();
                else
                    enc = new byte[] { 3 }.Concat(enc).ToArray();
            }
            else
                enc = new byte[] { 4 }.Concat(enc).Concat(ToReversedBytes(y)).ToArray();

            return enc;
        }


        //DER encoding ported from Brainwallet http://brainwallet.org/js/brainwallet.js
        public byte[] GetDER(bool compressed)
        {

            Func<int, byte[]> EncodeLength = len =>
            {
                if (len < 0x80) return new byte[] { (byte)len };
                else if (len < 255) return new byte[] { 0x80 | 1, (byte)len };
                else return new byte[] { 0x80 | 2, (byte)(len >> 8), (byte)(len & 0xff) };
            };
            Func<byte, byte[], byte[]> EncodeId = (id, s) => new byte[] { id }.Concat(EncodeLength(s.Length)).Concat(s).ToArray();
            Func<byte[], byte[]> EncodeBitstring = s => EncodeId(0x03, s);
            Func<byte, byte[], byte[]> EncodeConstructed = (tag, s) => EncodeId((byte)(0xa0 + tag), s);
            Func<byte[], byte[]> EncodeOctetString = s => EncodeId(0x04, s);
            Func<byte[], byte[]> EncodeInteger = s => EncodeId(0x02, s);
            Func<byte[][], byte[]> EncodeSequence = args =>
            {
                IEnumerable<byte> joined = new byte[] { };
                foreach (byte[] parts in args) joined = joined.Concat(parts);
                var sequence = joined.ToArray();
                return EncodeId(0x30, sequence);
            };

            EncodeSequence(new[] { new byte[] { } });

            var p = ToReversedBytes(Parameters.curve.q);
            var r = ToReversedBytes(Parameters.n);
            var encoded_oid = new byte[] { 6, 7, 42, 134, 72, 206, 61, 1, 1 };

            var secret = privateKey;
            var encoded_gxgy = GetEncoded(Parameters.g, compressed);
            var encoded_pub = GetPublicKey(compressed);

            return EncodeSequence(new byte[][] {
                    EncodeInteger(new byte[]{1}),
                    EncodeOctetString(secret),
                    EncodeConstructed(0, 
                        EncodeSequence(new[]{
                            EncodeInteger(new byte[]{1}),
                            EncodeSequence(new[]{
                                encoded_oid,
                                EncodeInteger(new byte[]{0}.Concat(p).ToArray())
                            }),
                            EncodeSequence(new[]{
                                EncodeOctetString(new byte[]{0}),
                                EncodeOctetString(new byte[]{7})
                            }),
                            EncodeOctetString(encoded_gxgy),
                            EncodeInteger(new byte[]{0}.Concat(r).ToArray()),
                            EncodeInteger(new byte[]{1})
                        })
                    ),
                    EncodeConstructed(1,
                        EncodeBitstring(new byte[]{0}.Concat(encoded_pub).ToArray())
                    )
                });
        }



        class ECFieldElement
        {
            BigInteger q, x;
            public ECFieldElement(BigInteger q, BigInteger x)
            {
                this.q = q;
                this.x = x;
            }

            public BigInteger ToInt()
            {
                return x;
            }

            public ECFieldElement Negate()
            {
                return new ECFieldElement(q, Mod(BigInteger.Negate(x), q));
            }
        }

        class ECPoint
        {
            ECFieldElement x, y;
            BigInteger z, zinv;
            ECCurve curve;
            public ECPoint(ECCurve curve, ECFieldElement x, ECFieldElement y, BigInteger z)
            {
                this.curve = curve;
                this.x = x;
                this.y = y;
                this.z = z;
                zinv = BigInteger.ModPow(z, curve.q - 2, curve.q);
            }


            public ECPoint Multiply(BigInteger k)
            {
                if (IsInfinity()) return this;
                if (k.Sign == 0) return curve.infinity;


                var neg = Negate();
                var R = this;
                var h = k * 3;

                var hBitArray = new BitArray(h.ToByteArray());
                var kBitArray = new BitArray(k.ToByteArray());

                var hBitLength = 0;
                do hBitLength++;
                while ((h >>= 1) != 0);

                for (var i = hBitLength - 2; i > 0; --i)
                {
                    R = R.Twice();
                    
                    var hBit = hBitArray[i];
                    var eBit = kBitArray[i];

                    if (hBit != eBit)
                        R = R.Add(hBit ? this : neg);

                }

                return R;
            }

            public ECPoint Add(ECPoint b)
            {
                if (IsInfinity()) return b;
                if (b.IsInfinity()) return this;

                var u = Mod(b.y.ToInt() * z - y.ToInt() * b.z, curve.q);
                var v = Mod(b.x.ToInt() * z - x.ToInt() * b.z, curve.q);

                if (BigInteger.Zero.Equals(v))
                {
                    if (BigInteger.Zero.Equals(u))
                        return Twice();
                    return curve.infinity;
                }

                var v2 = BigInteger.Pow(v, 2);
                var v3 = v2 * v;

                var x1v2 = x.ToInt() * v2;
                var zu2 = BigInteger.Pow(u, 2) * z;

                var x3 = Mod((((zu2 - (x1v2 << 1)) * b.z) - v3) * v, curve.q);
                var y3 = Mod((((((x1v2 * 3) * u) - (y.ToInt() * v3)) - (zu2 * u)) * b.z) + (u * v3), curve.q);
                var z3 = Mod((v3 * z) * b.z, curve.q);

                return new ECPoint(curve, curve.FromBigInteger(x3), curve.FromBigInteger(y3), z3);
            }

            public ECPoint Twice()
            {
                if (IsInfinity()) return this;
                if (y.ToInt().Sign == 0) return curve.infinity;

                var x1 = x.ToInt();
                var y1 = y.ToInt();

                var y1z1 = y1 * z;
                var y1sqz1 = Mod(y1z1 * y1, curve.q);
                var a = curve.a.ToInt();

                var w = BigInteger.Pow(x1, 2) * 3;

                if (!BigInteger.Zero.Equals(a))
                    w = w + (BigInteger.Pow(z, 2) * a);

                w = Mod(w, curve.q);
                var x3 = Mod(((BigInteger.Pow(w, 2) - ((x1 << 3) * y1sqz1)) << 1) * y1z1, curve.q);
                var y3 = Mod((((((w * 3) * x1) - (y1sqz1 << 1)) << 2) * y1sqz1) - (BigInteger.Pow(w, 2) * w), curve.q);
                var z3 = Mod((BigInteger.Pow(y1z1, 2) * y1z1) << 3, curve.q);

                return new ECPoint(curve, curve.FromBigInteger(x3), curve.FromBigInteger(y3), z3);
            }

            public ECPoint Negate()
            {
                return new ECPoint(curve, x, y.Negate(), z);
            }

            public bool IsInfinity()
            {
                if ((x == null) && (y == null))
                    return true;

                return (z == BigInteger.Zero) && (y.ToInt() != BigInteger.Zero);
            }

            public ECFieldElement GetX()
            {
                return curve.FromBigInteger(Mod(x.ToInt() * zinv, curve.q));
            }

            public ECFieldElement GetY()
            {
                return curve.FromBigInteger(Mod(y.ToInt() * zinv, curve.q));
            }
        }

        class ECCurve
        {
            public BigInteger q;
            public ECFieldElement a, b;
            public ECPoint infinity;

            public ECCurve(BigInteger q, BigInteger a, BigInteger b)
            {
                this.q = q;
                this.a = FromBigInteger(a);
                this.b = FromBigInteger(b);
                infinity = new ECPoint(this, null, null, 1);
            }

            public ECFieldElement FromBigInteger(BigInteger x)
            {
                return new ECFieldElement(q, x);
            }

        }

        static byte[] ToReversedBytes(BigInteger bi)
        {
            var bytes = bi.ToByteArray();
            if (bytes.Length % 2 == 1)
                Array.Resize(ref bytes, bytes.Length - 1);
            Array.Reverse(bytes);
            return bytes;
        }

        static BigInteger Mod(BigInteger x, BigInteger m)
        {
            var r = x % m;
            return r < 0 ? r + m : r;
        }

    }

}