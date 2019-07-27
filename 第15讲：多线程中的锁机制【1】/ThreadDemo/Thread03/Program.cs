using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Thread03
{
    class Program
    {
        static void Main(string[] args)
        {
            var myslot = Thread.AllocateNamedDataSlot("myname");
            //var myslot = Thread.AllocateDataSlot();//分配未命名的槽位

            //主线程上设置槽位， 也就是mainData只能被主线程读取，其他线程无法读取
            Thread.SetData(myslot, "mainData");

            var thread = new Thread(() =>
            {
                var data1 = Thread.GetData(myslot);//工作线程不能获取数据
                Console.WriteLine("当前工作线程:{0}", data1);
            });

            thread.Start();

            //主线程能获得数据
            var data2 = Thread.GetData(myslot);
            Console.WriteLine("主线程数据:{0}", data2);
            Console.Read();
        }

        //static void Main(string[] args)
        //{
        //    var myslot = Thread.AllocateNamedDataSlot("myname");
        //    //var myslot = Thread.AllocateDataSlot();//分配未命名的槽位，和命名的是一样的结果
        //    // Thread.FreeNamedDataSlot("myname");//释放槽位

        //    var thread = new Thread(() =>
        //    {
        //        //在工作线程中添加数据（把上面的赋值注释掉，然后开启这个)
        //        Thread.SetData(myslot, "threadData");
        //        var data1 = Thread.GetData(myslot);//工作线程能获取数据
        //        Console.WriteLine("当前工作线程:{0}", data1);
        //    });

        //    thread.Start();
        //    //主线程不能能获得数据
        //    var data2 = Thread.GetData(myslot);
        //    Console.WriteLine("主线程数据:{0}", data2);
        //    Console.Read();
        //}

        //[ThreadStatic]
        //static string info = string.Empty;

        //static void Main(string[] args)
        //{
        //    info = "我们正在研究多线程！";//观察在主线程上赋值会如何

        //    var childThread = new Thread(() =>
        //    {
        //        Console.WriteLine("当前工作线程:{0}", info);//子线程获取不到主线程的数据，说明多线程没有共享数据
        //    });

        //    childThread.Start();

        //    Console.WriteLine("主线程:{0}", info);

        //    Console.Read();
        //}


        //static void Main(string[] args)
        //{
        //    ThreadLocal<string> local = new ThreadLocal<string>();

        //    local.Value = "我们正在研究多线程！";

        //    var childThread = new Thread(() =>
        //    {
        //        Console.WriteLine("当前工作线程:{0}", local.Value);  //和上面的效果是一样的
        //    });

        //    childThread.Start();

        //    Console.WriteLine("主线程:{0}", local.Value);

        //    Console.Read();
        //}
    }
}
