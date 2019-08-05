using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagerPro
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

            //【1】启动登录初始化窗体
            FrmInitData frmData = new FrmInitData();
            DialogResult result1 = frmData.ShowDialog();

            //【2】启动正式的登录窗体
            if (result1 == DialogResult.OK)
            {
                FrmAdminLogin frmLogin = new FrmAdminLogin((List<string>)frmData.Tag);
                DialogResult result = frmLogin.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Application.Run(new FrmMain());
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }         
        }

        //定义一个全局登录对象，保存登录对象信息
        public static Models.SysAdmin currentAdmin = null;
    }
}
