using IOSerialize.IO;
using IOSerialize.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace IOSerialize
{
    /// <summary>
    /// 1 文件夹/文件 检查、新增、复制、移动、删除，
    /// 2 文件读写，记录文本日志/读取配置文件
    /// 3 try catch的正确姿势(链接：http://pan.baidu.com/s/1kVNorpd 密码：pyhv)
    /// 4 递归的编程技巧
    /// 5 三种序列化器
    /// 6 xml和json
    /// 7 验证码、图片缩放
    /// 8 作业部署
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.Net高级班vip课程，今天是Eleven老师为大家带来的IO和序列化");
                //MyIO.Show();

                //List<DirectoryInfo> dicList = Recursion.GetAllDirectory(@"D:\ruanmou\online8\homework\1");

                SerializeHelper.BinarySerialize();
                SerializeHelper.SoapSerialize();
                SerializeHelper.XmlSerialize();

                List<Programmer> list = DataFactory.BuildProgrammerList();
                {
                    string xmlResult = XmlHelper.ToXml<List<Programmer>>(list);
                    List<Programmer> list1 = XmlHelper.ToObject<List<Programmer>>(xmlResult);
                    List<Programmer> list2 = XmlHelper.FileToObject<List<Programmer>>("");
                }

                SerializeHelper.Json();

               
                {
                    string jResult = JsonHelper.ObjectToString<List<Programmer>>(list);
                    List<Programmer> list1 = JsonHelper.StringToObject<List<Programmer>>(jResult);
                }
                {
                    string jResult = JsonHelper.ToJson<List<Programmer>>(list);
                    List<Programmer> list1 = JsonHelper.ToObject<List<Programmer>>(jResult);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
