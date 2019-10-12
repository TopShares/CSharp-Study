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
        var path = @"H:\test\1\mytest.txt";

        var newpath = @"H:\test\2\mytest.txt";

        string[] arr = { "你好", "hello world" };

        //File.WriteAllText(path, "你好，我是来测试的");
        //File.WriteAllLines(path, arr);

        //var myarr = File.ReadAllLines(path);
        var str = File.ReadAllText(path);

        ////第一步：创建文件  【拿到的一个文件句柄】
        ////FileStream fs = File.Create(path);
        //FileInfo info = new FileInfo(path);

        //var fs = info.Create();

        //fs.Close();

        //Console.WriteLine("文件创建成功，等待10s 移动文件");

        //Thread.Sleep(10000);

        ////第二步：判断文件是否存在
        ////var isExists = File.Exists(path);


        ////第三步：如果文件存在，我们就移动到 ”2“这个文件夹下面
        //if (info.Exists)
        //{
        //    //File.Move(path, newpath);
        //    info.MoveTo(newpath);
        //}

        //Console.WriteLine("文件夹移动成功，等待10s 删除文件");

        //Thread.Sleep(10000);

        ////第四步：移动成功，我们开始删除
        //File.Delete(newpath);

    }
}