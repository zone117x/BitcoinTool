﻿using System;
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
using BitcoinTools;

namespace BitcoinTool
{
    public partial class Main : Form
    {

        Wallet wallet;

        public Main()
        {
            InitializeComponent();
            //Icon = Properties.Resources.bitcoin;

            labelKeyError.Text = "";

    

            toolStrip1.Renderer = new FixedTSSR();

            Wallet w = Wallet.FromPrivateKeyHex("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
            DisplayWallet(w);
            //var aa = w.Address(true);
            //MessageBox.Show(aa);
            //string key = null;

            //Parallel.For(0, long.MaxValue, (i, p) => 
            //{
            //    key = Wallet.GenerateUpperWIF();
            //    p.Stop();
            //});

            //Console.WriteLine("success: " + key);
            //Console.ReadLine();
        }

        public class FixedTSSR : ToolStripSystemRenderer
        {
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e){ }
        }




        void DisplayWallet(Wallet wallet)
        {
            this.wallet = wallet;
            labelKeyError.Text = "";

            textBoxPrivateWif.TextChanged -= textBoxPrivateKey_TextChanged;

            textBoxSecretExponent.Text = wallet.PrivateKeyHex;

            if (checkBoxCompressed.Checked)
            {
                textBoxPrivateWif.Text = wallet.PrivateKeyWifCompressed;
                textBoxAddress.Text = wallet.AddressCompressed;
                textBoxHash160.Text = wallet.RipeMD160Compressed;
                textBoxPublicKey.Text = wallet.PublicKeyHexCompressed;
                textBoxPrivateKeyDER.Text = wallet.PrivateKeyDerCompressed;
            }
            else
            {
                textBoxPrivateWif.Text = wallet.PrivateKeyWif;
                textBoxAddress.Text = wallet.Address;
                textBoxHash160.Text = wallet.RipeMD160;
                textBoxPublicKey.Text = wallet.PublicKeyHex;
                textBoxPrivateKeyDER.Text = wallet.PrivateKeyDer;
            }
            textBoxPrivateWif.TextChanged += textBoxPrivateKey_TextChanged;

        }

        

        void ClearTextboxes(TextBox exclude = null)
        {
            
            var textBoxes = new TextBox[]{
                textBoxPassphrase,
                textBoxMinikey,
                textBoxPrivateWif,
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
                var w = Wallet.FromWif(textBoxPrivateWif.Text);
                ClearTextboxes(textBoxPrivateWif);
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
            var typeDict = new Dictionary<ToolStripMenuItem, CharacterPool>
            {
                { alphanumericToolStripMenuItem, CharacterPool.AlphanumericMixedCase },
                { alphanumericUpperCaseToolStripMenuItem, CharacterPool.AlphanumericUppercase },
                { alphanumericLowercaseToolStripMenuItem, CharacterPool.AlphanumericLowercase },
                { numericToolStripMenuItem, CharacterPool.Numeric },
                { alphaMixedCaseToolStripMenuItem, CharacterPool.AlphaMixedCase },
                { alphaUppercaseToolStripMenuItem, CharacterPool.AlphaUppercase },
                { alphaLowercaseToolStripMenuItem, CharacterPool.AlphaLowercase }
            };

            var poolType = typeDict[(ToolStripMenuItem)sender];
            textBoxMinikey.Text = (Generation.GenerateMiniKey(poolType));

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
            DisplayWallet(Wallet.Generate());
        }

        private void checkBoxCompressed_CheckedChanged(object sender, EventArgs e)
        {
            DisplayWallet(wallet);
        }

        private void toolStripWifUncompressed_Click(object sender, EventArgs e)
        {
            checkBoxCompressed.Checked = false;
            DisplayWallet(Wallet.FromWif(Generation.GenerateWif(CharacterPool.AlphanumericMixedCase)));
        }

        private void toolStripWifUncompressedUppercase_Click(object sender, EventArgs e)
        {
            checkBoxCompressed.Checked = false;
            DisplayWallet(Wallet.FromWif(Generation.GenerateWif(CharacterPool.AlphanumericUppercase)));
        }
    }
}