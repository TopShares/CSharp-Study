using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyEncrypt
{
    /// <summary>
    /// RSA ECC
    /// 可逆非对称加密 
    /// 非对称加密算法的优点是密钥管理很方便，缺点是速度慢。
    /// </summary>
    public class RsaEncrypt
    {

        /// <summary>
        /// publicKey,privateKey
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<string, string> GetKeyPair()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            string publicKey = RSA.ToXmlString(false);
            string privateKey = RSA.ToXmlString(true);
            return new KeyValuePair<string, string>(publicKey, privateKey);
        }

        /// <summary>
        /// 加密：内容+公钥
        /// </summary>
        /// <param name="content"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static string Encrypt(string content, string publicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] DataToEncrypt = ByteConverter.GetBytes(content);
            byte[] resultBytes = rsa.Encrypt(DataToEncrypt, false);
            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="publicKey">返还公钥</param>
        /// <param name="privateKey">返回密钥</param>
        /// <returns>加密后结果</returns>
        public static string Encrypt(string content, out string publicKey, out string privateKey)
        {
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            publicKey = rsaProvider.ToXmlString(false);
            privateKey = rsaProvider.ToXmlString(true);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] DataToEncrypt = ByteConverter.GetBytes(content);
            byte[] resultBytes = rsaProvider.Encrypt(DataToEncrypt, false);
            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// 解密  内容+私钥
        /// </summary>
        /// <param name="content"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string Decrypt(string content, string privateKey)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(content);
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(privateKey);
            byte[] resultBytes = RSA.Decrypt(dataToDecrypt, false);
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            return ByteConverter.GetString(resultBytes);
        }
    }
}
