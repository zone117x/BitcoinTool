using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using BitcoinTools;

namespace BitcoinKeyGen.Views
{

    class WalletListItemAdapter : BaseAdapter
    {
        public readonly List<Wallet> Wallets = new List<Wallet>();

        public override int Count => Wallets.Count;

        public override Java.Lang.Object GetItem(int position) => null;

        public override long GetItemId(int position) => Wallets[position].GetHashCodeLong();

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? LayoutInflater
                .From(parent.Context)
                .Inflate(Resource.Layout.WalletListItem, parent, false);

            var holder = view.Tag as WalletItemViewHolder ?? new WalletItemViewHolder(view);

            var wallet = Wallets[position];
            holder.WalletAddress.Text = wallet.Address;
            return view;
        }

        class WalletItemViewHolder : Java.Lang.Object
        {
            public readonly TextView WalletAddress;

            public WalletItemViewHolder(View view)
            {
                WalletAddress = view.FindViewById<TextView>(Resource.Id.WalletListItemAddress);
            }
        }

    }


}


