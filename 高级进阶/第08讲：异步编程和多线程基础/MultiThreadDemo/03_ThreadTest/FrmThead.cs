using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace _03_ThreadTest
{

    /*
    * 进程：一个正在运行的程序就是一个进程。操作系统根据进程分配各种资源（内存...）
    * 线程：操作系统为了提高效率会将一个进程分成多个线程，并按照线程来分配CPU执行的时间。
    * 时间分配：比如A进程10个线程，Ｂ进程2个线程，操作系统会按照12个线程来分配CPU时间，这样A进程有机会获得CPU的几率就大。
    * 线程特点：在具有多个CPU的计算机中，可以并行执行。如果是单CPU，则会出现《假象》。
    * 1-CPU  A B C
    * 单线程：只有一个线程的进程称为“单线程”进程。拥有多个线程的的进程称为多线程进程。
    * Thread类：表示托管线程，每个Thread对象都代表这一个托管线程，每个托管线程都对应这一个函数。
    * 
    * 
    * Thread类：与操作系统真是的本地线程不是一一对应关系，它只是一个“逻辑线程”。
    * ProcessThread类：用于表示操作系统中真实的本地线程。
    */

    public partial class FrmThead : Form
    {
        public FrmThead()
        {
            InitializeComponent();
        }
        //执行任务1
        private void btnExecute1_Click(object sender, EventArgs e)
        {
            int a = 0;
            //Thread thread = new Thread(delegate ()
            // {
            //     for (int i = 1; i < 20; i++)
            //     {
            //         Console.WriteLine((a+i)+"  ");
            //         Thread.Sleep(500);
            //     }
            // });

            Thread thread = new Thread( ()=>
            {
                for (int i = 1; i < 20; i++)
                {
                    Console.WriteLine((a + i) + "  ");
                    Thread.Sleep(500);
                }
            });

            thread.IsBackground = true;//设置为后台线程（通常要这样设置）
            thread.Start();
        }
        //执行任务2
        private void btnExecute2_Click(object sender, EventArgs e)
        {          
            Thread thread2 = new Thread(delegate ()
            {
                for (int i = 1; i < 60; i++)
                {
                    Console.WriteLine("--------------a"+i+"--------------");
                    Thread.Sleep(100);
                }
            });
            thread2.IsBackground = true;
            thread2.Start();
        }
    }
}
