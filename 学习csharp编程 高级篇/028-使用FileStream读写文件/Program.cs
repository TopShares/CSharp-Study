using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _028_使用FileStream读写文件 {
    class Program {
        static void Main(string[] args) {
            //1，创建文件流 用来操作文件
            //FileStream stream = new FileStream("TextFile1.txt",FileMode.Open);

            ////2, 读取或者写入数据
            //byte[] data = new byte[1024];//数据容器
            ////1 byte = 1字节  1024byte=1KB 1024KB=1MB 1024MB = 1GB 1024GB=1T
            //while (true)
            //{
            //    int length = stream.Read(data, 0, data.Length);
            //    if (length == 0)
            //    {
            //        Console.WriteLine("读取结束");
            //        break;
            //    }
            //    for (int i = 0; i < length; i++) {
            //        Console.Write(data[i] + " ");
            //    }
            //}

            //使用filestream完成文件复制
            // 1.5MB = 1.5*1024KB = 2k多KB= 2k多*1000 byte
            FileStream readStream = new FileStream("3.LINQ.png",FileMode.Open);

            FileStream writeStream = new FileStream("LINQ副本.png",FileMode.Create);

            byte[] data = new byte[1024];

            while (true)
            {
                int length = readStream.Read(data, 0, data.Length);
                if (length == 0)
                {
                    Console.WriteLine("读取结束");
                    break;
                }
                else
                {
                    writeStream.Write(data,0,length);   
                }
            }

            writeStream.Close();
            readStream.Close();

            
            Console.ReadKey();
        }
    }
}
