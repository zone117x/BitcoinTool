using System;
using System.Collections.Generic;
using System.Text;
using static System.Text.Encoding;
using static BitcoinTools.Encoding;

namespace BitcoinTools
{
    public class Wallet
    {
        readonly Lazy<Secp256k1> _curvePoint;
        byte[] _privateKeyBytes;


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

        public Wallet(byte[] privateKeyBytes)
        {
            _privateKeyBytes = privateKeyBytes;
            _curvePoint = new Lazy<Secp256k1>(() => new Secp256k1(_privateKeyBytes));
        }

        public Secp256k1 CurvePoint => _curvePoint.Value;

        public string PrivateKeyHex => BytesToHex(_privateKeyBytes);

        public byte[] PrivateKeyBytes => _privateKeyBytes;

        public string PrivateKeyWif => BytesToWif(_privateKeyBytes);
        public string PrivateKeyWifCompressed => BytesToWifCompressed(_privateKeyBytes);

        public string PrivateKeyDER => BytesToHex(CurvePoint.GetDER(false));
        public string PrivateKeyDERCompressed => BytesToHex(CurvePoint.GetDER(true));

        public string Hash160 => BytesToHex(RipeMD160(Sha256(PublicKeyBytes)));
        public string Hash160Compressed => BytesToHex(RipeMD160(Sha256(PublicKeyBytesCompressed)));

        public string PublicKeyHex => BytesToHex(PublicKeyBytes);
        public string PublicKeyHexCompressed => BytesToHex(PublicKeyBytesCompressed);

        public byte[] PublicKeyBytes => CurvePoint.GetPublicKey(false);
        public byte[] PublicKeyBytesCompressed => CurvePoint.GetPublicKey(true);

        public string Address => Base58Encode(PublicKeyToAddressBytes(PublicKeyBytes));
        public string AddressCompressed => Base58Encode(PublicKeyToAddressBytes(PublicKeyBytesCompressed));
 
        
    }
}
