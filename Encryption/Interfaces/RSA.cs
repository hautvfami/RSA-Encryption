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
            BigInteger e = new BigInteger(plain);
            BigInteger c = MathUlti.fastExponent(e, PUBLIC_KEY, N);
            System.Array.Clear(plain, 0, plain.Length);
            c.ToByteArray().CopyTo(plain, 0);
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
