
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BitcoinTools;
using static Android.Support.V4.App.FragmentManager;

namespace BitcoinKeyGen.Views
{
    public class WalletViewFragment : Android.Support.V4.App.Fragment
    {
        readonly Wallet _wallet;

        public WalletViewFragment(Wallet wallet)
        {
            _wallet = wallet;
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.WalletViewFragment, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            View.FindViewById<TextView>(Resource.Id.WalletViewAddress).Text = _wallet.ToString();
        }


    }
}
