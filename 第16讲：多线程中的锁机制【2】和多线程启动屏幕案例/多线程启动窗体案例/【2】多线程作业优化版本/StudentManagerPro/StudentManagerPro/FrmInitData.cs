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

namespace StudentManagerPro
{
    public partial class FrmInitData : Form
    {
        private CancellationTokenSource cts = new CancellationTokenSource();

        public FrmInitData()
        {
            InitializeComponent();

            //【1】加载耗时的任务...
            InitializeData();

            //【2】显示进度条（横向显示进度条）
            var task = Task.Factory.StartNew(i =>
              {
                  while (!cts.IsCancellationRequested)
                  {
                      DisplayProgressBar(i);
                  }
              }, 30, cts.Token);//获取任务取消信号源（30：使用的数据，表示30个小圆点）
        }

        /// <summary>
        /// 显示初始化进度条
        /// </summary>
        /// <param name="state"></param>
        public void DisplayProgressBar(object state)
        {
            string result = string.Empty;
            string txt1 = string.Empty;
            string txt2 = string.Empty;
            int dotCount = (int)state;//显示的原点总数

            for (int i = 0; i < dotCount; i++)
            {
                txt1 = GetBarText("●", i + 1);//递增显示
                txt2 = GetBarText("○", dotCount - i - 1);//递减显示
                result = txt1 + txt2;

                //更新进度条
                if (lblProgressBar.IsHandleCreated)//获取一个值，该值指示控件是否有与它关联的句柄。 如果已经为控件分配了句柄，则为 true；否则为 false。
                {
                    this.lblProgressBar.Invoke(new Action<string>(s =>
                    {
                        this.lblProgressBar.Text = s;
                    }), result);
                }

                Thread.Sleep(50);//延时             
            }
            //递归显示进度条（空心的少一个，实心的就多一个）
            DisplayProgressBar(state);
        }
        /// <summary>
        /// 获取进度条显示点
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private string GetBarText(string txt, int count)
        {
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                result += txt;
            }
            return result;
        }

        /// <summary>
        /// 基于线程初始化数据
        /// </summary>
        private void InitializeData()
        {
            var task = Task.Factory.StartNew(() =>
              {
                  //1. 保存初始化的数据
                  List<string> dataList = new List<string>();

                  //2.在这里具体完成耗时的任务...
                  for (int i = 0; i < 50; i++)
                  {
                      Thread.Sleep(100);
                      dataList.Add("data" + i);
                  }

                  //3.任务完成关闭窗体并保存加载的数据
                  this.Invoke(new Action<List<string>>(s =>
                  {
                      this.Tag = s;
                      this.DialogResult = DialogResult.OK;
                      this.Close();
                  }), dataList);
                  cts.Cancel();//取消显示进度条的任务
              });
        }

        //取消按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            cts.Cancel();//取消显示进度条的任务

            this.Invoke(new Action(() =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }));
        }
    }
}
