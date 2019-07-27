using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StudentManagerPro
{
    public partial class FrmAdminLogin : Form
    {
        //创建数据访问方法
        private SysAdminService adminService = new SysAdminService();

        private SysAdmin admin = null;

        public FrmAdminLogin(List<string> dataList)
        {
            InitializeComponent();

            MessageBox.Show(dataList.Count .ToString ());

            //判断本地是否保留着有效的登录信息
            CheckLoginInfo();
        }
        private void CheckLoginInfo()
        {
            if (File.Exists("sysAdmins.sys"))//如果本地有保存登录信息
            {
                admin = adminService.ReadLoginInfo();
                if (Convert.ToDateTime(admin.LastLoginTime).AddDays(10) > DateTime.Now)
                {
                    //如果登录信息没有失效,则显示登录信息
                    this.txtLoginId.Text = admin.LoginId.ToString();
                    this.txtLoginPwd.Text = admin.LoginPwd;
                    this.ckbSavePwd.Checked = true;
                }
            }
        }

        #region  窗体拖动

        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //用户登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //int a = 100;
            //Console.WriteLine(a);
            //SysAdmin admin1 = new SysAdmin();
            //Console.WriteLine(admin1.GetType().ToString());
            //return;

            //【1】数据验证
            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录账号！", "登录提示");
                this.txtLoginId.Focus();
                return;
            }
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录密码！", "登录提示");
                this.txtLoginPwd.Focus();
                return;
            }
            //验证登录账号必须是数字（可以使用正则表达式，只需要了解，会用即可，如果感兴趣，可以自己研究怎么写）


            //【2】对象封装（把用户输入的数据封装为对象，用对象属性承载数据）
            admin = new SysAdmin
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text.Trim()
            };
            //【3】调用后台数据访问方法验证
            try
            {
                admin = adminService.AdminLogin(admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("用户登录发生异常！具体错误：" + ex.Message, "登录错误");
                return;
            }
            if (admin != null)//如果账号和密码是正确的
            {
                //【1】验证账号状态是否允许
                if (admin.AdminStatus == 1)
                {
                    //【2】把当前登录用户的信息保存起来（后面有可能用到）
                    Program.currentAdmin = admin;
                    //【3】如果有权限，那么可以在这个根据登录信息查询权限...(如果数据访问类中写了，此处就不要写，建议大家写到这个地方)

                    //【4】判断用户是否需要记住密码和登录账号
                    if (this.ckbSavePwd.Checked)
                    {
                        admin.LastLoginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    }
                    else //如果没有选中，有两种方式：1.可以删除保存的文件  2.在当前日期前面减去大于10的天数
                    {
                        //比如是2020-12-30   
                        admin.LastLoginTime = DateTime.Now.AddDays(-11).ToString("yyyy-MM-dd HH:mm");
                    }
                    adminService.SaveLoginInfo(admin);//保存登录信息

                    //【5】写入登录日志...(什么时候登录的，登录的IP地址是什么，登录名是谁...我们在课程8 就有讲解...)

                    //【6】关闭登录窗体
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("当前用户为禁止登录状态，请联系管理员！", "登录提示");
                }
            }
            else
            {
                MessageBox.Show("用户名或密码错误！", "登录提示");
            }
        }
    }
}
