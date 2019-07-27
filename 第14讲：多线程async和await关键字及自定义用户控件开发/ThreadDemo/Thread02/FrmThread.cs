using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Thread02
{
    public partial class FrmThread : Form
    {
        public FrmThread()
        {
            InitializeComponent();
        }

        Thread newThread = null;
        int counter = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            newThread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    try   //使用interrupt再添加try 
                    {
                        Thread.Sleep(1000);//避免死循环
                        //跨线程访问控件
                        lblInfo.Invoke(new Action(() =>
                        {
                            lblInfo.Text += counter++ + ",";
                        }));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ ex.Message}, {counter++}");
                    }
                }
            }));
            newThread.Start();
            //  newThread.IsBackground = true;
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            //WaitSleepJoin 表示休眠期也可以暂停
            if (newThread.ThreadState == ThreadState.Running ||
                newThread.ThreadState == ThreadState.WaitSleepJoin
               )
            {
                newThread.Suspend();
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (newThread.ThreadState == ThreadState.Suspended)
            {
                newThread.Resume();
            }
        }

        private void btnInterrupt_Click(object sender, EventArgs e)
        {
            newThread.Interrupt();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            newThread.Abort();
          
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(3000); //Thread.Sleep(300000);
                Console.WriteLine("这个是正在执行的子线程数据......");
            }));

            thread.Start();

            thread.Join();//会等待子线程执行完毕后，在执行下面的主线程内容

            Console.WriteLine("这个是主线程的数据......");

            Console.Read();
        }
    }
}
