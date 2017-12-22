using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace BitcoinTools
{
    public enum CharacterPool
    {
        AlphanumericMixedCase = 0,
        AlphanumericUppercase = 1,
        AlphanumericLowercase = 2,
        Numeric = 3,
        AlphaMixedCase = 4,
        AlphaUppercase = 5,
        AlphaLowercase = 6
    }


    public class Encoding
    {
        
        static readonly string[] CharacterPoolValues = {
                "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz",
                "123456789ABCDEFGHJKLMNPQRSTUVWXYZ",
                "123456789abcdefghijkmnopqrstuvwxyz",
                "123456789",
                "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz",
                "ABCDEFGHJKLMNPQRSTUVWXYZ",
                "abcdefghijkmnopqrstuvwxyz"
            };

        public static byte[] HexToBytes(string hex)
        {
            int GetHexVal(char c)
            {
                int val = c;
                return val - (val < 58 ? 48 : 87);
            }

            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];
            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }
            return arr;
        }

        public static long XorBytesToInt64(byte[] bytes)
        {
            long val = default(long);
            for (int index = 0; index < bytes.Length;)
            {
                var byteLen = bytes.Length - index;
                if (byteLen >= 8)
                {
                    val ^= BitConverter.ToInt64(bytes, index);
                    index += 8;
                }
                else if (byteLen >= 4)
                {
                    val ^= BitConverter.ToInt32(bytes, index);
                    index += 4;
                }
                else if (byteLen >= 2)
                {
                    val ^= BitConverter.ToInt16(bytes, index);
                    index += 2;
                }
                else
                {
                    val ^= bytes[index];
                    index += 1;
                }
            }
            return val;
        }

        public static int XorBytesToInt32(byte[] bytes)
        {
            int val = default(int);
            for (int index = 0; index < bytes.Length;)
            {
                var byteLen = bytes.Length - index;
                if (byteLen >= 4)
                {
                    val ^= BitConverter.ToInt32(bytes, index);
                    index += 4;
                }
                else if (byteLen >= 2)
                {
                    val ^= BitConverter.ToInt16(bytes, index);
                    index += 2;
                }
                else
                {
                    val ^= bytes[index];
                    index += 1;
                }
            }
            return val;
        }

        public static byte[] RipeMD160(byte[] bytes)
        {
            using (var d = new RIPEMD160Managed())
            {
                var result = d.ComputeHash(bytes);
                return result;
            }
        }

        public static byte[] PublicKeyToAddressBytes(byte[] bytes)
        {
            var sha = Sha256(bytes);
            var ripemd = RipeMD160(sha);

            var versioned = new byte[ripemd.Length + 1];
            Buffer.BlockCopy(ripemd, 0, versioned, 1, ripemd.Length);

            var checksum = DoubleSha256(versioned);

            var addr = new byte[versioned.Length + 4];
            Buffer.BlockCopy(versioned, 0, addr, 0, versioned.Length);
            Buffer.BlockCopy(checksum, 0, addr, addr.Length - 4, 4);

            return addr;
        }

        public static byte[] DoubleSha256(byte[] bytes)
        {
            return Sha256(Sha256(bytes));
        }

        public static byte[] Sha256(byte[] bytes)
        {
            using (var d = new SHA256Managed())
            {
                var result = d.ComputeHash(bytes);
                return result;
            }
        }

        public static byte[] Sha256(string s)
        {
            return Sha256(System.Text.Encoding.ASCII.GetBytes(s));
        }

        public static string GetCharacterPool(CharacterPool type = CharacterPool.AlphanumericMixedCase)
        {
            return CharacterPoolValues[(int)type];
        }

        public static string Base58Encode(byte[] bytes)
        {
            return BaseEncode(bytes, CharacterPool.AlphanumericMixedCase, true);
        }

        public static string BaseEncode(byte[] bytes, CharacterPool characterPool, bool preserveLeadingZeros)
        {
            var pool = GetCharacterPool(characterPool);
            var byteEndian = new byte[bytes.Length + 1];
            Buffer.BlockCopy(bytes, 0, byteEndian, 1, bytes.Length);
            Array.Reverse(byteEndian);
            var intData = new BigInteger(byteEndian);
            string result = "";
            while (intData > 0)
            {
                int remainder = (int)(intData % pool.Length);
                intData /= pool.Length;
                result = pool[remainder] + result;
            }

            if (preserveLeadingZeros)
            {
                for (int i = 0; i < bytes.Length && bytes[i] == 0; i++)
                    result = '1' + result;
            }
            return result;
        }


        public static byte[] Base58Decode(string s)
        {
            var Base58Alphabet = GetCharacterPool(CharacterPool.AlphanumericMixedCase);
            BigInteger intData = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int digit = Base58Alphabet.IndexOf(s[i]);
                if (digit < 0)
                    throw new FormatException(string.Format("Invalid Base58 character `{0}` at position {1}", s[i], i));
                intData = intData * 58 + digit;
            }
            int leadingZeroCount = s.TakeWhile(c => c == '1').Count();
            var leadingZeros = Enumerable.Repeat((byte)0, leadingZeroCount);
            var bytesWithoutLeadingZeros = intData.ToByteArray().Reverse().SkipWhile(b => b == 0);
            return leadingZeros.Concat(bytesWithoutLeadingZeros).ToArray();
        }

        public static byte[] WifToBytes(string wif)
        {
            var bytes = Base58Decode(wif);
            var trimmed = new byte[32];
            Buffer.BlockCopy(bytes, 1, trimmed, 0, trimmed.Length);
            return trimmed;
        }

        public static string BytesToWif(byte[] bytes)
        {
            var addr = new byte[bytes.Length + 1];
            addr[0] = 128;
            Buffer.BlockCopy(bytes, 0, addr, 1, bytes.Length);
            var checksum = DoubleSha256(addr);
            Array.Resize(ref addr, addr.Length + 4);
            Buffer.BlockCopy(checksum, 0, addr, addr.Length - 4, 4);
            return Base58Encode(addr);
        }

        public static string BytesToWifCompressed(byte[] bytes)
        {
            var addr = new byte[bytes.Length + 2];
            addr[0] = 128;
            addr[addr.Length - 1] = 0x01;
            Buffer.BlockCopy(bytes, 0, addr, 1, bytes.Length);
            var checksum = DoubleSha256(addr);
            Array.Resize(ref addr, addr.Length + 4);
            Buffer.BlockCopy(checksum, 0, addr, addr.Length - 4, 4);
            return Base58Encode(addr);
        }

        public static string PassphraseToWif(string passphrase)
        {
            var privateKeyBytes = Sha256(System.Text.Encoding.UTF8.GetBytes(passphrase));
            return BytesToWif(privateKeyBytes);
        }

        public static string BytesToHex(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
        }

    }


}
