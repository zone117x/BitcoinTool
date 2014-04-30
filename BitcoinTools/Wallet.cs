using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTool
{
    public class Wallet
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

        public string PrivateKeyHex
        {
            get
            {
                return Encoders.BytesToHex(privateKeyBytes);
            }
        }
        public byte[] PrivateKeyBytes
        {
            get
            {
                return privateKeyBytes;
            }
        }
        public string PrivateKeyWIF(bool compressed)
        {
            return Encoders.BytesToWIF(privateKeyBytes, compressed);
        }
        public string PrivateKeyDER(bool compressed)
        {
            return Encoders.BytesToHex(CurvePoint.GetDER(compressed));
        }
        

        Secp256k1 CurvePoint
        {
            get
            {
                if (curvePoint == null)
                    curvePoint = new Secp256k1(privateKeyBytes);
                return curvePoint;
            }
        }

        public string Hash160(bool compressed)
        {
            return Encoders.BytesToHex(Encoders.Hash160(Encoders.SHA256(PublicKeyBytes(compressed))));
        }

        public string PublicKeyHex(bool compressed)
        {
            return Encoders.BytesToHex(PublicKeyBytes(compressed));
        }

        byte[] PublicKeyBytes(bool compressed)
        {
            return CurvePoint.GetPublicKey(compressed);
        }

        public string Address(bool compressed)
        {
            var addressBytes = Encoders.PublicKeyToAddressBytes(PublicKeyBytes(compressed));
            return Encoders.Base58CheckEncode(addressBytes);
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
            RandomNumberGenerator random = System.Security.Cryptography.RandomNumberGenerator.Create();
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
                catch(Exception e)
                {
                    if (e.Message != "Failed to pass typo check")
                    {
                        var aa = minikey.Length;
                        Console.WriteLine(aa);
                    }
                }
            }
        }

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

        class Encoders
        {
            public static byte[] Hash160(byte[] bytes)
            {
                return RIPEMD160Managed.Create().ComputeHash(bytes);
            }

            public static byte[] PublicKeyToAddressBytes(byte[] bytes)
            {
                var sha = Encoders.SHA256(bytes);
                var ripemd = Hash160(sha);
                var versioned = new byte[] { 0 }.Concat(ripemd).ToArray();
                var checksum = DoubleSHA256(versioned).Take(4).ToArray();
                var address = versioned.Concat(checksum).ToArray();
                return address;
            }

            public static byte[] DoubleSHA256(byte[] bytes)
            {
                return SHA256(SHA256(bytes));
            }

            public static byte[] SHA256(byte[] bytes)
            {
                var crypt = new SHA256Managed();
                return crypt.ComputeHash(bytes);
            }
            public static byte[] SHA256(string s)
            {
                return SHA256(Encoding.ASCII.GetBytes(s));
            }

            static string[] CharacterPoolValues = {
                "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz",
                "123456789ABCDEFGHJKLMNPQRSTUVWXYZ",
                "123456789abcdefghijkmnopqrstuvwxyz",
                "123456789",
                "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz",
                "ABCDEFGHJKLMNPQRSTUVWXYZ",
                "abcdefghijkmnopqrstuvwxyz"
            };

            public static string GetCharacterPool(CharacterPool type = CharacterPool.AlphanumericMixedCase)
            {
                return CharacterPoolValues[(int)type];
            }

            public static string Base58CheckEncode(byte[] bytes)
            {
                return BaseEncode(bytes, CharacterPool.AlphanumericMixedCase, true);
            }

            public static string BaseEncode(byte[] bytes, CharacterPool characterPool, bool preserveLeadingZeros)
            {
                var pool = GetCharacterPool(characterPool);

                var intData = new BigInteger(bytes.Reverse().Concat(new byte[] { 0x00 }).ToArray());
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

            public static byte[] WIFToBytes(string wif)
            {
                var bytes = Base58Decode(wif);
                var trimmed = new byte[32];
                Buffer.BlockCopy(bytes, 1, trimmed, 0, trimmed.Length);
                return trimmed;
            }

            public static string BytesToWIF(byte[] bytes, bool compress)
            {
                var versionAndKey = new byte[] { 128 }.Concat(bytes).ToArray();
                if (compress)
                    versionAndKey = versionAndKey.Concat(new byte[] { 0x01 }).ToArray();
                var checksum = DoubleSHA256(versionAndKey).Take(4).ToArray();
                var keyAndChecksum = versionAndKey.Concat(checksum).ToArray();
                return Base58CheckEncode(keyAndChecksum);
            }

            public static string PassphraseToWIF(string passphrase)
            {
                var privateKeyBytes = SHA256(Encoding.ASCII.GetBytes(passphrase));
                return BytesToWIF(privateKeyBytes, false);
            }

            public static string BytesToHex(byte[] bytes)
            {
                return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
            }

        }

        
    }
}
