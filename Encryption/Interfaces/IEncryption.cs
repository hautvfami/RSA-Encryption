using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Interfaces
{
    interface IEncryption
    {
        //IEncryption getInstance();
        int getKeySize();
        byte[] encrypt(byte[] plain);
        byte[] decrypt(byte[] plain);
    }
}
