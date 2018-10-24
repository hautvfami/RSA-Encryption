using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Models
{
    class RSAPrivateKey
    {
        public BigInteger q { get; set; }
        public BigInteger p { get; set; }
        public BigInteger dP { get; set; }
        public BigInteger dQ { get; set; }
        public BigInteger qInv { get; set; }
    }
}
