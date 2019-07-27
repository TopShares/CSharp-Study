using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace Thread03
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var myslot = Thread.AllocateNamedDataSlot("myname");

        //    //在主线程上设置一个槽位，也就是mainData只能被主线程读取，其他线程读取不到
        //    Thread.SetData(myslot, "mainData");

        //    var thread = new Thread(() =>
        //      {
        //          var data1 = Thread.GetData(myslot);//子线程应该是获取不到的
        //          Console.WriteLine("当前工作子线程：{0}",data1);
        //      });

        //    thread.Start();

        //    //在主线程上获取的数据
        //    var data2 = Thread.GetData(myslot);
        //    Console.WriteLine("当前主线程：{0}", data2);

        //    Console.Read();
        //}

        //static void Main(string[] args)
        //{
        //    var myslot = Thread.AllocateNamedDataSlot("myname");

        //    var thread = new Thread(() =>
        //    {
        //        Thread.SetData(myslot, "threadData");
        //        var data1 = Thread.GetData(myslot);
        //        Console.WriteLine("当前工作子线程：{0}", data1);
        //    });

        //    thread.Start();         
        //    var data2 = Thread.GetData(myslot);   //在主线程上获取不到数据
        //    Console.WriteLine("当前主线程：{0}", data2);

        //    Console.Read();
        //}


        //[ThreadStatic]
        //static string info = string.Empty;

        //static void Main(string[] args)
        //{
        //    info = "我们正在研究多线程！";
        //    var childThread = new Thread(() =>
        //     {
        //         Console.WriteLine("当前工作子线程：{0}", info);//子线程不会获取到主线程的数据，说明多线程没有共享数据
        //     });
        //    childThread.Start();

        //    Console.WriteLine("当前主线程：{0}", info);
        //    Console.Read();
        //}

        static void Main(string[] args)
        {
            ThreadLocal<string> local = new ThreadLocal<string>();
            local.Value= "我们正在研究多线程！";

            var childThread = new Thread(() =>
             {
                 Console.WriteLine("当前工作子线程：{0}", local.Value);//效果和上面是一样的
                 });
            childThread.Start();

            Console.WriteLine("当前主线程：{0}", local.Value);
            Console.Read();
        }


    }
}
