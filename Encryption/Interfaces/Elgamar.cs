using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Interfaces
{
    class Elgamar : IEncryption
    {
        public byte[] encrypt(byte[] plain)
        {
            return plain;
        }

        public byte[] decrypt(byte[] plain)
        {
            return plain;
        }

        public int getKeySize()
        {
            return 0;
        }
    }
}
