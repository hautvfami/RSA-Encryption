namespace Encryption
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtPK = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKey = new System.Windows.Forms.Button();
            this.txtKeyPath = new System.Windows.Forms.TextBox();
            this.btnTarget = new System.Windows.Forms.Button();
            this.txtTargetPath = new System.Windows.Forms.TextBox();
            this.btnGenKey = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.cbbKeySize = new System.Windows.Forms.ComboBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.lbModulus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMini = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ttGenerateKey = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbPercent = new System.Windows.Forms.Label();
            this.lbKeySize = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPK
            // 
            this.txtPK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPK.Cursor = System.Windows.Forms.Cursors.No;
            this.txtPK.Enabled = false;
            this.txtPK.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPK.Location = new System.Drawing.Point(12, 179);
            this.txtPK.Multiline = true;
            this.txtPK.Name = "txtPK";
            this.txtPK.Size = new System.Drawing.Size(505, 60);
            this.txtPK.TabIndex = 0;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(12, 42);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 1;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(12, 67);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 2;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(13, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "PK Exponent";
            // 
            // btnKey
            // 
            this.btnKey.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKey.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey.Location = new System.Drawing.Point(441, 42);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(75, 23);
            this.btnKey.TabIndex = 6;
            this.btnKey.Text = "Key";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // txtKeyPath
            // 
            this.txtKeyPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKeyPath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyPath.Location = new System.Drawing.Point(167, 42);
            this.txtKeyPath.Name = "txtKeyPath";
            this.txtKeyPath.Size = new System.Drawing.Size(272, 22);
            this.txtKeyPath.TabIndex = 7;
            this.txtKeyPath.TextChanged += new System.EventHandler(this.txtKeyPath_TextChanged);
            // 
            // btnTarget
            // 
            this.btnTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTarget.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarget.Location = new System.Drawing.Point(441, 67);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(75, 23);
            this.btnTarget.TabIndex = 8;
            this.btnTarget.Text = "Target";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetPath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTargetPath.Location = new System.Drawing.Point(167, 68);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(272, 22);
            this.txtTargetPath.TabIndex = 9;
            // 
            // btnGenKey
            // 
            this.btnGenKey.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenKey.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenKey.Location = new System.Drawing.Point(410, 103);
            this.btnGenKey.Name = "btnGenKey";
            this.btnGenKey.Size = new System.Drawing.Size(107, 23);
            this.btnGenKey.TabIndex = 10;
            this.btnGenKey.Text = "Generate Key";
            this.btnGenKey.UseVisualStyleBackColor = true;
            this.btnGenKey.Click += new System.EventHandler(this.btnGenKey_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerify.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.Location = new System.Drawing.Point(344, 103);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(60, 23);
            this.btnVerify.TabIndex = 11;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnSign
            // 
            this.btnSign.BackColor = System.Drawing.SystemColors.Control;
            this.btnSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSign.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSign.Location = new System.Drawing.Point(278, 103);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(60, 23);
            this.btnSign.TabIndex = 12;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = false;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // cbbKeySize
            // 
            this.cbbKeySize.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbKeySize.FormattingEnabled = true;
            this.cbbKeySize.Location = new System.Drawing.Point(410, 132);
            this.cbbKeySize.Name = "cbbKeySize";
            this.cbbKeySize.Size = new System.Drawing.Size(107, 22);
            this.cbbKeySize.TabIndex = 13;
            // 
            // txtN
            // 
            this.txtN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtN.Cursor = System.Windows.Forms.Cursors.No;
            this.txtN.Enabled = false;
            this.txtN.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtN.Location = new System.Drawing.Point(12, 264);
            this.txtN.Multiline = true;
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(505, 60);
            this.txtN.TabIndex = 16;
            this.txtN.TextChanged += new System.EventHandler(this.txtN_TextChanged);
            // 
            // lbModulus
            // 
            this.lbModulus.AutoSize = true;
            this.lbModulus.BackColor = System.Drawing.Color.Transparent;
            this.lbModulus.Font = new System.Drawing.Font("Consolas", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModulus.ForeColor = System.Drawing.Color.White;
            this.lbModulus.Location = new System.Drawing.Point(13, 244);
            this.lbModulus.Name = "lbModulus";
            this.lbModulus.Size = new System.Drawing.Size(77, 15);
            this.lbModulus.TabIndex = 17;
            this.lbModulus.Text = "PK Modulus";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lbPercent);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(-4, 331);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 24);
            this.panel1.TabIndex = 18;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Location = new System.Drawing.Point(73, 3);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(42, 14);
            this.lbStatus.TabIndex = 10;
            this.lbStatus.Text = "Ready";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(13, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "STATUS:";
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.Color.Transparent;
            this.btnMini.BackgroundImage = global::Encryption.Properties.Resources.btnMini;
            this.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.ForeColor = System.Drawing.Color.Transparent;
            this.btnMini.Location = new System.Drawing.Point(465, 5);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(24, 23);
            this.btnMini.TabIndex = 19;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Encryption.Properties.Resources.btnClose;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(495, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 23);
            this.btnClose.TabIndex = 20;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ttGenerateKey
            // 
            this.ttGenerateKey.ToolTipTitle = "GUILD";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbPercent
            // 
            this.lbPercent.AutoSize = true;
            this.lbPercent.BackColor = System.Drawing.Color.Transparent;
            this.lbPercent.Location = new System.Drawing.Point(490, 3);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(0, 14);
            this.lbPercent.TabIndex = 11;
            // 
            // lbKeySize
            // 
            this.lbKeySize.AutoSize = true;
            this.lbKeySize.BackColor = System.Drawing.Color.Transparent;
            this.lbKeySize.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKeySize.ForeColor = System.Drawing.Color.White;
            this.lbKeySize.Location = new System.Drawing.Point(97, 245);
            this.lbKeySize.Name = "lbKeySize";
            this.lbKeySize.Size = new System.Drawing.Size(84, 15);
            this.lbKeySize.TabIndex = 21;
            this.lbKeySize.Text = "           ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Encryption.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(531, 350);
            this.Controls.Add(this.lbKeySize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbModulus);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.cbbKeySize);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnGenKey);
            this.Controls.Add(this.txtTargetPath);
            this.Controls.Add(this.btnTarget);
            this.Controls.Add(this.txtKeyPath);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtPK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryption";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPK;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.TextBox txtKeyPath;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.Button btnGenKey;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.ComboBox cbbKeySize;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label lbModulus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip ttGenerateKey;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.Label lbKeySize;

    }
}

