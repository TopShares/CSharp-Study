using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//喜科堂课程网址：xiketang.ke.qq.com
namespace Task01
{
    class Program
    {
        #region Task的基本使用

        //static void Main(string[] args)
        //{
        //    ////【1】new一个新的Task来启动（包含很多的重载）
        //    //Task task = new Task(() =>
        //    //  {
        //    //      //在这个地方写我们需要的逻辑...

        //    //      Console.WriteLine("子线程Id={0}", Thread.CurrentThread.ManagedThreadId);
        //    //  });
        //    //task.Start();

        //    ////【2】使用Task的Run（）方法
        //    //Task task = Task.Run(() =>
        //    //{
        //    //    //在这个地方写我们需要的逻辑...

        //    //    Console.WriteLine("子线程Id={0}", Thread.CurrentThread.ManagedThreadId);
        //    //});

        //    ////【3】使用TaskFactory启动（类似于ThreadPool）
        //    //Task task = Task.Factory.StartNew(() =>
        //    //{
        //    //    //在这个地方写我们需要的逻辑...

        //    //    Console.WriteLine("子线程Id={0}", Thread.CurrentThread.ManagedThreadId);
        //    //});

        //    ////【4】以上是三种异步方式。对于第一种情况，我们也可以使用同步执行（阻塞）
        //    //Task task = new Task(() =>
        //    //  {
        //    //      Console.WriteLine("子线程开始执行......");
        //    //      Thread.Sleep(1000);
        //    //      Console.WriteLine("子线程Id={0}", Thread.CurrentThread.ManagedThreadId);
        //    //  });
        //    //task.RunSynchronously();//这个是同步方法

        //    //Console.WriteLine("主线程开始执行......");

        //    ////【5】Task还可以有返回值Task<TResult> 它的父类也是Task
        //    //var task = new Task<string>(() =>
        //    //  {
        //    //      //在这个地方可以编写自己的业务逻辑...

        //    //      return "We are Studying Task！";
        //    //  });
        //    //task.Start();
        //    //var result = task.Result;
        //    //Console.WriteLine(result);


        //   // Console.Read();
        //}

        #endregion

        #region Task的基本使用【2】

        //【1】使用Thread
        //static void Main(string[] args)
        //{
        //    Thread thread1 = new Thread(() =>
        //    {
        //        Thread.Sleep(2000);
        //        Console.WriteLine("Child Thread (1)......");
        //    });
        //    Thread thread2 = new Thread(() =>
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Child Thread (2)......");
        //    });
        //    thread1.Start();
        //    thread2.Start();
        //    //。。。

        //    thread1.Join();
        //    thread2.Join();
        //    //如果有很多的thread，是不是也得有很多的Join？

        //    Console.WriteLine("This is Main Thread!");

        //    Console.Read();
        //}

        ////【2】使用Task各种阻塞方法
        //static void Main(string[] args)
        //{
        //    Task task1 = new Task(() =>
        //      {
        //          Thread.Sleep(1000);
        //          Console.WriteLine("子线程Id={0}", Thread.CurrentThread.ManagedThreadId);
        //      });
        //    task1.Start();
        //    Task task2 = new Task(() =>
        //    {
        //        Thread.Sleep(3000);
        //        Console.WriteLine("子线程Id={0}", Thread.CurrentThread.ManagedThreadId);
        //    });
        //    task2.Start();            

        //    //第一种：等待所有的任务都完成
        //    // Task.WaitAll(task1, task2);

        //    //var taskArray = new Task[2] { task1, task2 };
        //    //Task.WaitAll(taskArray);

        //    var taskArray = new Task[2] { task1, task2 };
        //    Task.WaitAny(taskArray);

        //    Console.WriteLine("This is Main Thread!");

        //    Console.Read();
        //}

        ////Task的延续【1】：WhenAll
        //static void Main(string[] args)
        //{
        //    Task task1 = new Task(() =>
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Child（1）Time={0}",DateTime.Now .ToLongTimeString());
        //    });
        //    task1.Start();
        //    Task task2 = new Task(() =>
        //    {
        //        Thread.Sleep(2000);
        //        Console.WriteLine("Child（2）Time={0}", DateTime.Now.ToLongTimeString());
        //    });
        //    task2.Start();

        //    //线程的延续...(主线下不等待，子线程依次执行)
        //    Task.WhenAll(task1, task2).ContinueWith(task3 =>
        //     {
        //         Console.WriteLine("Child（3）Time={0}", DateTime.Now.ToLongTimeString());
        //     });

        //    Console.WriteLine("This is Main Thread!");

        //    Console.Read();
        //}

        ////Task的延续【2】：WhenAny
        //static void Main(string[] args)
        //{
        //    Task task1 = new Task(() =>
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Child（1）Time={0}", DateTime.Now.ToLongTimeString());
        //    });
        //    task1.Start();
        //    Task task2 = new Task(() =>
        //    {
        //        Thread.Sleep(3000);
        //        Console.WriteLine("Child（2）Time={0}", DateTime.Now.ToLongTimeString());
        //    });
        //    task2.Start();

        //    //线程的延续...(任何一个线程执行完，就执行后面的信任，主线程依然不等待)
        //    Task.WhenAny(task1, task2).ContinueWith(task3 =>
        //    {
        //        Console.WriteLine("Child（3）Time={0}", DateTime.Now.ToLongTimeString());
        //    });

        //    Console.WriteLine("This is Main Thread!");

        //    Console.Read();
        //}

        ////Task的延续【3】：使用工厂完成：ContinueWhenAll
        //static void Main(string[] args)
        //{
        //    Task task1 = new Task(() =>
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Child（1）Time={0}", DateTime.Now.ToLongTimeString());
        //    });
        //    task1.Start();
        //    Task task2 = new Task(() =>
        //    {
        //        Thread.Sleep(3000);
        //        Console.WriteLine("Child（2）Time={0}", DateTime.Now.ToLongTimeString());
        //    });
        //    task2.Start();

        //    //Factory里面的：public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction);
        //    // 摘要:
        //    //     创建一个延续任务，该任务在一组指定的任务完成后开始。
        //    //
        //    // 参数:
        //    //   tasks:
        //    //     继续执行的任务所在的数组。
        //    //
        //    //   continuationAction:
        //    //     在 tasks 数组中的所有任务完成时要执行的操作委托。
        //    //
        //    // 返回结果:
        //    //     新的延续任务。
        //    //
        //    Task.Factory.ContinueWhenAll(new Task[] { task1, task2 },(task)=>
        //    {

        //        Console.WriteLine("Child（3）Time={0}", DateTime.Now.ToLongTimeString());
        //    });


        //    Console.WriteLine("This is Main Thread!");

        //    Console.Read();
        //}




        #endregion


        #region Task的基本使用【3】：Task常见枚举 TaskCreationOptions（父子任务运行和拒绝附加，长时间运行的任务...）

        //public Task(Action action, TaskCreationOptions creationOptions);
        //static void Main(string[] args)
        //{
        //    // 摘要:
        //    //     指定将任务附加到任务层次结构中的某个父级。默认情况下，子任务（即由外部任务创建的内部任务）将独立于其父任务执行。可以使用 System.Threading.Tasks.TaskContinuationOptions.AttachedToParent
        //    //     选项以便将父任务和子任务同步。请注意，如果使用 System.Threading.Tasks.TaskCreationOptions.DenyChildAttach
        //    //     选项配置父任务，则子任务中的 System.Threading.Tasks.TaskCreationOptions.AttachedToParent 选项不起作用，并且子任务将作为分离的子任务执行。有关详细信息，请参阅附加和分离的子任务。

        //    Task parentTask = new Task(() =>
        //     {
        //         //任务1
        //         Task task1 = new Task(() =>
        //         {
        //             Thread.Sleep(1000);
        //             Console.WriteLine("Child（1）Time={0}", DateTime.Now.ToLongTimeString());
        //         }, TaskCreationOptions.AttachedToParent);
        //         task1.Start();
        //         //任务2
        //         Task task2 = new Task(() =>
        //         {
        //             Thread.Sleep(3000);
        //             Console.WriteLine("Child（2）Time={0}", DateTime.Now.ToLongTimeString());
        //         }, TaskCreationOptions.AttachedToParent);
        //         task2.Start();
        //     });

        //    parentTask.Start();
        //    parentTask.Wait();//等待附加的子任务全部完成，相当于：Task.WaitAll(task1,task2);
        //     //如果子线程不使用TaskCreationOptions.AttachedToParent，则主线程直接运行不等待

        //    Console.WriteLine("This is Main Thread!");

        //    Console.Read();
        //}

        //static void Main(string[] args)
        //{       
        //    Task parentTask = new Task(() =>
        //    {
        //        //任务1
        //        Task task1 = new Task(() =>
        //        {
        //            Thread.Sleep(1000);
        //            Console.WriteLine("Child（1）Time={0}", DateTime.Now.ToLongTimeString());
        //        }, TaskCreationOptions.AttachedToParent);
        //        task1.Start();
        //        //任务2
        //        Task task2 = new Task(() =>
        //        {
        //            Thread.Sleep(3000);
        //            Console.WriteLine("Child（2）Time={0}", DateTime.Now.ToLongTimeString());
        //        }, TaskCreationOptions.AttachedToParent);
        //        task2.Start();
        //    },TaskCreationOptions.DenyChildAttach);//禁止子任务附加（如果前面附加了，在这里等于没有附加）

        //    parentTask.Start();
        //    parentTask.Wait();//等待附加的子任务全部完成，相当于：Task.WaitAll(task1,task2);
        //                      //如果子线程不使用TaskCreationOptions.AttachedToParent，则主线程直接运行不等待

        //    Console.WriteLine("This is Main Thread!");

        //    Console.Read();
        //}

        //static void Main(string[] args)
        //{
        //    Task task1 = new Task(() =>
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Child（1）Time={0}", DateTime.Now.ToLongTimeString());
        //    }, TaskCreationOptions.LongRunning);

        //    //LongRunning：如果你明确的知道这个任务是运行时间长，建议你选择此项。同时我们也建议使用“Thread”，而不是ThreadPool。
        //    //如果我们采用了ThreadPool,我们长时间的使用线程，而不归还，强制开启新的线程，会影响性能。

        //    task1.Start();
        //    task1.Wait();

        //    //以上代码看不到效果...可以通过windbg去看（略）

        //    Console.WriteLine("This is Main Thread!");

        //    Console.Read();
        //}
        #endregion

        #region Task的基本使用【4】：Task常见枚举 （延续、完成、取消）

        //ContinueWith的使用
        static void Main(string[] args)
        {
            //任务1
            Task task1 = new Task(() =>
            {               
                Console.WriteLine("Child（1）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(),Thread.CurrentThread.ManagedThreadId);
            });
          
            //任务2
            Task task2 =task1.ContinueWith((task) =>
            {             
                Console.WriteLine("Child（2）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
            });
            //任务3
            Task task3 = task2.ContinueWith((task) =>
            {   
                Console.WriteLine("Child（3）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
            });
            task1.Start();



            Console.Read();
        }
        #endregion

    }




}
