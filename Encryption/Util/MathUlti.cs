using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Util
{
    public class MathUlti
    {
        private static Random random = new Random();

        #region Extends Aglogrith
        public static BigInteger fastExponent2(BigInteger a, BigInteger b, BigInteger c)
        {
            return BigInteger.ModPow(a, b, c);
        }

        public static BigInteger fastExponent(BigInteger baseN, BigInteger index, BigInteger modulo)
        {
            BigInteger result = 1;

            while (index > 0)
            {
                if ((index & 1) == 1)
                {
                    // multiply in this bit's contribution while using modulus to keep result small
                    result = (result * baseN) % modulo;
                }
                // move to the next bit of the exponent, square (and mod) the base accordingly
                index >>= 1;
                baseN = (baseN * baseN) % modulo;
            }
            return result;
        }

        public static BigInteger moduloInverse(BigInteger a, BigInteger n)
        {
            BigInteger temp = n, y = 0, r, q, y0 = 0, y1 = 1;

            while (a > 0)
            {
                r = n % a;
                if (r == 0) break;
                q = n / a;
                y = y0 - y1 * q;
                y0 = y1; y1 = y;
                n = a; a = r;
            }

            if (a > 1) return -1;
            if (y < 0) y += temp;
            return y;
        }
        #endregion


        #region Prime Number
        public static BigInteger generatePrime(int size) // size%8==0
        {
            BigInteger bi, i = 0;

            do
            {
                bi = getRandomNumber(size);
                i++;
            } while (!isPrime(bi, 10));
            Console.WriteLine("KEY_SIZE = " + size + "|Loop in " + i + " round|" + "isPrime bi: " + bi);
            GC.Collect();

            return bi;
        }

        public static bool isPrime(BigInteger n, int k)
        {
            BigInteger d = n - 1, s = 0;

            while (true)
            {
                if (d % 2 != 0) break;
                d /= 2; s++;
            }

            for (int i = 0; i <= k; i++)
                if (!millerTest(n, d, s)) return false;

            return true;
        }

        private static bool millerTest(BigInteger n, BigInteger d, BigInteger s)
        {
            Random random = new Random();
            int sizeInt = 65000;    // Max random value
            if (n - 2 < sizeInt) sizeInt = (int)n;
            BigInteger a = (BigInteger)random.Next(2, sizeInt);

            BigInteger x = fastExponent(a, d, n);
            if (x == 1 || x == n - 1) return true;

            for (BigInteger i = 1; i < s; i++)
            {
                x = (x * x) % n;
                if (x == 1) return false;
                if (x == (n - 1)) return true;
            }
            return false;
        }
        #endregion


        #region Random Number
        private static BigInteger getRandomNumber(int size)
        {
            BigInteger randNum;
            BitArray bits;
            byte[] byteArray = new byte[size / 8];
            random.NextBytes(byteArray);

            bits = new BitArray(byteArray);
            bits.Set(0, true);              // bit chan le
            bits.Set(size - 1, true);       // bit lon nhat
            bits.CopyTo(byteArray, 0);

            // size/8 + 1 bytes BigInteger
            randNum = new BigInteger(addLastZeroByte(byteArray));
            return randNum;
        }

        public static byte[] addLastZeroByte(byte[] byteArray)
        {
            byteArray = byteArray.Concat(new byte[] { 0 }).ToArray();
            return byteArray;
        }
        #endregion
    }
}
