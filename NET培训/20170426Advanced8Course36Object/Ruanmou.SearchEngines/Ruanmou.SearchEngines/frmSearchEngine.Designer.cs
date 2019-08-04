namespace Ruanmou.SearchEngines
{
    partial class frmSearchEngine
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
            this.gboIndex = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gboSearcher = new System.Windows.Forms.GroupBox();
            this.btnStartWCF = new System.Windows.Forms.Button();
            this.btnStopWCF = new System.Windows.Forms.Button();
            this.gboIndex.SuspendLayout();
            this.gboSearcher.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboIndex
            // 
            this.gboIndex.Controls.Add(this.btnStop);
            this.gboIndex.Controls.Add(this.btnStart);
            this.gboIndex.Location = new System.Drawing.Point(22, 28);
            this.gboIndex.Name = "gboIndex";
            this.gboIndex.Size = new System.Drawing.Size(188, 92);
            this.gboIndex.TabIndex = 0;
            this.gboIndex.TabStop = false;
            this.gboIndex.Text = "Lucene索引";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(102, 40);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 40);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gboSearcher
            // 
            this.gboSearcher.Controls.Add(this.btnStopWCF);
            this.gboSearcher.Controls.Add(this.btnStartWCF);
            this.gboSearcher.Location = new System.Drawing.Point(22, 163);
            this.gboSearcher.Name = "gboSearcher";
            this.gboSearcher.Size = new System.Drawing.Size(200, 100);
            this.gboSearcher.TabIndex = 1;
            this.gboSearcher.TabStop = false;
            this.gboSearcher.Text = "搜索服务";
            // 
            // btnStartWCF
            // 
            this.btnStartWCF.Location = new System.Drawing.Point(6, 44);
            this.btnStartWCF.Name = "btnStartWCF";
            this.btnStartWCF.Size = new System.Drawing.Size(75, 23);
            this.btnStartWCF.TabIndex = 0;
            this.btnStartWCF.Text = "Start";
            this.btnStartWCF.UseVisualStyleBackColor = true;
            this.btnStartWCF.Click += new System.EventHandler(this.btnStartWCF_Click);
            // 
            // btnStopWCF
            // 
            this.btnStopWCF.Location = new System.Drawing.Point(102, 44);
            this.btnStopWCF.Name = "btnStopWCF";
            this.btnStopWCF.Size = new System.Drawing.Size(75, 23);
            this.btnStopWCF.TabIndex = 1;
            this.btnStopWCF.Text = "Stop";
            this.btnStopWCF.UseVisualStyleBackColor = true;
            this.btnStopWCF.Click += new System.EventHandler(this.btnStopWCF_Click);
            // 
            // frmSearchEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 309);
            this.Controls.Add(this.gboSearcher);
            this.Controls.Add(this.gboIndex);
            this.Name = "frmSearchEngine";
            this.Text = "SearchEngine";
            this.gboIndex.ResumeLayout(false);
            this.gboSearcher.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboIndex;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox gboSearcher;
        private System.Windows.Forms.Button btnStartWCF;
        private System.Windows.Forms.Button btnStopWCF;

    }
}

