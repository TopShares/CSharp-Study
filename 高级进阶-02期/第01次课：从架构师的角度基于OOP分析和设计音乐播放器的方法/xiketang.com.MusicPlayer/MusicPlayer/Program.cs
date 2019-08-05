using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MusicPlayer
{
    static class Program
    {
        /// <summary>
        /// 喜科堂互联教育网址：xiketang.ke.qq.com
        /// 原创设计：常慧勇    QQ：2934008878
        /// 版权声明：版权所有，侵权必究。本项目源码是开放式设计，不能用于任何商业用途！
        /// 如有更改，请标注哪些更改！
        /// 本课程地址：https://ke.qq.com/course/248962
        /// </summary>
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
