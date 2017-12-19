using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTool
{
    public partial class Wallet
    {
        Secp256k1 curvePoint;
        byte[] privateKeyBytes;


        static byte[] HexToBytes(String HexString)
        {
            int NumberChars = HexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return bytes;
        }

        public static Wallet FromPassphrase(string passphrase)
        {
            var privateKeyBytes = Encoders.SHA256(Encoding.ASCII.GetBytes(passphrase));
            return new Wallet(privateKeyBytes);
        }

        public static Wallet FromPrivateKeyHex(string hex)
        {
            return new Wallet(HexToBytes(hex));
        }

        public static Wallet FromMiniKey(string miniKey)
        {
            switch (miniKey.Length)
            {
                case 22:
                case 30:
                    ValidateMiniKey(miniKey);
                    var privateKeyBytes = Encoders.SHA256(miniKey);
                    return new Wallet(privateKeyBytes);
                default:
                    throw new System.ArgumentException("Key must be 22 or 30 chars for minikeys");
            }
        }

        public static Wallet FromWIF(string privateKey, Action<bool> isCompressed = null)
        {

            CheckBase58(privateKey);

            byte[] privateKeyBytes;
            switch (privateKey.Length)
            {
                case 51:
                case 52:
                    ValidatePrivateKey(privateKey);
                    privateKeyBytes = Encoders.WIFToBytes(privateKey);
                    break;
                default:
                    throw new System.ArgumentException("Key must be 51 or 52 chars");
            }

            var compressed = privateKey.Length == 52;
            if (isCompressed != null) isCompressed(compressed);

            return new Wallet(privateKeyBytes);
        }

        public Wallet()
        {
            privateKeyBytes = GeneratePrivateKey();
        }

        public Wallet(byte[] privateKeyBytes)
        {
            this.privateKeyBytes = privateKeyBytes;
        }

        static void CheckBase58(string key)
        {
            var pool = Encoders.GetCharacterPool();
            foreach (char c in key)
            {
                if (!pool.Contains(c))
                    throw new System.ArgumentException("Key cannot contain the '" + c + "' character");
            }
        }

        static void ValidatePrivateKey(string key)
        {
            if (key.Length == 51 && key[0] != '5')
                throw new System.ArgumentException("Uncompressed key must begin with the number 5");
            if (key.Length == 52 && !(key[0] == 'K' || key[0] == 'L'))
                throw new System.ArgumentException("Compressed key must begin with the letters K or L");
            if (!WIFPassedChecksum(key))
                throw new System.ArgumentException("WIF did not pass checksum");

        }

        static void ValidateMiniKey(string minikey)
        {
            if (!minikey.StartsWith("S"))
                throw new System.ArgumentException("Missing S Prefix");
            if (!(minikey.Length == 30 || minikey.Length == 22))
                throw new System.ArgumentException("Invalid length, must be 30 or 22 chars");
            if (Encoders.SHA256(minikey + "?")[0] != 0)
                throw new System.ArgumentException("Failed to pass typo check");

        }


        static bool WIFPassedChecksum(string key)
        {
            var decoded = Encoders.Base58Decode(key);
            var checksum = decoded.Skip(decoded.Count() - 4).Take(4).ToArray();
            var keyBytes = decoded.Take(decoded.Count() - 4).ToArray();
            var newChecksum = Encoders.DoubleSHA256(keyBytes).Take(4).ToArray();

            return newChecksum.SequenceEqual(checksum);
        }

        public string PrivateKeyHex => Encoders.BytesToHex(privateKeyBytes);

        public byte[] PrivateKeyBytes => privateKeyBytes;

        public string PrivateKeyWIFCompressed => Encoders.BytesToWIF(privateKeyBytes, true);

        public string PrivateKeyWIF => Encoders.BytesToWIF(privateKeyBytes, false);

        public string PrivateKeyDERCompressed => Encoders.BytesToHex(CurvePoint.GetDER(true));

        public string PrivateKeyDER => Encoders.BytesToHex(CurvePoint.GetDER(false));

        Secp256k1 CurvePoint
        {
            get
            {
                if (curvePoint == null)
                    curvePoint = new Secp256k1(privateKeyBytes);
                return curvePoint;
            }
        }

        public string Hash160Compressed
        {
            get
            {
                return Encoders.BytesToHex(Encoders.Hash160(Encoders.SHA256(PublicKeyBytesCompressed)));
            }
        }

        public string Hash160
        {
            get
            {
                return Encoders.BytesToHex(Encoders.Hash160(Encoders.SHA256(PublicKeyBytes)));
            }
        }

        public string PublicKeyHexCompressed => Encoders.BytesToHex(PublicKeyBytesCompressed);

        public string PublicKeyHex => Encoders.BytesToHex(PublicKeyBytes);

        public byte[] PublicKeyBytesCompressed
        {
            get
            {
                return CurvePoint.GetPublicKey(true);
            }
        }

        public byte[] PublicKeyBytes
        {
            get
            {
                return CurvePoint.GetPublicKey(false);
            }
        }

        public string AddressCompressed
        {
            get
            {
                var addressBytes = Encoders.PublicKeyToAddressBytes(PublicKeyBytesCompressed);
                return Encoders.Base58CheckEncode(addressBytes);
            }
        }

        public string Address
        {
            get
            {
                var addressBytes = Encoders.PublicKeyToAddressBytes(PublicKeyBytes);
                return Encoders.Base58CheckEncode(addressBytes);
            }
        }

        byte[] GeneratePrivateKey()
        {
            var ff = RandomNumberGenerator.Create();
            var privateKeyBytes = new byte[32];
            ff.GetNonZeroBytes(privateKeyBytes);
            return privateKeyBytes;
        }

        public static string GenerateMiniKey(CharacterPool type = CharacterPool.AlphanumericMixedCase)
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            var pool = Encoders.GetCharacterPool(type);
            while (true)
            {
                var bytes = new byte[29];
                random.GetNonZeroBytes(bytes);
                var minikey = "S" + new String(bytes.Select<byte, char>(x => pool[x % pool.Length]).ToArray());

                try
                {
                    ValidateMiniKey(minikey);
                    return minikey;
                }
                catch (Exception e)
                {
                    if (e.Message != "Failed to pass typo check")
                    {
                        var aa = minikey.Length;
                        Console.WriteLine(aa);
                    }
                }
            }
        }

        public static string GenerateUpperWIF()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            var pool = Encoders.GetCharacterPool(CharacterPool.AlphanumericUppercase);
            long attempts = 0;
            while (true)
            {
                var bytes = new byte[51];
                random.GetNonZeroBytes(bytes);
                var prefix = attempts++ % 2 == 0 ? "L" : "K";
                var key = prefix + new String(bytes.Select(x => pool[x % pool.Length]).ToArray());

                try
                {
                    ValidatePrivateKey(key);
                    return key;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " : " + key);
                }
            }
        }

 
        
    }
}
