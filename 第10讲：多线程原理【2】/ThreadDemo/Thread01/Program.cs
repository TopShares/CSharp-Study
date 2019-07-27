using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Thread01
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(new ThreadStart(() =>
        //     {
        //         Console.WriteLine("线程占用资源的情况分析...");
        //     }));

        //    thread.Start();
        //    thread.IsBackground = true;

        //    Console.Read();
        //}
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("这个是正在执行的子线程数据......");
            }));

            thread.Start();

            thread.Join();//会等待子线程执行完毕后，在执行下面的主线程内容。

            Console.WriteLine("这个是主线程的数据...");

            Console.Read();

        }

    }
}
