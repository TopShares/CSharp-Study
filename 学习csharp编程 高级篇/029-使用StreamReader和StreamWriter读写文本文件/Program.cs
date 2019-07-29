using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_使用StreamReader和StreamWriter读写文本文件 {
    class Program {
        static void Main(string[] args) {
            //创建文本文件读取流
            //StreamReader reader = new StreamReader("TextFile1.txt");

            //while (true)
            //{
            //    string str = reader.ReadLine();//读取一行字符串
            //    if (str == null) break;
            //    Console.WriteLine(str);
            //}
            //string str = reader.ReadToEnd();//读取到文本的结尾（读取文本中所有的字符）
            //Console.WriteLine(str);

            //while (true)
            //{
            //    int res = reader.Read();//读取
            //    if (res == -1)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.Write((char)res);
            //    }
                
            //}


            //reader.Close();

            //文本文件写入流
            StreamWriter writer = new StreamWriter("textfile2.txt");//如果文件存在，那么文件会被覆盖
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "q")
                    break;
                //writer.Write(message);//写入一个字符串
                writer.WriteLine(message);//吸入一个字符串并换行
            }
            writer.Close();
            //Console.ReadKey();
        }
    }
}
