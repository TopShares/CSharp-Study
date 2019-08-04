using Ruanmou.SearchEngines.LuceneService.Processor;
using Ruanmou.SearchEngines.SearchService;
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

namespace Ruanmou.SearchEngines
{
    public partial class frmSearchEngine : Form
    {
        public frmSearchEngine()
        {
            InitializeComponent();
            this.btnStop.Enabled = false;
            this.btnStopWCF.Enabled = false;
        }

        private CancellationTokenSource CTS = null;

        /// <summary>
        /// 建索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("{0} id={1} 开始索引的创建", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                this.btnStart.Enabled = false;
                CTS = new CancellationTokenSource();
                new Action(() => IndexBuilder.BuildIndex(CTS)).BeginInvoke(null, null);
                this.btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} id={1} 索引创建出现异常：{2}", ex.Message);
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
        }

        /// <summary>
        /// 停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("{0} id={1} 停止索引的创建", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                if (CTS != null)
                    CTS.Cancel();
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} id={1} 停止索引出现异常：{2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, ex.Message);
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
        }


        /// <summary>
        /// 开启wcf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartWCF_Click(object sender, EventArgs e)
        {
            try
            {
                WCFInit.Start();
                this.btnStartWCF.Enabled = false;
                this.btnStopWCF.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} id={1} 停止索引出现异常：{2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, ex.Message);
                this.btnStartWCF.Enabled = true;
                this.btnStopWCF.Enabled = false;
            }
        }

        /// <summary>
        /// 关闭wcf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopWCF_Click(object sender, EventArgs e)
        {
            try
            {
                WCFInit.Stop();
                this.btnStartWCF.Enabled = true;
                this.btnStopWCF.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} id={1} 停止索引出现异常：{2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, ex.Message);
                this.btnStartWCF.Enabled = true;
                this.btnStopWCF.Enabled = false;
            }
        }


    }
}
