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
        int bufferSize;
        int numRead;

        public FileEncryptionHandle(){ }

        public bool EncryptFile(string UserDirectory, IEncryption encryption)
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
            bufferSize = encryption.getKeySize() / 8;
            buffer = new byte[bufferSize];

            try
            {
                using (FileStream SourceReader = File.OpenRead(UserDirectory))
                {
                    using (FileStream DestinationWriter = File.OpenWrite(UserDirectory + ".encrypt"))
                    {
                        while (SourceReader.Read(buffer, 0, bufferSize - 1) != 0)
                        {
                            //BufferDebug.show("1", buffer);
                            buffer = encryption.encrypt(buffer);
                            //BufferDebug.show("2", buffer);
                            //buffer = encryption.decrypt(buffer);
                            //BufferDebug.show("3", buffer);
                            //Console.WriteLine("\n" + Encoding.UTF8.GetString(buffer));
                            DestinationWriter.Write(buffer, 0, buffer.Length);
                            buffer = new byte[bufferSize];
                        }
                    }
                }
                System.IO.File.Delete(UserDirectory);
                return true;
                GC.Collect();
            }
            catch (IOException e)
            {
                return false;
            }
        }

        public bool DecryptFile(string UserDirectory, IEncryption encryption)
        {
            #region Comment
            //byte[] byteData1 = File.ReadAllBytes(UserDirectory + "phising.encrypt.txt");
            //byte[] byteData = encryption.decrypt(byteData1);

            //System.IO.FileStream oFileStream = null;
            //oFileStream = new System.IO.FileStream(UserDirectory + "phising.decrypt.txt", System.IO.FileMode.Create);
            //oFileStream.Write(byteData, 0, byteData.Length);
            //oFileStream.Close();
            #endregion
            bufferSize = encryption.getKeySize() / 8;
            buffer = new byte[bufferSize];

            try
            {
                using (FileStream SourceReader = File.OpenRead(UserDirectory + ".encrypt"))
                {
                    using (FileStream DestinationWriter = File.OpenWrite(reverseFileName(UserDirectory)))
                    {
                        while (SourceReader.Read(buffer, 0, bufferSize) != 0)
                        {
                            buffer = encryption.decrypt(buffer);
                            try
                            {
                                //BufferDebug.show("BeforeDecrypt",buffer);
                                DestinationWriter.Write(buffer, 0, bufferSize - 1);
                            }
                            catch (Exception e)
                            {
                                DestinationWriter.Write(buffer, 0, buffer.Length);
                            }
                            finally
                            {
                                BufferDebug.show("3", buffer);
                                buffer = new byte[encryption.getKeySize() / 8];
                            }
                        }
                    }
                }
                System.IO.File.Delete(UserDirectory + ".encrypt");
                return true;
                GC.Collect();
            }
            catch (IOException e)
            {
                return false;
            }
        }

        public string reverseFileName(string filePath)
        {
            string dir = filePath.Substring(0, filePath.LastIndexOf('\\'));
            string fileName = filePath.Substring(filePath.LastIndexOf('\\'), filePath.Length - dir.Length);
            fileName = fileName.Replace(".encrypt", " ");
            return dir + fileName;
        }

    }
}
