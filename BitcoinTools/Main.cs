using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.IO;
using System.Threading;

namespace BitcoinTool
{
    public partial class Main : Form
    {

        double btcUsd = 0;
        Wallet wallet;

        public Main()
        {
            InitializeComponent();
            Icon = Properties.Resources.bitcoin;

            labelKeyError.Text = "";

            GetExchangeRates();

            toolStrip1.Renderer = new FixedTSSR();

        }

        public class FixedTSSR : ToolStripSystemRenderer
        {
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e){ }
        }


        private void buttonRefreshExchange_Click(object sender, EventArgs e)
        {
            GetExchangeRates();
        }

        void UpdateWalletBalance()
        {
            if (btcUsd == 0 || labelWalletBalance.Tag == null)
                return;

            var balanceUSD = (double)labelWalletBalance.Tag * btcUsd;
            labelWalletBalance.Text = String.Format("{0} BTC / {1:C}", labelWalletBalance.Tag, balanceUSD);
        }

        void GetWalletBalance()
        {
            labelWalletBalance.Text = "...";
            labelWalletTxns.Text = "...";
            if (wallet == null) return;

            wallet.FetchBlockChainInfo(info => {
                labelWalletTxns.Text = info.NumberOfTransactions + " Past Transactions";
                labelWalletBalance.Tag = info.FinalBalance / 100000000d;
                UpdateWalletBalance();
            });
        }

        class MarketBinding
        {
            public Label label { get; set; }
            public string endpoint { get; set; }
            public Func<dynamic, object> parser {get; set;}
            public MarketBinding(Label l, string e, Func<dynamic, object> p)
            {
                label = l;
                endpoint = e;
                parser = p;
            }
        }

        void GetExchangeRates()
        {

            Func<string, string> formatPrice = p => String.Format("{0:C}", Decimal.Parse(p));

            var markets = new MarketBinding[] { 
                new MarketBinding(labelPriceAverage, "http://api.bitcoinaverage.com/ticker/USD", d => {
                        btcUsd = (double)(decimal)d["last"];
                        UpdateWalletBalance();
                        return d["last"];
                    }),
                new MarketBinding(labelPriceCoinbase, "https://coinbase.com/api/v1/prices/spot_rate", d => d["amount"]),
                new MarketBinding(labelPriceMtGox, "http://data.mtgox.com/api/2/BTCUSD/money/ticker_fast", d => d["data"]["last"]["value"]),
                new MarketBinding(labelPriceBitstamp, "https://www.bitstamp.net/api/ticker/", d => d["last"]),
                new MarketBinding(labelPriceBTCe, "https://btc-e.com/api/2/btc_usd/ticker", d => d["ticker"]["last"]),
                new MarketBinding(labelPriceCampBX, "http://campbx.com/api/xticker.php", d => d["Last Trade"])
            };


            foreach (var market in markets)
            {
                market.label.Text = "...";
                var c = new WebClient();
                c.DownloadStringAsync(new Uri(market.endpoint));
                c.DownloadStringCompleted += (s, e) => {
                    try
                    {
                        var dynamicObj = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<dynamic>(e.Result);
                        var price = market.parser(dynamicObj);
                        decimal priceDecimal = price is string ? Decimal.Parse(price) : price;
                        market.label.Text = String.Format("{0:C}", priceDecimal);
                    }
                    catch
                    {
                        market.label.Text = "n/a";
                    }
                };
            }
        }


        void DisplayWallet(Wallet wallet)
        {
            this.wallet = wallet;
            labelKeyError.Text = "";

            string newPassphrase = wallet.Passphrase != null ? wallet.Passphrase : "";
            if (textBoxPassphrase.Text != newPassphrase){
                ignoreTextBoxPassphrase = true;
                textBoxPassphrase.Text = newPassphrase;
            }

            string newMinikey = wallet.Minikey != null ? wallet.Minikey : "";
            if (textBoxMinikey.Text != newMinikey)
            {
                ignoreTextBoxMinikey = true;
                textBoxMinikey.Text = newMinikey;
            }

            string newPrivateKey = wallet.PrivateKeyWIF;
            if (textBoxPrivateKey.Text != newPrivateKey)
            {
                ignoreTextBoxPrivateKey = true;
                textBoxPrivateKey.Text = newPrivateKey;
            }

            textBoxAddress.Text = wallet.Address;
            textBoxSecretExponent.Text = wallet.PrivateKeyHex;
            textBoxHash160.Text = wallet.Hash160;
            textBoxPointConversion.Text = wallet.IsCompressed ? "compressed" : "uncompressed";
            textBoxPublicKey.Text = wallet.PublicKeyHex;
            textBoxPrivateKeyDER.Text = wallet.PrivateKeyDER;
            GetWalletBalance();
        }

        

        void ClearTextboxes(TextBox exclude = null)
        {
            
            var textBoxes = new TextBox[]{
                textBoxPassphrase,
                textBoxMinikey,
                textBoxPrivateKey,
                textBoxAddress,
                textBoxSecretExponent,
                textBoxHash160,
                textBoxPointConversion,
                textBoxPublicKey,
                textBoxPrivateKeyDER
            };
            foreach (var t in textBoxes)
            {
                if (t != exclude)
                {
                    if (t.Text != "")
                    {
                        if (t == textBoxPassphrase) ignoreTextBoxPassphrase = true;
                        else if (t == textBoxMinikey) ignoreTextBoxMinikey = true;
                        else if (t == textBoxPrivateKey) ignoreTextBoxPrivateKey = true;
                    }
                    t.Text = "";
                }
            }
            labelWalletBalance.Text = "...";
            labelWalletTxns.Text = "...";
            labelWalletBalance.Tag = null;
        }

        void TryKey(string key)
        {
            try
            {
                DisplayWallet(new Wallet(key));
            }
            catch (Exception e)
            {
                labelKeyError.Text = e.Message;
                wallet = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetWalletBalance();
        }

        bool ignoreTextBoxPassphrase = false;
        bool ignoreTextBoxMinikey = false;
        bool ignoreTextBoxPrivateKey = false;

        private void textBoxPassphrase_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextBoxPassphrase)
            {
                ignoreTextBoxPassphrase = false;
                return;
            }
            ClearTextboxes(textBoxPassphrase);
            DisplayWallet(Wallet.FromPassphrase(textBoxPassphrase.Text));
        }

        private void textBoxMinikey_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextBoxMinikey)
            {
                ignoreTextBoxMinikey = false;
                return;
            }
            ClearTextboxes(textBoxMinikey);
            TryKey(textBoxMinikey.Text);
        }

        private void textBoxPrivateKey_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextBoxPrivateKey)
            {
                ignoreTextBoxPrivateKey = false;
                return;
            }
            ClearTextboxes(textBoxPrivateKey);
            TryKey(textBoxPrivateKey.Text);
            
        }

        private void minikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var typeDict = new Dictionary<ToolStripMenuItem, Wallet.CharacterPool>
            {
                { alphanumericToolStripMenuItem, Wallet.CharacterPool.AlphanumericMixedCase },
                { alphanumericUpperCaseToolStripMenuItem, Wallet.CharacterPool.AlphanumericUppercase },
                { alphanumericLowercaseToolStripMenuItem, Wallet.CharacterPool.AlphanumericLowercase },
                { numericToolStripMenuItem, Wallet.CharacterPool.Numeric },
                { alphaMixedCaseToolStripMenuItem, Wallet.CharacterPool.AlphaMixedCase },
                { alphaUppercaseToolStripMenuItem, Wallet.CharacterPool.AlphaUppercase },
                { alphaLowercaseToolStripMenuItem, Wallet.CharacterPool.AlphaLowercase }
            };

            var poolType = typeDict[(ToolStripMenuItem)sender];

            DisplayWallet(new Wallet(Wallet.GenerateMiniKey(poolType)));

        }

        private void privateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayWallet(new Wallet(sender.Equals(compressedToolStripMenuItem)));
        }

        void GetRandomPhrase(Action<string> callback)
        {
            var wc = new WebClient();
            wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            wc.UploadStringAsync(new Uri("http://watchout4snakes.com/wo4snakes/Random/RandomParagraph"), "Subject1=&Subject2=");
            wc.UploadStringCompleted += (s, e) => {
                var sentences = e.Result.Replace('!', '.').Replace('?', '.');
                sentences = String.Join(".", sentences.Split('.').Take(2)) + ".";
                callback(sentences);
            };
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GetRandomPhrase(s => textBoxPassphrase.Text = s);
        }

    }
}