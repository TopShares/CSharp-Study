using ClassLibrary2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Class1
{
    static void Main(string[] args)
    {
        var path = @"H:\test\1\mydirectory";

        var newpath = @"H:\test\2\mydirectory";

        //第一步：在1下面创建一个叫做“mydirectory”的文件夹。
        //var dirc = Directory.CreateDirectory(path);
        var directory = new DirectoryInfo(path);

        Console.WriteLine("文件创建成功，等待10s 移动文件夹");

        Thread.Sleep(10000);

        //第二步：判断1下面的文件夹是否存在，如果存在，将其移动到2这个文件夹下面。。

        //var isExists = Directory.Exists(path);
        var isExists = directory.Exists;

        Console.WriteLine("文件夹是否存在:{0}", isExists);

        if (isExists)
        {
            //Directory.Move(path, newpath);
            directory.MoveTo(newpath);
        }

        Console.WriteLine("文件夹移动成功，等待10s 三处文件夹");

        Thread.Sleep(10000);

        //删除文件夹
        Directory.Delete(newpath);
    }
}