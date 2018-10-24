using Encryption.Algorithm;
using Encryption.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Data
{
    class FileEncryptionHandle
    {
        private byte[] buffer;
        private int bufferSize;
        private long readed;
        private long numread;

        public FileEncryptionHandle(){ }

        public bool encryptFile(string UserDirectory, IEncryption encryption, ref int progress)
        {
            bufferSize = encryption.getKeySize() / 8;
            buffer = new byte[bufferSize];
            progress = 0;
            readed = 0;

            try
            {
                using (FileStream SourceReader = File.OpenRead(UserDirectory))
                {
                    using (FileStream DestinationWriter = File.OpenWrite(UserDirectory + Consts.ENCRYPT_FILE_NAME))
                    {
                        while (SourceReader.Read(buffer, 0, bufferSize - 1) != 0)
                        {
                            // Count progress person
                            readed += bufferSize - 1;
                            progress = (int)(100.0 * readed / SourceReader.Length);
                            // Main encrypt file
                            encryption.encrypt(ref buffer);
                            DestinationWriter.Write(buffer, 0, bufferSize);
                            System.Array.Clear(buffer, 0, bufferSize);
                        }
                    }
                }
                //System.IO.File.Delete(UserDirectory);
                GC.Collect();
                return true;
            }
            catch (IOException e)
            {
                Debug.showLog("func encryptFile", e.Message);
                return false;
            }
        }

        public bool decryptFile(string UserDirectory, IEncryption encryption, ref int progress)
        {
            bufferSize = encryption.getKeySize() / 8;
            buffer = new byte[bufferSize];
            progress = 0;
            readed = 0;

            try
            {
                using (FileStream SourceReader = File.OpenRead(UserDirectory))
                {
                    using (FileStream DestinationWriter = File.OpenWrite(UserDirectory.Substring(0, UserDirectory.LastIndexOf("."))))
                    {
                        Debug.showTime("Start");
                        while (SourceReader.Read(buffer, 0, bufferSize) != 0)
                        {
                            // Count progress person
                            readed += bufferSize;
                            progress = (int)(100.0 * readed / SourceReader.Length);
                            // Main decrypt file
                            encryption.decrypt(ref buffer);//.CopyTo(buffer,0);
                            DestinationWriter.Write(buffer, 0, bufferSize - 1);
                            System.Array.Clear(buffer, 0, bufferSize);
                        }
                        Debug.showTime("Finish");
                    }
                }
                //System.IO.File.Delete(UserDirectory);
                GC.Collect();
                return true;
            }
            catch (IOException e)
            {
                Debug.showLog("func decryptFile", e.Message);
                return false;
            }
        }
    }
}
