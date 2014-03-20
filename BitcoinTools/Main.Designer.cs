namespace BitcoinTool
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.textBoxPrivateKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSecretExponent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPointConversion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHash160 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPublicKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMinikey = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPassphrase = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.alphanumericToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphanumericUpperCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphanumericLowercaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphaMixedCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphaUppercaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphaLowercaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.uncompressedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelPriceAverage = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelPriceCampBX = new System.Windows.Forms.Label();
            this.labelPriceBTCe = new System.Windows.Forms.Label();
            this.labelPriceBitstamp = new System.Windows.Forms.Label();
            this.labelPriceMtGox = new System.Windows.Forms.Label();
            this.labelPriceCoinbase = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonRefreshExchange = new System.Windows.Forms.Button();
            this.labelKeyError = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelWalletTxns = new System.Windows.Forms.Label();
            this.labelWalletBalance = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxPrivateKeyDER = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrivateKey.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrivateKey.Location = new System.Drawing.Point(110, 230);
            this.textBoxPrivateKey.MaxLength = 52;
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.Size = new System.Drawing.Size(471, 18);
            this.textBoxPrivateKey.TabIndex = 0;
            this.textBoxPrivateKey.TextChanged += new System.EventHandler(this.textBoxPrivateKey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Private Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddress.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(110, 256);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(471, 18);
            this.textBoxAddress.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Secret Exponent";
            // 
            // textBoxSecretExponent
            // 
            this.textBoxSecretExponent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSecretExponent.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSecretExponent.Location = new System.Drawing.Point(111, 282);
            this.textBoxSecretExponent.Name = "textBoxSecretExponent";
            this.textBoxSecretExponent.ReadOnly = true;
            this.textBoxSecretExponent.Size = new System.Drawing.Size(470, 18);
            this.textBoxSecretExponent.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Point Conversion";
            // 
            // textBoxPointConversion
            // 
            this.textBoxPointConversion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPointConversion.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPointConversion.Location = new System.Drawing.Point(111, 334);
            this.textBoxPointConversion.Name = "textBoxPointConversion";
            this.textBoxPointConversion.ReadOnly = true;
            this.textBoxPointConversion.Size = new System.Drawing.Size(470, 18);
            this.textBoxPointConversion.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hash160";
            // 
            // textBoxHash160
            // 
            this.textBoxHash160.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHash160.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHash160.Location = new System.Drawing.Point(111, 308);
            this.textBoxHash160.Name = "textBoxHash160";
            this.textBoxHash160.ReadOnly = true;
            this.textBoxHash160.Size = new System.Drawing.Size(470, 18);
            this.textBoxHash160.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Public Key (SEC)";
            // 
            // textBoxPublicKey
            // 
            this.textBoxPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPublicKey.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPublicKey.Location = new System.Drawing.Point(111, 360);
            this.textBoxPublicKey.Multiline = true;
            this.textBoxPublicKey.Name = "textBoxPublicKey";
            this.textBoxPublicKey.ReadOnly = true;
            this.textBoxPublicKey.Size = new System.Drawing.Size(470, 34);
            this.textBoxPublicKey.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Minikey";
            // 
            // textBoxMinikey
            // 
            this.textBoxMinikey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMinikey.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMinikey.Location = new System.Drawing.Point(110, 204);
            this.textBoxMinikey.MaxLength = 30;
            this.textBoxMinikey.Name = "textBoxMinikey";
            this.textBoxMinikey.Size = new System.Drawing.Size(471, 18);
            this.textBoxMinikey.TabIndex = 14;
            this.textBoxMinikey.TextChanged += new System.EventHandler(this.textBoxMinikey_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Passphrase";
            // 
            // textBoxPassphrase
            // 
            this.textBoxPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassphrase.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassphrase.Location = new System.Drawing.Point(111, 178);
            this.textBoxPassphrase.Name = "textBoxPassphrase";
            this.textBoxPassphrase.Size = new System.Drawing.Size(471, 18);
            this.textBoxPassphrase.TabIndex = 16;
            this.textBoxPassphrase.TextChanged += new System.EventHandler(this.textBoxPassphrase_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 55);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate key from random:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(12, 19);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(212, 25);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alphanumericToolStripMenuItem,
            this.alphanumericUpperCaseToolStripMenuItem,
            this.alphanumericLowercaseToolStripMenuItem,
            this.numericToolStripMenuItem,
            this.alphaMixedCaseToolStripMenuItem,
            this.alphaUppercaseToolStripMenuItem,
            this.alphaLowercaseToolStripMenuItem});
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripSplitButton1.Text = "Minikey";
            // 
            // alphanumericToolStripMenuItem
            // 
            this.alphanumericToolStripMenuItem.Name = "alphanumericToolStripMenuItem";
            this.alphanumericToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.alphanumericToolStripMenuItem.Text = "Alphanumeric Mixed Case";
            this.alphanumericToolStripMenuItem.Click += new System.EventHandler(this.minikeyToolStripMenuItem_Click);
            // 
            // alphanumericUpperCaseToolStripMenuItem
            // 
            this.alphanumericUpperCaseToolStripMenuItem.Name = "alphanumericUpperCaseToolStripMenuItem";
            this.alphanumericUpperCaseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.alphanumericUpperCaseToolStripMenuItem.Text = "Alphanumeric Uppercase";
            this.alphanumericUpperCaseToolStripMenuItem.Click += new System.EventHandler(this.minikeyToolStripMenuItem_Click);
            // 
            // alphanumericLowercaseToolStripMenuItem
            // 
            this.alphanumericLowercaseToolStripMenuItem.Name = "alphanumericLowercaseToolStripMenuItem";
            this.alphanumericLowercaseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.alphanumericLowercaseToolStripMenuItem.Text = "Alphanumeric Lowercase";
            this.alphanumericLowercaseToolStripMenuItem.Click += new System.EventHandler(this.minikeyToolStripMenuItem_Click);
            // 
            // numericToolStripMenuItem
            // 
            this.numericToolStripMenuItem.Name = "numericToolStripMenuItem";
            this.numericToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.numericToolStripMenuItem.Text = "Numeric";
            this.numericToolStripMenuItem.Click += new System.EventHandler(this.minikeyToolStripMenuItem_Click);
            // 
            // alphaMixedCaseToolStripMenuItem
            // 
            this.alphaMixedCaseToolStripMenuItem.Name = "alphaMixedCaseToolStripMenuItem";
            this.alphaMixedCaseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.alphaMixedCaseToolStripMenuItem.Text = "Alpha Mixed Case";
            this.alphaMixedCaseToolStripMenuItem.Click += new System.EventHandler(this.minikeyToolStripMenuItem_Click);
            // 
            // alphaUppercaseToolStripMenuItem
            // 
            this.alphaUppercaseToolStripMenuItem.Name = "alphaUppercaseToolStripMenuItem";
            this.alphaUppercaseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.alphaUppercaseToolStripMenuItem.Text = "Alpha Uppercase";
            this.alphaUppercaseToolStripMenuItem.Click += new System.EventHandler(this.minikeyToolStripMenuItem_Click);
            // 
            // alphaLowercaseToolStripMenuItem
            // 
            this.alphaLowercaseToolStripMenuItem.Name = "alphaLowercaseToolStripMenuItem";
            this.alphaLowercaseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.alphaLowercaseToolStripMenuItem.Text = "Alpha Lowercase";
            this.alphaLowercaseToolStripMenuItem.Click += new System.EventHandler(this.minikeyToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uncompressedToolStripMenuItem,
            this.compressedToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 22);
            this.toolStripDropDownButton1.Text = "Private Key";
            // 
            // uncompressedToolStripMenuItem
            // 
            this.uncompressedToolStripMenuItem.Name = "uncompressedToolStripMenuItem";
            this.uncompressedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.uncompressedToolStripMenuItem.Text = "Uncompressed";
            this.uncompressedToolStripMenuItem.Click += new System.EventHandler(this.privateKeyToolStripMenuItem_Click);
            // 
            // compressedToolStripMenuItem
            // 
            this.compressedToolStripMenuItem.Name = "compressedToolStripMenuItem";
            this.compressedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.compressedToolStripMenuItem.Text = "Compressed";
            this.compressedToolStripMenuItem.Click += new System.EventHandler(this.privateKeyToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
            this.toolStripButton1.Text = "Passphrase";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelPriceAverage);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.labelPriceCampBX);
            this.groupBox2.Controls.Add(this.labelPriceBTCe);
            this.groupBox2.Controls.Add(this.labelPriceBitstamp);
            this.groupBox2.Controls.Add(this.labelPriceMtGox);
            this.groupBox2.Controls.Add(this.labelPriceCoinbase);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(400, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 130);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spot Price";
            // 
            // labelPriceAverage
            // 
            this.labelPriceAverage.AutoSize = true;
            this.labelPriceAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceAverage.Location = new System.Drawing.Point(85, 23);
            this.labelPriceAverage.Name = "labelPriceAverage";
            this.labelPriceAverage.Size = new System.Drawing.Size(17, 16);
            this.labelPriceAverage.TabIndex = 12;
            this.labelPriceAverage.Text = "...";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 16);
            this.label15.TabIndex = 11;
            this.label15.Text = "Average";
            // 
            // labelPriceCampBX
            // 
            this.labelPriceCampBX.AutoSize = true;
            this.labelPriceCampBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceCampBX.Location = new System.Drawing.Point(85, 103);
            this.labelPriceCampBX.Name = "labelPriceCampBX";
            this.labelPriceCampBX.Size = new System.Drawing.Size(17, 16);
            this.labelPriceCampBX.TabIndex = 10;
            this.labelPriceCampBX.Text = "...";
            // 
            // labelPriceBTCe
            // 
            this.labelPriceBTCe.AutoSize = true;
            this.labelPriceBTCe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceBTCe.Location = new System.Drawing.Point(85, 87);
            this.labelPriceBTCe.Name = "labelPriceBTCe";
            this.labelPriceBTCe.Size = new System.Drawing.Size(17, 16);
            this.labelPriceBTCe.TabIndex = 9;
            this.labelPriceBTCe.Text = "...";
            // 
            // labelPriceBitstamp
            // 
            this.labelPriceBitstamp.AutoSize = true;
            this.labelPriceBitstamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceBitstamp.Location = new System.Drawing.Point(85, 71);
            this.labelPriceBitstamp.Name = "labelPriceBitstamp";
            this.labelPriceBitstamp.Size = new System.Drawing.Size(17, 16);
            this.labelPriceBitstamp.TabIndex = 8;
            this.labelPriceBitstamp.Text = "...";
            // 
            // labelPriceMtGox
            // 
            this.labelPriceMtGox.AutoSize = true;
            this.labelPriceMtGox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceMtGox.Location = new System.Drawing.Point(85, 55);
            this.labelPriceMtGox.Name = "labelPriceMtGox";
            this.labelPriceMtGox.Size = new System.Drawing.Size(17, 16);
            this.labelPriceMtGox.TabIndex = 7;
            this.labelPriceMtGox.Text = "...";
            // 
            // labelPriceCoinbase
            // 
            this.labelPriceCoinbase.AutoSize = true;
            this.labelPriceCoinbase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceCoinbase.Location = new System.Drawing.Point(85, 39);
            this.labelPriceCoinbase.Name = "labelPriceCoinbase";
            this.labelPriceCoinbase.Size = new System.Drawing.Size(17, 16);
            this.labelPriceCoinbase.TabIndex = 6;
            this.labelPriceCoinbase.Text = "...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "CampBX";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "BTC-e";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Bitstamp";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Mt.Gox";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Coinbase";
            // 
            // buttonRefreshExchange
            // 
            this.buttonRefreshExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefreshExchange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRefreshExchange.Location = new System.Drawing.Point(504, 8);
            this.buttonRefreshExchange.Name = "buttonRefreshExchange";
            this.buttonRefreshExchange.Size = new System.Drawing.Size(57, 23);
            this.buttonRefreshExchange.TabIndex = 0;
            this.buttonRefreshExchange.Text = "Refresh";
            this.buttonRefreshExchange.UseVisualStyleBackColor = true;
            this.buttonRefreshExchange.Click += new System.EventHandler(this.buttonRefreshExchange_Click);
            // 
            // labelKeyError
            // 
            this.labelKeyError.AutoSize = true;
            this.labelKeyError.ForeColor = System.Drawing.Color.Red;
            this.labelKeyError.Location = new System.Drawing.Point(11, 147);
            this.labelKeyError.Name = "labelKeyError";
            this.labelKeyError.Size = new System.Drawing.Size(29, 13);
            this.labelKeyError.TabIndex = 20;
            this.labelKeyError.Text = "Error";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelWalletTxns);
            this.groupBox3.Controls.Add(this.labelWalletBalance);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(12, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 63);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wallet Balance";
            // 
            // labelWalletTxns
            // 
            this.labelWalletTxns.AutoSize = true;
            this.labelWalletTxns.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWalletTxns.Location = new System.Drawing.Point(12, 37);
            this.labelWalletTxns.Name = "labelWalletTxns";
            this.labelWalletTxns.Size = new System.Drawing.Size(20, 17);
            this.labelWalletTxns.TabIndex = 12;
            this.labelWalletTxns.Text = "...";
            // 
            // labelWalletBalance
            // 
            this.labelWalletBalance.AutoSize = true;
            this.labelWalletBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWalletBalance.Location = new System.Drawing.Point(12, 20);
            this.labelWalletBalance.Name = "labelWalletBalance";
            this.labelWalletBalance.Size = new System.Drawing.Size(20, 17);
            this.labelWalletBalance.TabIndex = 11;
            this.labelWalletBalance.Text = "...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 17);
            this.label17.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(130, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 401);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Private Key (DER)";
            // 
            // textBoxPrivateKeyDER
            // 
            this.textBoxPrivateKeyDER.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrivateKeyDER.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrivateKeyDER.Location = new System.Drawing.Point(110, 400);
            this.textBoxPrivateKeyDER.Multiline = true;
            this.textBoxPrivateKeyDER.Name = "textBoxPrivateKeyDER";
            this.textBoxPrivateKeyDER.ReadOnly = true;
            this.textBoxPrivateKeyDER.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPrivateKeyDER.Size = new System.Drawing.Size(470, 52);
            this.textBoxPrivateKeyDER.TabIndex = 24;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 464);
            this.Controls.Add(this.textBoxPrivateKeyDER);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.labelKeyError);
            this.Controls.Add(this.buttonRefreshExchange);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPassphrase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMinikey);
            this.Controls.Add(this.textBoxPublicKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxHash160);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPointConversion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSecretExponent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrivateKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Bitcoin Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSecretExponent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPointConversion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxHash160;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPublicKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMinikey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPassphrase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRefreshExchange;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelPriceCampBX;
        private System.Windows.Forms.Label labelPriceBTCe;
        private System.Windows.Forms.Label labelPriceBitstamp;
        private System.Windows.Forms.Label labelPriceMtGox;
        private System.Windows.Forms.Label labelPriceCoinbase;
        private System.Windows.Forms.Label labelKeyError;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelWalletBalance;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelPriceAverage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelWalletTxns;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem alphanumericToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphanumericUpperCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphanumericLowercaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numericToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphaMixedCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphaUppercaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphaLowercaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem uncompressedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressedToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxPrivateKeyDER;
    }
}

