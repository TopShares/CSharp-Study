using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_文件操作_查看文件和文件夹信息 {
    class Program {
        static void Main(string[] args) {
            //相对路径：就是找当前程序所在的路径
            //FileInfo fileInfo = new FileInfo("TextFile1.txt");

            //绝对路径：加上文件完整的路径名
            //FileInfo fileInfo = new FileInfo(@"C:\Users\devsiki\Documents\Visual Studio 2012\Projects\学习csharp编程 高级篇\026-文件操作-查看文件和文件夹信息\bin\Debug\TextFile1.txt");
            //Console.WriteLine(fileInfo.Exists);//判断该文件是否存在

            //Console.WriteLine(fileInfo.Name);//文件名.后缀

            //Console.WriteLine(fileInfo.Directory);//取得文件所在路径

            //Console.WriteLine(fileInfo.Length);

            //Console.WriteLine(fileInfo.IsReadOnly);

            ////fileInfo.Delete();//删除的是输出路径的文件，工程下的文件还是存在的

            //fileInfo.CopyTo("tt.txt");

            //FileInfo fileInfo = new FileInfo("siki.txt");
            //if (fileInfo.Exists == false)//如果当前文件不存在
            //{
            //    fileInfo.Create();//创建当前文件
            //}
            //fileInfo.MoveTo("siki2.txt");//重命名操作

            //文件夹操作(目录操作) (按照完整路径名创建)
            //DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\devsiki\Documents\Visual Studio 2012\Projects\学习csharp编程 高级篇\026-文件操作-查看文件和文件夹信息\bin\Debug");//查看Debug文件夹的信息

            //Console.WriteLine(dirInfo.Exists);
            //Console.WriteLine(dirInfo.Name);
            //Console.WriteLine(dirInfo.Parent);
            //Console.WriteLine(dirInfo.Root);
            //Console.WriteLine(dirInfo.CreationTime);
            //dirInfo.CreateSubdirectory("siki");

            //DirectoryInfo dirInfo = new DirectoryInfo("test");
            //if (dirInfo.Exists == false)
            //{
            //    dirInfo.Create();//创建目录
            //}
            

            Console.ReadKey();
        }
    }
}
