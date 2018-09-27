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

namespace Encryption.Interfaces
{
    class RSA : IEncryption
    {
        public BigInteger PUBLIC_KEY;
        public BigInteger N;
        private BigInteger SECRET_KEY;
        private BigInteger p, q, n;
        public int KEY_SIZE;

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
        public byte[] encrypt(byte[] plain)
        {
            //System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            //Debug.showLog("1",sw.ElapsedMilliseconds);
            BigInteger e = new BigInteger(plain);
            //Debug.showLog("2", sw.ElapsedMilliseconds);
            BigInteger c = MathUlti.fastExponent(e, PUBLIC_KEY, N);
            //Debug.showLog("3", sw.ElapsedMilliseconds);
            System.Array.Clear(plain, 0, plain.Length);
            //Debug.showLog("4", sw.ElapsedMilliseconds);
            c.ToByteArray().CopyTo(plain, 0);
            //Debug.showLog("5", sw.ElapsedMilliseconds);
            //sw.Stop();
            return plain;
        }

        public byte[] decrypt(byte[] crypt)
        {
            BigInteger c = new BigInteger(crypt);
            BigInteger e = MathUlti.fastExponent(c, SECRET_KEY, N);
            System.Array.Clear(crypt, 0, crypt.Length);
            e.ToByteArray().CopyTo(crypt, 0);
            return crypt;
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

            byte[] signOrigin;
            signOrigin = encrypt(sign);
            if (new BigInteger(hash) == new BigInteger(signOrigin)) return true;
            return false;
        }

        public bool sign (string filePath)
        {
            byte[] hash = new byte[KEY_SIZE / 8];
            getHashSHA256(filePath).CopyTo(hash, 0);

            byte[] sign = decrypt(hash);
            using (Stream file = File.OpenWrite(filePath + ".sign"))
                file.Write(sign, 0, sign.Length);
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
            N = BigInteger.Multiply(p, q);
            n = BigInteger.Multiply(p - 1, q - 1);
            PUBLIC_KEY = 65537;//MathUlti.getPublicKey(KEY_SIZE, n);
            SECRET_KEY = MathUlti.moduloInverse(PUBLIC_KEY, n);

            Debug.showLog("p", p);
            Debug.showLog("q", q);
            Debug.showLog("n", n);
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
                            case "PUBLIC_KEY:": PUBLIC_KEY = BigInteger.Parse(element[++i], NumberStyles.AllowHexSpecifier); break;
                            case "SECRET_KEY:": SECRET_KEY = BigInteger.Parse(element[++i], NumberStyles.AllowHexSpecifier); break;
                            case "N:": N = BigInteger.Parse(element[++i], NumberStyles.AllowHexSpecifier); break;
                        }
                    }
                    KEY_SIZE = (N.ToByteArray().Length) * 8;
                }

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
                        "N:"          + Environment.NewLine + N.ToString("X")
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
