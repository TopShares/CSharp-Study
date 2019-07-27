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

namespace _04_CrossThreadVistControl
{
    public partial class FrmThreadControl : Form
    {
        public FrmThreadControl()
        {
            InitializeComponent();
        }

        //执行任务1
        private void btnExecute1_Click(object sender, EventArgs e)
        {
            int a = 0;

            Thread thread1 = new Thread(() =>
            {
                for (int i = 1; i < 100; i++)
                {
                    a += i;

                    if (this.lblResult1.InvokeRequired)
                    {
                        this.lblResult1.Invoke(
                            new Action<string>(s => { this.lblResult1.Text = s; }), a.ToString());
                    }
                    Thread.Sleep(200);
                }
            });

            thread1.IsBackground = true;
            thread1.Start();
        }
        //通过线程给控件赋值
        private void btnExecute2_Click(object sender, EventArgs e)
        {

        }

        //通过线程读取控件的值
        private void btnRead_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(() =>
             {
                 this.txtV.Invoke(new Action<string>(s =>
                 {
                     this.lblV.Text = s;//将读取的控件值，在其他控件显示出来
                 }), this.txtV.Text);
             });
            newThread.IsBackground = true;
            newThread.Start();
        }





    }
}
