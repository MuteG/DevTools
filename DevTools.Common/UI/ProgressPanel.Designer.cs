namespace DevTools.Common.UI
{
    partial class ProgressPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMainMessage = new System.Windows.Forms.Label();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.labelSubMessage = new System.Windows.Forms.Label();
            this.progressBarSub = new System.Windows.Forms.ProgressBar();
            this.labelMainPersent = new System.Windows.Forms.Label();
            this.labelSubPersent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMainMessage
            // 
            this.labelMainMessage.AutoSize = true;
            this.labelMainMessage.Location = new System.Drawing.Point(7, 7);
            this.labelMainMessage.Name = "labelMainMessage";
            this.labelMainMessage.Size = new System.Drawing.Size(101, 12);
            this.labelMainMessage.TabIndex = 0;
            this.labelMainMessage.Text = "labelMainMessage";
            // 
            // progressBarMain
            // 
            this.progressBarMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarMain.Location = new System.Drawing.Point(7, 22);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(250, 23);
            this.progressBarMain.TabIndex = 1;
            // 
            // labelSubMessage
            // 
            this.labelSubMessage.AutoSize = true;
            this.labelSubMessage.Location = new System.Drawing.Point(7, 59);
            this.labelSubMessage.Name = "labelSubMessage";
            this.labelSubMessage.Size = new System.Drawing.Size(95, 12);
            this.labelSubMessage.TabIndex = 2;
            this.labelSubMessage.Text = "labelSubMessage";
            // 
            // progressBarSub
            // 
            this.progressBarSub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarSub.Location = new System.Drawing.Point(7, 74);
            this.progressBarSub.Name = "progressBarSub";
            this.progressBarSub.Size = new System.Drawing.Size(250, 23);
            this.progressBarSub.TabIndex = 3;
            // 
            // labelMainPersent
            // 
            this.labelMainPersent.AutoSize = true;
            this.labelMainPersent.Location = new System.Drawing.Point(263, 27);
            this.labelMainPersent.Name = "labelMainPersent";
            this.labelMainPersent.Size = new System.Drawing.Size(23, 12);
            this.labelMainPersent.TabIndex = 4;
            this.labelMainPersent.Text = "00%";
            // 
            // labelSubPersent
            // 
            this.labelSubPersent.AutoSize = true;
            this.labelSubPersent.Location = new System.Drawing.Point(263, 79);
            this.labelSubPersent.Name = "labelSubPersent";
            this.labelSubPersent.Size = new System.Drawing.Size(23, 12);
            this.labelSubPersent.TabIndex = 5;
            this.labelSubPersent.Text = "00%";
            // 
            // ProgressPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSubPersent);
            this.Controls.Add(this.labelMainPersent);
            this.Controls.Add(this.progressBarSub);
            this.Controls.Add(this.labelSubMessage);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.labelMainMessage);
            this.Name = "ProgressPanel";
            this.Size = new System.Drawing.Size(293, 105);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMainMessage;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.Label labelSubMessage;
        private System.Windows.Forms.ProgressBar progressBarSub;
        private System.Windows.Forms.Label labelMainPersent;
        private System.Windows.Forms.Label labelSubPersent;
    }
}
