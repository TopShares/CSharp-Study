namespace Task03
{
    partial class FrmThread
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnMyScheduler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(132, 134);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(231, 39);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "异步更新数据";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(173, 83);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(137, 12);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "这个是异步更新的数据！";
            // 
            // btnMyScheduler
            // 
            this.btnMyScheduler.Location = new System.Drawing.Point(132, 196);
            this.btnMyScheduler.Name = "btnMyScheduler";
            this.btnMyScheduler.Size = new System.Drawing.Size(231, 39);
            this.btnMyScheduler.TabIndex = 0;
            this.btnMyScheduler.Text = "调用自定义的Scheduler";
            this.btnMyScheduler.UseVisualStyleBackColor = true;
            this.btnMyScheduler.Click += new System.EventHandler(this.btnMyScheduler_Click);
            // 
            // FrmThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 270);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnMyScheduler);
            this.Controls.Add(this.btnUpdate);
            this.Name = "FrmThread";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI线程的访问";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnMyScheduler;
    }
}

