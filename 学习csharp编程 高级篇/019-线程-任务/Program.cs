using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _019_线程_任务 {
    class Program {
        static void ThreadMethod() {
            Console.WriteLine("任务开始");
            Thread.Sleep(2000);
            Console.WriteLine("任务结束");
        }
        static void Main(string[] args) {
            //Task t = new Task(ThreadMethod);//传递一个需要线程去执行的方法
            //t.Start();

            //TaskFactory tf = new TaskFactory();
            //Task t = tf.StartNew(ThreadMethod);

            Console.WriteLine("Main");
            Console.ReadKey();
        }
    }
}
