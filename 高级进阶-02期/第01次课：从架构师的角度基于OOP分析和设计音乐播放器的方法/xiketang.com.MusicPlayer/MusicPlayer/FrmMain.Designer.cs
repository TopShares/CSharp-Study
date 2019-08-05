namespace MusicPlayer
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.myPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.lbVideoList = new System.Windows.Forms.ListBox();
            this.imageListICO = new System.Windows.Forms.ImageList(this.components);
            this.btnMin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel_bar = new System.Windows.Forms.Panel();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPause_Start = new System.Windows.Forms.Button();
            this.trackBar_Voice = new System.Windows.Forms.TrackBar();
            this.llblPlayList = new System.Windows.Forms.LinkLabel();
            this.llblPaly_3 = new System.Windows.Forms.LinkLabel();
            this.llblPaly_2 = new System.Windows.Forms.LinkLabel();
            this.llblPaly_1 = new System.Windows.Forms.LinkLabel();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.lblCurrentPlayedFile = new System.Windows.Forms.Label();
            this.pb_Voice = new System.Windows.Forms.PictureBox();
            this.trackBar_Position = new System.Windows.Forms.TrackBar();
            this.timer_ShowPostion = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llblLogin = new System.Windows.Forms.LinkLabel();
            this.llblSaveAs = new System.Windows.Forms.LinkLabel();
            this.llblClear = new System.Windows.Forms.LinkLabel();
            this.llblChose = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelPlayList = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClosePanel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.myPlayer)).BeginInit();
            this.panel_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Voice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Voice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPlayList.SuspendLayout();
            this.SuspendLayout();
            // 
            // myPlayer
            // 
            this.myPlayer.Enabled = true;
            this.myPlayer.Location = new System.Drawing.Point(188, 49);
            this.myPlayer.Name = "myPlayer";
            this.myPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("myPlayer.OcxState")));
            this.myPlayer.Size = new System.Drawing.Size(798, 479);
            this.myPlayer.TabIndex = 1;
            // 
            // lbVideoList
            // 
            this.lbVideoList.AllowDrop = true;
            this.lbVideoList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.lbVideoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbVideoList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbVideoList.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbVideoList.FormattingEnabled = true;
            this.lbVideoList.ItemHeight = 17;
            this.lbVideoList.Location = new System.Drawing.Point(1, 34);
            this.lbVideoList.Margin = new System.Windows.Forms.Padding(0);
            this.lbVideoList.Name = "lbVideoList";
            this.lbVideoList.Size = new System.Drawing.Size(371, 408);
            this.lbVideoList.TabIndex = 2;
            this.lbVideoList.SelectedIndexChanged += new System.EventHandler(this.lbVideoList_SelectedIndexChanged);
            this.lbVideoList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbVideoList_DragDrop);
            this.lbVideoList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbVideoList_DragEnter);
            // 
            // imageListICO
            // 
            this.imageListICO.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListICO.ImageStream")));
            this.imageListICO.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListICO.Images.SetKeyName(0, "stop.ico");
            this.imageListICO.Images.SetKeyName(1, "继续.bmp");
            this.imageListICO.Images.SetKeyName(2, "login.png");
            this.imageListICO.Images.SetKeyName(3, "Msg.ico");
            // 
            // btnMin
            // 
            this.btnMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMin.Location = new System.Drawing.Point(920, 12);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(29, 23);
            this.btnMin.TabIndex = 3;
            this.btnMin.Text = "▁";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Location = new System.Drawing.Point(955, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel_bar
            // 
            this.panel_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.panel_bar.Controls.Add(this.btnPre);
            this.panel_bar.Controls.Add(this.btnNext);
            this.panel_bar.Controls.Add(this.btnPause_Start);
            this.panel_bar.Controls.Add(this.trackBar_Voice);
            this.panel_bar.Controls.Add(this.llblPlayList);
            this.panel_bar.Controls.Add(this.llblPaly_3);
            this.panel_bar.Controls.Add(this.llblPaly_2);
            this.panel_bar.Controls.Add(this.llblPaly_1);
            this.panel_bar.Controls.Add(this.lblTotalTime);
            this.panel_bar.Controls.Add(this.label1);
            this.panel_bar.Controls.Add(this.lblCurrentPosition);
            this.panel_bar.Controls.Add(this.lblCurrentPlayedFile);
            this.panel_bar.Controls.Add(this.pb_Voice);
            this.panel_bar.Controls.Add(this.trackBar_Position);
            this.panel_bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bar.Location = new System.Drawing.Point(0, 537);
            this.panel_bar.Name = "panel_bar";
            this.panel_bar.Size = new System.Drawing.Size(1002, 74);
            this.panel_bar.TabIndex = 8;
            // 
            // btnPre
            // 
            this.btnPre.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.btnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.Location = new System.Drawing.Point(18, 15);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(42, 43);
            this.btnPre.TabIndex = 9;
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(129, 14);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(42, 43);
            this.btnNext.TabIndex = 9;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPause_Start
            // 
            this.btnPause_Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.btnPause_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause_Start.Image = ((System.Drawing.Image)(resources.GetObject("btnPause_Start.Image")));
            this.btnPause_Start.Location = new System.Drawing.Point(72, 13);
            this.btnPause_Start.Name = "btnPause_Start";
            this.btnPause_Start.Size = new System.Drawing.Size(45, 45);
            this.btnPause_Start.TabIndex = 9;
            this.btnPause_Start.Tag = "暂停";
            this.btnPause_Start.UseVisualStyleBackColor = true;
            this.btnPause_Start.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // trackBar_Voice
            // 
            this.trackBar_Voice.Location = new System.Drawing.Point(583, 27);
            this.trackBar_Voice.Maximum = 100;
            this.trackBar_Voice.Name = "trackBar_Voice";
            this.trackBar_Voice.Size = new System.Drawing.Size(117, 45);
            this.trackBar_Voice.TabIndex = 4;
            this.trackBar_Voice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Voice.Scroll += new System.EventHandler(this.trackBar_Voice_Scroll);
            // 
            // llblPlayList
            // 
            this.llblPlayList.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.llblPlayList.Image = ((System.Drawing.Image)(resources.GetObject("llblPlayList.Image")));
            this.llblPlayList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblPlayList.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblPlayList.LinkColor = System.Drawing.SystemColors.ButtonFace;
            this.llblPlayList.Location = new System.Drawing.Point(960, 25);
            this.llblPlayList.Name = "llblPlayList";
            this.llblPlayList.Size = new System.Drawing.Size(30, 23);
            this.llblPlayList.TabIndex = 6;
            this.llblPlayList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblPlayList.Click += new System.EventHandler(this.llblPlayList_Click);
            this.llblPlayList.MouseHover += new System.EventHandler(this.llblPlayList_MouseHover);
            // 
            // llblPaly_3
            // 
            this.llblPaly_3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.llblPaly_3.Image = ((System.Drawing.Image)(resources.GetObject("llblPaly_3.Image")));
            this.llblPaly_3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblPaly_3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblPaly_3.LinkColor = System.Drawing.SystemColors.ButtonFace;
            this.llblPaly_3.Location = new System.Drawing.Point(877, 25);
            this.llblPaly_3.Name = "llblPaly_3";
            this.llblPaly_3.Size = new System.Drawing.Size(77, 23);
            this.llblPaly_3.TabIndex = 6;
            this.llblPaly_3.TabStop = true;
            this.llblPaly_3.Text = "    单曲循环";
            this.llblPaly_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblPaly_3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PlayMode);
            // 
            // llblPaly_2
            // 
            this.llblPaly_2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.llblPaly_2.Image = ((System.Drawing.Image)(resources.GetObject("llblPaly_2.Image")));
            this.llblPaly_2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblPaly_2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblPaly_2.LinkColor = System.Drawing.SystemColors.ButtonFace;
            this.llblPaly_2.Location = new System.Drawing.Point(794, 25);
            this.llblPaly_2.Name = "llblPaly_2";
            this.llblPaly_2.Size = new System.Drawing.Size(77, 22);
            this.llblPaly_2.TabIndex = 6;
            this.llblPaly_2.TabStop = true;
            this.llblPaly_2.Text = "    循环播放";
            this.llblPaly_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblPaly_2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PlayMode);
            // 
            // llblPaly_1
            // 
            this.llblPaly_1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.llblPaly_1.Image = ((System.Drawing.Image)(resources.GetObject("llblPaly_1.Image")));
            this.llblPaly_1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblPaly_1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblPaly_1.LinkColor = System.Drawing.SystemColors.ButtonFace;
            this.llblPaly_1.Location = new System.Drawing.Point(711, 25);
            this.llblPaly_1.Name = "llblPaly_1";
            this.llblPaly_1.Size = new System.Drawing.Size(77, 21);
            this.llblPaly_1.TabIndex = 6;
            this.llblPaly_1.TabStop = true;
            this.llblPaly_1.Text = "    顺序播放";
            this.llblPaly_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblPaly_1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PlayMode);
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTotalTime.Location = new System.Drawing.Point(506, 12);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(47, 12);
            this.lblTotalTime.TabIndex = 8;
            this.lblTotalTime.Text = "0:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(495, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "/";
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.AutoSize = true;
            this.lblCurrentPosition.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCurrentPosition.Location = new System.Drawing.Point(461, 12);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(35, 12);
            this.lblCurrentPosition.TabIndex = 8;
            this.lblCurrentPosition.Text = "00:00";
            // 
            // lblCurrentPlayedFile
            // 
            this.lblCurrentPlayedFile.AutoSize = true;
            this.lblCurrentPlayedFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCurrentPlayedFile.Location = new System.Drawing.Point(202, 11);
            this.lblCurrentPlayedFile.Name = "lblCurrentPlayedFile";
            this.lblCurrentPlayedFile.Size = new System.Drawing.Size(71, 12);
            this.lblCurrentPlayedFile.TabIndex = 8;
            this.lblCurrentPlayedFile.Text = "当前播放...";
            // 
            // pb_Voice
            // 
            this.pb_Voice.Image = ((System.Drawing.Image)(resources.GetObject("pb_Voice.Image")));
            this.pb_Voice.Location = new System.Drawing.Point(556, 20);
            this.pb_Voice.Name = "pb_Voice";
            this.pb_Voice.Size = new System.Drawing.Size(30, 33);
            this.pb_Voice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Voice.TabIndex = 7;
            this.pb_Voice.TabStop = false;
            this.pb_Voice.Tag = "normal";
            this.pb_Voice.Click += new System.EventHandler(this.pb_Voice_Click);
            // 
            // trackBar_Position
            // 
            this.trackBar_Position.Location = new System.Drawing.Point(195, 38);
            this.trackBar_Position.Maximum = 100;
            this.trackBar_Position.Name = "trackBar_Position";
            this.trackBar_Position.Size = new System.Drawing.Size(364, 45);
            this.trackBar_Position.TabIndex = 4;
            this.trackBar_Position.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Position.Scroll += new System.EventHandler(this.trackBar_Position_Scroll);
            // 
            // timer_ShowPostion
            // 
            this.timer_ShowPostion.Tick += new System.EventHandler(this.timer_ShowPostion_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // llblLogin
            // 
            this.llblLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.llblLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblLogin.ImageKey = "(无)";
            this.llblLogin.ImageList = this.imageListICO;
            this.llblLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblLogin.LinkColor = System.Drawing.SystemColors.ButtonHighlight;
            this.llblLogin.Location = new System.Drawing.Point(66, 19);
            this.llblLogin.Name = "llblLogin";
            this.llblLogin.Size = new System.Drawing.Size(87, 22);
            this.llblLogin.TabIndex = 6;
            this.llblLogin.TabStop = true;
            this.llblLogin.Text = "喜科堂播放器";
            this.llblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llblSaveAs
            // 
            this.llblSaveAs.AutoSize = true;
            this.llblSaveAs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.llblSaveAs.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.llblSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("llblSaveAs.Image")));
            this.llblSaveAs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblSaveAs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblSaveAs.LinkColor = System.Drawing.SystemColors.ButtonFace;
            this.llblSaveAs.Location = new System.Drawing.Point(25, 144);
            this.llblSaveAs.Name = "llblSaveAs";
            this.llblSaveAs.Size = new System.Drawing.Size(65, 12);
            this.llblSaveAs.TabIndex = 6;
            this.llblSaveAs.TabStop = true;
            this.llblSaveAs.Text = "    另存为";
            this.llblSaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblSaveAs.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // llblClear
            // 
            this.llblClear.AutoSize = true;
            this.llblClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.llblClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.llblClear.Image = ((System.Drawing.Image)(resources.GetObject("llblClear.Image")));
            this.llblClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblClear.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblClear.LinkColor = System.Drawing.SystemColors.ButtonFace;
            this.llblClear.Location = new System.Drawing.Point(25, 115);
            this.llblClear.Name = "llblClear";
            this.llblClear.Size = new System.Drawing.Size(77, 12);
            this.llblClear.TabIndex = 6;
            this.llblClear.TabStop = true;
            this.llblClear.Text = "    清空列表";
            this.llblClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // llblChose
            // 
            this.llblChose.AutoSize = true;
            this.llblChose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.llblChose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.llblChose.Image = ((System.Drawing.Image)(resources.GetObject("llblChose.Image")));
            this.llblChose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblChose.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblChose.LinkColor = System.Drawing.SystemColors.ButtonFace;
            this.llblChose.Location = new System.Drawing.Point(25, 86);
            this.llblChose.Name = "llblChose";
            this.llblChose.Size = new System.Drawing.Size(77, 12);
            this.llblChose.TabIndex = 6;
            this.llblChose.TabStop = true;
            this.llblChose.Text = "    选择文件";
            this.llblChose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblChose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblChose_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(185, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(581, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "喜科堂互联教育网址：xiketang.ke.qq.com --.NET高级进阶VIP课程专用项目       （版权所有，侵权必究）";
            // 
            // panelPlayList
            // 
            this.panelPlayList.BackColor = System.Drawing.Color.Black;
            this.panelPlayList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayList.Controls.Add(this.lbVideoList);
            this.panelPlayList.Controls.Add(this.label3);
            this.panelPlayList.Controls.Add(this.btnClosePanel);
            this.panelPlayList.Location = new System.Drawing.Point(630, 93);
            this.panelPlayList.Name = "panelPlayList";
            this.panelPlayList.Size = new System.Drawing.Size(371, 444);
            this.panelPlayList.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "正在播放内容列表...";
            // 
            // btnClosePanel
            // 
            this.btnClosePanel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClosePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosePanel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClosePanel.Location = new System.Drawing.Point(337, 4);
            this.btnClosePanel.Name = "btnClosePanel";
            this.btnClosePanel.Size = new System.Drawing.Size(29, 23);
            this.btnClosePanel.TabIndex = 3;
            this.btnClosePanel.Text = "×";
            this.btnClosePanel.UseVisualStyleBackColor = true;
            this.btnClosePanel.Click += new System.EventHandler(this.btnClosePanel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 479);
            this.panel1.TabIndex = 11;
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1002, 611);
            this.Controls.Add(this.panelPlayList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel_bar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.llblLogin);
            this.Controls.Add(this.llblSaveAs);
            this.Controls.Add(this.llblClear);
            this.Controls.Add(this.llblChose);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.myPlayer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的视频播放器-【喜科堂互联教育】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.myPlayer)).EndInit();
            this.panel_bar.ResumeLayout(false);
            this.panel_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Voice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Voice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPlayList.ResumeLayout(false);
            this.panelPlayList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer myPlayer;
        private System.Windows.Forms.ListBox lbVideoList;
        private System.Windows.Forms.ImageList imageListICO;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llblChose;
        private System.Windows.Forms.LinkLabel llblClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llblLogin;
        private System.Windows.Forms.Panel panel_bar;
        private System.Windows.Forms.TrackBar trackBar_Position;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Label lblCurrentPlayedFile;
        private System.Windows.Forms.TrackBar trackBar_Voice;
        private System.Windows.Forms.PictureBox pb_Voice;
        private System.Windows.Forms.Button btnPause_Start;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.LinkLabel llblPaly_3;
        private System.Windows.Forms.LinkLabel llblPaly_2;
        private System.Windows.Forms.LinkLabel llblPaly_1;
        private System.Windows.Forms.LinkLabel llblSaveAs;
        private System.Windows.Forms.Timer timer_ShowPostion;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llblPlayList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelPlayList;
        private System.Windows.Forms.Button btnClosePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}