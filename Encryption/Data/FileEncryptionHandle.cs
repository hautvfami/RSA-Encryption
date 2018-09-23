using Encryption.Interfaces;
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

        public FileEncryptionHandle(){ }

        public bool encryptFile(string UserDirectory, IEncryption encryption)
        {
            bufferSize = encryption.getKeySize() / 8;
            buffer = new byte[bufferSize];

            try
            {
                using (FileStream SourceReader = File.OpenRead(UserDirectory))
                {
                    using (FileStream DestinationWriter = File.OpenWrite(UserDirectory + Consts.ENCRYPT_FILE_NAME))
                    {
                        while (SourceReader.Read(buffer, 0, bufferSize - 1) != 0)
                        {
                            //Debug.showBuffer("1", buffer);
                            encryption.encrypt(buffer).CopyTo(buffer,0);
                            //Debug.showLog("Text", Encoding.UTF8.GetString(buffer));
                            DestinationWriter.Write(buffer, 0, bufferSize);
                            System.Array.Clear(buffer, 0, bufferSize);
                        }
                    }
                }
                System.IO.File.Delete(UserDirectory);
                GC.Collect();
                return true;
            }
            catch (IOException e)
            {
                Debug.showLog("func encryptFile", e.Message);
                return false;
            }
        }

        public bool decryptFile(string UserDirectory, IEncryption encryption)
        {
            bufferSize = encryption.getKeySize() / 8;
            buffer = new byte[bufferSize];

            try
            {
                using (FileStream SourceReader = File.OpenRead(UserDirectory))
                {
                    using (FileStream DestinationWriter = File.OpenWrite(UserDirectory.Substring(0, UserDirectory.LastIndexOf("."))))
                    {
                        while (SourceReader.Read(buffer, 0, bufferSize) != 0)
                        {
                            encryption.decrypt(buffer).CopyTo(buffer,0);
                            DestinationWriter.Write(buffer, 0, bufferSize - 1);
                            System.Array.Clear(buffer, 0, bufferSize);
                        }
                    }
                }
                System.IO.File.Delete(UserDirectory);
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
