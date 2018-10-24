using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Algorithm
{
    interface IEncryption
    {
        //IEncryption getInstance();
        int getKeySize();
        void encrypt(ref byte[] plain);
        void decrypt(ref byte[] cipher);

        bool sign(string filePath);
        bool verify(string filePath);
    }
}
