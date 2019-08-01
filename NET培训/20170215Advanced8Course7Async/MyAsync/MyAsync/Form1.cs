using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsync
{
    /// <summary>
    /// 1 作业讲解，事件回顾
    /// 2 进程-线程-多线程，同步和异步
    /// 3 异步使用和回调
    /// 4 异步参数
    /// 5 异步等待
    /// 6 异步返回值
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private delegate void DoSomethingDelegate(string name);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnAsync_Click Start {0}***************", Thread.CurrentThread.ManagedThreadId);


            DoSomethingDelegate method = new DoSomethingDelegate(this.DoSomethingLong);

            IAsyncResult asyncResult = null;

            //AsyncCallback callback = t =>
            //    {
            //        Console.WriteLine(t.Equals(asyncResult));

            //        Console.WriteLine(t.AsyncState);
            //        Console.WriteLine("这里是回调函数 {0}", Thread.CurrentThread.ManagedThreadId);
            //    };

            ////callback.Invoke(IAsyncResult)

            //asyncResult = method.BeginInvoke("btnAsync_Click", callback, "假洒脱");

            //asyncResult = method.BeginInvoke("btnAsync_Click", t =>
            //    {
            //        Console.WriteLine(t.Equals(asyncResult));
            //        Console.WriteLine(t.AsyncState);
            //        Console.WriteLine("这里是回调函数 {0}", Thread.CurrentThread.ManagedThreadId);
            //    }, "假洒脱");

            //var asyncResult1 = method.BeginInvoke("btnAsync_Click", t =>
            //{
            //    Console.WriteLine(t.Equals(asyncResult));
            //    Console.WriteLine(t.AsyncState);
            //    Console.WriteLine("这里是回调函数 {0}", Thread.CurrentThread.ManagedThreadId);
            //}, "假洒脱");

            //等待异步结束后，主线程还要做事儿

            //int i = 1;
            //while (!asyncResult.IsCompleted)
            //{
            //    Console.WriteLine("*****正在计算，已完成{0}%。。。。", 10 * i++);
            //    //Thread.Sleep(100);
            //}

            //asyncResult.AsyncWaitHandle.WaitOne();//一直等待
            //asyncResult.AsyncWaitHandle.WaitOne(-1);//一直等待
            //asyncResult.AsyncWaitHandle.WaitOne(1000);//等待1000毫秒，超时就不等待了

            //method.EndInvoke(asyncResult);

            string name = "23";

            Func<int, string> func1 = i =>
                {
                    DoSomethingLong("btnAsync_Click");
                    return "二零一七给力";
                };
            func1.Invoke(123);
            //Func<int, string> func2 = t =>
            //{
            //    DoSomethingLong("btnAsync_Click");
            //    return "二零一七给力";
            //};
            //Func<int, string> func3 = t =>
            //{
            //    DoSomethingLong("btnAsync_Click");
            //    return "二零一七给力";
            //};
            //Func<int, string> func4 = t =>
            //{
            //    DoSomethingLong("btnAsync_Click");
            //    return "二零一七给力";
            //};
            //Func<int, string> func5 = t =>
            //{
            //    DoSomethingLong("btnAsync_Click");
            //    return "二零一七给力";
            //};
            string sResultInvoke = func1.Invoke(1);

            string remark = "";

            asyncResult = func1.BeginInvoke(DateTime.Now.Millisecond, t =>
            {
                string sResultCallback = func1.EndInvoke(t);

                Console.WriteLine(t.AsyncState);
                remark = t.AsyncState == null ? "123" : t.AsyncState.ToString();
                Console.WriteLine("这里是回调函数 {0}", Thread.CurrentThread.ManagedThreadId);
            }, "AlwaysOnline");

            string sResult = func1.EndInvoke(asyncResult);

            //method.Invoke("btnAsync_Click1");
            //method.Invoke("btnAsync_Click2");

            //method.BeginInvoke("btnAsync_Click3", null, null);
            //method.BeginInvoke("btnAsync_Click4", null, null);
            Console.WriteLine("****************btnAsync_Click   End {0}***************", Thread.CurrentThread.ManagedThreadId);
        }


        private void DoSomethingLong(string name)
        {
            Console.WriteLine("****************DoSomethingLong Start {0}***************", Thread.CurrentThread.ManagedThreadId);
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);

            Console.WriteLine("****************DoSomethingLong   End {0}***************", Thread.CurrentThread.ManagedThreadId);

        }
    }
}
