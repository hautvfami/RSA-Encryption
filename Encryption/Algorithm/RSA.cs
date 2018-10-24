using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

using Encryption.Util;
using System.Globalization;                       

namespace Encryption.Algorithm
{
    class RSA : IEncryption
    {
        public BigInteger PUBLIC_KEY;
        public BigInteger N;
        private BigInteger SECRET_KEY;
        private BigInteger p, q, n;
        public int KEY_SIZE;

        BigInteger dP, dQ, qInv, m1, m2, h, m;

        //#region Singeton
        //private static RSA instance;
        //public static IEncryption getInstance()    // Singeton
        //{
        //    if (instance == null) instance = new RSA();
        //    return instance;
        //}
        //#endregion

        #region Constructor...
        public RSA() { }

        public RSA(string keyFile)
        {
            if (!readKeyStorage(keyFile))
            {
                KEY_SIZE = Consts.KEY_SIZE_1024;
                generateKeyPair();
                writeKeyStorage(keyFile);
            }
        }

        public RSA(string keyFile, int keySize = Consts.KEY_SIZE_32){
            KEY_SIZE = keySize;
            generateKeyPair();
            writeKeyStorage(keyFile);
        }

        public RSA(BigInteger PUBLIC_KEY_, BigInteger SECRET_KEY_, BigInteger N_)
        {
            PUBLIC_KEY = PUBLIC_KEY_;
            SECRET_KEY = SECRET_KEY_;
            N = N_;
        }
        #endregion

        public bool hasSecretKey()
        {
            return SECRET_KEY != 0 ? true : false;
        }
        public void encrypt(ref byte[] plain)
        {
            BigInteger e = new BigInteger(plain);
            BigInteger c = MathUlti.fastExponent(e, PUBLIC_KEY, N);
            System.Array.Clear(plain, 0, plain.Length);
            c.ToByteArray().CopyTo(plain, 0);
        }

        public void decrypt(ref byte[] cipher)
        {
            #region Origin aglorigth
            //BigInteger c = new BigInteger(crypt);
            //BigInteger e = MathUlti.fastExponent(c, SECRET_KEY, N);
            //System.Array.Clear(crypt, 0, crypt.Length);
            //e.ToByteArray().CopyTo(crypt, 0);
            //return crypt;
            #endregion

            //System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            //Chinese Remainder Theorem
            BigInteger c = new BigInteger(cipher);
            //Debug.showLog("1", sw.ElapsedMilliseconds);
            m1 = MathUlti.fastExponent(c, dP, p);
            //Debug.showLog("2", sw.ElapsedMilliseconds);
            m2 = MathUlti.fastExponent(c, dQ, q);
            //Debug.showLog("3", sw.ElapsedMilliseconds);
            h = (m1 > m2) ? (qInv * (m1 - m2)) % p : ((qInv * (m1 - m2 + p)) % p);
            m = m2 + (h * q);
            //Debug.showLog("4", sw.ElapsedMilliseconds);
            System.Array.Clear(cipher, 0, cipher.Length);
            //Debug.showLog("5", sw.ElapsedMilliseconds);
            m.ToByteArray().CopyTo(cipher, 0);
            //Debug.showLog("6", sw.ElapsedMilliseconds);
            //sw.Stop();
        }

        #region Sign-Verify
        public bool verify(string filePath)
        {
            byte[] hash = new byte[KEY_SIZE / 8];
            byte[] sign = new byte[KEY_SIZE / 8];
            try
            {
                getHashSHA256(filePath).CopyTo(hash, 0);
                using (Stream file = File.OpenRead(filePath + ".sign"))
                    file.Read(sign, 0, sign.Length);
            }
            catch (Exception e)
            {
                throw e;
            }

            encrypt(ref sign);
            if (new BigInteger(hash) == new BigInteger(sign)) return true;
            return false;
        }

        public bool sign (string filePath)
        {
            byte[] hash = new byte[KEY_SIZE / 8];
            getHashSHA256(filePath).CopyTo(hash, 0);

            decrypt(ref hash);
            using (Stream file = File.OpenWrite(filePath + ".sign"))
                file.Write(hash, 0, hash.Length);
            return true;
        }

        private byte[] getHashSHA256(string filePath)
        {
            byte[] hash;
            SHA1Managed sha = new SHA1Managed();
            try
            {
                using (Stream file = File.OpenRead(filePath))
                    hash = sha.ComputeHash(file);
                Debug.showBuffer("Hash", hash);
                return hash;
            }
            catch (Exception e)
            {
                Debug.showLog("ERROR", e.Message);
            }
            return null;
            
        }
        #endregion

        #region Generate Key
        private void generateKeyPair()
        {
            p = MathUlti.generatePrime(KEY_SIZE / 2);
            q = MathUlti.generatePrime(KEY_SIZE / 2);
            if (p < q) MathUlti.swapBigInteger(ref p, ref q);
            N = BigInteger.Multiply(p, q);
            n = BigInteger.Multiply(p - 1, q - 1);
            PUBLIC_KEY = 65537;//MathUlti.getPublicKey(KEY_SIZE, n);
            SECRET_KEY = MathUlti.moduloInverse(PUBLIC_KEY, n);

            dP = MathUlti.moduloInverse(PUBLIC_KEY, p - 1);
            dQ = MathUlti.moduloInverse(PUBLIC_KEY, q - 1);
            qInv = MathUlti.moduloInverse(q, p);

            Debug.showLog("dP", dP);
            Debug.showLog("dQ", dQ);
            Debug.showLog("N", N);
            Debug.showLog("PUBLIC_KEY", PUBLIC_KEY);
            Debug.showLog("SECRET_KEY", SECRET_KEY);
        }
        #endregion

        #region KeyFromFile...
        public bool readKeyStorage(string keyFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(keyFile))
                {
                    string line = sr.ReadToEnd();
                    string[] element = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    for (int i = 0; i < element.Length; i++)
                    {
                        switch (element[i])
                        {
                            case "PUBLIC_KEY:": PUBLIC_KEY = BigInteger.Parse(element[i+1], NumberStyles.AllowHexSpecifier); break;
                            case "SECRET_KEY:": SECRET_KEY = BigInteger.Parse(element[i+1], NumberStyles.AllowHexSpecifier); break;
                            case "N:": N = BigInteger.Parse(element[i+1], NumberStyles.AllowHexSpecifier); break;
                            // Chinese Remainder Theorem
                            case "p:": p = BigInteger.Parse(element[i+1], NumberStyles.AllowHexSpecifier); break;
                            case "q:": q = BigInteger.Parse(element[i+1], NumberStyles.AllowHexSpecifier); break;
                        }
                    }
                    if (p < q) MathUlti.swapBigInteger(ref p, ref q);
                    dP = MathUlti.moduloInverse(PUBLIC_KEY, p - 1);
                    dQ = MathUlti.moduloInverse(PUBLIC_KEY, q - 1);
                    qInv = MathUlti.moduloInverse(q, p);

                    KEY_SIZE = (N.ToByteArray().Length) * 8;
                }

                Debug.showLog("dP", dP);
                Debug.showLog("dQ", dQ);
                Debug.showLog("N", N);
                Debug.showLog("KEY_SIZE", KEY_SIZE);
                Debug.showLog("PUBLIC_KEY", PUBLIC_KEY);
                Debug.showLog("SECRET_KEY", SECRET_KEY);

                return true;
            }
            catch (Exception e)
            {
                Debug.showLog("func readKeyStorage", e.Message);
                return false;
            }
        }

        public bool writeKeyStorage(string keyFile)
        {
            keyFile = FileUtil.getDirectory(keyFile) + "RSA.keystorage";
            try
            {
                using (StreamWriter ds = new StreamWriter(keyFile))
                {
                    ds.Write(
                        "PUBLIC_KEY:" + Environment.NewLine + PUBLIC_KEY.ToString("X") + Environment.NewLine +
                        "SECRET_KEY:" + Environment.NewLine + SECRET_KEY.ToString("X") + Environment.NewLine +
                        "N:" + Environment.NewLine + N.ToString("X") + Environment.NewLine +
                        // Chinese Remainder Theorem
                        "p:" + Environment.NewLine + p.ToString("X") + Environment.NewLine +
                        "q:" + Environment.NewLine + q.ToString("X") + Environment.NewLine
                        );
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.showLog("func writeKeyStorage", e.Message);
                return false;
            }
        }

        public int getKeySize()
        {
            return KEY_SIZE;
        }
        #endregion

    }
}
