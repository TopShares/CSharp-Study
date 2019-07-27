using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptAnDecrypt_xiketang.com
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 【1】DES可逆对称加密

            //特点：加密速度较快，不足：秘钥管理安全性有待思考（可以采用秘钥分离保存，和二次加密）
            //秘钥长度规定为8位

            string encryptResult1 = BasedDESEncrypt.ExecuteEncrypt(".NET高级开发");
            string decryptResult1 = BasedDESEncrypt.ExecuteDecrypt(encryptResult1);


            #endregion

            #region 【2】RSA可逆非对称加密

       
            KeyValuePair<string, string> keyValuePair = BasedRSAEncrypt.CreateKeyValuePair();//加密和解密秘钥对有系统格根据算法生成
            string encryptResult2 = BasedRSAEncrypt.ExecuteEncrypt(".NET高级开发", keyValuePair.Key);      
            string decryptResult2 = BasedRSAEncrypt.ExecuteDecrypt(encryptResult2, keyValuePair.Value); 
                                                                                                     


            #endregion

            #region 【3】实现MD5加密和基于MD5生成文件摘要

            string result1 = BasedMD5Encrypt.ExcuteEncrypt("jack");
            string result2 = BasedMD5Encrypt.ExcuteEncrypt("jack");
            string result3 = BasedMD5Encrypt.ExcuteEncrypt("Tom");

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine("----------------------------------------\r\n");
            Console.WriteLine(result3);
            Console.WriteLine("----------------------------------------\r\n");

            string fileAbstract1 = BasedMD5Encrypt.CreateFileAbstract("VIP课程【学习标准指导书】1.docx");
            string fileAbstract2 = BasedMD5Encrypt.CreateFileAbstract("VIP课程【学习标准指导书】2.docx");

            Console.WriteLine("-----------------文件摘要---------------\r\n");
            Console.WriteLine(fileAbstract1);
            Console.WriteLine(fileAbstract2);

            Console.Read();

            #endregion
        }


    }
}
