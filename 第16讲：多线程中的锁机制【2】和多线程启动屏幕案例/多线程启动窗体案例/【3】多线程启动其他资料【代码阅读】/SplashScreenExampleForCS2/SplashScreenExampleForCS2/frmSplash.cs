using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SplashScreenExampleForCS
{
    //显示进度
    public delegate void ShowProgressDelegate(string ProgressInfo);
    //关闭启动屏幕
    public delegate void CloseSplashDelegate();
    //要完成的系统初始化工作
    public delegate void DoWorkDelegate(Object frm);

    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private Thread worker;

        //外界挂接的用于持续较长时间工作的函数
        //比如系统初始化
        public DoWorkDelegate DoWork;
       

        #region"进程的可视化显示"

            //显示初始化进程,供外界调用
            public  ShowProgressDelegate ShowProgress ;
            //关闭Splash窗体，供外界调用
            public  CloseSplashDelegate CloseSplash;
            
            //显示初始化进程，可以在此定义您所需要的显示方式
            private void ShowProgressInForm(String ProgressInfo)
            {
                lblInfo.Text = string.Format("正在初始化：{0}％", ProgressInfo);
                progressBar1.Value = Convert.ToInt32(ProgressInfo);
            }

        #endregion

        //在装入窗体的过程中完成准备工作
        private void frmSplash_Load(object sender, EventArgs e)
        {
            ShowProgress = ShowProgressInForm;
            CloseSplash = this.Close;

            if (DoWork != null)
            {
                //创建完成系统初始化工作的辅助线程并启动它。
                worker = new Thread(new ParameterizedThreadStart(DoWork));
                worker.Start(this); //将自身引用作为参数，启动线程
            }
        }

        
        }
}