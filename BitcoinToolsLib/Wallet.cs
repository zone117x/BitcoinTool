using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Text.Encoding;
using static BitcoinTools.Encoding;

namespace BitcoinTools
{
    public partial class Wallet
    {
        public Wallet(byte[] privateKeyBytes)
        {
            _privateKeyBytes = privateKeyBytes;
        }

        byte[] _privateKeyBytes;
        public byte[] PrivateKeyBytes => _privateKeyBytes;

        Secp256k1 _curvePoint;
        public Secp256k1 CurvePoint => _curvePoint
            ?? (_curvePoint = new Secp256k1(_privateKeyBytes));

        string _privateKeyHex;
        public string PrivateKeyHex => _privateKeyHex
            ?? (_privateKeyHex = BytesToHex(_privateKeyBytes));

        string _privateKeyWif;
        public string PrivateKeyWif => _privateKeyWif
            ?? (_privateKeyWif = BytesToWif(_privateKeyBytes));

        string _privateKeyWifCompressed;
        public string PrivateKeyWifCompressed => _privateKeyWifCompressed
            ?? (_privateKeyWifCompressed = BytesToWifCompressed(_privateKeyBytes));

        string _privateKeyDer;
        public string PrivateKeyDer => _privateKeyDer
            ?? (_privateKeyDer = BytesToHex(CurvePoint.GetDER(false)));

        string _privateKeyDerCompressed;
        public string PrivateKeyDerCompressed => _privateKeyDerCompressed
            ?? (_privateKeyDerCompressed = BytesToHex(CurvePoint.GetDER(true)));

        string _ripeMD160;
        public string RipeMD160 => _ripeMD160
            ?? (_ripeMD160 = BytesToHex(RipeMD160(Sha256(PublicKeyBytes))));

        string _ripeMD160Compressed;
        public string RipeMD160Compressed => _ripeMD160Compressed
            ?? (_ripeMD160Compressed = BytesToHex(RipeMD160(Sha256(PublicKeyBytesCompressed))));

        string _publicKeyHex;
        public string PublicKeyHex => _publicKeyHex
            ?? (_publicKeyHex = BytesToHex(PublicKeyBytes));

        string _publicKeyHexCompressed;
        public string PublicKeyHexCompressed => _publicKeyHexCompressed
            ?? (_publicKeyHexCompressed = BytesToHex(PublicKeyBytesCompressed));

        byte[] _publicKeyBytes;
        public byte[] PublicKeyBytes => _publicKeyBytes
            ?? (_publicKeyBytes = CurvePoint.GetPublicKey(false));

        byte[] _publicKeyBytesCompressed;
        public byte[] PublicKeyBytesCompressed => _publicKeyBytesCompressed
            ?? (_publicKeyBytesCompressed = CurvePoint.GetPublicKey(true));

        string _address;
        public string Address => _address
            ?? (_address = Base58Encode(PublicKeyToAddressBytes(PublicKeyBytes)));

        string _addressCompressed;
        public string AddressCompressed => _addressCompressed
            ?? (_addressCompressed = Base58Encode(PublicKeyToAddressBytes(PublicKeyBytesCompressed)));

        long? _hashCodeLong;
        public long GetHashCodeLong() => (_hashCodeLong
            ?? (_hashCodeLong = XorBytesToInt64(PublicKeyBytesCompressed))).Value;

        int? _hashCode;
        public override int GetHashCode() => (_hashCode
            ?? (_hashCode = XorBytesToInt32(PublicKeyBytesCompressed))).Value;

        public override string ToString()
        {
            return string.Join(Environment.NewLine, new[] 
            {               
                $"{nameof(Address)}: {Address}",
                $"{nameof(AddressCompressed)}: {AddressCompressed}",
                $"{nameof(PublicKeyHex)}: {PublicKeyHex}",
                $"{nameof(PublicKeyHexCompressed)}: {PublicKeyHexCompressed}",
                $"{nameof(PrivateKeyWif)}: {PrivateKeyWif}",
                $"{nameof(PrivateKeyWifCompressed)}: {PrivateKeyWifCompressed}",
                $"{nameof(PrivateKeyHex)}: {PrivateKeyHex}",
            });
        }
 
        
    }
}
