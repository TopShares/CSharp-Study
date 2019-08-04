using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEncrypt
{
    /// <summary>
    /// 1：MD5 不可逆加密
    /// 2：Des 对称可逆加密
    /// 3：RSA 非对称可逆加密
    /// 4：数字证书 SSL 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(MD5Encrypt.Encrypt("123456小杨中交一公局第六工程有限公司"));
                Console.WriteLine(MD5Encrypt.Encrypt("123456小夏中交一公局第六工程有限公司"));
                Console.WriteLine(MD5Encrypt.Encrypt("123456小吴中交一公局第六工程有限公司"));
                Console.WriteLine(MD5Encrypt.Encrypt("123456李小中交一公局第六工程有限公司"));
                Console.WriteLine(MD5Encrypt.Encrypt("123456小李中交一公局第六工程有限公司"));
                Console.WriteLine(MD5Encrypt.Encrypt("123456小李"));
                Console.WriteLine(MD5Encrypt.Encrypt("1"));
                //不可逆
                Console.WriteLine(MD5Encrypt.Encrypt("1冉娃娃是.net高级班的一名vip学员，他是四川的小伙子，目前好像还没结婚47926363838753576475637566573654756735438547385434"));
                Console.WriteLine(MD5Encrypt.Encrypt("2冉娃娃是.net高级班的一名vip学员，他是四川的小伙子，目前好像还没结婚47926363838753576475637566573654756735438547385434"));
                Console.WriteLine(MD5Encrypt.Encrypt("3冉娃娃是.net高级班的一名vip学员，他是四川的小伙子，目前好像还没结婚47926363838753576475637566573654756735438547385434"));
                Console.WriteLine(MD5Encrypt.Encrypt("1"));
                Console.WriteLine(MD5Encrypt.Encrypt("xiaoduirensheng123455"));
                Console.WriteLine(MD5Encrypt.Encrypt("kuaileyangguang123455"));
                Console.WriteLine(MD5Encrypt.Encrypt("haha123455"));
                Console.WriteLine(MD5Encrypt.Encrypt("haha123456"));
                Console.WriteLine(MD5Encrypt.Encrypt("张三李四"));
                Console.WriteLine(MD5Encrypt.Encrypt("张三李四"));

                //可逆对称加密
                string desEn = DesEncrypt.Encrypt("王殃殃");
                string desDe = DesEncrypt.Decrypt(desEn);
                string desEn1 = DesEncrypt.Encrypt("张三李四");
                string desDe1 = DesEncrypt.Decrypt(desEn1);

                //非对称加密
                //string publicKey = "";
                //string privateKey = "";
                //string rsaEn = RsaEncrypt.Encrypt("netnetnetnetnetnetnetne", out publicKey, out privateKey);
                //string rsaDe = RsaEncrypt.Decrypt(rsaEn, privateKey);


                KeyValuePair<string, string> publicPrivate = RsaEncrypt.GetKeyPair();
                string rsaEn1 = RsaEncrypt.Encrypt("net", publicPrivate.Key);
                string rsaDe1 = RsaEncrypt.Decrypt(rsaEn1, publicPrivate.Value);
                //加密key  解密key
                //公开加密key，接受加密消息,因为只有我一个人能解密
                //公开解密key，用于签名，表明数据一定是我发的，因为只有我有加密的key
                //公钥私钥只是跟公开与否有关
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
