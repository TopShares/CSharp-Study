using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static CountdownEvent cdeLock = new CountdownEvent(10);

        static void Main(string[] args)
        {
            //加载Orders搞定
            cdeLock.Reset(10);

            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    LoadOrders();
                });
            }

            cdeLock.Wait();

            Console.WriteLine("所有的Orders都加载完毕。。。。。。。。。。。。。。。。。。。。。");

            //加载Product搞定
            cdeLock.Reset(5);

            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    LoadProducts();
                });
            }

            cdeLock.Wait();

            Console.WriteLine("所有的Products都加载完毕。。。。。。。。。。。。。。。。。。。。。");

            //加载Users搞定
            cdeLock.Reset(2);

            for (int i = 0; i < 2; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    LoadUsers();
                });
            }

            cdeLock.Wait();

            Console.WriteLine("所有的Users都加载完毕。。。。。。。。。。。。。。。。。。。。。");

            Console.WriteLine("所有的表数据都执行结束了。。。恭喜恭喜。。。。");

            Console.Read();
        }

        /// <summary>
        /// 10 threads
        /// </summary>
        static void LoadOrders()
        {
            //具体的业务逻辑，不细说
            Console.WriteLine("当前Orders正在加载中。。。{0}", Thread.CurrentThread.ManagedThreadId);

            cdeLock.Signal();
        }

        /// <summary>
        /// 5 threads
        /// </summary>
        static void LoadProducts()
        {
            //具体的业务逻辑，不细说
            Console.WriteLine("当前Products正在加载中。。。{0}", Thread.CurrentThread.ManagedThreadId);

            cdeLock.Signal();
        }

        /// <summary>
        /// 2 threads
        /// </summary>
        static void LoadUsers()
        {
            //具体的业务逻辑，不细说
            Console.WriteLine("当前Users正在加载中。。。{0}", Thread.CurrentThread.ManagedThreadId);

            cdeLock.Signal();
        }
    }
}
