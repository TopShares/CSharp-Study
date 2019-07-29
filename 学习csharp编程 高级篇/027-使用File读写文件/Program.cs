using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _027_使用File读写文件 {
    class Program {
        static void Main(string[] args)
        {
            //string[] strArray = File.ReadAllLines("TextFile1.txt");//读取文件，把每一个行文本读取成一个字符串，最后组成一个字符串的数组
            //foreach (var s in strArray)
            //{
            //    Console.WriteLine(s);
            //}
            //string s = File.ReadAllText("TextFile1.txt");
            //Console.WriteLine(s);

            //byte[] byteArray = File.ReadAllBytes("3.LINQ.png");
            //foreach (var b in byteArray)
            //{
            //    Console.Write(b);
            //}


            //File.WriteAllText("textfile2.txt", "hello sdf中国");
            //File.WriteAllLines("textfile3.txt",new string[]{" sdfsdflk","213412","流口水的减肥"});

            byte[] data = File.ReadAllBytes("3.LINQ.png");
            File.WriteAllBytes("4.png",data);


            Console.ReadKey();
        }
    }
}
