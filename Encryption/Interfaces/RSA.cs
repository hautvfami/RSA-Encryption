using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

using Encryption.Util;

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

        public RSA(string keyFile, int keySize = Consts.KEY_SIZE_32)
        {
            if (!readKeyStorage(keyFile))
            {
                KEY_SIZE = keySize;
                generateKeyPair();
                //writeKeyStorage(keyFile);
            }
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
            plain = MathUlti.addLastZeroByte(plain);
            BigInteger e = new BigInteger(plain);

            BigInteger c = MathUlti.fastExponent(e, PUBLIC_KEY, N);
            byte[] temp2 = c.ToByteArray();
            temp2 = temp2.Take(plain.Length).ToArray();
            return temp2;
        }

        public byte[] decrypt(byte[] crypt)
        {
            crypt = MathUlti.addLastZeroByte(crypt);
            BigInteger c = new BigInteger(crypt);

            BigInteger e = MathUlti.fastExponent(c, SECRET_KEY, N);
            byte[] temp2 = e.ToByteArray();
            temp2 = temp2.Take(crypt.Length).ToArray();
            return temp2;
        }

        #region Generate Key
        private void generateKeyPair()
        {
            p = MathUlti.generatePrime(KEY_SIZE/2);
            q = MathUlti.generatePrime(KEY_SIZE/2);
            N = BigInteger.Multiply(p,q);
            n = BigInteger.Multiply(p - 1, q - 1);
            PUBLIC_KEY = MathUlti.generatePrime(KEY_SIZE - 8);
            SECRET_KEY = MathUlti.moduloInverse(PUBLIC_KEY, n);
            Console.WriteLine("\nN: " + N + "\nn: " + n + "\nPUBLIC_KEY: " + PUBLIC_KEY + "\nSECRET_KEY: " + SECRET_KEY + "\np: " + p + "\nq: " + q + "\nGCD(PK,SK):" + BigInteger.GreatestCommonDivisor(PUBLIC_KEY, n) + "\nn>PK? " + (n > PUBLIC_KEY).ToString() + "\n----------------------------");
        }
        #endregion

        #region KeyFromFile...
        public bool readKeyStorage(string keyFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(keyFile + @"RSA.keystorage"))
                {
                    string line = sr.ReadToEnd();
                    string[] element = line.Split('\n');
                    for (int i = 0; i<element.Length; i++)
                    {
                        switch (element[i])
                        {
                            case "PUBLIC_KEY:": PUBLIC_KEY = BigInteger.Parse(element[++i]); break;
                            case "SECRET_KEY:": SECRET_KEY = BigInteger.Parse(element[++i]); break;
                            case "N:": N = BigInteger.Parse(element[++i]); break;
                        }
                    }
                    KEY_SIZE = (PUBLIC_KEY.ToByteArray().Length - 1) * 8;
                }
                Console.WriteLine("N: " + N + "\nPUBLIC_KEY: " + PUBLIC_KEY + "\nSECRET_KEY: " + SECRET_KEY + "\nKEY_SIZE: " + KEY_SIZE);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool writeKeyStorage(string keyFile)
        {
            try
            {
                using (StreamWriter ds = new StreamWriter(keyFile + @"RSA.keystorage"))
                {
                    ds.Write("PUBLIC_KEY:\n" + PUBLIC_KEY + "\nSECRET_KEY:\n" + SECRET_KEY + "\nN:\n" + N);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public int getKeySize(){
            return KEY_SIZE;
        }
        #endregion
    }
}
