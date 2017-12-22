using Android.App;
using Android.Widget;
using Android.OS;
using Java.Security;
using System.Text;
using System.Globalization;
using System;
using System.IO;
using System.Collections.Generic;
using Javax.Crypto;
using Javax.Crypto.Spec;
using System.Security;
using Android.Content;
using Java.IO;
using System.Threading.Tasks;
using Java.Lang;
using BitcoinTools;
using Android.Support.V7.App;
using BitcoinKeyGen.Services;
using System.Linq;
using Android.Support.V4.Widget;
using Android.Views;
using static Android.Support.V4.App.FragmentManager;

namespace BitcoinKeyGen.Views
{
    [Activity(Label = "Bitcoin Sharp Wallet", MainLauncher = true, Icon = "@mipmap/icon")]
    public partial class MainActivity : AppCompatActivity, IOnBackStackChangedListener
    {
        
        WalletStorage _walletStorage;
        WalletListFragment _walletListFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            SupportFragmentManager.AddOnBackStackChangedListener(this);
            PromptPassword();
        }

        void PromptPassword()
        {
            var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
            var input = new EditText(this);
            input.InputType = Android.Text.InputTypes.NumberVariationPassword;
            builder.SetTitle("Enter password");
            builder.SetView(input);
            builder.SetPositiveButton("OK", (s, e) =>
            {
                _walletStorage = new WalletStorage(this, input.Text);
                ShowWalletList();
            });
            builder.Show();
        }

        void ShowWalletList()
        {
            _walletListFragment = new WalletListFragment(_walletStorage);
            SupportFragmentManager
                .BeginTransaction()
                .Add(Resource.Id.MainFragmentContainer, _walletListFragment)
                //.AddToBackStack(null)
                .Commit();
        }

        async void GenerateWallet(CharacterPool charPool = CharacterPool.AlphanumericUppercase)
        {
            var wallet = await Task.Run(() =>
            {
                var wif = Generation.GenerateWif(charPool);
                var wal = Wallet.FromWif(wif);
                wal.PrivateKeyWif.ToString();
                _walletStorage.StoreWallet(wal.Address, wal.PrivateKeyBytes);
                return wal;
            });

            _walletListFragment.WalletListItemAdapter.Wallets.Insert(0, wallet);
            _walletListFragment.WalletListItemAdapter.NotifyDataSetChanged();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MainMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_generate_wallet:
                    GenerateWallet(CharacterPool.AlphanumericMixedCase);
                    return true;
                case Resource.Id.menu_generate_wallet_uppercase:
                    GenerateWallet(CharacterPool.AlphanumericUppercase);
                    return true;
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);

            }
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
            }
        }

        public void OnBackStackChanged()
        {
            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }
            else
            {
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            }
        }
    }
}

