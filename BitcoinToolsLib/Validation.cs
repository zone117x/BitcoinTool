using System;
using static BitcoinTools.Encoding;

namespace BitcoinTools
{
    public static class Validation
    {

        public static void CheckBase58(string key)
        {
            var pool = GetCharacterPool();
            foreach (char c in key)
            {
                if (pool.IndexOf(c) == -1)
                    throw new ArgumentException("Key cannot contain the '" + c + "' character");
            }
        }

        public static void ValidatePrivateKey(string key)
        {
            if (key.Length == 51 && key[0] != '5')
                throw new ArgumentException("Uncompressed key must begin with the number 5");
            if (key.Length == 52 && !(key[0] == 'K' || key[0] == 'L'))
                throw new ArgumentException("Compressed key must begin with the letters K or L");
            if (!TryValidateWifChecksum(key))
                throw new ArgumentException("WIF did not pass checksum");

        }

        public static bool TryValidatePrivateKey(string key)
        {
            if (key.Length == 51 && key[0] != '5')
                return false;
            if (key.Length == 52 && !(key[0] == 'K' || key[0] == 'L'))
                return false;
            if (!TryValidateWifChecksum(key))
                return false;
            return true;
        }

        public static void ValidateMiniKey(string minikey)
        {
            if (minikey[0] != 'S')
                throw new ArgumentException("Missing S Prefix");
            if (!(minikey.Length == 30 || minikey.Length == 22))
                throw new ArgumentException("Invalid length, must be 30 or 22 chars");
            if (Sha256(minikey + "?")[0] != 0)
                throw new ArgumentException("Failed to pass typo check");
        }

        public static bool TryValidateWifChecksum(string key)
        {
            var decoded = Base58Decode(key);
            var keyLen = decoded.Length;
            var keyBytes = new byte[keyLen - 4];
            Buffer.BlockCopy(decoded, 0, keyBytes, 0, keyBytes.Length);
            keyBytes = DoubleSha256(keyBytes);
            return keyBytes[0] == decoded[keyLen - 4]
                && keyBytes[1] == decoded[keyLen - 3]
                && keyBytes[2] == decoded[keyLen - 2]
                && keyBytes[3] == decoded[keyLen - 1];
        }

    }
}
