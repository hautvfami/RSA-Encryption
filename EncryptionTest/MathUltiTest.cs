using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Encryption.Util;
using Encryption.Interfaces;
using System.Numerics;

namespace EncryptionTest
{
    [TestClass]
    public class MathUltiTest
    {
        BigInteger[] input = new BigInteger[]{
                68549684304454985, 495454321143423555, 2323543443548435,
                92832385745345534, 456464645645626266, 7868527174574464,
                87687973357342461, 776979626346546546, 1536554654546453,
                66282555755232012, 094914532565543534, 1234576365463536};
        BigInteger a, b;


        [TestMethod]
        public void testFastExponent()
        {
            for (int i = 0; i < input.Length / 3; i += 3)
            {
                a = MathUlti.fastExponent(input[i], input[i + 1], input[i + 2]);
                b = BigInteger.ModPow(input[i], input[i + 1], input[i + 2]);
                Assert.AreEqual(a, b, "fastExponent wrong");
            }
        }

        [TestMethod]
        public void testModuloInverse()
        {
            for (int i = 0; i < input.Length / 2; i += 2)
            {
                //a = MathUlti.moduloInverse(input[i], input[i+1]);
                //b = BigInteger.(input[i],input[i+1] - 2, input[i + 1]);
                //Assert.AreEqual(a, b, "fastExponent wrong");
            }
        }

        [TestMethod]
        public void testIsPrime()
        {
            Assert.AreEqual(MathUlti.isPrime(17, 10), true, "isPrime wrong");
            Assert.AreEqual(MathUlti.isPrime(23, 10), true, "isPrime wrong");
            Assert.AreEqual(MathUlti.isPrime(45, 10), false, "isPrime wrong");
            Assert.AreEqual(MathUlti.isPrime(53, 10), true, "isPrime wrong");
            Assert.AreEqual(MathUlti.isPrime(71, 10), true, "isPrime wrong");
        }

        [TestMethod]
        public void testRSA()
        {
        }
    }
}
