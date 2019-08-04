using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyThreads
{
    /// <summary>
    /// 1 作业讲解，事件回顾
    /// 2 进程-线程-多线程，同步和异步
    /// 3 异步使用和回调
    /// 4 异步参数
    /// 5 异步等待
    /// 6 异步返回值
    /// 
    /// 1 多线程的特点：不卡主线程、速度快、无序性
    /// 2 thread：线程等待，回调，前台线程/后台线程， 
    /// 3 threadpool：线程池使用，设置线程池，ManualResetEvent
    /// 4 Task初步接触
    /// 
    /// 1 task：waitall  waitany  continueWhenAny  continueWhenAll  
    /// 2 并行运算Parallel
    /// 3 异常处理、线程取消、多线程的临时变量和lock
    /// 4 Await/Async
    /// 5 作业
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的多线程课程");
            InitializeComponent();
        }
        #region btnSync_Click
        /// <summary>
        /// 同步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("**********************btnSync_Click Start 主线程id {0}****************************************", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnSync_Click_{0}", i);
                TestThread(name);
            }

            watch.Stop();
            Console.WriteLine("**********************btnSync_Click   End 主线程id {0} {1}*******************************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
            Console.WriteLine();
        }
        #endregion

        #region btnAsync_Click
        /// <summary>
        /// 委托的异步调用
        /// 异步多线程的三大特点：
        /// 1 同步方法卡界面，原因是主线程被占用；异步方法不卡界面，原因是计算交给了别的线程，主线程空闲
        /// 2 同步方法慢，原因是只有一个线程计算；异步方法快，原因是多个线程同时计算，但是更消耗资源，不宜太多
        /// 3 异步多线程是无序的，启动顺序不确定、执行时间不确定、结束时间不确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("***********************btnAsync_Click Start 主线程id {0}**********************************", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnAsync_Click_{0}", i);
                Action act = () => this.TestThread(name);
                //AsyncCallback actCallback = t => Console.WriteLine("123");
                //act.BeginInvoke(actCallback, null);
                act.BeginInvoke(null, null);
                //ThreadStart method = () => this.TestThread(name);
                //Action callback = () => Console.WriteLine("123");
                //this.ThreadCallback(method, callback);
            }

            watch.Stop();
            Console.WriteLine("**********************btnAsync_Click   End 主线程id {0} {1}************************************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
            Console.WriteLine();
        }
        #endregion

        #region btnThread_Click
        /// <summary>
        /// Threads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThread_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("***********************btnThread_Click Start 主线程id {0}**********************************", Thread.CurrentThread.ManagedThreadId);

            List<Thread> threadList = new List<Thread>();
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnThread_Click_{0}", i);
                ThreadStart method = () => this.TestThread(name);
                Thread thread = new Thread(method);//1 默认前台线程：程序退出后，计算任务会继续
                thread.IsBackground = true;//2 后台线程：程序退出，计算立即结束
                thread.Start();
                threadList.Add(thread);

                //ParameterizedThreadStart method = o => this.TestThread(o.ToString());
                //Thread thread = new Thread(method);
                //thread.Start(name);
            }

            foreach (Thread thread in threadList)
            {
                thread.Join();
            }

            watch.Stop();
            Console.WriteLine("**********************btnThread_Click   End 主线程id {0} {1}************************************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
            Console.WriteLine();
        }

        /// <summary>
        /// 使用Thread 完成多线程回调
        /// </summary>
        /// <param name="method">要多线程执行的任务</param>
        /// <param name="callback">回调执行的任务</param>

        private void ThreadBeginInvoke(ThreadStart method, Action callback)
        {
            ThreadStart methodAll = new ThreadStart(() =>
            {
                method.Invoke();
                callback.Invoke();
            });
            Thread thread = new Thread(methodAll);
            thread.Start();
        }
        #endregion

        #region btnThreadPool_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("***********************btnThreadPool_Click Start 主线程id {0}**********************************", Thread.CurrentThread.ManagedThreadId);

            //for (int i = 0; i < 5; i++)
            //{
            //    string name = string.Format("btnThreadPool_Click_{0}", i);
            //    WaitCallback method = t => this.TestThread(t.ToString());
            //    ThreadPool.QueueUserWorkItem(method, name);
            //}
            ManualResetEvent mre = new ManualResetEvent(false);
            WaitCallback method = t =>
                {
                    this.TestThread(t.ToString());
                    mre.Set();
                };
            ThreadPool.QueueUserWorkItem(method, "TestManualResetEvent");

            Console.WriteLine("我们来干点别的。。。。");
            Console.WriteLine("我们来干点别的。。。。");
            Console.WriteLine("我们来干点别的。。。。");
            Console.WriteLine("我们来干点别的。。。。");
            mre.WaitOne();

            //ManualResetEvent mre = new ManualResetEvent(false);
            //new Action(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("委托的异步调用");
            //    mre.Set();//打开
            //}).BeginInvoke(null, null);

            //mre.WaitOne();
            //Console.WriteLine("12345");
            //mre.Reset();//关闭
            //new Action(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("委托的异步调用2");
            //    mre.Set();//打开
            //}).BeginInvoke(null, null);
            //mre.WaitOne();
            //Console.WriteLine("23456");


            //ThreadPool.SetMaxThreads(8, 8);//最小也是核数
            //ThreadPool.SetMinThreads(8, 8);
            //int workerThreads;
            //int ioThreads;
            //ThreadPool.GetMaxThreads(out workerThreads, out ioThreads);
            //Console.WriteLine(String.Format("Max worker threads: {0};    Max I/O threads: {1}", workerThreads, ioThreads));

            //ThreadPool.GetMinThreads(out workerThreads, out ioThreads);
            //Console.WriteLine(String.Format("Min worker threads: {0};    Min I/O threads: {1}", workerThreads, ioThreads));

            //ThreadPool.GetAvailableThreads(out workerThreads, out ioThreads);
            //Console.WriteLine(String.Format("Available worker threads: {0};    Available I/O threads: {1}", workerThreads, ioThreads));
            watch.Stop();
            Console.WriteLine("**********************btnThreadPool_Click   End 主线程id {0} {1}************************************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
            Console.WriteLine();
        }
        #endregion

        #region btnTask_Click
        /// <summary>
        /// Task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("***********************btnTask_Click Start 主线程id {0}**********************************", Thread.CurrentThread.ManagedThreadId);

            //new Action(() =>
            //{


            TaskFactory taskFactory = new TaskFactory();
            List<Task> taskList = new List<Task>();

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnAsync_Click_{0}", i);
                //Action act = () => this.TestThread(name);
                //Task task = taskFactory.StartNew(act);
                Action<object> act = t => this.TestThread(name);
                Task task = taskFactory.StartNew(act, name);

                //task.ContinueWith(t =>
                //{
                //    //t.AsyncState
                //    Console.WriteLine("这里是ContinueWhenAny {0}", Thread.CurrentThread.ManagedThreadId);
                //});

                taskList.Add(task);

                //Task task = new Task(act);
                //task.Start();

                //Task task = Task.Run(act);
            }


            Task any = taskFactory.ContinueWhenAny(taskList.ToArray(), t =>
                {
                    //t.AsyncState
                    Console.WriteLine("这里是ContinueWhenAny {0}", Thread.CurrentThread.ManagedThreadId);
                });

            Task all = taskFactory.ContinueWhenAll(taskList.ToArray(), tList =>
                {
                    Console.WriteLine("这里是ContinueWhenAll {0}", Thread.CurrentThread.ManagedThreadId);
                });


            //name="btnAsync_Click_{2}"
            //Task.WaitAny(task);


            Task.WaitAny(taskList.ToArray());//执行的线程等待某一个task的完成
            Console.WriteLine("after WaitAny{0}", Thread.CurrentThread.ManagedThreadId);
            Task.WaitAll(taskList.ToArray());//执行的线程等待全部的task的完成
            Console.WriteLine("after WaitAll{0}", Thread.CurrentThread.ManagedThreadId);


            //}).BeginInvoke(null, null);
            //Console.WriteLine("out BeginInvoke");
            watch.Stop();
            Console.WriteLine("**********************btnTask_Click   End 主线程id {0} {1}************************************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
            Console.WriteLine();
        }
        #endregion

        #region btnParallel_Click
        /// <summary>
        /// 并行计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParallel_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("***********************btnParallel_Click Start 主线程id {0}**********************************", Thread.CurrentThread.ManagedThreadId);

            //Parallel.Invoke(() => this.TestThread("btnParallel_Click_0")
            //              , () => this.TestThread("btnParallel_Click_1")
            //              , () => this.TestThread("btnParallel_Click_2")
            //              , () => this.TestThread("btnParallel_Click_3")
            //              , () => this.TestThread("btnParallel_Click_4"));


            //等于使用4个task，然后主线程同步invoke一个委托  然后主线程waitall

            //Parallel.For(6, 10, t =>
            //{
            //    string name = string.Format("For btnParallel_Click_{0}", t);
            //    this.TestThread(name);
            //});

            //Parallel.ForEach(new int[] { 5, 6, 7, 10, 8473847 }, t =>
            //{
            //    string name = string.Format("ForEach btnParallel_Click_{0}", t);
            //    this.TestThread(name);
            //});

            ParallelOptions parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 5
            };
            Parallel.For(6, 15, parallelOptions, (t, state) =>
                        {
                            string name = string.Format("btnParallel_Click_{0}", t);
                            this.TestThread(name);
                            //state.Break();//退出单次循环
                            //state.Stop();//退出全部的循环
                            //return;
                        });

            watch.Stop();
            Console.WriteLine("**********************btnParallel_Click   End 主线程id {0} {1}************************************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
            Console.WriteLine();

        }
        #endregion

        #region  btnThreadCore_Click
        private int TotalCount = 0;

        private static List<int> IntList = new List<int>();
        private static object btnThreadCore_Click_Lock = new object();


        /// <summary>
        /// 异常处理、线程取消、多线程的临时变量和线程安全lock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadCore_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine();
            Console.WriteLine("***********************btnThreadCore_Click Start 主线程id {0}**********************************", Thread.CurrentThread.ManagedThreadId);
            try
            {
                TaskFactory taskFactory = new TaskFactory();
                List<Task> taskList = new List<Task>();
                #region 异常处理
                //多线程的委托是不允许异常的， try catch包住，写下日志
                //for (int i = 0; i < 20; i++)
                //{
                //    string name = string.Format("btnThreadCore_Click{0}", i);
                //    Action<object> act = t =>
                //    {
                //        try
                //        {
                //            Thread.Sleep(2000);
                //            if (t.ToString().Equals("btnThreadCore_Click11"))
                //            {
                //                throw new Exception(string.Format("{0} 执行失败", t));
                //            }
                //            if (t.ToString().Equals("btnThreadCore_Click12"))
                //            {
                //                throw new Exception(string.Format("{0} 执行失败", t));
                //            }
                //            Console.WriteLine("{0} 执行成功", t);
                //        }
                //        catch (Exception ex)
                //        {
                //            Console.WriteLine(ex.Message);
                //        }
                //    };
                //    taskList.Add(taskFactory.StartNew(act, name));
                //}
                //Task.WaitAll(taskList.ToArray());
                #endregion

                #region 线程取消
                ////Task不能主动取消，只能通过信号量检查的方式
                //CancellationTokenSource cts = new CancellationTokenSource();

                //for (int i = 0; i < 40; i++)
                //{
                //    string name = string.Format("btnThreadCore_Click{0}", i);
                //    Action<object> act = t =>
                //    {
                //        try
                //        {
                //            //if (cts.IsCancellationRequested)
                //            //{
                //            //    Console.WriteLine("{0} 取消一个任务的执行", t);
                //            //}
                //            Thread.Sleep(2000);
                //            if (t.ToString().Equals("btnThreadCore_Click11"))
                //            {
                //                throw new Exception(string.Format("{0} 执行失败", t));
                //            }
                //            if (t.ToString().Equals("btnThreadCore_Click12"))
                //            {
                //                throw new Exception(string.Format("{0} 执行失败", t));
                //            }
                //            if (cts.IsCancellationRequested)
                //            {
                //                Console.WriteLine("{0} 放弃执行", t);
                //            }
                //            else
                //            {
                //                Console.WriteLine("{0} 执行成功", t);
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            cts.Cancel();
                //            Console.WriteLine(ex.Message);
                //        }
                //    };
                //    taskList.Add(taskFactory.StartNew(act, name, cts.Token));//没有启动的任务  在Cancel后放弃启动
                //}
                //Task.WaitAll(taskList.ToArray());
                #endregion

                #region 多线程临时变量
                //for (int i = 0; i < 5; i++)
                //{
                //    //int k = i;
                //    new Action(() =>
                //    {
                //        //Thread.Sleep(100);
                //        Console.WriteLine(i);
                //        //Console.WriteLine(k);
                //    }).BeginInvoke(null, null);
                //}

                //foreach (var item in collection)
                //{
                //    //做了事件的注册  每次用的都是item
                //}

                #endregion

                #region 线程安全 lock
                for (int i = 0; i < 10000; i++)
                {
                    int newI = i;
                    taskList.Add(taskFactory.StartNew(() =>
                        {
                            int k = 2;
                            int w = 3;
                            int iResult = k + w;
                            lock (btnThreadCore_Click_Lock)
                            {
                                this.TotalCount += 1;
                                IntList.Add(newI);
                            }
                        }));
                }
                Task.WaitAll(taskList.ToArray());

                Console.WriteLine(this.TotalCount);
                Console.WriteLine(IntList.Count());
                #endregion
            }
            catch (AggregateException aex)
            {
                foreach (var item in aex.InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            watch.Stop();
            Console.WriteLine("**********************btnThreadCore_Click   End 主线程id {0} {1}************************************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
            Console.WriteLine();
        }
        #endregion

        #region Private Method

        /// <summary>
        /// 执行动作:耗时而已
        /// </summary>
        private void TestThread(string threadName)
        {
            Console.WriteLine("TestThread Start  Name={2}当前线程的id:{0}，当前时间为{1},", System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), threadName);
            long sum = 0;
            for (int i = 1; i < 999999999; i++)
            {
                sum += i;
            }
            //Thread.Sleep(1000);
            Console.WriteLine("TestThread End  Name={2}当前线程的id:{0}，当前时间为{1},计算结果{3}", System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), threadName, sum);
        }
        #endregion

    }
}
