using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruanmou.Advaned.Lottery
{
    /// <summary>
    /// 双色球：投注号码由6个红色球号码和1个蓝色球号码组成。
    /// 红色球号码从01--33中选择
    /// 蓝色球号码从01--16中选择
    /// </summary>
    public partial class frmSSQ : Form
    {
        public frmSSQ()
        {
            InitializeComponent();

            this.btnStop.Enabled = false;
        }

        #region
        /// <summary>
        /// 红球集合
        /// </summary>
        private string[] RedNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",
            "31","32","33"
        };

        /// <summary>
        /// 蓝球集合
        /// </summary>
        private string[] BlueNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16"
        };

        private static object Start_Lock = new object();
        private bool IsGoon = true;
        #endregion



        /// <summary>
        /// 点击开始：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                this.btnStart.Text = "开始ing";
                this.btnStart.Enabled = false;
                this.IsGoon = true;
                this.lblBlue.Text = "00";
                this.lblRed1.Text = "00";
                this.lblRed2.Text = "00";
                this.lblRed3.Text = "00";
                this.lblRed4.Text = "00";
                this.lblRed5.Text = "00";
                this.lblRed6.Text = "00";
                Thread.Sleep(1000);

                TaskFactory taskFactory = new TaskFactory();
                List<Task> taskList = new List<Task>();
                foreach (var item in this.gboSSQ.Controls)
                {
                    if (item is Label)
                    {
                        Label lable = (Label)item;
                        taskList.Add(taskFactory.StartNew(() =>
                             {
                                 try
                                 {
                                     while (this.IsGoon)
                                     {
                                         this.ChangeBall(lable);
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                     Console.WriteLine(ex.Message);
                                 }
                             }));
                    }
                }
                this.btnStop.Enabled = true;

                taskFactory.ContinueWhenAll(taskList.ToArray(), tList =>
                    {
                        watch.Stop();
                        Console.WriteLine("耗时{0}ms", watch.ElapsedMilliseconds);
                        this.ShowResult();
                    });

            }
            catch (Exception ex)
            {
                Console.WriteLine("双色球启动出现异常：{0}", ex.Message);
            }
        }

        #region btnStart_Click Private
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lable"></param>
        private void ChangeBall(Label lable)
        {
            Thread.Sleep(1000);//可以把if else 委托出去
            if (lable.Name.Contains("Blue"))
            {
                int index = this.GetRandom(0, this.BlueNums.Length);
                string ball = this.BlueNums[index];
                this.UpdateLable(lable, ball);
            }
            else if (lable.Name.Contains("Red"))
            {
                //多个线程同时随机在33个数里面取一个，一定是有几率重复的，如果保证不重复：
                //1 白开水：分6组，线程在组里获取，然后换组：    这里存在作弊
                //  微笑刺客:换组的时候，重新随机6个组
                //2 化蝶：把33个数字都随机存到队列中   拿头上的数据，然后放回原来的
                //3 曾经沧海： 放到数组 lock
                int index = this.GetRandom(0, this.RedNums.Length);
                string ball = this.RedNums[index];

                lock (Start_Lock)
                {
                    List<string> usedNumberList = this.GetUsedRed();
                    if (usedNumberList.Contains(ball))
                    {
                        //被用了就算了
                    }
                    else
                    {
                        this.UpdateLable(lable, ball);
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<string> GetUsedRed()
        {
            List<string> usedNumberList = new List<string>();
            foreach (var lableSSQ in this.gboSSQ.Controls)
            {
                if (lableSSQ is Label && ((Label)lableSSQ).Name.Contains("Red"))
                {
                    usedNumberList.Add(((Label)lableSSQ).Text);
                }
            }
            return usedNumberList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lable"></param>
        /// <param name="number"></param>
        private void UpdateLable(Label lable, string number)
        {
            this.Invoke(new Action(() => lable.Text = number));
        }

        #endregion btnStart_Click Private

        /// <summary>
        /// 点击结束：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            this.IsGoon = false;
            //this.ShowResult();

        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowResult()
        {
            MessageBox.Show(string.Format("本期双色球结果为：{0} {1} {2} {3} {4} {5}  蓝球{6}"
                , this.lblRed1.Text
                , this.lblRed2.Text
                , this.lblRed3.Text
                , this.lblRed4.Text
                , this.lblRed5.Text
                , this.lblRed6.Text
                , this.lblBlue.Text));
        }

        #region random 分组
        /// <summary>
        /// 6个list string
        /// </summary>
        /// <returns></returns>
        private List<List<string>> Group()
        {
            List<List<string>> listList = new List<List<string>>()
            {
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>()
            };
            for (int i = 0; i < this.RedNums.Length; i++)
            {
                int num = this.GetRandom(0, 1000);
                int groupNum = num % 6;
                if (listList[groupNum].Count() == 6)
                    i--;
                else
                    listList[groupNum].Add(this.RedNums[i]);
            }
            return listList;
        }
        #endregion


        #region Random 扩展
        /// <summary>
        /// 扩展的random方法
        /// </summary>
        /// <param name="min">可以获取到</param>
        /// <param name="max">可以获取到max-1</param>
        /// <returns></returns>
        private int GetRandom(int min, int max)
        {
            Guid guid = Guid.NewGuid();
            string sGuid = guid.ToString();
            int seed = DateTime.Now.Millisecond;
            for (int i = 0; i < sGuid.Length; i++)
            {
                switch (sGuid[i])
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed = seed + 1;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed = seed + 2;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed = seed + 3;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed = seed + 3;
                        break;
                    default:
                        seed = seed + 4;
                        break;
                }
            }
            Random random = new Random(seed);
            return random.Next(min, max);
        }
        #endregion
    }
}
