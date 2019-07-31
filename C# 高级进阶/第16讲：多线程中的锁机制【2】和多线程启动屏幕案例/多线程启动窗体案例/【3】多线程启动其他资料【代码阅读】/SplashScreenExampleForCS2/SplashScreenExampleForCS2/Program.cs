using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace SplashScreenExampleForCS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //创建启动窗体对象
            frmSplash splash = new frmSplash();
            //将系统初始化过程挂接到此启动窗体对象上
            splash.DoWork = SystemInitializeLongTask;

            //创建自定义的ApplicationContext对象
            SplashAppContext splashContext = new SplashAppContext(new frmMain (), splash );

            //在自定义ApplicationContext对象的控制下，
            //先显示启动屏幕，在启动屏幕的Form_Load过程中多线程调用系统初始化过程
            //SystemInitializeLongTask工作完成后，自动关闭启动屏幕
            //显示真正的主窗体
            Application.Run(splashContext);
        }

        //启动一个长时间的系统初始化任务，
        //其参数为显示这一工作任务进度的启动窗体
        //启动窗体的DoWork字段接收此函数。
        private static void SystemInitializeLongTask(Object Splash)
        {
            frmSplash frm = (frmSplash)Splash;

            for (int i = 0; i < 100; i++)
            {
                //在启动屏幕上显示进度
                frm.Invoke(frm.ShowProgress, new object[] { Convert.ToString(i) });
                Thread.Sleep(200);
            }
            //关闭启动屏幕
            frm.Invoke(frm.CloseSplash);
        }
    }
}