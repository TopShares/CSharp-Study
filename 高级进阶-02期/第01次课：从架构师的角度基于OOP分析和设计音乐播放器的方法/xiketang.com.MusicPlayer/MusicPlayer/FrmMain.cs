using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace MusicPlayer
{
    /// <summary>
    /// 喜科堂互联教育网址：xiketang.ke.qq.com
    /// 原创设计：常慧勇    QQ：2934008878
    /// 版权声明：版权所有，侵权必究。本项目源码是开放式设计，不能用于任何商业用途！
    /// 如有更改，请标注哪些更改！
    /// 本课程地址：https://ke.qq.com/course/248962
    /// </summary>
    public partial class FrmMain : Form
    {
        //【1】初始化当前播放器操作类
        private PlayerCore playerCore = new PlayerCore();


        #region 项目初始化

        public FrmMain()
        {
            InitializeComponent();

            //【1】禁用按钮
            this.btnPause_Start.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnPre.Enabled = false;
            this.llblSaveAs.Enabled = false;
            this.llblClear.Enabled = false;

            //【2】禁用播放器下半部分的功能按钮
            this.myPlayer.uiMode = "none";

            //【3】隐藏播放列表
            //this.lbVideoList.Visible = false;
            this.panelPlayList.Visible = false;

            //使用RGB设置下面背景条颜色和相关按钮的边框颜色
            //this.panel_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            //this.btnPre.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));

            //【3】设置定时器的时间间隔
            this.timer_ShowPostion.Interval = 200;

            //【4】加载最新播放列表
            LoadList();

            this.playerCore.PlayMode = "顺序播放";
        }

        //加载最新播放列表
        private void LoadList()
        {
            if (playerCore.LoadNewList())
            {
                //【1】显示播放列表
                this.lbVideoList.Items.AddRange(this.playerCore.FileList.Keys.ToArray());

                //【2】读取上次播放的位置并自动播放
                int index = this.playerCore.ReadPlayIndex();
                if (index > this.lbVideoList.Items.Count - 1 || index == -1)//如果保存的播放记录所对应的文件被删除或文件丢失
                {
                    this.lbVideoList.SelectedIndex = 0;
                }
                else
                {
                    this.lbVideoList.SelectedIndex = index;
                }
                lbVideoList_SelectedIndexChanged(null, null);

                //【3】开启按钮
                this.btnPause_Start.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnPre.Enabled = true;
                this.llblSaveAs.Enabled = true;
                this.llblClear.Enabled = true;
            }
        }

        #endregion

        #region 浏览选择文件、拖拽上传文件

        //添加到列表
        private void AddList(string[] fileNames)
        {
            //将选中的文件添加到文件集合和控件列表
            foreach (string path in fileNames)
            {
                //判断扩展名是否符合要求，自动过滤不符合要求的扩展名文件（此处省略，请自行完成...）

                string fileName = path.Substring(path.LastIndexOf(@"\") + 1);//截取完整的文件名，将来播放的使用使用
                string file_Name = fileName.Substring(0, fileName.LastIndexOf("."));//没有扩展名的文件名，作为集合的Key使用

                if (playerCore.FileList.Keys.Contains(file_Name)) continue;//如果当前播放列表集合中已经包括这个文件，则不用重复添加（根据需要决定）

                //封装视频对象
                PlayedFile playedFile = new PlayedFile()
                {
                    FileName = fileName,
                    FilePath = path,
                    PlayedTotalTime = this.myPlayer.newMedia(path).duration,//获取视频播放时长
                    PlayedTotalTimeString = this.myPlayer.newMedia(path).durationString//获取视频播放时长字符串表示
                };

                //在文件播放列表《集合中》保存选择的视频列表
                playerCore.FileList.Add(file_Name, playedFile);

                //将新的播放文件，添加的《控件列表》
                this.lbVideoList.Items.AddRange(new string[] { file_Name });
            }

            this.playerCore.SaveNewList();//保存最新的播放列表

            //默认播放第一个
            if (this.lbVideoList.Items.Count == 0) return;
            this.lbVideoList.SelectedIndex = 0;
            lbVideoList_SelectedIndexChanged(null, null);

            //开启按钮
            this.btnPause_Start.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnPre.Enabled = true;
            this.llblSaveAs.Enabled = true;
            this.llblClear.Enabled = true;
        }
        //选择文件
        private void llblChose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;//设置允许选择多个文件
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //首先清除以前添加的（可以在测试出错后再讲解）
                this.playerCore.FileList.Clear();
                this.lbVideoList.Items.Clear();

                //获取所有选中的文件名,并调用添加方法  
                AddList(fileDialog.FileNames);
            }
        }

        //拖放文件
        private void lbVideoList_DragDrop(object sender, DragEventArgs e)
        {
            string[] pathList = ((string[])e.Data.GetData(DataFormats.FileDrop));//获取拖拽的一个或多个文件的路径

            AddList(pathList);//调用添加方法          
        }
        private void lbVideoList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else e.Effect = DragDropEffects.None;
        }

        #endregion

        #region 开始播放视频或音频、自动循环播放

        private void lbVideoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbVideoList.SelectedIndex == -1 || this.lbVideoList.Items.Count == 0) return;

            //【1】设置播放的URL
            string fileName = this.lbVideoList.SelectedItem.ToString();//获取当前选中的视频名称
            this.myPlayer.URL = this.playerCore.FileList[fileName].FilePath;

            //【2】设置音频的默认值
            this.trackBar_Voice.Value = this.myPlayer.settings.volume;
            //【3】设置播放时长进度最大值
            this.trackBar_Position.Maximum = (int)this.playerCore.FileList[fileName].PlayedTotalTime;
            //【4】显示文件播放时长
            this.lblTotalTime.Text = this.playerCore.FileList[fileName].PlayedTotalTimeString;
            //【5】显示当前播放文件名
            this.lblCurrentPlayedFile.Text = fileName;

            //启动定时器显示文件播放进度
            this.timer_ShowPostion.Start();

            //开启播放按钮
            this.btnPause_Start.Enabled = true;
        }

        //定时器：同步显示播放进度和循环播放
        private void timer_ShowPostion_Tick(object sender, EventArgs e)
        {
            //【1】显示当前文件的播放进度
            this.lblCurrentPosition.Text = this.myPlayer.Ctlcontrols.currentPositionString;
            //【2】显示进度条的当前播放位置
            this.trackBar_Position.Value = (int)myPlayer.Ctlcontrols.currentPosition;

            //【3】检查是否播放完毕
            if (this.myPlayer.playState.ToString() == "wmppsStopped")
            {
                this.btnPause_Start.Enabled = false;
                PlayByMode();
            }
        }


        #endregion

        #region 暂停和继续、上一首、下一首
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (this.btnPause_Start.Tag.ToString() == "暂停")
            {
                this.myPlayer.Ctlcontrols.pause();
                this.btnPause_Start.Tag = "继续";
                this.btnPause_Start.Image = Properties.Resources.btnPlay;
            }
            else
            {
                this.myPlayer.Ctlcontrols.play();
                this.btnPause_Start.Tag = "暂停";
                this.btnPause_Start.Image = Properties.Resources.btnPause;
            }
        }
        //上一首
        private void btnPre_Click(object sender, EventArgs e)
        {
            if (this.lbVideoList.SelectedIndex > 0)//如果不是第一个
            {
                this.lbVideoList.SelectedIndex -= 1;
                this.btnPause_Start.Tag = "暂停";
                this.btnPause_Start.Image = Properties.Resources.btnPause;
                lbVideoList_SelectedIndexChanged(null, null);
            }
        }
        //下一首
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.lbVideoList.SelectedIndex < this.lbVideoList.Items.Count - 1)//如果不是最后一个
            {
                this.btnPause_Start.Tag = "暂停";
                this.btnPause_Start.Image = Properties.Resources.btnPause;
                this.lbVideoList.SelectedIndex += 1;
                lbVideoList_SelectedIndexChanged(null, null);
            }
        }
        //停止
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.myPlayer.Ctlcontrols.stop();
            this.lblCurrentPlayedFile.Text = "暂无播放视频";
            this.lblCurrentPosition.Text = "00:00";
            this.lblTotalTime.Text = "00:00";
            this.btnPause_Start.Enabled = false;
            this.timer_ShowPostion.Stop();//定时器停止
        }
        #endregion

        #region 另存到新目录、清空播放列表

        //另存为
        private void btnCopy_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = folderDialog.SelectedPath;//获取选择的路径
                playerCore.SaveFileAs(path);//开始复制
                MessageBox.Show("文件复制成功！", "信息提示");
            }
        }
        //清空播放列表
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空播放列表吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                this.playerCore.ClearPlayList();
                this.lbVideoList.Items.Clear();
                this.myPlayer.Ctlcontrols.stop();

                this.btnPause_Start.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnPre.Enabled = false;
                this.llblSaveAs.Enabled = false;
                this.llblClear.Enabled = false;
            }
        }

        #endregion           

        #region 程序退出时自动保存播放位置
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.lbVideoList.SelectedIndex != -1)
            {
                this.playerCore.SavePlayIndex(this.lbVideoList.SelectedIndex);
            }
        }

        #endregion

        #region 播放器控制：调整音量、调整播放进度

        //调整音量
        private void trackBar_Voice_Scroll(object sender, EventArgs e)
        {
            this.myPlayer.settings.volume = this.trackBar_Voice.Value;
        }
        //调整播放位置
        private void trackBar_Position_Scroll(object sender, EventArgs e)
        {
            this.myPlayer.Ctlcontrols.currentPosition = this.trackBar_Position.Value;
        }
        //静音或取消静音
        private void pb_Voice_Click(object sender, EventArgs e)
        {
            if (!this.myPlayer.settings.mute)
            {
                this.myPlayer.settings.mute = true;//设置静音
                this.pb_Voice.Image = Properties.Resources.voice_mute;
            }
            else
            {
                this.myPlayer.settings.mute = false;//取消静音
                this.pb_Voice.Image = Properties.Resources.voice_ICO;
            }
        }
        #endregion     

        #region 播放模式切换和播放列表

        private void llblPlayList_Click(object sender, EventArgs e)
        {
            this.panelPlayList.Visible = !this.panelPlayList.Visible;
        }
        private void llblPlayList_MouseHover(object sender, EventArgs e)
        {
            this.panelPlayList.Visible = !this.panelPlayList.Visible;
        }
        private void btnClosePanel_Click(object sender, EventArgs e)
        {
            this.panelPlayList.Visible = false;
        }
        //设置播放模式
        private void PlayMode(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.playerCore.PlayMode = ((LinkLabel)sender).Text.Trim();

            this.llblPaly_1.Enabled = true;
            this.llblPaly_2.Enabled = true;
            this.llblPaly_3.Enabled = true;

            ((LinkLabel)sender).Enabled = false;//禁用当前的播放模式
        }
        //按照播放模式播放
        private void PlayByMode()
        {
            int playeIndex = this.lbVideoList.SelectedIndex;
            switch (this.playerCore.PlayMode)
            {
                case "循环播放":
                    if (playeIndex == this.lbVideoList.Items.Count - 1)//如果是最后一首了
                    {
                        this.lbVideoList.SelectedIndex = 0;//开始第一个播放
                        lbVideoList_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        btnNext_Click(null, null);
                    }
                    break;
                case "单曲循环":
                    lbVideoList_SelectedIndexChanged(null, null);
                    break;
                case "顺序播放":
                    if (playeIndex == this.lbVideoList.Items.Count - 1)//如果当前播放的是最后一曲
                    {
                        btnStop_Click(null, null);
                    }
                    else
                    {
                        btnNext_Click(null, null);
                    }
                    break;
                case "随机播放":
                    Random ra = new Random();
                    this.lbVideoList.SelectedIndex = ra.Next(this.lbVideoList.Items.Count - 1);
                    lbVideoList_SelectedIndexChanged(null, null);
                    break;
            }
        }
        #endregion

        #region 后续扩展...

        //播放模式、上次播放记录、上次播放进度保存到配置文件

        #endregion

        #region 其他

        #region 窗体最小化、最大化、关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMax_Click(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Maximized;
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region  拖动窗体的实现

        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        #endregion

        #endregion

    }
}
