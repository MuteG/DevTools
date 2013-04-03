/* *************************************************************************
 * Copyright (c)2012 NTT DATA BEEN (China) Information Technology Co.,Ltd.
 * 作成:高雲鵬
 * 機能:
 * 履歴:
 * 2013/04/03 新規 高雲鵬 新規作成
 * *************************************************************************/
namespace DevTools.Plugin.CodeLines.USL
{
    partial class FormMain
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxIncludeMix = new System.Windows.Forms.CheckBox();
            this.checkBoxResource = new System.Windows.Forms.CheckBox();
            this.checkBoxDesign = new System.Windows.Forms.CheckBox();
            this.checkBoxAnnotate = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // checkBoxIncludeMix
            // 
            this.checkBoxIncludeMix.AutoSize = true;
            this.checkBoxIncludeMix.Checked = true;
            this.checkBoxIncludeMix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeMix.Location = new System.Drawing.Point(294, 12);
            this.checkBoxIncludeMix.Name = "checkBoxIncludeMix";
            this.checkBoxIncludeMix.Size = new System.Drawing.Size(96, 16);
            this.checkBoxIncludeMix.TabIndex = 11;
            this.checkBoxIncludeMix.Text = "包含混合注释";
            this.checkBoxIncludeMix.UseVisualStyleBackColor = true;
            this.checkBoxIncludeMix.CheckedChanged += new System.EventHandler(this.checkBoxAnnotate_CheckedChanged);
            // 
            // checkBoxResource
            // 
            this.checkBoxResource.AutoSize = true;
            this.checkBoxResource.Location = new System.Drawing.Point(192, 12);
            this.checkBoxResource.Name = "checkBoxResource";
            this.checkBoxResource.Size = new System.Drawing.Size(96, 16);
            this.checkBoxResource.TabIndex = 10;
            this.checkBoxResource.Text = "包含资源文件";
            this.checkBoxResource.UseVisualStyleBackColor = true;
            this.checkBoxResource.CheckedChanged += new System.EventHandler(this.checkBoxAnnotate_CheckedChanged);
            // 
            // checkBoxDesign
            // 
            this.checkBoxDesign.AutoSize = true;
            this.checkBoxDesign.Location = new System.Drawing.Point(90, 12);
            this.checkBoxDesign.Name = "checkBoxDesign";
            this.checkBoxDesign.Size = new System.Drawing.Size(96, 16);
            this.checkBoxDesign.TabIndex = 9;
            this.checkBoxDesign.Text = "包含设计代码";
            this.checkBoxDesign.UseVisualStyleBackColor = true;
            this.checkBoxDesign.CheckedChanged += new System.EventHandler(this.checkBoxAnnotate_CheckedChanged);
            // 
            // checkBoxAnnotate
            // 
            this.checkBoxAnnotate.AutoSize = true;
            this.checkBoxAnnotate.Location = new System.Drawing.Point(12, 12);
            this.checkBoxAnnotate.Name = "checkBoxAnnotate";
            this.checkBoxAnnotate.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAnnotate.TabIndex = 8;
            this.checkBoxAnnotate.Text = "包含注释";
            this.checkBoxAnnotate.UseVisualStyleBackColor = true;
            this.checkBoxAnnotate.CheckedChanged += new System.EventHandler(this.checkBoxAnnotate_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(12, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(372, 250);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 296);
            this.Controls.Add(this.checkBoxIncludeMix);
            this.Controls.Add(this.checkBoxResource);
            this.Controls.Add(this.checkBoxDesign);
            this.Controls.Add(this.checkBoxAnnotate);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码行数统计";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.CheckBox checkBoxIncludeMix;
        private System.Windows.Forms.CheckBox checkBoxResource;
        private System.Windows.Forms.CheckBox checkBoxDesign;
        private System.Windows.Forms.CheckBox checkBoxAnnotate;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
