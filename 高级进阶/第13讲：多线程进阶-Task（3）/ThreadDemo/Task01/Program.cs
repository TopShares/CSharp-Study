using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//喜科堂课程网址：xiketang.ke.qq.com
namespace Task01
{
    //异步-->Thead-->ThreadPool-->Task(重点)-->并行计算（Parallel，内容挺多，有的理解还是很困难）-->
    class Program
    {
        #region Task的基本使用【1】

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

        #region Task的基本使用【4】：Task常见枚举 （延续、完成、取消、异常）TaskContiuationOptions

        ////【1】ContinueWith的使用
        //static void Main(string[] args)
        //{
        //    //任务1
        //    Task task1 = new Task(() =>
        //    {               
        //        Console.WriteLine("Child（1）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(),Thread.CurrentThread.ManagedThreadId);
        //    });

        //    //任务2
        //    Task task2 =task1.ContinueWith((task) =>
        //    {             
        //        Console.WriteLine("Child（2）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    });
        //    //任务3
        //    Task task3 = task2.ContinueWith((task) =>
        //    {   
        //        Console.WriteLine("Child（3）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    });
        //    task1.Start();
        //    Console.Read();
        //}


        ////【2】任务取消信号源对象的使用：CancellationTokenSource
        //static void Main(string[] args)
        //{
        //    //《1》任务取消信号源对象
        //    CancellationTokenSource cts = new CancellationTokenSource();

        //    cts.Cancel();//《3》传达任务取消的请求

        //    //任务1
        //    Task task1 = new Task(() =>
        //    {
        //        Console.WriteLine("Child（1）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    });

        //    //任务2
        //    Task task2 = task1.ContinueWith((task) =>
        //    {
        //        Console.WriteLine("Child（2）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    },cts.Token);//《2》cts.Token：获取任务取消信号源

        //    //任务3
        //    Task task3 = task2.ContinueWith((task) =>
        //    {
        //        Console.WriteLine("Child（3）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    });
        //    task1.Start();
        //    Console.Read();

        //    //结果分析：task2任务取消，task3先执行了！why?
        //    //task1-->ContinueWith  task2-->ContinueWith -->task3
        //    //当ContinueWith时候，会预先判断cts.Token的值，当task2取消后，task2和task3就没有了延续关系。task3和task1也就没有了关系。
        //    //所以：ContinueWith这个关系不会正常延续...

        //}


        ////【3】任务延续的保证：TaskContinuationOptions.LazyCancellation前面task2被取消后，但是任务task1如果还希望和task3有顺序关系，该如何做？....
        //static void Main(string[] args)
        //{
        //    //《1》任务取消信号源对象
        //    CancellationTokenSource cts = new CancellationTokenSource();
        //    cts.Cancel();//《3》传达任务取消的请求

        //    //任务1
        //    Task task1 = new Task(() =>
        //    {
        //        Console.WriteLine("Child（1）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    });

        //    //任务2
        //    Task task2 = task1.ContinueWith((task) =>
        //    {
        //        Console.WriteLine("Child（2）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    }, cts.Token,TaskContinuationOptions.LazyCancellation,TaskScheduler.Current);
        //    //《2》cts.Token：获取任务取消信号源
        //    //TaskContinuationOptions.LazyCancellation  :在延续被取消的情况下，也会等待前面的task完成后再做判断

        //    //任务3
        //    Task task3 = task2.ContinueWith((task) =>
        //    {
        //        Console.WriteLine("Child（3）Time={0}  Id={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    });
        //    task1.Start();
        //    Console.Read();
        //}

        ////【4】防止多任务时候线程的切换：TaskContinuationOptions.ExecuteSynchronously  
        //static void Main(string[] args)
        //{
        //    //任务1
        //    Task task1 = new Task(() =>
        //    {
        //        Console.WriteLine("Child（1）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    });

        //    //任务2
        //    Task task2 = task1.ContinueWith((task) =>
        //    {
        //        Console.WriteLine("Child（2）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    }, TaskContinuationOptions.ExecuteSynchronously);
        //    //TaskContinuationOptions.ExecuteSynchronously 这个枚举就是希望前面那个task执行的Thread也在本任务中延续执行。
        //    //好处：这种方式，对于多而小的任务，可以在一定程度上防止线程切换，如果没有这个枚举，task1和task2会用不同的线程（当然不是完全绝对）

        //    //任务3
        //    Task task3 = task2.ContinueWith((task) =>
        //    {
        //        Console.WriteLine("Child（3）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    }, TaskContinuationOptions.ExecuteSynchronously);//继续使用第一个任务的线程执行
        //    task1.Start();
        //    Console.Read();
        //}

        ////【5】延续任务必须在前面task完成状态下才能执行：TaskContinuationOptions.OnlyOnRanToCompletion
        //static void Main(string[] args)
        //{
        //    //任务1
        //    Task task1 = new Task(() =>
        //    {
        //        Console.WriteLine("Child（1）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    });

        //    //任务2
        //    Task task2 = task1.ContinueWith((task) =>
        //    {
        //        Console.WriteLine("Child（2）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    }, TaskContinuationOptions.OnlyOnRanToCompletion);          

        //    //好处：不需要判断前面的线程IsCompleted等这种操作...

        //    task1.Start();
        //    Console.Read();
        //}

        ////【6】延续任务必须在前面task非完成状态下，或出现异常的时候才能执行：TaskContinuationOptions.OnlyOnFaulted/NotOnRanToCompletion
        //static void Main(string[] args)
        //{
        //    //任务1
        //    Task task1 = new Task(() =>
        //    {
        //        Console.WriteLine("Child task1（1）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);

        //        throw new Exception("task1 出现异常了！");

        //    });

        //    ////任务2
        //    //Task task2 = task1.ContinueWith((task) =>
        //    //{
        //    //    Console.WriteLine("Child task2（2）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    //}, TaskContinuationOptions.OnlyOnRanToCompletion);

        //    ////实现方法1：OnlyOnFaulted
        //    ////任务2
        //    //Task task2 = task1.ContinueWith((task) =>
        //    //{
        //    //    Console.WriteLine("Child task2（2）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    //}, TaskContinuationOptions.OnlyOnFaulted);
        //    ////TaskContinuationOptions.OnlyOnFaulted  :  当前前面任务未处理异常的时候，执行的任务。


        //    //实现方法2：NotOnRanToCompletion
        //    //任务2
        //    Task task2 = task1.ContinueWith((task) =>
        //    {
        //        Console.WriteLine("Child task2（2）Time={0}  ThreadId={1}", DateTime.Now.ToLongTimeString(), Thread.CurrentThread.ManagedThreadId);
        //    }, TaskContinuationOptions.NotOnRanToCompletion);
        //    //TaskContinuationOptions.NotOnRanToCompletion  : 也就是前面任务没有完成的时候执行

        //    task1.Start();
        //    Console.Read();
        //}


        #endregion

        #region Task中的取消功能：使用的是CacellationTokenSoure解决多任务中协作取消和超时取消方法

        ////【1】简单的线程的取消（存在bug）
        //static void Main(string[] args)
        //{
        //    var isStop = false;//标志变量
        //    var thread = new Thread(() =>
        //      {
        //          while (!isStop)
        //          {
        //              Thread.Sleep(200);
        //              Console.WriteLine("threadId=" + Thread.CurrentThread.ManagedThreadId);
        //          }
        //      });
        //    thread.Start();

        //    //主线程的任务
        //    Thread.Sleep(1000);
        //    isStop = true;//但是我们前面讲过，不能让多个线程操作一个共享变量，否则在release版本中有潜在的bug

        //    Console.Read();
        //}

        ////【2】Task任务的取消与判断：CancellationTokenSource 实现和前面isStop判断相同的功能，去处理"取消任务” 但是比前面优化很多....
        //static void Main(string[] args)
        //{
        //    //前面用过的类：
        //    CancellationTokenSource cts = new CancellationTokenSource();

        //    Task task = Task.Factory.StartNew(() =>
        //     {
        //         while (!cts.IsCancellationRequested)//判断任务是否被取消
        //         {
        //             Thread.Sleep(200);
        //             Console.WriteLine("threadId=" + Thread.CurrentThread.ManagedThreadId);
        //         }
        //     },cts.Token);

        //    Thread.Sleep(1000);
        //    cts.Cancel();

        //    Console.Read();
        //}

        ////思考：和前面的isStop相比较好处：
        ////【3】Task任务取消的时候，我们希望能够有一些其他的清理工作要执行，也就是这个取消的动作会触发一个任务，比如更新订单队列，或数据库等
        //static void Main(string[] args)
        //{          
        //    CancellationTokenSource cts = new CancellationTokenSource();

        //    //注册一个委托：这个委托将在任务取消的时候调用
        //    cts.Token.Register(() =>
        //    {
        //        //在这个地方可以编写自己要处理的逻辑....

        //        Console.WriteLine("当前task被取消，我们现在可以做相关的清理工作...");
        //    });

        //    Task task = Task.Factory.StartNew(() =>
        //    {
        //        while (!cts.IsCancellationRequested)
        //        {
        //            Thread.Sleep(200);
        //            Console.WriteLine("threadId=" + Thread.CurrentThread.ManagedThreadId);
        //        }
        //    }, cts.Token);

        //    Thread.Sleep(1000);
        //    cts.Cancel();

        //    Console.Read();
        //}

        ////【4】Task任务延时取消：比如我们请求远程的接口，如果在指定时间没有返回数据，我们可以做一个时间现在，超时可以取消任务
        //static void Main(string[] args)
        //{
        //    //CancellationTokenSource cts = new CancellationTokenSource();
        //    CancellationTokenSource cts = new CancellationTokenSource(2000);

        //    //注册一个委托：这个委托将在任务取消的时候调用
        //    cts.Token.Register(() =>
        //    {
        //        //在这个地方可以编写自己要处理的逻辑....

        //        Console.WriteLine("当前task被取消，我们现在可以做相关的清理工作...");
        //    });

        //    Task task = Task.Factory.StartNew(() =>
        //    {
        //        while (!cts.IsCancellationRequested)
        //        {
        //            Thread.Sleep(200);
        //            Console.WriteLine("threadId=" + Thread.CurrentThread.ManagedThreadId);
        //        }
        //    }, cts.Token);

        //    ////取消方法1：public void CancelAfter(TimeSpan delay);
        //    //cts.CancelAfter(new TimeSpan(0, 0, 0, 2));

        //    //取消方法2：public void CancelAfter(int millisecondsDelay);
        //    //在构造方法中设置取消的时间

        //    Console.Read();
        //}

        #endregion

        #region Task中的返回值

        ////【1】常规的获取返回值
        //static void Main(string[] args)
        //{
        //    Task<int> task1 = Task.Factory.StartNew(() =>
        //      {
        //          //在这个地方可以编写自己需要的逻辑部分...

        //          return 100;
        //      });

        //    //  task1.Wait();
        //    Console.WriteLine(task1.Result);

        //    Console.Read();
        //}

        ////【2】ContinueWith<TResult>也可以具有返回值
        //static void Main(string[] args)
        //{
        //    Task<int> task1 = Task.Factory.StartNew(() =>
        //    {
        //        //在这个地方可以编写自己需要的逻辑部分...

        //        return 100;
        //    });
        //    var task2 = task1.ContinueWith(task =>
        //      {
        //          var num = task.Result;
        //          var square = num * num;
        //          return square;
        //      });

        //    Console.WriteLine(task2.Result);

        //    Console.Read();
        //}

        ////【3】Task.WhenAll<TResult>/WhenAny
        //static void Main(string[] args)
        //{
        //    Task<int> task1 = Task.Factory.StartNew(() =>
        //    {
        //        //在这个地方可以编写自己需要的逻辑部分...

        //        return 100;
        //    });
        //    Task<int> task2 = Task.Factory.StartNew(() =>
        //      {
        //          //在这个地方可以编写自己需要的逻辑部分...

        //          return 200;
        //      });

        //    var task3 = Task.WhenAll(new Task<int>[2] { task1, task2 });
        //    var result = task3.Result;

        //    foreach (var item in result)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.Read();
        //}



        #endregion

        #region 并行计算：Parallel各种使用方法

        ////【1】并行计算的基础使用
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("-------------串行执行------------");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    Console.WriteLine("-------------并行执行------------");
        //    Parallel.For(0, 10, (num) =>
        //      {
        //          Console.WriteLine(num);
        //      });

        //    Console.Read();
        //}

        ////【2】重载方法1：中断的出现的bug
        //static void Main(string[] args)
        //{         
        //    Console.WriteLine("-------------并行执行-----------");
        //    //public static ParallelLoopResult For(int fromInclusive, int toExclusive, Action<int, ParallelLoopState> body);
        //    Parallel.For(0, 10, (num,loop) =>
        //    {
        //        if (num == 5)
        //        {
        //            loop.Break();
        //            //建议不要在Parallel.For中使用Break，因为很多时候不会在你希望的地方停止，因为并发的其他线程也在执行...这种随意中断会有bug
        //        }
        //        Console.WriteLine(num);
        //    });

        //    Console.Read();
        //}

        ////【3】重载方法2：可以指定参与线程的个数：
        ////public static ParallelLoopResult For(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, Action<int> body);
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("-------------并行执行-----------");
        //    Parallel.For(0, 10, new ParallelOptions()
        //    {
        //        MaxDegreeOfParallelism = Environment.ProcessorCount - 2
        //        //Environment.ProcessorCount 表示当前计算机上处理器的个数，设置这个值后，可以让固定个数的线程不参与

        //    }, (num) =>
        //    {
        //        //在这里编写业务逻辑...

        //        Console.WriteLine(num);
        //    });

        //    Console.Read();
        //}

        ////【3】 Parallel.For：使用数组可以做累加运算
        //static void Main(string[] args)
        //{
        //    int[] nums = { 10, 90, 20, 45, 89, 35 };
        //    int sum = 0;
        //    Parallel.For(0, nums.Length, (item) =>
        //      {
        //          //可以在这里编写相关的业务逻辑...

        //          sum += nums[item];
        //          Console.WriteLine(sum);
        //      });
        //    Console.Read();
        //}

        ////【4】Parallel.ForEach：可以遍历字典
        //static void Main(string[] args)
        //{
        //    Dictionary<int, string> dic = new Dictionary<int, string>()
        //        {
        //            {1,".NET基础"},
        //            {2,".NET高级" },
        //            {3,"Java高级"}
        //        };

        //    Parallel.ForEach(dic, (item) =>
        //     {
        //         Console.WriteLine(item.Key);
        //     });
        //    Parallel.ForEach(dic, (item) =>
        //    {
        //        Console.WriteLine(item.Value);
        //    });
        //    Console.Read();
        //}

        ////【5】Parallel.Invoke并行计算方法
        //static void Main(string[] args)
        //{
        //    Parallel.Invoke(() =>
        //    {
        //        //在这里写我们需要的业务逻辑...

        //        Console.WriteLine("Paralle Calculator 1 id=" + Thread.CurrentThread.ManagedThreadId);
        //    },
        //    () =>
        //    {
        //        //在这里写我们需要的业务逻辑...

        //        Console.WriteLine("Paralle Calculator 2 id=" + Thread.CurrentThread.ManagedThreadId);
        //    });
        //    Console.Read();
        //}

        #region PLinq

        //为什么使用Plinq？也就是在LINQ查询中，为了提高效率，可以使用并行版本

        //普通LINQ查询
        //static void Main(string[] args)
        //{
        //    var nums = Enumerable.Range(0, 10);//生成一组整数
        //    var query = from n in nums
        //                select new
        //                {
        //                    tid = Thread.CurrentThread.ManagedThreadId,
        //                    num = n
        //                };
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.Read();
        //}
        ////PLinq查询操作（并行）
        //static void Main(string[] args)
        //{
        //    var nums = Enumerable.Range(0, 10);//生成一组整数
        //    var query = from n in nums.AsParallel()  //AsParallel（）这个是扩展方法，可以将串行的代码转为并行
        //                select new
        //                {
        //                    tid = Thread.CurrentThread.ManagedThreadId,
        //                    num = n
        //                };
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.Read();
        //}

        ////扩展方法:AsOrdered() 就是按照原始顺序排序。AsOrdered() 不等于我们串行编程中的OrderBy
        ////AsSequential()就是把PLINQ转成LINQ
        //static void Main(string[] args)
        //{
        //    var nums = new int[] { 10, 8, 7, 3, 4 };

        //    var query = from n in nums.AsParallel().AsOrdered().AsSequential()//.AsUnordered()//.AsOrdered() 
        //                select new
        //                {
        //                    tid = Thread.CurrentThread.ManagedThreadId,
        //                    num = n
        //                };
        //    foreach (var item in query)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.Read();
        //}

        #endregion


        #endregion

    }




}
