using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptAnDecrypt_xiketang.com
{
    class BasedMD5Encrypt
    {
        #region 基于的MD5的加密方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ExcuteEncrypt(string content, int length = 32)//默认参数
        {
            if (string.IsNullOrEmpty(content)) return string.Empty;
            HashAlgorithm hashAlgorithm = CryptoConfig.CreateFromName("MD5") as HashAlgorithm;
            byte[] bytes = Encoding.UTF8.GetBytes(content);   //这里需要区别编码的
            byte[] hashValue = hashAlgorithm.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            if (length == 16)//16位密文是32位密文的9到24位字符
            {
                for (int i = 4; i < 12; i++)
                {
                    builder.Append(hashValue[i].ToString("x2"));
                }
            }
            else if (length == 32)
            {
                for (int i = 0; i < 16; i++)
                {
                    builder.Append(hashValue[i].ToString("x2"));
                }
            }
            else
            {
                for (int i = 0; i < hashValue.Length; i++)
                {
                    builder.Append(hashValue[i].ToString("x2"));
                }
            }
            return builder.ToString();
        }
        #endregion MD5

        #region 基于MD5对文件内容进行摘要

        /// <summary>
        /// 获取文件的MD5摘要
        /// </summary>
        /// <param name="fileName">完整的文件路径</param>
        /// <returns></returns>
        public static string CreateFileAbstract(string fileName)
        {
            StringBuilder returnString = new StringBuilder();
            FileStream fs = new FileStream(fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(fs);
            for (int i = 0; i < bytes.Length; i++)
            {
                returnString.Append(bytes[i].ToString("x2"));
            }
            fs.Close();

            return returnString.ToString();
        }
        #endregion
    }
}
