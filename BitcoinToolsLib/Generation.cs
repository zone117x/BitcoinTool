using System;
using System.Linq;
using System.Security.Cryptography;

namespace BitcoinTools
{
    public static class Generation
    {
        [ThreadStatic]
        static RandomNumberGenerator _rand = RandomNumberGenerator.Create();

        public static byte[] GeneratePrivateKey()
        {
            var privateKeyBytes = new byte[32];
            _rand.GetNonZeroBytes(privateKeyBytes);
            return privateKeyBytes;
        }

        public static string GenerateMiniKey(CharacterPool type = CharacterPool.AlphanumericMixedCase)
        {
            var pool = Encoding.GetCharacterPool(type);
            while (true)
            {
                var bytes = new byte[29];
                _rand.GetNonZeroBytes(bytes);
                var minikey = "S" + new String(bytes.Select<byte, char>(x => pool[x % pool.Length]).ToArray());

                try
                {
                    Validation.ValidateMiniKey(minikey);
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

        public static string GenerateWif(CharacterPool charPool = CharacterPool.AlphanumericUppercase)
        {
            var pool = Encoding.GetCharacterPool(charPool);
            var bytes = new byte[50];
            int attempts = 0;
            while (true)
            {
                attempts++;
                _rand.GetNonZeroBytes(bytes);
                var key = "5" + new String(bytes.Select(x => pool[x % pool.Length]).ToArray());

                var decoded = Encoding.Base58Decode(key);
                var keyLen = decoded.Length;
                var keyBytes = decoded.Take(keyLen - 4).ToArray();
                keyBytes = Encoding.DoubleSha256(keyBytes);

                decoded[keyLen - 4] = keyBytes[0];
                decoded[keyLen - 3] = keyBytes[1];
                decoded[keyLen - 2] = keyBytes[2];
                decoded[keyLen - 1] = keyBytes[3];

                key = Encoding.Base58Encode(decoded);

                // check if key has any lowercase chars
                if (key.Any(k => !pool.Contains(k)))
                {
                    continue;
                }

                // ensure wif can roundtrip decode
                var wallet = Wallet.FromWif(key);
                if (wallet.PrivateKeyWif != key)
                {
                    continue;
                }

                Console.WriteLine($"Generated uppercase private WIF key after {attempts} attempts");
                return key;

            }
        }

    }
}
