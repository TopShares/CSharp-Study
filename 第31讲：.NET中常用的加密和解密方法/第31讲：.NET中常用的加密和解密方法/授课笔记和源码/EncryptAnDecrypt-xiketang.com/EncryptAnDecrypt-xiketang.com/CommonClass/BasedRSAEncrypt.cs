using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptAnDecrypt_xiketang.com
{
 
    public class BasedRSAEncrypt
    {
        /// <summary>
        /// 生成秘钥对
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<string, string> CreateKeyValuePair()
        {
            RSACryptoServiceProvider reaProvider = new RSACryptoServiceProvider();
            string publicKey = reaProvider.ToXmlString(false);//公开的秘钥
            string privateKey = reaProvider.ToXmlString(true);//私有的秘钥
            return new KeyValuePair<string, string>(publicKey, privateKey);
        }

        /// <summary>
        /// 基于RSA算法执行加密
        /// </summary>
        /// <param name="content">需要加密的内容</param>
        /// <param name="encryptKey">加密秘钥</param>
        /// <returns></returns>
        public static string ExecuteEncrypt(string content, string encryptKey)
        {
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            rsaProvider.FromXmlString(encryptKey);
            UnicodeEncoding encoding = new UnicodeEncoding();    
            byte[] resultBytes = rsaProvider.Encrypt(encoding.GetBytes(content), false);
            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// 基于RSA算法执行解密
        /// </summary>
        /// <param name="content">需要解密的内容</param>
        /// <param name="decryptKey">解密秘钥</param>
        /// <returns></returns>
        public static string ExecuteDecrypt(string content, string decryptKey)
        {
            byte[] btyes = Convert.FromBase64String(content);
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            rsaProvider.FromXmlString(decryptKey);
            byte[] resultBytes = rsaProvider.Decrypt(btyes, false);
            UnicodeEncoding encoding = new UnicodeEncoding();
            return encoding.GetString(resultBytes);
        }
    }
}
