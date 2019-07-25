using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();

            source.Token.Register(() =>
            {
                //如果当前的token被取消，此函数将会被执行
                Console.WriteLine("当前source已经被取消，现在可以做资源清理了。。。。");
            });

            var task = Task.Factory.StartNew(() =>
            {
                while (true)
                {

                    source.Token.ThrowIfCancellationRequested();

                    Thread.Sleep(100);

                    Console.WriteLine("当前thread={0} 正在运行", Thread.CurrentThread.ManagedThreadId);

                }
            }, source.Token);

            Thread.Sleep(1000);
            source.Cancel();

            Thread.Sleep(100);

            Console.WriteLine(task.Status);

            Console.Read();
        }
    }
}


