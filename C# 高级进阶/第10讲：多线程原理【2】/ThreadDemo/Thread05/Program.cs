using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace Thread05
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    ThreadPool.QueueUserWorkItem((arg) =>
        //    {
        //        Console.WriteLine("子线程ID：{0}",Thread.CurrentThread.ManagedThreadId);
        //    });

        //    Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);

        //    Console.Read();
        //}

        //static void Main(string[] args)
        //{
        //    //public static bool QueueUserWorkItem(WaitCallback callBack, object state);
        //    //ThreadPool.QueueUserWorkItem((arg) =>
        //    //{
        //    //    Console.WriteLine("子线程ID：{0}  喜科堂网址={1}", Thread.CurrentThread.ManagedThreadId,arg);
        //    //},"xiketang.ke.qq.com");

        //    ThreadPool.QueueUserWorkItem((arg) =>
        //    {
        //        Func<string> myfunc = arg as Func<string>;

        //        Console.WriteLine("子线程ID：{0}  喜科堂网址={1}", Thread.CurrentThread.ManagedThreadId, myfunc());
        //    }, new Func<string>(() => "xiketang.ke.qq.com"));


        //    Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);

        //    Console.Read();
        //}


        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Thread thread = new Thread(() =>
        //         {
        //             for (int a = 0; a < 5; a++)
        //             {
        //                 Console.WriteLine("-----------------------------");
        //                 Console.WriteLine("子线程{0}\t子线程ID：{1}", i, Thread.CurrentThread.ManagedThreadId);
        //             }
        //         });

        //        thread.Name = "线程名称：" + i;
        //        thread.IsBackground = true;
        //        thread.Start();
        //    }


        //    Console.Read();
        //}

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {       
                ThreadPool.QueueUserWorkItem((arg) =>
                {
                    for (int a = 0; a < 5; a++)
                    {
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("子线程{0}\t子线程ID：{1}", i, Thread.CurrentThread.ManagedThreadId);
                    }
                });             
            }


            Console.Read();
        }
    }
}
