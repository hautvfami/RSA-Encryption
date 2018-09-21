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
        string fileLocation = @"C:\Users\hautv\Desktop\";
        RSA rsa;
        FileEncryptionHandle fileHandle;

        public MainForm()
        {
            InitializeComponent();
            initData();
        }

        private void initData()
        {
            rsa = new RSA(fileLocation, Consts.KEY_SIZE_512);
            fileHandle = new FileEncryptionHandle();
            textBox1.Text = rsa.PUBLIC_KEY.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            fileHandle.EncryptFile(fileLocation, rsa);
            textBox1.Text = "Encrypt Successful!";
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            fileHandle.DecryptFile(fileLocation, rsa);
            textBox1.Text = "Decrypt Successful!";
        }
    }
}
