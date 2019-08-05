namespace _03_ThreadTest
{
    partial class FrmThead
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExecute1 = new System.Windows.Forms.Button();
            this.btnExecute2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExecute1
            // 
            this.btnExecute1.Location = new System.Drawing.Point(36, 48);
            this.btnExecute1.Name = "btnExecute1";
            this.btnExecute1.Size = new System.Drawing.Size(104, 23);
            this.btnExecute1.TabIndex = 0;
            this.btnExecute1.Text = "执行任务【1】";
            this.btnExecute1.UseVisualStyleBackColor = true;
            this.btnExecute1.Click += new System.EventHandler(this.btnExecute1_Click);
            // 
            // btnExecute2
            // 
            this.btnExecute2.Location = new System.Drawing.Point(182, 48);
            this.btnExecute2.Name = "btnExecute2";
            this.btnExecute2.Size = new System.Drawing.Size(104, 23);
            this.btnExecute2.TabIndex = 0;
            this.btnExecute2.Text = "执行任务【2】";
            this.btnExecute2.UseVisualStyleBackColor = true;
            this.btnExecute2.Click += new System.EventHandler(this.btnExecute2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 136);
            this.Controls.Add(this.btnExecute2);
            this.Controls.Add(this.btnExecute1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "线程测试";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExecute1;
        private System.Windows.Forms.Button btnExecute2;
    }
}

