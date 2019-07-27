using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Task03
{
    //主要是研究：TaskScheduler（任务调度器）相对Task来讲，属于较为底层内容，它的作用是什么？
    //在winform中，wpf，如果我们给一个控件赋值，因为控件都是用主线程创建的，当我们使用线程操作数据的时候，
    //如果要把这个数据给控件，都是调用invoke（）方法。因为需要从队列中取数据才能访问UI控件。
    //也就是最后UI线程会从Action Queue中去取数据，然后更新数据。
    //在UI线程中，建议不要做耗时太多的任务，否则会出问题（页面卡顿）
    //如果真的耗时，一般要放到ThreadPool中。

    public partial class FrmThread : Form
    {

        public FrmThread()
        {
            InitializeComponent();
        }
        ////【1】普通方法和报错解决
        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    Task task = new Task(() =>
        //     {
        //         this.lblInfo.Text = "来自Task的数据：我们在学习多线程！";
        //     });
        //    // task.Start();
        //    task.Start(TaskScheduler.FromCurrentSynchronizationContext());
        //}

        ////对于UI耗时的情况，单独的重载方法并不是很好...
        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    Task task = new Task(() =>
        //    {
        //        //如果有耗时的任务（界面会卡主）
        //        Thread.Sleep(10000);
        //        this.lblInfo.Text = "来自Task的数据：我们在学习多线程！";
        //    });
        //    // task.Start();
        //    task.Start(TaskScheduler.FromCurrentSynchronizationContext());
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.btnUpdate.Enabled = false;
            this.lblInfo.Text = "数据更新中，请等待...";

            Task task = Task.Factory.StartNew(() =>
            {
                //有耗时的任务放到ThreadPool中
                Thread.Sleep(10000);             
            });
            //// task.Start();
            //task.Start(TaskScheduler.FromCurrentSynchronizationContext());
            task.ContinueWith(t =>
            {
                this.lblInfo.Text = "来自Task的数据：我们在学习多线程！";
                this.btnUpdate.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());//更新操作到同步上下文中
           
        }

        //调用自定义Scheduler
        private void btnMyScheduler_Click(object sender, EventArgs e)
        {
            Task task = new Task(() =>
             {
                 Thread.Sleep(10000);
                 Console.WriteLine("自定义TaskScheduler调用...");
             });
            task.Start(new MyCustomTaskScheduler());
        }

    }

    //自定义TaskScheduler
    public class MyCustomTaskScheduler : TaskScheduler
    {
        /// <summary>
        /// 给调试使用的
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<Task> GetScheduledTasks()
        {

            return Enumerable.Empty<Task>();
        }
        /// <summary>
        /// 执行Task用的方法
        /// </summary>
        /// <param name="task"></param>
        protected override void QueueTask(Task task)
        {
            var thread = new Thread(() =>
              {
                  TryExecuteTask(task);
              });
            thread.Start();
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            //在这个地方可以添加自己的业务...

            return true;
        }
    }

}
