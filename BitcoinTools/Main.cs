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

        Wallet wallet;

        public Main()
        {
            InitializeComponent();
            Icon = Properties.Resources.bitcoin;

            labelKeyError.Text = "";

    

            toolStrip1.Renderer = new FixedTSSR();

            Wallet w = Wallet.FromPrivateKeyHex("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
            var aa = w.Address(true);
            MessageBox.Show(aa);
        }

        public class FixedTSSR : ToolStripSystemRenderer
        {
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e){ }
        }




        void DisplayWallet(Wallet wallet)
        {
            this.wallet = wallet;
            labelKeyError.Text = "";

            textBoxPrivateKey.TextChanged -= textBoxPrivateKey_TextChanged;
            textBoxPrivateKey.Text = wallet.PrivateKeyWIF(checkBoxCompressed.Checked);
            textBoxPrivateKey.TextChanged += textBoxPrivateKey_TextChanged;

            textBoxAddress.Text = wallet.Address(checkBoxCompressed.Checked);
            textBoxSecretExponent.Text = wallet.PrivateKeyHex;
            textBoxHash160.Text = wallet.Hash160(checkBoxCompressed.Checked);
            textBoxPublicKey.Text = wallet.PublicKeyHex(checkBoxCompressed.Checked);
            textBoxPrivateKeyDER.Text = wallet.PrivateKeyDER(checkBoxCompressed.Checked);

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
                textBoxPublicKey,
                textBoxPrivateKeyDER
            };
            foreach (var t in textBoxes)
            {
                if (t != exclude)
                {
                    t.Text = "";
                }
            }

        }


        private void textBoxPassphrase_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassphrase.Text == "") return;
            ClearTextboxes(textBoxPassphrase);
            DisplayWallet(Wallet.FromPassphrase(textBoxPassphrase.Text));
        }

        private void textBoxMinikey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var w = Wallet.FromMiniKey(textBoxMinikey.Text);
                ClearTextboxes(textBoxMinikey);
                DisplayWallet(w);
            }
            catch (Exception err)
            {
                labelKeyError.Text = err.Message;
                wallet = null;
            }
        }

        private void textBoxPrivateKey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var w = Wallet.FromWIF(textBoxPrivateKey.Text, c => checkBoxCompressed.Checked = c);
                ClearTextboxes(textBoxPrivateKey);
                DisplayWallet(w);
            }
            catch (Exception err)
            {
                labelKeyError.Text = err.Message;
                wallet = null;
            }
            
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
            textBoxMinikey.Text = (Wallet.GenerateMiniKey(poolType));

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ClearTextboxes();
            DisplayWallet(new Wallet());
        }

        private void checkBoxCompressed_CheckedChanged(object sender, EventArgs e)
        {
            DisplayWallet(wallet);
        }


    }
}