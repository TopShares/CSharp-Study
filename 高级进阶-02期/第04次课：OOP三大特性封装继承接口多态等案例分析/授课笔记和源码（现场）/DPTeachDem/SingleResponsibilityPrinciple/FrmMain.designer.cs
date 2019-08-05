namespace SingleResponsibilityPrinciple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnModifyPwd = new System.Windows.Forms.Button();
            this.btnTeacherManage = new System.Windows.Forms.Button();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnProductManage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckbAutoClear = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCourseList = new System.Windows.Forms.DataGridView();
            this.txtClassHour = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxCourseInfo = new System.Windows.Forms.GroupBox();
            this.txtCourseContent = new System.Windows.Forms.TextBox();
            this.btnSaveToDB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseList)).BeginInit();
            this.groupBoxCourseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(920, 66);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(56)))), ((int)(((byte)(117)))));
            this.lblCurrentUser.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentUser.Location = new System.Drawing.Point(809, 27);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(76, 23);
            this.lblCurrentUser.TabIndex = 25;
            this.lblCurrentUser.Text = "Nora老师";
            this.lblCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(56)))), ((int)(((byte)(117)))));
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(891, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 23);
            this.label5.TabIndex = 26;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(109)))), ((int)(((byte)(176)))));
            this.panel2.Controls.Add(this.monthCalendar1);
            this.panel2.Controls.Add(this.btnModifyPwd);
            this.panel2.Controls.Add(this.btnTeacherManage);
            this.panel2.Controls.Add(this.btnAddCourse);
            this.panel2.Controls.Add(this.btnProductManage);
            this.panel2.Location = new System.Drawing.Point(9, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 468);
            this.panel2.TabIndex = 27;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(-6, -8);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 31;
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnModifyPwd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnModifyPwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyPwd.ForeColor = System.Drawing.Color.White;
            this.btnModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyPwd.Image")));
            this.btnModifyPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyPwd.Location = new System.Drawing.Point(29, 410);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(149, 39);
            this.btnModifyPwd.TabIndex = 30;
            this.btnModifyPwd.Text = "     修 改 登 录 密 码";
            this.btnModifyPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyPwd.UseVisualStyleBackColor = false;
            // 
            // btnTeacherManage
            // 
            this.btnTeacherManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnTeacherManage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnTeacherManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeacherManage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTeacherManage.ForeColor = System.Drawing.Color.White;
            this.btnTeacherManage.Image = ((System.Drawing.Image)(resources.GetObject("btnTeacherManage.Image")));
            this.btnTeacherManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeacherManage.Location = new System.Drawing.Point(29, 290);
            this.btnTeacherManage.Name = "btnTeacherManage";
            this.btnTeacherManage.Size = new System.Drawing.Size(149, 39);
            this.btnTeacherManage.TabIndex = 29;
            this.btnTeacherManage.Text = "     讲 师 信 息 管 理";
            this.btnTeacherManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeacherManage.UseVisualStyleBackColor = false;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnAddCourse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddCourse.ForeColor = System.Drawing.Color.White;
            this.btnAddCourse.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCourse.Image")));
            this.btnAddCourse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCourse.Location = new System.Drawing.Point(29, 200);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(149, 39);
            this.btnAddCourse.TabIndex = 28;
            this.btnAddCourse.Text = "     添 加 课 程 信 息";
            this.btnAddCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCourse.UseVisualStyleBackColor = false;
            // 
            // btnProductManage
            // 
            this.btnProductManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnProductManage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnProductManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductManage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProductManage.ForeColor = System.Drawing.Color.White;
            this.btnProductManage.Image = ((System.Drawing.Image)(resources.GetObject("btnProductManage.Image")));
            this.btnProductManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductManage.Location = new System.Drawing.Point(29, 245);
            this.btnProductManage.Name = "btnProductManage";
            this.btnProductManage.Size = new System.Drawing.Size(149, 39);
            this.btnProductManage.TabIndex = 28;
            this.btnProductManage.Text = "     课 程 信 息 管 理";
            this.btnProductManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductManage.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(54)))), ((int)(((byte)(115)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(54)))), ((int)(((byte)(115)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(888, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "×";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.lblCount);
            this.panelRight.Controls.Add(this.dgvCourseList);
            this.panelRight.Controls.Add(this.btnClose);
            this.panelRight.Controls.Add(this.groupBoxCourseInfo);
            this.panelRight.Controls.Add(this.btnSaveToDB);
            this.panelRight.Controls.Add(this.label2);
            this.panelRight.Controls.Add(this.label7);
            this.panelRight.Controls.Add(this.label10);
            this.panelRight.Location = new System.Drawing.Point(222, 73);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(690, 470);
            this.panelRight.TabIndex = 27;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCount.Location = new System.Drawing.Point(303, 13);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(17, 20);
            this.lblCount.TabIndex = 47;
            this.lblCount.Text = "0";
            // 
            // CategoryName
            // 
            this.CategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "课程分类";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // CourseContent
            // 
            this.CourseContent.DataPropertyName = "CourseContent";
            this.CourseContent.HeaderText = "内容概述";
            this.CourseContent.Name = "CourseContent";
            this.CourseContent.ReadOnly = true;
            this.CourseContent.Width = 280;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            this.Credit.Frozen = true;
            this.Credit.HeaderText = "学分";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Width = 50;
            // 
            // ClassHour
            // 
            this.ClassHour.DataPropertyName = "ClassHour";
            this.ClassHour.Frozen = true;
            this.ClassHour.HeaderText = "课时";
            this.ClassHour.Name = "ClassHour";
            this.ClassHour.ReadOnly = true;
            this.ClassHour.Width = 50;
            // 
            // ckbAutoClear
            // 
            this.ckbAutoClear.AutoSize = true;
            this.ckbAutoClear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbAutoClear.Location = new System.Drawing.Point(75, -2);
            this.ckbAutoClear.Name = "ckbAutoClear";
            this.ckbAutoClear.Size = new System.Drawing.Size(135, 21);
            this.ckbAutoClear.TabIndex = 32;
            this.ckbAutoClear.Text = "添加后自动清除文本";
            this.ckbAutoClear.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(451, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "课程学分：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(300, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "课时总数：";
            // 
            // txtCredit
            // 
            this.txtCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCredit.Location = new System.Drawing.Point(520, 31);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(109, 21);
            this.txtCredit.TabIndex = 30;
            this.txtCredit.Text = "20";
            // 
            // CourseName
            // 
            this.CourseName.DataPropertyName = "CourseName";
            this.CourseName.Frozen = true;
            this.CourseName.HeaderText = "课程名称";
            this.CourseName.Name = "CourseName";
            this.CourseName.ReadOnly = true;
            this.CourseName.Width = 150;
            // 
            // dgvCourseList
            // 
            this.dgvCourseList.AllowUserToAddRows = false;
            this.dgvCourseList.AllowUserToDeleteRows = false;
            this.dgvCourseList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvCourseList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCourseList.ColumnHeadersHeight = 30;
            this.dgvCourseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseName,
            this.ClassHour,
            this.Credit,
            this.CourseContent,
            this.CategoryName});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCourseList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCourseList.EnableHeadersVisualStyles = false;
            this.dgvCourseList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.dgvCourseList.Location = new System.Drawing.Point(16, 178);
            this.dgvCourseList.Name = "dgvCourseList";
            this.dgvCourseList.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourseList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCourseList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCourseList.RowTemplate.Height = 23;
            this.dgvCourseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourseList.Size = new System.Drawing.Size(662, 281);
            this.dgvCourseList.TabIndex = 45;
            // 
            // txtClassHour
            // 
            this.txtClassHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassHour.Location = new System.Drawing.Point(374, 31);
            this.txtClassHour.Name = "txtClassHour";
            this.txtClassHour.Size = new System.Drawing.Size(63, 21);
            this.txtClassHour.TabIndex = 30;
            this.txtClassHour.Text = "150";
            // 
            // txtCourseName
            // 
            this.txtCourseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCourseName.Location = new System.Drawing.Point(75, 31);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(219, 21);
            this.txtCourseName.TabIndex = 30;
            this.txtCourseName.Text = ".Net高级进阶VIP课程";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "内容概述：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(6, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 17);
            this.label24.TabIndex = 29;
            this.label24.Text = "课程名称：";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(587, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 27);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "   关闭窗口";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // groupBoxCourseInfo
            // 
            this.groupBoxCourseInfo.Controls.Add(this.ckbAutoClear);
            this.groupBoxCourseInfo.Controls.Add(this.label4);
            this.groupBoxCourseInfo.Controls.Add(this.label3);
            this.groupBoxCourseInfo.Controls.Add(this.txtCredit);
            this.groupBoxCourseInfo.Controls.Add(this.txtClassHour);
            this.groupBoxCourseInfo.Controls.Add(this.txtCourseName);
            this.groupBoxCourseInfo.Controls.Add(this.txtCourseContent);
            this.groupBoxCourseInfo.Controls.Add(this.label1);
            this.groupBoxCourseInfo.Controls.Add(this.label24);
            this.groupBoxCourseInfo.Location = new System.Drawing.Point(16, 54);
            this.groupBoxCourseInfo.Name = "groupBoxCourseInfo";
            this.groupBoxCourseInfo.Size = new System.Drawing.Size(662, 108);
            this.groupBoxCourseInfo.TabIndex = 44;
            this.groupBoxCourseInfo.TabStop = false;
            this.groupBoxCourseInfo.Text = "[课程信息]";
            // 
            // txtCourseContent
            // 
            this.txtCourseContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCourseContent.Location = new System.Drawing.Point(75, 68);
            this.txtCourseContent.Name = "txtCourseContent";
            this.txtCourseContent.Size = new System.Drawing.Size(554, 21);
            this.txtCourseContent.TabIndex = 30;
            this.txtCourseContent.Text = "C#语法/OOP/SQL/Winform/HTML/jQuery/MVC/EF/WCF/WPF/.Net Coure";
            // 
            // btnSaveToDB
            // 
            this.btnSaveToDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(155)))), ((int)(((byte)(252)))));
            this.btnSaveToDB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnSaveToDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToDB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveToDB.ForeColor = System.Drawing.Color.White;
            this.btnSaveToDB.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveToDB.Image")));
            this.btnSaveToDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToDB.Location = new System.Drawing.Point(449, 13);
            this.btnSaveToDB.Name = "btnSaveToDB";
            this.btnSaveToDB.Size = new System.Drawing.Size(134, 27);
            this.btnSaveToDB.TabIndex = 43;
            this.btnSaveToDB.Text = "  保存到数据库";
            this.btnSaveToDB.UseVisualStyleBackColor = false;
            this.btnSaveToDB.Click += new System.EventHandler(this.btnSaveToDB_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(1, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(685, 10);
            this.label2.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "当前位置：新增课程";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(196, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 17);
            this.label10.TabIndex = 48;
            this.label10.Text = "已添加课程总数：";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(184)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(920, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseList)).EndInit();
            this.groupBoxCourseInfo.ResumeLayout(false);
            this.groupBoxCourseInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTeacherManage;
        private System.Windows.Forms.Button btnProductManage;
        private System.Windows.Forms.Button btnModifyPwd;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvCourseList;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxCourseInfo;
        private System.Windows.Forms.CheckBox ckbAutoClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.TextBox txtClassHour;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.TextBox txtCourseContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnSaveToDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
    }
}