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

        public static string GenerateUpperWif()
        {
            var pool = Encoding.GetCharacterPool(CharacterPool.AlphanumericUppercase);
            long attempts = 0;
            if (_rand == null)
            {
                _rand = RandomNumberGenerator.Create();
            }

            while (true)
            {
                var bytes = new byte[46];
                _rand.GetNonZeroBytes(bytes);
                var key = "5" + new String(bytes.Select(x => pool[x % pool.Length]).ToArray());

                var keyBytes = Encoding.Base58Decode(key);
                var test = Encoding.Base58Encode(keyBytes);
                var checksum = Encoding.DoubleSha256(keyBytes);
                Array.Reverse(keyBytes);
                Array.Resize(ref keyBytes, keyBytes.Length + 4);
                Array.Reverse(keyBytes);
                //Buffer.BlockCopy(checksum, 0, keyBytes, keyBytes.Length - 4, 4);
                key = Encoding.Base58Encode(keyBytes);

                if (Validation.TryValidatePrivateKey(key))
                {
                    return key;
                }
                else
                {
                    //Console.WriteLine("Invalid key: " + key);
                }
            }
        }

    }
}
