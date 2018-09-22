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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKey = new System.Windows.Forms.Button();
            this.txtKeyPath = new System.Windows.Forms.TextBox();
            this.txtTargetPath = new System.Windows.Forms.TextBox();
            this.btnTarget = new System.Windows.Forms.Button();
            this.btnGenKey = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.cbbKeySize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 138);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(505, 34);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(12, 12);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 1;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(12, 41);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PUBLIC KEY";
            // 
            // btnKey
            // 
            this.btnKey.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKey.Location = new System.Drawing.Point(442, 10);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(75, 23);
            this.btnKey.TabIndex = 6;
            this.btnKey.Text = "Browser Key";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // txtKeyPath
            // 
            this.txtKeyPath.Location = new System.Drawing.Point(167, 12);
            this.txtKeyPath.Name = "txtKeyPath";
            this.txtKeyPath.Size = new System.Drawing.Size(272, 20);
            this.txtKeyPath.TabIndex = 7;
            this.txtKeyPath.TextChanged += new System.EventHandler(this.txtKeyPath_TextChanged);
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.Location = new System.Drawing.Point(167, 37);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(272, 20);
            this.txtTargetPath.TabIndex = 9;
            // 
            // btnTarget
            // 
            this.btnTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTarget.Location = new System.Drawing.Point(442, 35);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(75, 23);
            this.btnTarget.TabIndex = 8;
            this.btnTarget.Text = "Target";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // btnGenKey
            // 
            this.btnGenKey.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenKey.Location = new System.Drawing.Point(428, 72);
            this.btnGenKey.Name = "btnGenKey";
            this.btnGenKey.Size = new System.Drawing.Size(89, 23);
            this.btnGenKey.TabIndex = 10;
            this.btnGenKey.Text = "Generate Key";
            this.btnGenKey.UseVisualStyleBackColor = true;
            // 
            // btnVerify
            // 
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerify.Location = new System.Drawing.Point(362, 72);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(60, 23);
            this.btnVerify.TabIndex = 11;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            // 
            // btnSign
            // 
            this.btnSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSign.Location = new System.Drawing.Point(296, 72);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(60, 23);
            this.btnSign.TabIndex = 12;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            // 
            // cbbKeySize
            // 
            this.cbbKeySize.FormattingEnabled = true;
            this.cbbKeySize.Location = new System.Drawing.Point(428, 101);
            this.cbbKeySize.Name = "cbbKeySize";
            this.cbbKeySize.Size = new System.Drawing.Size(89, 21);
            this.cbbKeySize.TabIndex = 13;
            this.cbbKeySize.SelectedIndexChanged += new System.EventHandler(this.cbbKeySize_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "SECRET KEY";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 197);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(505, 34);
            this.textBox2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "N__________";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 259);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(505, 34);
            this.textBox3.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.status);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 22);
            this.panel1.TabIndex = 18;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(72, 5);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(38, 13);
            this.status.TabIndex = 7;
            this.status.Text = "Ready";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "STATUS:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 318);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
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
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.TextBox txtKeyPath;
        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Button btnGenKey;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.ComboBox cbbKeySize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label2;
    }
}

