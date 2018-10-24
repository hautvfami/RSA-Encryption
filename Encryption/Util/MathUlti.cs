using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Util
{
    public class MathUlti
    {
        #region test
        RSACryptoServiceProvider a = new RSACryptoServiceProvider();
        private void test()
        {
        }
        #endregion


        private static Random random = new Random();
        #region Extends Aglogrith
        public static BigInteger fastExponent(BigInteger baseN, BigInteger index, BigInteger modulo)
        {
            BigInteger result = new BigInteger(1);

            while (index > 0)
            {
                // multiply in this bit's contribution while using modulus to keep result small
                if ((index & 1) == 1) result = BigInteger.Remainder(BigInteger.Multiply(result, baseN), modulo);
                // move to the next bit of the exponent, square (and mod) the base accordingly
                index >>= 1;
                baseN = BigInteger.Remainder(BigInteger.Multiply(baseN, baseN), modulo);
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
            Console.WriteLine("PRIME_SIZE = " + size + "|Loop in " + i + " round|" + "isPrime bi: " + bi);
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
        public static BigInteger getPublicKey(int size, BigInteger n)
        {
            BigInteger rd;
            byte[] byteArray = new byte[size / 8];
            BitArray bits;

            do
            {
                random.NextBytes(byteArray);
                bits = new BitArray(byteArray);
                bits.Set(size - 1, false);      // sign bit
                bits.CopyTo(byteArray, 0);
                rd = new BigInteger(byteArray);
            } while (BigInteger.GreatestCommonDivisor(rd, n) != 1);

            return rd;
        }
        private static BigInteger getRandomNumber(int size)
        {
            BitArray bits;
            byte[] byteArray = new byte[size / 8];
            random.NextBytes(byteArray);

            bits = new BitArray(byteArray);
            bits.Set(0, true);              // parity bit
            bits.Set(size - 2, true);       // greatest bit
            bits.Set(size - 1, false);      // sign bit
            bits.CopyTo(byteArray, 0);

            return new BigInteger(byteArray);
        }
        #endregion

        public static void swapBigInteger(ref BigInteger a, ref BigInteger b)
        {
            BigInteger c;
            c = a; a = b; b = c;
        }
    }
}
