using Encryption.Data;
using Encryption.Interfaces;
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

namespace Encryption
{
    public partial class MainForm : Form
    {
        RSA rsa;
        FileEncryptionHandle fileHandle;

        public MainForm()
        {
            InitializeComponent();
            initData();
        }

        private void initData()
        {
            rsa = new RSA();
            fileHandle = new FileEncryptionHandle();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtTargetPath.Text != "" && txtKeyPath.Text != "")
            {
                status.Text = Dict.ENCRYPTING;

                if (fileHandle.EncryptFile(txtTargetPath.Text, rsa))
                {
                    status.Text = Dict.ENCRYPT_SUCCESSFUL;
                    txtTargetPath.Text += ".encrypt";
                }
                else { status.Text = Dict.FILE_NOT_FOUND; }
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtTargetPath.Text != "" && txtKeyPath.Text != "")
            {
                status.Text = Dict.DECRYPTING;

                if (fileHandle.DecryptFile(txtTargetPath.Text, rsa))
                {
                    status.Text = Dict.DECRYPT_SUCCESSFUL;
                    txtTargetPath.Text = txtTargetPath.Text.Substring(0, txtTargetPath.Text.LastIndexOf("."));
                }
                else { status.Text = Dict.FILE_NOT_FOUND; }
            }
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "*Key File | *.keystorage";
            fd.Title = "Select a Key File";

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtKeyPath.Text = fd.FileName;
            }
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Select a Target File";

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTargetPath.Text = fd.FileName;
            }
        }

        private void txtKeyPath_TextChanged(object sender, EventArgs e)
        {
            rsa.readKeyStorage(txtKeyPath.Text);
            textBox1.Text = rsa.PUBLIC_KEY.ToString("X");
        }

        private void cbbKeySize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
