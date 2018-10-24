using Encryption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.PKCS1
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc8017
    /// </summary>
    interface IPKCS1
    {
        /// <summary>
        /// I2OSP converts a nonnegative integer to an octet string of a specified length.
        /// I2OSP (x, xLen)
        /// </summary>
        /// <param name="x">nonnegative integer to be converted</param>
        /// <param name="xLen">intended length of the resulting octet string</param>
        /// <returns>X corresponding octet string of length xLen</returns>
        byte[] I2OSP(BigInteger x, int xLen);

        /// <summary>
        /// OS2IP converts an octet string to a nonnegative integer.
        /// OS2IP (X)
        /// </summary>
        /// <param name="X">X octet string to be converted</param>
        /// <returns>x corresponding nonnegative integer</returns>
        BigInteger OS2IP(byte[] X);

        /// <summary>
        /// RSAEP ((n, e), m)
        /// </summary>
        /// <param name="ne">(n, e) RSA public key</param>
        /// <param name="m">m message representative, an integer between 0 and n - 1</param>
        /// <returns>c ciphertext representative, an integer between 0 and n - 1</returns>
        BigInteger RSAEP(RSAPublicKey ne, BigInteger m);

        /// <summary>
        /// RSADP (K, c)
        /// </summary>
        /// <param name="K">K RSA private key, where K has one of the following forms: a quintuple (p, q, dP, dQ, qInv) and a possibly empty sequence of triplets (r_i, d_i, t_i), i = 3, ..., u</param>
        /// <param name="c">c ciphertext representative, an integer between 0 and n - 1</param>
        /// <returns>m message representative, an integer between 0 and n - 1</returns>
        BigInteger RSADP(RSAPrivateKey K, BigInteger c);

        /// <summary>
        /// RSASP1 (K, m)
        /// </summary>
        /// <param name="K">RSA private key, where K has one of the following forms: a quintuple (p, q, dP, dQ, qInv) and a (possibly empty) sequence of triplets (r_i, d_i, t_i), i = 3, ..., u</param>
        /// <param name="m"> message representative, an integer between 0 and n - 1</param>
        /// <returns>signature representative, an integer between 0 and n - 1</returns>
        BigInteger RSASP1(RSAPrivateKey K, BigInteger m);

        /// <summary>
        /// RSAVP1 ((n, e), s)
        /// </summary>
        /// <param name="ne">(n, e) RSA public key</param>
        /// <param name="s">s signature representative, an integer between 0 and n - 1</param>
        /// <returns>m message representative, an integer between 0 and n - 1</returns>
        BigInteger RSAVP1(RSAPublicKey ne, BigInteger s);

        /// <summary>
        ///  RSAES-OAEP-ENCRYPT ((n, e), M, L)
        /// </summary>
        /// <param name="ne">(n, e)   recipient's RSA public key (k denotes the length in octets of the RSA modulus n)</param>
        /// <param name="M">message to be encrypted, an octet string of length mLen, where mLen <= k - 2hLen - 2</param>
        /// <param name="L">optional label to be associated with the message; the default value for L, if L is not provided, is the empty string</param>
        /// <returns> C        ciphertext, an octet string of length k</returns>
        byte[] RSAES_OAEP_ENCRYPT(RSAPublicKey ne, byte[] M, string L);

        byte[] RSAES_OAEP_DECRYPT(RSAPrivateKey K, byte[] C, string L);
        byte[] RSAES_PKCS1_V1_5_ENCRYPT(RSAPublicKey ne, byte[] M);
        byte[] RSAES_PKCS1_V1_5_DECRYPT(RSAPrivateKey K, byte[] M);
        byte[] RSASSA_PSS_SIGN(RSAPrivateKey K, byte[] M);
        string RSASSA_PSS_VERIFY(RSAPublicKey ne, byte[] M, byte[] S);
        byte[] RSASSA_PKCS1_V1_5_SIGN(RSAPrivateKey K, byte[] M);
        byte[] RSASSA_PKCS1_V1_5_VERIFY(RSAPublicKey ne, byte[] M, byte[] S);
        byte[] EMSA_PSS_ENCODE(byte[] M, int emBits);
        string EMSA_PSS_VERIFY(byte[] M, byte[] EM, int emBits);
        byte[] EMSA_PKCS1_V1_5_ENCODE(byte[] M, int emLen);
        byte[] MGF1(byte[] mgfSeed, int maskLen);
    }
}
