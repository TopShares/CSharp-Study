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
    /// 1 多线程的特点：不卡主线程、速度快、无序性
    /// 2 thread：线程等待，回调，前台线程/后台线程， 
    /// 3 threadpool：线程池使用，设置线程池，ManualResetEvent
    /// 4 Task初步接触
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

            TaskFactory taskFactory = new TaskFactory();

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("btnAsync_Click_{0}", i);
                Action act = () => this.TestThread(name);
                //taskFactory.StartNew(act);
                
                //Task task = new Task(act);
                //task.Start();

                Task task = Task.Run(act);
            }

            watch.Stop();
            Console.WriteLine("**********************btnTask_Click   End 主线程id {0} {1}************************************", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
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
