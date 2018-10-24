using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;

namespace Encryption.PKCS1
{
    class RSA_PKCS1 : IPKCS1
    {
        public Random random = new Random();
        public byte[] I2OSP(BigInteger x, int xLen)
        {
            if (x >= BigInteger.Pow(256, xLen)) throw new Exception("integer too large");
            byte[] X = new byte[xLen];
            x.ToByteArray().CopyTo(X, 0);
            return X;
        }

        public BigInteger OS2IP(byte[] X)
        {
            return new BigInteger(X);
        }

        public BigInteger RSAEP(Models.RSAPublicKey ne, BigInteger m)
        {
            if (m <= 0 || m >= ne.n - 1) throw new Exception("message representative out of range");
            BigInteger c = BigInteger.ModPow(m, ne.e, ne.n);
            return c;
        }

        public BigInteger RSADP(Models.RSAPrivateKey K, BigInteger c)
        {
            if (c <= 0 || c >= (K.p * K.q - 1)) throw new Exception("ciphertext representative out of range");
            BigInteger m_1 = BigInteger.ModPow(c, K.dP, K.p);
            BigInteger m_2 = BigInteger.ModPow(c, K.dQ, K.q);
            BigInteger h = (m_1 - m_2) * K.qInv % K.p;
            BigInteger m = m_2 + K.q * h;
            return m;
        }

        public BigInteger RSASP1(Models.RSAPrivateKey K, BigInteger m)
        {
            if (m <= 0 || m >= (K.p * K.q - 1)) throw new Exception("message representative out of range");
            BigInteger s_1 = BigInteger.ModPow(m, K.dP, K.p);
            BigInteger s_2 = BigInteger.ModPow(m, K.dQ, K.q);
            BigInteger h = (s_1 - s_2) * K.qInv % K.p;
            BigInteger s = s_2 + K.q * h;
            return s;
        }

        public BigInteger RSAVP1(Models.RSAPublicKey ne, BigInteger s)
        {
            if (s <= 0 || s >= ne.n - 1) throw new Exception("signature representative out of range");
            BigInteger m = BigInteger.ModPow(s, ne.e, ne.n);
            return m;
        }

        //*????????????????????SHA256 = 256 bits(32bytes)
        public byte[] RSAES_OAEP_ENCRYPT(Models.RSAPublicKey ne, byte[] M, string L = "")
        {
            int mLen = (int)Math.Pow(2, 65) - 1;
            int hLen = 256 / 8;
            int k = ne.n.ToByteArray().Length;

            if (L.Length > mLen) throw new Exception("label too long");
            if (mLen > k - 2 * hLen - 2) throw new Exception("message too long");

            // EME-OAEP encoding
            SHA256Managed hashString = new SHA256Managed();
            byte[] lHash = hashString.ComputeHash(Encoding.ASCII.GetBytes(L));

            // DB = lHash || PS || 0x01 || M.
            byte[] PS = new byte[k - mLen - 2 * hLen - 2];
            byte[] DB = new byte[k - hLen - 1];
            var list = new List<byte>();
            list.AddRange(lHash);
            list.AddRange(PS);
            list.AddRange(new byte[] { 0x01 });
            list.AddRange(M);
            list.ToArray().CopyTo(DB, 0);

            byte[] seed = new byte[hLen];
            random.NextBytes(seed);

            byte[] dbMask = MGF1(seed, k - hLen - 1);
            byte[] maskedDB = new byte[k - hLen - 1];
            for (int i = 0; i < k - hLen - 1; i++)
                maskedDB[i] = (byte)(DB[i] ^ dbMask[i]);

            byte[] seedMask = MGF1(maskedDB, hLen);

            byte[] maskedSeed = new byte[hLen];
            for (int i = 0; i < hLen; i++)
                maskedSeed[i] = (byte)(seed[i] ^ seedMask[i]);

            byte[] EM = new byte[k];
            list = new List<byte>();
            list.AddRange(new byte[] { 0x00 });
            list.AddRange(maskedSeed);
            list.AddRange(maskedDB);
            list.ToArray().CopyTo(EM, 0);

            //  RSA encryption
            BigInteger m = OS2IP(EM);
            BigInteger c = RSAEP(ne, m);
            byte[] C = I2OSP(c, k);

            return C;
        }

        public byte[] RSAES_OAEP_DECRYPT(Models.RSAPrivateKey K, byte[] C, string L)
        {
            BigInteger n = K.p * K.q;
            int mLen = (int)Math.Pow(2, 65) - 1;
            int hLen = 256 / 8;
            int k = n.ToByteArray().Length;

            if (L.Length > mLen) throw new Exception("decryption error");
            if (C.Length != k) throw new Exception("decryption error");
            if (k < 2 * hLen + 2) throw new Exception("decryption error");

            BigInteger c = OS2IP(C);
            BigInteger m = RSADP(K, c);

            byte[] EM = I2OSP(m, k);
            // EME-OAEP decoding
            SHA256Managed hashString = new SHA256Managed();
            byte[] lHash = hashString.ComputeHash(Encoding.ASCII.GetBytes(L));

            byte[] Y = new byte[] { EM[0] };
            byte[] maskedSeed = new byte[hLen];
            byte[] maskedDB = new byte[k - hLen - 1];
            Buffer.BlockCopy(EM, 1, maskedSeed, 0, hLen);
            Buffer.BlockCopy(EM, hLen + 1, maskedDB, 0, k - hLen - 1);

            byte[] seedMask = MGF1(maskedDB, hLen);
            byte[] seed = new byte[hLen];
            for (int i = 0; i < hLen; i++)
                seed[i] = (byte)(maskedSeed[i] ^ seedMask[i]);

            byte[] dbMask = MGF1(seed, k - hLen - 1);
            byte[] DB = new byte[k - hLen - 1];
            for (int i = 0; i < k - hLen - 1; i++)
                DB[i] = (byte)(maskedDB[i] ^ dbMask[i]);
            //.......................................Page 26


            throw new NotImplementedException();
        }

        public byte[] RSAES_PKCS1_V1_5_ENCRYPT(Models.RSAPublicKey ne, byte[] M)
        {
            throw new NotImplementedException();
        }

        public byte[] RSAES_PKCS1_V1_5_DECRYPT(Models.RSAPrivateKey K, byte[] M)
        {
            throw new NotImplementedException();
        }

        public byte[] RSASSA_PSS_SIGN(Models.RSAPrivateKey K, byte[] M)
        {
            throw new NotImplementedException();
        }

        public string RSASSA_PSS_VERIFY(Models.RSAPublicKey ne, byte[] M, byte[] S)
        {
            throw new NotImplementedException();
        }

        public byte[] RSASSA_PKCS1_V1_5_SIGN(Models.RSAPrivateKey K, byte[] M)
        {
            throw new NotImplementedException();
        }

        public byte[] RSASSA_PKCS1_V1_5_VERIFY(Models.RSAPublicKey ne, byte[] M, byte[] S)
        {
            throw new NotImplementedException();
        }

        public byte[] EMSA_PSS_ENCODE(byte[] M, int emBits)
        {
            throw new NotImplementedException();
        }

        public string EMSA_PSS_VERIFY(byte[] M, byte[] EM, int emBits)
        {
            throw new NotImplementedException();
        }

        public byte[] EMSA_PKCS1_V1_5_ENCODE(byte[] M, int emLen)
        {
            throw new NotImplementedException();
        }

        public byte[] MGF1(byte[] mgfSeed, int maskLen)
        {
            throw new NotImplementedException();
        }
    }
}
