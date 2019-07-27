using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task05
{
    //本次主题：《.NET多线程中使用锁机制》线程安全问题
    //为什么使用锁？多线程中对一个“共享资源” 进行操作的时候，会涉及到资源争用（并发），容易出现问题。
    //.NET中相关是锁机制：事件锁，信号量，互斥锁，读写锁...
    //分类学习
    //《1》用户模式锁：通常是使用一些CPU指令或者死循环，达到线程等待和休眠。
    //《2》内核模式锁：通常是调用win32底层代码，来实现线程的各种操作。
    //《3》混合锁：《1》+《2》综合使用。

    class Program
    {
        #region 用户模式锁

        //用户模式锁：1. 异变结构（一个线程读，一个线程写入）思考：以前我们使用Release版本，会有一个潜在的bug。
        //当时的解决方法：Thread.MemoryBarrier,VolatileRead
        //static void Main(string[] args)
        //{
        //    bool stop = false;
        //    Thread thread = new Thread(() =>
        //     {
        //         int a = 0;
        //         while (!stop)//子线程使用了主线程定义的变量
        //         {
        //             a++;
        //            // Console.WriteLine(a);
        //         }
        //     });
        //    thread.Start();
        //    thread.IsBackground = true;

        //    Thread.Sleep(1000);

        //    stop = true;//主线程中修改stop变量

        //    thread.Join();
        //    Console.WriteLine("Main Thread Is  End!");
        //    Console.Read();
        //}

        ////新的解决方法volatile关键字的使用
        //public static volatile bool stop = false;
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(() =>
        //    {
        //        int a = 0;
        //        while (!stop)//子线程使用了主线程定义的变量
        //        {
        //            a++;
        //            // Console.WriteLine(a);
        //        }
        //    });
        //    thread.Start();
        //    thread.IsBackground = true;

        //    Thread.Sleep(1000);

        //    stop = true;//主线程中修改stop变量

        //    thread.Join();
        //    Console.WriteLine("Main Thread Is  End!");
        //    Console.Read();
        //}
        ////volatile关键字：1.禁止了Release版本对底层代码的优化。2. 程序在Read和Write的时候从Memory中读取。

        //用户模式锁：互锁结构（自行了解）

        //用户模式锁：《2》SpinLock（旋转锁） （可以帮助我们实现一个自增）
        //基本原理：提供一个相互排斥的锁单元。

        //public static SpinLock spinLock = new SpinLock();
        //static void Main(string[] args)
        //{
        //    //开启多个线程，分别操作静态变量
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            Test();
        //        });
        //    }

        //    Console.Read();
        //}

        ////定义静态变量和方法
        //private static int nums = 0;
        //private static int a = 0;
        //private static void Test()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        try
        //        {
        //            bool lockTaken = false;
        //            //public void Enter(ref bool lockTaken);使用Enter方法之前lockTaken要初始化为false
        //            spinLock.Enter(ref lockTaken);//锁住下面的内容
        //            nums++;
        //            a++;
        //            Console.WriteLine(nums);
        //            Console.WriteLine("----------------------" + a);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        finally
        //        {
        //            spinLock.Exit();//释放锁
        //        }
        //    }
        //}
        #endregion

        #region 内核模式锁

        //建议：通常不建议随便使用内核模式锁，资源付出相对较大。
        //其实，我们可以使用混合锁代替，以及我们马上讲到的lock关键字

        //《1》事件锁：也就是相当于一个开关锁，也就是通过true、false变量来控制

        //《1.1》自动事件锁：使用场景--》可以用此锁实现多线程环境下某个变量的自增

        //private static AutoResetEvent myLock = new AutoResetEvent(true);
        //static void Main(string[] args)
        //{
        //    myLock.WaitOne();

        //    Console.WriteLine("我们的等待结束啦！大家bye！");

        //    myLock.Set();

        //    Console.Read();
        //}

        //private static AutoResetEvent myLock = new AutoResetEvent(true);
        ////true：表示终止状态（初始状态）
        ////false：非终止状态。
        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            Test();
        //        });
        //    }

        //    Console.Read();
        //}
        //private static int nums = 0;
        //private static void Test()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        myLock.WaitOne();//组织当前线程（就是等待）相当于：地铁站，刷卡后，正在通过的状态....
        //        nums++;
        //        Console.WriteLine($"第{nums}位检查正常！可以正常通过...");//有序的输出，并且是按照顺序来的。

        //        myLock.Set();//将事件设置为终止状态，允许一个或多个线程继续。
        //    }
        //}

        //《1.2》手动事件锁：本锁其实锁住的是一批，和自动事件锁比较，自动事件锁锁住的是一个。
        //典型的例子：红绿灯，锁住的是一批人或者车辆；我们过铁道路口，当火车来的时候，拦住的是一批人或车辆。
        //true：可以正常通过的。
        //false：拦截状态，禁止通过。

        //private static ManualResetEvent myLock = new ManualResetEvent(false);

        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            Test();
        //        });
        //    }

        //    Thread.Sleep(3000);//3s后，绿灯亮了（或者铁道路口栏杆抬起），这个时候会有一批数据过来。
        //    myLock.Set();

        //    Console.Read();
        //}
        //private static int nums = 0;
        //private static void Test()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        myLock.WaitOne();//拦截
        //        nums++;
        //        Console.WriteLine(nums);//输出是无序的，手动锁，锁住的不是一个值，而是一批值，和前面自动锁不一样

        //    }
        //}

        ////《2》信号量 Semaphore 基本原理：是通过int数值来控制线程的个数
        ////private static Semaphore myLock = new Semaphore(5, 10);//第一个参数表示同时可以允许的线程数，第二个是最大值
        //private static Semaphore myLock = new Semaphore(1, 10);
        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            Test();
        //        });
        //    }
        //    Console.Read();
        //}
        //private static int nums = 0;
        //private static void Test()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        myLock.WaitOne();
        //        nums++;
        //        Console.WriteLine(nums);
        //        myLock.Release();
        //    }
        //}

        ////《3》mutex互斥锁
        //private static Mutex myLock = new Mutex();
        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            Test();
        //        });
        //    }
        //    Console.Read();
        //}
        //private static int nums = 0;
        //private static void Test()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        myLock.WaitOne();
        //        nums++;
        //        Console.WriteLine(nums);
        //        myLock.ReleaseMutex();
        //    }
        //}

        ////《4》读写锁：ReaderWriterLock
        //// 注意：读写锁并不是从限定线程个数的角度出发。而是按照读写的功能划分。
        //// 比如：SqlLite：库锁（每次只能一个线程访问） SqlServer：行锁（只锁住一行）

        ////读写锁的基本方案：多个线程可以一起读，只能让一个线程去写。
        ////模拟场景：多个线程读取，一个线程写。请思考：写的线程是否能够正常阻止读的线程？如果能阻止，则达到目标。

        ////定义支持单个写线程和多个读线程的锁。
        //private static ReaderWriterLock myLock = new ReaderWriterLock();
        //static void Main(string[] args)
        //{
        //    //开启多个读的线程
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            ThreadRead();
        //        });
        //    }

        //    //开启写的线程
        //    Task.Factory.StartNew(() =>
        //    {
        //        ThreadWrite();
        //    });
        //    Console.Read();
        //}
        ///// <summary>
        ///// 读取数据的线程
        ///// </summary>
        //private static void ThreadRead()
        //{
        //    while (true)
        //    { 
        //        myLock.AcquireReaderLock(int.MaxValue);//参数：表示最大的超时时间

        //        Thread.Sleep(100);
        //        Console.WriteLine("当前读取的tid={0}  {1}",Thread.CurrentThread.ManagedThreadId,
        //            DateTime.Now .ToLongTimeString());

        //        myLock.ReleaseReaderLock();
        //    }
        //}
        ///// <summary>
        ///// 写入数据的线程
        ///// </summary>
        //private static void ThreadWrite()
        //{
        //    while (true)
        //    {
        //        myLock.AcquireWriterLock(int.MaxValue);//参数：表示最大的超时时间

        //        Thread.Sleep(3000);
        //        Console.WriteLine("---------------------------------------------当前写入的tid={0}  {1}", Thread.CurrentThread.ManagedThreadId,
        //            DateTime.Now.ToLongTimeString());

        //        myLock.ReleaseWriterLock();
        //    }
        //}
        ////通过观察，我们发现写入的时候，能够正常的拦截读取的线程。
        ////PS：如果我们写入数据的任务耗时太长，比如十几秒或更长，此时读的线程会被卡死，从而超时。开发中要特别注意。

        #endregion

        #region 动态计数锁：CountdownEvent：限制线程数的一个机制，而且这个也是比较常用的（同属于信号量的一种）

        ////使用场景：基于多个线程从某一个表中读取数据：比如我们现有A、B、C...每一张数据表我们都希望通过多个线程去读取。
        ////因为用一个线程的话，那么数据量大会出现卡死的情况。
        ////举例：A表：10w数据--》10个线程读取，1个线程1w条数据。
        ////          B表：5w数据  --》5个线程            1个线程1w
        ////          C表：1w数据  --》2个线程            1个线程5k

        ////【1】定义表示在技术变为0时处于有信号状态的同步单元。
        //private static CountdownEvent myLock = new CountdownEvent(10);
        //static void Main(string[] args)
        //{
        //    //【3】加载A表
        //    myLock.Reset(10);//重置当前ThreadCount上限
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            Thread.Sleep(500);
        //            LoadTableA();
        //        });
        //    }

        //    //阻止当前线程，直到设置了System.Threading.CountdonwEvent为止
        //    myLock.Wait();//相当于我们前面学习的Task.WaitAll()

        //    Console.WriteLine("所有的TableA加载完毕..........\r\n");

        //    //加载B表
        //    myLock.Reset(5);
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            Thread.Sleep(500);
        //            LoadTableB();
        //        });
        //    }
        //    myLock.Wait();
        //    Console.WriteLine("所有的TableB加载完毕..........\r\n");

        //    //加载C表
        //    myLock.Reset(2);
        //    for (int i = 0; i < 2; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            Thread.Sleep(500);
        //            LoadTableC();
        //        });
        //    }
        //    myLock.Wait();
        //    Console.WriteLine("所有的TableC加载完毕..........\r\n");

        //    Console.Read();
        //}

        //#region 【2】完成的几种任务

        ///// <summary>
        ///// 加载A表
        ///// </summary>
        //private static void LoadTableA()
        //{
        //    //在这里编写具体的业务逻辑...

        //    Console.WriteLine("当前TableA正在加载中...{0}",Thread.CurrentThread.ManagedThreadId);
        //    myLock.Signal();//将当前的ThreadCount--操作
        //}
        ///// <summary>
        ///// 加载B表
        ///// </summary>
        //private static void LoadTableB()
        //{
        //    //在这里编写具体的业务逻辑...

        //    Console.WriteLine("当前TableB正在加载中...{0}", Thread.CurrentThread.ManagedThreadId);
        //    myLock.Signal();
        //}
        ///// <summary>
        ///// 加载C表
        ///// </summary>
        //private static void LoadTableC()
        //{
        //    //在这里编写具体的业务逻辑...

        //    Console.WriteLine("当前TableC正在加载中...{0}", Thread.CurrentThread.ManagedThreadId);
        //    myLock.Signal();
        //}

        //#endregion

        #endregion

        #region 监视锁：Monitor  限制线程个数的一把锁

        //具体使用方法：Enter 锁住某一个资源

        private static int nums = 0;

        private static object myLock = new object();

        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Task.Factory.StartNew(() =>
        //        {
        //            TestMethod();
        //        });
        //    }

        //    Console.Read();
        //}

        //////【1】简单写法
        ////static void TestMethod()
        ////{
        ////    for (int i = 0; i < 100; i++)
        ////    {
        ////        Monitor.Enter(myLock);

        ////        nums++;
        ////        Console.WriteLine(nums);

        ////        Monitor.Exit(myLock);
        ////    }
        ////}

        ////【2】严谨的写法
        //static void TestMethod()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        bool taken = false;
        //        try
        //        {
        //            Monitor.Enter(myLock, ref taken);//这个类似于SpinLock

        //            nums++;
        //            Console.WriteLine(nums);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        finally
        //        {
        //            if (taken)
        //            {
        //                Monitor.Exit(myLock);
        //            }                 
        //        }
        //    }

        //总结：为了严谨性，保证程序正常秩序，我们在锁区域添加了异常处理，还要添加判断，非常麻烦。我们可以使用语法糖Lock。
        //语法糖：只是编译器层面的，底层代码生成还是跟以前一样的。
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                lock (myLock)
                {
                    nums++;
                    Console.WriteLine(nums);
                }
            }

            Console.Read();
        }
        //用ILSyp自己观察生成的代码，发现和Monitor是一样的
        //lock/Monitor的内部机制
        //PS：在前面挺多的锁中，只有Monitor有语法糖，说明这个重要。
        //本质上就是利用对上的“同步块”实现资源锁定。     

        //注意事项
        //1. 我们锁住的资源一定要让可访问的线程能够访问到，所以不能是局部变量。
        //2. 锁住的资源千万不要是值类型。
        //3. lock 不能锁住string类型，虽然它是引用类型。

    }
    #endregion


}

