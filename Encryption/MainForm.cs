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
        string fileLocation = @"C:\Users\hautv\Desktop\phising.txt";
        RSA rsa;
        FileEncryptionHandle fileHandle;

        public MainForm()
        {
            InitializeComponent();
            initData();
        }

        private void initData()
        {
            rsa = new RSA(fileLocation, Consts.KEY_SIZE_1024);
            fileHandle = new FileEncryptionHandle();
            textBox1.Text = rsa.PUBLIC_KEY.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (fileHandle.EncryptFile(fileLocation, rsa))
            {
                status.Text = Dict.ENCRYPT_SUCCESSFUL;
            }
            else
            {
                status.Text = Dict.FILE_NOT_FOUND;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (fileHandle.DecryptFile(fileLocation, rsa))
            {
                status.Text = Dict.DECRYPT_SUCCESSFUL;
            }
            else
            {
                status.Text = Dict.FILE_NOT_FOUND;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void status_Click(object sender, EventArgs e)
        {

        }
    }
}
