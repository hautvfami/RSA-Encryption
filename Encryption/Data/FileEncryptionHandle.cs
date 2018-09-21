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
        byte[] buffer;
        byte[] bufferWrite;
        int numRead;

        public void EncryptFile(string UserDirectory, IEncryption encryption)
        {
            #region Comment
            //string[] lines = File.ReadAllLines(UserDirectory + "phising.txt", Encoding.UTF8);
            //List<byte> plainBytes = new List<byte>();
            //foreach (var str in lines)
            //{
            //    System.Text.UTF8Encoding encod = new System.Text.UTF8Encoding();
            //    byte[] byteData1 = encod.GetBytes(str);
            //    plainBytes.AddRange(byteData1);
            //}

            //System.IO.FileStream oFileStream = null;
            //oFileStream = new System.IO.FileStream(UserDirectory + "phising.encrypt.txt", System.IO.FileMode.Create);
            //var encryptedBytes = encryption.encrypt(plainBytes.ToArray());
            //oFileStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            //oFileStream.Close();
            #endregion

            buffer = new byte[encryption.getKeySize() / 8];
            using (FileStream SourceReader = File.OpenRead(UserDirectory + "phising.txt"))
            {
                using (FileStream DestinationWriter = File.OpenWrite(UserDirectory + "phising.encrypt.txt"))
                {
                    while (SourceReader.Read(buffer, 0, buffer.Length - 1) != 0)
                    {
                        //BufferDebug.show("1", buffer);
                        buffer = encryption.encrypt(buffer);
                        //BufferDebug.show("2", buffer);
                        //buffer = encryption.decrypt(buffer);
                        //BufferDebug.show("3", buffer);
                        Console.WriteLine("\n" + Encoding.UTF8.GetString(buffer));
                        DestinationWriter.Write(buffer, 0, buffer.Length);
                        buffer = new byte[encryption.getKeySize() / 8];
                    }
                }
            }
            GC.Collect();
        }

        public void DecryptFile(string UserDirectory, IEncryption encryption)
        {
            #region Comment
            //byte[] byteData1 = File.ReadAllBytes(UserDirectory + "phising.encrypt.txt");
            //byte[] byteData = encryption.decrypt(byteData1);

            //System.IO.FileStream oFileStream = null;
            //oFileStream = new System.IO.FileStream(UserDirectory + "phising.decrypt.txt", System.IO.FileMode.Create);
            //oFileStream.Write(byteData, 0, byteData.Length);
            //oFileStream.Close();
            #endregion

            buffer = new byte[encryption.getKeySize() / 8];
            using (FileStream SourceReader = File.OpenRead(UserDirectory + "phising.encrypt.txt"))
            {
                using (FileStream DestinationWriter = File.OpenWrite(UserDirectory + "phising.decrypt.txt"))
                {
                    while (SourceReader.Read(buffer, 0, buffer.Length) != 0)
                    {
                        //BufferDebug.show("BeforeDecrypt",buffer);
                        buffer = encryption.decrypt(buffer);
                        //BufferDebug.show("AfterDecrypt",buffer);
                        DestinationWriter.Write(buffer, 0, buffer.Length);
                        //Console.WriteLine(Encoding.UTF8.GetString(buffer));
                        buffer = new byte[encryption.getKeySize() / 8];
                    }
                }
            }
            GC.Collect();
        }

    }
}
