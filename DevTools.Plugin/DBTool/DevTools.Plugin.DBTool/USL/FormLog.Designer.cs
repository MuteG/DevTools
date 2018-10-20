namespace DevTools.Plugin.DBTool.USL
{
    partial class FormLog
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
            this.rtbLogList = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbLogList
            // 
            this.rtbLogList.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.rtbLogList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogList.Location = new System.Drawing.Point(0, 0);
            this.rtbLogList.Name = "rtbLogList";
            this.rtbLogList.Size = new System.Drawing.Size(284, 261);
            this.rtbLogList.TabIndex = 17;
            this.rtbLogList.Text = "";
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.rtbLogList);
            this.Name = "FormLog";
            this.Text = "日志";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLogList;
    }
}