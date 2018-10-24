using Encryption.Data;
using Encryption.Algorithm;
using Encryption.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    public partial class MainForm : Form
    {
        RSA rsa;
        FileEncryptionHandle fileHandle;
        int progress;

        public MainForm()
        {
            InitializeComponent();
            initData();
        }

        private void initData()
        {
            rsa = new RSA();
            fileHandle = new FileEncryptionHandle();
            initControlData();
            initToolTip();
        }

        private void initControlData()
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

            txtTargetPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
        }

        private void initToolTip()
        {
            ttGenerateKey.SetToolTip(btnGenKey, "Select your taget, key's going to write in the same folder of target!");
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtTargetPath.Text != "" && rsa.PUBLIC_KEY != 0)
            {
                lbStatus.Text = Dict.ENCRYPTING;
                timer1.Start();
                Thread encrypting = new Thread(delegate()
                {
                    if (fileHandle.encryptFile(txtTargetPath.Text, rsa, ref progress))
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            txtTargetPath.Text += Consts.ENCRYPT_FILE_NAME;
                            lbStatus.Text = Dict.ENCRYPT_SUCCESSFUL;
                        });
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            lbStatus.Text = Dict.FILE_NOT_FOUND;
                        });
                    }
                    timer1.Stop();
                });

                encrypting.Priority = ThreadPriority.Highest;
                encrypting.Start();
            }
            else
            {
                lbStatus.Text = Dict.FILE_NOT_FOUND_OR_DONT_HAVE_PUBLIC_KEY;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtTargetPath.Text != Consts.EMPTY && rsa.hasSecretKey())
            {
                lbStatus.Text = Dict.DECRYPTING;
                timer1.Start();
                Thread decrypting = new Thread(delegate()
                {
                    if (fileHandle.decryptFile(txtTargetPath.Text, rsa, ref progress))
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            txtTargetPath.Text = txtTargetPath.Text.Substring(0, txtTargetPath.Text.LastIndexOf("."));
                            lbStatus.Text = Dict.DECRYPT_SUCCESSFUL;
                        });
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            lbStatus.Text = Dict.FILE_NOT_FOUND;
                        });
                    }
                    timer1.Stop();
                });
                decrypting.Priority = ThreadPriority.Highest;
                decrypting.Start();
            }
            else
            {
                lbStatus.Text = Dict.FILE_NOT_FOUND_OR_DONT_HAVE_SECRET_KEY;
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

        private void btnGenKey_Click(object sender, EventArgs e)
        {
            string targetPath = "";
            int keySize = Int16.Parse(cbbKeySize.SelectedItem.ToString());
            FolderBrowserDialog fd = new FolderBrowserDialog();

            // Select folder to save Key
            fd.Description = Dict.SELECT_TARGET_FOLDER;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                targetPath = fd.SelectedPath;

            if (targetPath != Consts.EMPTY && keySize / 8 != 0)
            {
                lbStatus.Text = Dict.GENERATING;
                Debug.showLog("genKey", targetPath + "|" + keySize);
                // Gen key
                Thread genKey = new Thread(delegate() {
                    rsa = new RSA(targetPath + "\\", keySize);
                    this.Invoke((MethodInvoker)delegate()
                    {
                        txtPK.Text = rsa.PUBLIC_KEY.ToString("X");
                        txtN.Text = rsa.N.ToString("X");
                        lbStatus.Text = Dict.GENERATE_KEY_COMPLETED;
                    });
                });
                genKey.Start();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (rsa.sign(txtTargetPath.Text))
            {
                lbStatus.Text = Dict.SIGN_SUCCESSFUL;
            }
            else
            {
                lbStatus.Text = Dict.SIGN_FAILED;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (rsa.verify(txtTargetPath.Text))
            {
                lbStatus.Text = Dict.VERIFY_SUCCESSFUL;
            }
            else
            {
                lbStatus.Text = Dict.VERIFY_FAILED;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbPercent.Text =  progress + "%";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void txtN_TextChanged(object sender, EventArgs e)
        {
            lbKeySize.Text = rsa.getKeySize() + " Bits";
        }
    }
}
