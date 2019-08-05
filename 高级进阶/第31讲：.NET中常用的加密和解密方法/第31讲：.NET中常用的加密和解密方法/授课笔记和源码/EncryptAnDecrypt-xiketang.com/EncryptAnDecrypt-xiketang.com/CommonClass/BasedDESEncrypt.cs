using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EncryptAnDecrypt_xiketang.com
{
  
    public class BasedDESEncrypt
    {    
        private static string key = "xiketang.ke.qq.com";//这个可以采取动态获取的方式。
        //可以通过用户输入、特殊文件的保存，或者数据库读取等...

        /// <summary> 
        /// DES加密 
        /// </summary> 
        /// <param name="content">需要加密的字符串内容</param> 
        /// <returns></returns> 
        public static string ExecuteEncrypt(string content)
        {
            StringBuilder returnString = new StringBuilder();

            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(content);
            DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();

            dsp.Mode = CipherMode.ECB;  
            dsp.Padding = PaddingMode.Zeros;

            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dsp.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();

            //组织成16进制字符串            
            foreach (byte b in mStream.ToArray())
            {
                returnString.AppendFormat("{0:X2}", b);
            }
            return returnString.ToString();
        }

        /// <summary> 
        /// DES解密 
        /// </summary> 
        /// <param name="content">需要解密的字符串内容</param> 
        /// <returns></returns>         
        public static string ExecuteDecrypt(string content)
        {

            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIV = keyBytes;

            byte[] inputByteArray = new byte[content.Length / 2];
            for (int x = 0; x < content.Length / 2; x++)
            {
                int i = (Convert.ToInt32(content.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
            dsp.Mode = CipherMode.ECB;
            dsp.Padding = PaddingMode.Zeros;
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dsp.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
        
            return Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd('\0');
        }
    }
}
