using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagerPro
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            //显示登录用户名
            this.lblCurrentAdmin.Text = Program.currentAdmin.AdminName;

            //根据登录用户的性别改变图标
            this.label1.ImageIndex = 1;
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
        //窗体关闭之前发生的事件
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出询问", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        #region 嵌入窗体显示      
        private void OpenForm(Form frm)
        {
            //关闭前面的窗体
            foreach (Control item in this.panelRight.Controls)
            {
                if (item is Form)
                {
                    Form objControl = (Form)item;
                    objControl.Close();
                }
            }
            frm.TopLevel = false;//将子窗体设置成非顶级控件      
            frm.FormBorderStyle = FormBorderStyle.None;//去掉子窗体的边框
            frm.Parent = this.panelRight;//指定子窗体显示的容器  
            frm.Dock = DockStyle.Fill;//随着容器大小自动调整窗体大小
            frm.Show();
        }
        #endregion
        private void btnStuManage_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmStudentManager());
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string connString = DAL.SQLHelper.connString;

        }
       
    }
}
