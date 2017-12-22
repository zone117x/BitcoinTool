using System;
using System.Collections.Generic;
using Android.Content;
using BitcoinKeyGen.Utils;
using Java.Security;
using Javax.Crypto;

namespace BitcoinKeyGen.Services
{
    public class WalletStorage
    {

        const string _keystoreFile = "wallet_keystore";
        readonly KeyStore.PasswordProtection _protection;
        readonly KeyStore _ks;
        readonly Context _ctx;

        public WalletStorage(Context ctx, string password)
        {
            _ctx = ctx;
            _protection = new KeyStore.PasswordProtection(password.ToCharArray());
            _ks = LoadKeyStore();
        }

        KeyStore LoadKeyStore()
        {
            var keyStore = KeyStore.GetInstance(KeyStore.DefaultType);
            using (var file = _ctx.GetFileStreamPath(_keystoreFile))
            {
                try
                {
                    if (file.Exists())
                    {
                        using (var stream = _ctx.OpenFileInput(_keystoreFile))
                        {
                            keyStore.Load(stream, _protection.GetPassword());
                        }
                    }
                    else
                    {
                        keyStore.Load(null, _protection.GetPassword());
                    }


                    return keyStore;
                }
                catch
                {
#if DEBUG
                    file.Delete();
                    return LoadKeyStore();
#else
                    throw;
#endif
                }
            }
        }


        void SaveKeyStore()
        {
            using (var stream = _ctx.OpenFileOutput(_keystoreFile, FileCreationMode.Private))
            {
                _ks.Store(stream, _protection.GetPassword());
            }
        }

        public void StoreWallet(string walletAddr, byte[] privateKey)
        {
            if (_ks.ContainsAlias(walletAddr))
            {
                _ks.DeleteEntry(walletAddr);
            }
            var keyEntry = new KeyStore.SecretKeyEntry(new BtcKeyData(privateKey));
            _ks.SetEntry(walletAddr, keyEntry, _protection);
            SaveKeyStore();
        }

        public IEnumerable<byte[]> LoadWalletPrivateKeys()
        {
            foreach (var alias in _ks.Aliases().ToStringArray())
            {
                var entry = _ks.GetEntry(alias, _protection);
                var secreyKey = entry as KeyStore.SecretKeyEntry;
                var walletPrivateKey = secreyKey.SecretKey.GetEncoded();
                yield return walletPrivateKey;
            }
        }


        class BtcKeyData : Java.Lang.Object, ISecretKey
        {
            public string Algorithm => "RAW";
            public string Format => "RAW";
            byte[] _key;
            public byte[] GetEncoded() => _key;
            public BtcKeyData(byte[] key) => _key = key;
        }


    }


}
