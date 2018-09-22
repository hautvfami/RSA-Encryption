using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Interfaces
{
    class RSASignVerify : RSA
    {
        public void verify(string filePath)
        {
            byte[] hash = getHashSHA256(filePath);
            byte[] signOrigin = encrypt(hash);

            byte[] sign = new byte[Consts.KEY_SIZE_1024];
            using (Stream file = File.OpenRead(filePath + ".sign"))
                file.Read(sign, 0, sign.Length);

            if (signOrigin == sign) Console.WriteLine("Sign correct");
        }

        public void sign(string filePath)
        {
            byte[] hash = getHashSHA256(filePath);
            byte[] sign = encrypt(hash);
            using (Stream file = File.OpenWrite(filePath + ".sign"))
                file.Write(sign, 0, sign.Length);
        }

        private byte[] getHashSHA256(string filePath)
        {
            byte[] hash;
            SHA1Managed sha = new SHA1Managed();

            using (Stream file = File.OpenRead(filePath))
                hash = sha.ComputeHash(file);
            return hash;
        }
    }
}
