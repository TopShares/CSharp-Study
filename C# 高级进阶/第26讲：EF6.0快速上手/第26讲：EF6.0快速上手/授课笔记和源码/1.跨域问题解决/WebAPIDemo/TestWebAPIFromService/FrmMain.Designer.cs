namespace TestWebAPIFromService
{
    partial class FrmMain
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
            this.txtReturnContent = new System.Windows.Forms.TextBox();
            this.btnCallAPI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtReturnContent
            // 
            this.txtReturnContent.Location = new System.Drawing.Point(27, 27);
            this.txtReturnContent.Multiline = true;
            this.txtReturnContent.Name = "txtReturnContent";
            this.txtReturnContent.Size = new System.Drawing.Size(461, 136);
            this.txtReturnContent.TabIndex = 0;
            // 
            // btnCallAPI
            // 
            this.btnCallAPI.Location = new System.Drawing.Point(27, 179);
            this.btnCallAPI.Name = "btnCallAPI";
            this.btnCallAPI.Size = new System.Drawing.Size(461, 42);
            this.btnCallAPI.TabIndex = 1;
            this.btnCallAPI.Text = "调用WebAPI2（基于JOSN传递实体对象为参数，并返回数据）";
            this.btnCallAPI.UseVisualStyleBackColor = true;
            this.btnCallAPI.Click += new System.EventHandler(this.btnCallAPI_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 244);
            this.Controls.Add(this.btnCallAPI);
            this.Controls.Add(this.txtReturnContent);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在服务端（后台）调用WebAPI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReturnContent;
        private System.Windows.Forms.Button btnCallAPI;
    }
}

