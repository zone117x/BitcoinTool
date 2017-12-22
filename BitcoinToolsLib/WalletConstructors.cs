using System;
using static System.Text.Encoding;
using static BitcoinTools.Encoding;

namespace BitcoinTools
{
    public partial class Wallet
    {

        public static Wallet FromPassphrase(string passphrase)
        {
            var privateKeyBytes = Sha256(UTF8.GetBytes(passphrase));
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
                    Validation.ValidateMiniKey(miniKey);
                    var privateKeyBytes = Sha256(miniKey);
                    return new Wallet(privateKeyBytes);
                default:
                    throw new ArgumentException("Key must be 22 or 30 chars for minikeys");
            }
        }

        public static Wallet FromWif(string privateKey)
        {
            Validation.CheckBase58(privateKey);

            byte[] privateKeyBytes;
            switch (privateKey.Length)
            {
                case 51:
                case 52:
                    Validation.ValidatePrivateKey(privateKey);
                    privateKeyBytes = WifToBytes(privateKey);
                    break;
                default:
                    throw new ArgumentException("Key must be 51 or 52 chars");
            }

            return new Wallet(privateKeyBytes);
        }

        public static Wallet Generate()
        {
            return new Wallet(Generation.GeneratePrivateKey());
        }

    }
}
