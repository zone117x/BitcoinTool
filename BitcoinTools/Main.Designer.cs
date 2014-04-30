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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.labelKeyError = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxPrivateKeyDER = new System.Windows.Forms.TextBox();
            this.uncompressedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxCompressed = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrivateKey.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrivateKey.Location = new System.Drawing.Point(110, 188);
            this.textBoxPrivateKey.MaxLength = 52;
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.Size = new System.Drawing.Size(590, 18);
            this.textBoxPrivateKey.TabIndex = 0;
            this.textBoxPrivateKey.TextChanged += new System.EventHandler(this.textBoxPrivateKey_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Private Key";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddress.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(110, 214);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(590, 18);
            this.textBoxAddress.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Secret Exponent";
            // 
            // textBoxSecretExponent
            // 
            this.textBoxSecretExponent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSecretExponent.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSecretExponent.Location = new System.Drawing.Point(111, 240);
            this.textBoxSecretExponent.Name = "textBoxSecretExponent";
            this.textBoxSecretExponent.ReadOnly = true;
            this.textBoxSecretExponent.Size = new System.Drawing.Size(589, 18);
            this.textBoxSecretExponent.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hash160";
            // 
            // textBoxHash160
            // 
            this.textBoxHash160.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHash160.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHash160.Location = new System.Drawing.Point(111, 266);
            this.textBoxHash160.Name = "textBoxHash160";
            this.textBoxHash160.ReadOnly = true;
            this.textBoxHash160.Size = new System.Drawing.Size(589, 18);
            this.textBoxHash160.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Public Key (SEC)";
            // 
            // textBoxPublicKey
            // 
            this.textBoxPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPublicKey.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPublicKey.Location = new System.Drawing.Point(111, 290);
            this.textBoxPublicKey.Multiline = true;
            this.textBoxPublicKey.Name = "textBoxPublicKey";
            this.textBoxPublicKey.ReadOnly = true;
            this.textBoxPublicKey.Size = new System.Drawing.Size(589, 34);
            this.textBoxPublicKey.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Minikey";
            // 
            // textBoxMinikey
            // 
            this.textBoxMinikey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMinikey.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMinikey.Location = new System.Drawing.Point(110, 162);
            this.textBoxMinikey.MaxLength = 30;
            this.textBoxMinikey.Name = "textBoxMinikey";
            this.textBoxMinikey.Size = new System.Drawing.Size(590, 18);
            this.textBoxMinikey.TabIndex = 14;
            this.textBoxMinikey.TextChanged += new System.EventHandler(this.textBoxMinikey_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Passphrase";
            // 
            // textBoxPassphrase
            // 
            this.textBoxPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassphrase.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassphrase.Location = new System.Drawing.Point(111, 136);
            this.textBoxPassphrase.Name = "textBoxPassphrase";
            this.textBoxPassphrase.Size = new System.Drawing.Size(590, 18);
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
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(12, 19);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(234, 25);
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
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(69, 22);
            this.toolStripButton2.Text = "Private Key";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // labelKeyError
            // 
            this.labelKeyError.AutoSize = true;
            this.labelKeyError.ForeColor = System.Drawing.Color.Red;
            this.labelKeyError.Location = new System.Drawing.Point(12, 81);
            this.labelKeyError.Name = "labelKeyError";
            this.labelKeyError.Size = new System.Drawing.Size(29, 13);
            this.labelKeyError.TabIndex = 20;
            this.labelKeyError.Text = "Error";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Private Key (DER)";
            // 
            // textBoxPrivateKeyDER
            // 
            this.textBoxPrivateKeyDER.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrivateKeyDER.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrivateKeyDER.Location = new System.Drawing.Point(110, 330);
            this.textBoxPrivateKeyDER.Multiline = true;
            this.textBoxPrivateKeyDER.Name = "textBoxPrivateKeyDER";
            this.textBoxPrivateKeyDER.ReadOnly = true;
            this.textBoxPrivateKeyDER.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPrivateKeyDER.Size = new System.Drawing.Size(589, 56);
            this.textBoxPrivateKeyDER.TabIndex = 24;
            // 
            // uncompressedToolStripMenuItem
            // 
            this.uncompressedToolStripMenuItem.Name = "uncompressedToolStripMenuItem";
            this.uncompressedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.uncompressedToolStripMenuItem.Text = "Uncompressed";
            // 
            // compressedToolStripMenuItem
            // 
            this.compressedToolStripMenuItem.Name = "compressedToolStripMenuItem";
            this.compressedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.compressedToolStripMenuItem.Text = "Compressed";
            // 
            // checkBoxCompressed
            // 
            this.checkBoxCompressed.AutoSize = true;
            this.checkBoxCompressed.Checked = true;
            this.checkBoxCompressed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompressed.Location = new System.Drawing.Point(276, 31);
            this.checkBoxCompressed.Name = "checkBoxCompressed";
            this.checkBoxCompressed.Size = new System.Drawing.Size(84, 17);
            this.checkBoxCompressed.TabIndex = 25;
            this.checkBoxCompressed.Text = "Compressed";
            this.checkBoxCompressed.UseVisualStyleBackColor = true;
            this.checkBoxCompressed.CheckedChanged += new System.EventHandler(this.checkBoxCompressed_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 398);
            this.Controls.Add(this.checkBoxCompressed);
            this.Controls.Add(this.textBoxPrivateKeyDER);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.labelKeyError);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPassphrase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMinikey);
            this.Controls.Add(this.textBoxPublicKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxHash160);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxHash160;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPublicKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMinikey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPassphrase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelKeyError;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem alphanumericToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphanumericUpperCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphanumericLowercaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numericToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphaMixedCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphaUppercaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphaLowercaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxPrivateKeyDER;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem uncompressedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressedToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxCompressed;
    }
}

