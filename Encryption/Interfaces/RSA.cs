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

        //private static RSA instance;
        //#region Singeton
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

        public byte[] encrypt(byte[] plain)
        {
            //System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            //Console.WriteLine("1\t" + sw.ElapsedMilliseconds);
            BigInteger e = new BigInteger(plain);
            //Console.WriteLine("2\t" + sw.ElapsedMilliseconds);
            BigInteger c = MathUlti.fastExponent(e, PUBLIC_KEY, N);
            //Console.WriteLine("3\t" + sw.ElapsedMilliseconds);
            System.Array.Clear(plain, 0, plain.Length);
            //Console.WriteLine("4\t" + sw.ElapsedMilliseconds);
            c.ToByteArray().CopyTo(plain, 0);
            //Console.WriteLine("5\t" + sw.ElapsedMilliseconds);
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
            getHashSHA256(filePath).CopyTo(hash, 0);

            byte[] sign = new byte[KEY_SIZE / 8];
            using (Stream file = File.OpenRead(filePath + ".sign"))
                file.Read(sign, 0, sign.Length);

            byte[] signOrigin;
            signOrigin = encrypt(sign);
            //Debug.showBuffer("signOrigin",signOrigin);
            if (new BigInteger(hash) == new BigInteger(signOrigin)) return true;
            return false;
        }

        public bool sign(string filePath)
        {
            byte[] hash = new byte[KEY_SIZE / 8];
            getHashSHA256(filePath).CopyTo(hash, 0);
            try
            {
                byte[] sign = decrypt(hash);
                using (Stream file = File.OpenWrite(filePath + ".sign"))
                    file.Write(sign, 0, sign.Length);
                return true;
            }
            catch (Exception e)
            {
                Debug.showLog("func sign", e.Message);
                return false;
            }
        }

        private byte[] getHashSHA256(string filePath)
        {
            byte[] hash;
            SHA1Managed sha = new SHA1Managed();

            using (Stream file = File.OpenRead(filePath))
                hash = sha.ComputeHash(file);
            Debug.showBuffer("Hash", hash);
            return hash;
        }
        #endregion

        #region Generate Key
        private void generateKeyPair()
        {
            p = MathUlti.generatePrime(KEY_SIZE / 2);
            q = MathUlti.generatePrime(KEY_SIZE / 2);
            N = BigInteger.Multiply(p, q);
            n = BigInteger.Multiply(p - 1, q - 1);
            PUBLIC_KEY = MathUlti.generatePrime(KEY_SIZE);
            SECRET_KEY = MathUlti.moduloInverse(PUBLIC_KEY, n);
            Debug.showLog("N", N);
            Debug.showLog("n", n);
            Debug.showLog("p", p);
            Debug.showLog("q", q);
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
                    string[] element = line.Split('\n');
                    for (int i = 0; i < element.Length; i++)
                    {
                        switch (element[i])
                        {
                            case "PUBLIC_KEY:": PUBLIC_KEY = BigInteger.Parse(element[++i], NumberStyles.AllowHexSpecifier); break;
                            case "SECRET_KEY:": SECRET_KEY = BigInteger.Parse(element[++i], NumberStyles.AllowHexSpecifier); break;
                            case "N:": N = BigInteger.Parse(element[++i], NumberStyles.AllowHexSpecifier); break;
                        }
                    }
                    KEY_SIZE = (PUBLIC_KEY.ToByteArray().Length) * 8;
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
                        "PUBLIC_KEY:\n" + PUBLIC_KEY.ToString("X") +
                        "\nSECRET_KEY:\n" + SECRET_KEY.ToString("X") +
                        "\nN:\n" + N.ToString("X")
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
