using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Thread05
{
    class Program
    {

        #region ThreadPool 线程池

        //观察线程ID
        static void Main(string[] args)
        {
            //public static bool QueueUserWorkItem(WaitCallback callBack)
            ThreadPool.QueueUserWorkItem((arg) =>
            {
                Console.WriteLine("工作线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);

            Console.Read();
        }

        //static void Main(string[] args)
        //{
        //    //public static bool QueueUserWorkItem(WaitCallback callBack, object state);
        //    // public delegate void WaitCallback(object state);//Action适合

        //    //ThreadPool.QueueUserWorkItem((arg) =>
        //    //{
        //    //    Console.WriteLine("工作线程ID：{0}, 喜科堂网址={1}",
        //    //        Thread.CurrentThread.ManagedThreadId, arg);

        //    //}, "xiketang.ke.qq.com");//state参数是object类型

        //    //还可以用下面的方法
        //    ThreadPool.QueueUserWorkItem((arg) =>
        //        {
        //            Func<string> myFunc = arg as Func<string>;//【2】把传递的参数，转换成Func委托变量

        //            Console.WriteLine("工作线程ID：{0}, 喜科堂网址={1}",
        //                Thread.CurrentThread.ManagedThreadId, myFunc());//【3】通过MyFunc()方法调用
        //        }, new Func<string>(() => "xiketang.ke.qq.com"));//【1】将state参数用Func委托传递
        //                                                         //new Func<string>(() => "xiketang.ke.qq.com")可以作为回调使用


        //    Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);

        //    Console.Read();
        //}

        #endregion

        #region ThreadPool和Thread比较

        //static void Main(string[] args)
        //{
        //    //开启10个线程
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Thread thread = new Thread(() =>
        //        {
        //            for (int a = 0; a < 5; a++)
        //            {
        //                Console.WriteLine("----------------------" + a);
        //                Console.WriteLine("工作任务：{0}\t线程ID={1}", i, Thread.CurrentThread.ManagedThreadId);
        //            }
        //        });

        //        thread.Name = "线程名称：" + i;//为了后面观察
        //        thread.IsBackground = true;
        //        thread.Start();
        //    }

        //    Console.Read();
        //}

        //使用线程池
        //static void Main(string[] args)
        //{
        //    //开启10个线程
        //    for (int i = 0; i < 10; i++)
        //    {              
        //        ThreadPool.QueueUserWorkItem((arg) =>
        //        {
        //            for (int a = 0; a < 5; a++)
        //            {
        //                Console.WriteLine("----------------------" + a);
        //                Console.WriteLine("工作任务：{0}\t线程ID={1}", i, Thread.CurrentThread.ManagedThreadId);
        //            }
        //        });   
        //        //线程池不能给名字，因为我们使用的是系统的线程          
        //    }

        //    Console.Read();
        //}

        #endregion

    }
}
