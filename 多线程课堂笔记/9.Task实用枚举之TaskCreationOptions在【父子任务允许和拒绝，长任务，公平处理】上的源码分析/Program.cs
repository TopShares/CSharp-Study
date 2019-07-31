using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("task1");

            }, TaskCreationOptions.PreferFairness);

            task.Start();

            task.Wait();  //task.WaitAll(task1,task2);

            Console.WriteLine("我是主线程！！！！");

            Console.Read();
        }
    }
}


