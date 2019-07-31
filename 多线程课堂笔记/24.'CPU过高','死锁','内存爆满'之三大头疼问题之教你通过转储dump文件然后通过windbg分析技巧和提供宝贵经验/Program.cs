using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication51
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            //Run();
            //new Program().Run();

            for (int i = 0; i < 10000000; i++)
            {
                sb.Append("hello world");
            }
            Console.WriteLine("执行完毕！");

            Console.Read();
        }

        //static void Run()
        //{
        //    var task = Task.Factory.StartNew(() =>
        //    {
        //        var i = true;
        //        //这个地方是一个非常复杂的逻辑。导致死循环
        //        while (true)
        //        {
        //            i = !i;
        //        }
        //    });
        //}

        //void Run()
        //{
        //    lock (this)
        //    {
        //        var task = Task.Run(() =>
        //        {
        //            Console.WriteLine("----- start ---- ");
        //            Thread.Sleep(1000);

        //            Run2();

        //            Console.WriteLine("------ end  -----");
        //        });

        //        task.Wait();
        //    }
        //}

        //void Run2()
        //{
        //    lock (this)
        //    {
        //        Console.WriteLine("我是 run2.。。。。");
        //    }
        //}
    }
}
