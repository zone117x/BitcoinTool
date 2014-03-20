using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTool
{
    public static class WalletExtensions
    {

        public class BlockChainInfo
        {
            public int FinalBalance { get; set; }
            public int NumberOfTransactions { get; set; }
        }

        public static void FetchBlockChainInfo(this Wallet wallet, Action<BlockChainInfo> callback)
        {
            var w = new WebClient();
            w.DownloadStringAsync(new Uri("http://blockchain.info/rawaddr/" + wallet.Address));
            w.DownloadStringCompleted += (s, c) =>
            {
                try
                {
                    var data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<dynamic>(c.Result);
                    int balance = data["final_balance"];
                    int txns = data["n_tx"];
                    callback(new BlockChainInfo { FinalBalance = balance, NumberOfTransactions = txns });
                }
                catch { }
            };
        }
        


    }
}
