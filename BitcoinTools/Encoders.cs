using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace BitcoinTool
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


    public class Encoders
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
