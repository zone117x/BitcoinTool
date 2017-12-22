
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using BitcoinKeyGen.Services;
using BitcoinTools;

namespace BitcoinKeyGen.Views
{
    class WalletListFragment : Android.Support.V4.App.Fragment
    {
        SwipeRefreshLayout _refreshView;
        ListView _walletListView;
        WalletListItemAdapter _adapter;
        WalletStorage _walletStorage;

        public event Action<Wallet> WalletSelected;

        public WalletListItemAdapter WalletListItemAdapter => _adapter;

        public WalletListFragment(WalletStorage walletStorage)
        {
            _walletStorage = walletStorage;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.WalletListFragment, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            _refreshView = View.FindViewById<SwipeRefreshLayout>(Resource.Id.RefreshView);
            _refreshView.SetEnabled(false);

            _adapter = new WalletListItemAdapter();
            _walletListView = View.FindViewById<ListView>(Resource.Id.WalletListView);
            _walletListView.Adapter = _adapter;
            _walletListView.ItemClick += _walletListView_ItemClick;

            LoadList();
        }

        void _walletListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var wallet = _adapter.Wallets[e.Position];
            var walletViewFragment = new WalletViewFragment(wallet);

            FragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.MainFragmentContainer, walletViewFragment)
                .AddToBackStack(null)
                .Commit();
        }

        async void LoadList()
        {

            _refreshView.SetEnabled(true);
            _refreshView.Refreshing = true;
            try
            {
                var wallets = new List<Wallet>();
                await Task.Run(() =>
                {
                    var privKeys = _walletStorage.LoadWalletPrivateKeys().ToArray();

                    // trigger lazy value loading
                    foreach (var privKey in privKeys)
                    {
                        var wallet = new Wallet(privKey);
                        wallet.Address.ToString();
                        wallet.PrivateKeyWif.ToString();
                        wallets.Add(wallet);
                    }
                });

                _adapter.Wallets.Clear();
                _adapter.Wallets.AddRange(wallets);
                _adapter.NotifyDataSetChanged();
            }
            finally
            {
                _refreshView.Refreshing = false;
                _refreshView.SetEnabled(false);
            }
        }


    }
}
