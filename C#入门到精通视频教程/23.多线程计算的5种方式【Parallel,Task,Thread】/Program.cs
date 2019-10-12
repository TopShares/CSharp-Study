using ClassLibrary2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Class1
{
    static void Main(string[] args)
    {
        //    Run1();

        //    Run2();

        //    Console.WriteLine("我是主线程 {0}", Thread.CurrentThread.ManagedThreadId);

        //第一种：
        //var thread = new Thread(Run1);

        //var thread2 = new Thread(Run2);

        //thread.Start();
        //thread2.Start();

        //第二种：
        //ThreadPool.QueueUserWorkItem(i => { Run1(); });

        //ThreadPool.QueueUserWorkItem(i => { Run2(); });

        //Console.WriteLine("我是主线程 {0}", Thread.CurrentThread.ManagedThreadId);

        //第三种：
        //Task task = new Task(Run1);

        //Task task2 = new Task(Run2);

        //task.Start();
        //task2.Start();

        //Console.WriteLine("我是主线程 {0}", Thread.CurrentThread.ManagedThreadId);

        //第四种：
        //Task.Factory.StartNew(Run1);

        //Task.Factory.StartNew(Run2);

        //Console.WriteLine("我是主线程 {0}", Thread.CurrentThread.ManagedThreadId);

        //第五种
        Parallel.Invoke(Run1, Run2);

        Console.WriteLine("我是主线程 {0}", Thread.CurrentThread.ManagedThreadId);

        Console.Read();
    }

    static void Run1()
    {
        Thread.Sleep(5000);

        Console.WriteLine("run1执行完毕 {0}, threadid={1}", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
    }

    static void Run2()
    {
        //假定执行该方法所耗费的时间
        Thread.Sleep(2000);

        Console.WriteLine("run2执行完毕 {0} threadid={1}", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
    }
}