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

namespace LoginThread
{
    public partial class FrmMain : Form
    {

        CancellationTokenSource cts = new CancellationTokenSource();
        public FrmMain()
        {
            InitializeComponent();

            this.panel1.Visible = false;

            //第一个线程：完成数据加载
            Task t0 = Task.Factory.StartNew(new Action(() =>
           {
               InitializeData();
           }));
            //第二个线程：完成加载进度条的显示
            Task t1 = Task.Factory.StartNew(i => { DisplayProgress(i); }, 30, cts.Token);  //获取任务取消信号源           
        }

        /// <summary>
        /// 显示初始化数据进度条
        /// </summary>
        /// <param name="olength"></param>
        public void DisplayProgress(object olength)
        {
            string result = string.Empty;
            string str1 = string.Empty;
            string str2 = string.Empty;
            int length = (int)olength;
            for (int i = 0; i < length; i++)
            {
                str1 = GetStr("■", i + 1);
                str2 = GetStr("□", length - i - 1);
                result = str1 + str2;
                //显示进度条的过程
                this.lblStatus.Invoke(new Action<string>(s =>
               {
                   this.lblStatus.Text = s;
               }), result);

                Thread.Sleep(300);
                if (isComplete)//这个地方用的不好，根本不用这个
                {
                    return;
                }
            }
            //递归显示进度条
            DisplayProgress(olength);
        }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■
        //□□□□□□□□□□□□□□□□□□□□□□□□□□

        //■□□□□□□□□□□□□□□□□□□□□□□□□□
        //■■□□□□□□□□□□□□□□□□□□□□□□□□
        //■■■□□□□□□□□□□□□□□□□□□□□□□□
        //■■■■□□□□□□□□□□□□□□□□□□□□□□
        //■■■■■□□□□□□□□□□□□□□□□□□□□□

        /// <summary>
        /// 获取指定长度的文本
        /// </summary>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private string GetStr(string str, int count)
        {
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                result += str;
            }
            return result;
        }

        bool isComplete = false;//是否初始化完成（不能直接用）
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitializeData()
        {
            List<string> sList = new List<string>();
            //这个地方应该是耗时的任务
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(50);
                sList.Add($"数据{i}");
                this.lblDisplay.Invoke(new Action<string>((s) => { this.lblDisplay.Text = s; }), $"正在载入数据【{i}】");
            }

            this.cbxData.Invoke(new Action<List<string>>(s =>
            {
                this.cbxData.Items.AddRange(s.ToArray());

            }), sList);
            cts.Cancel();//取消任务并显示登录窗口
            this.panel1.Invoke(new Action(() =>
            {
                this.panel1.Visible = true;
                isComplete = true;
                this.lblDisplay.Visible = false;
                this.lblStatus.Visible = false;
            }));

        }
    }
}
