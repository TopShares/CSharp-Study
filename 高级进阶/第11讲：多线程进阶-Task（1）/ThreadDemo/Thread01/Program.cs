using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Thread01
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("线程占用资源的情况分析...");
            }));

            thread.Start();
            thread.IsBackground = true;

            Console.Read();
        }
    }
}
