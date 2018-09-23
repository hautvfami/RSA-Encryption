using Encryption.Data;
using Encryption.Interfaces;
using Encryption.Util;
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
            initCbbKey();
        }

        private void initCbbKey()
        {
            cbbKeySize.Items.Insert(0, Consts.KEY_SIZE_16);
            cbbKeySize.Items.Insert(1, Consts.KEY_SIZE_32);
            cbbKeySize.Items.Insert(2, Consts.KEY_SIZE_64);
            cbbKeySize.Items.Insert(3, Consts.KEY_SIZE_128);
            cbbKeySize.Items.Insert(4, Consts.KEY_SIZE_256);
            cbbKeySize.Items.Insert(5, Consts.KEY_SIZE_512);
            cbbKeySize.Items.Insert(6, Consts.KEY_SIZE_1024);
            cbbKeySize.Items.Insert(7, Consts.KEY_SIZE_2048);
            cbbKeySize.SelectedIndex = 6;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtTargetPath.Text != "" && txtKeyPath.Text != "")
            {
                status.Text = Dict.ENCRYPTING;
                Debug.showTime("Begin");

                if (fileHandle.encryptFile(txtTargetPath.Text, rsa))
                {
                    status.Text = Dict.ENCRYPT_SUCCESSFUL;
                    txtTargetPath.Text += Consts.ENCRYPT_FILE_NAME;
                }
                else { status.Text = Dict.FILE_NOT_FOUND; }
                Debug.showTime("End");
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtTargetPath.Text != "" && txtKeyPath.Text != "")
            {
                status.Text = Dict.DECRYPTING;

                if (fileHandle.decryptFile(txtTargetPath.Text, rsa))
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
            fd.Filter = Consts.DIALOG_KEY_FILTER;
            fd.Title = Dict.SELECT_KEY_FILE;

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtKeyPath.Text = fd.FileName;
            }
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = Dict.SELECT_TARGET_FILE;

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTargetPath.Text = fd.FileName;
            }
        }

        private void txtKeyPath_TextChanged(object sender, EventArgs e)
        {
            rsa.readKeyStorage(txtKeyPath.Text);
            txtPK.Text = rsa.PUBLIC_KEY.ToString("X");
            txtN.Text = rsa.N.ToString("X");
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

        private void btnGenKey_Click(object sender, EventArgs e)
        {
            string targetPath = txtTargetPath.Text;
            int keySize = Int16.Parse(cbbKeySize.SelectedItem.ToString());
            Debug.showLog("genKey", targetPath + "|" + keySize);

            if (targetPath != Consts.EMPTY && keySize / 8 != 0)
            {
                rsa = new RSA(targetPath, keySize);
                txtPK.Text = rsa.PUBLIC_KEY.ToString("X");
                txtN.Text = rsa.N.ToString("X");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
