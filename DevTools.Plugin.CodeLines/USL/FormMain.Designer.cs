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
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.groupBoxInclude = new System.Windows.Forms.GroupBox();
            this.listViewInclude = new System.Windows.Forms.ListView();
            this.groupBoxInclude.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxReport.BackColor = System.Drawing.Color.White;
            this.richTextBoxReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxReport.Location = new System.Drawing.Point(12, 65);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.ReadOnly = true;
            this.richTextBoxReport.Size = new System.Drawing.Size(679, 370);
            this.richTextBoxReport.TabIndex = 7;
            this.richTextBoxReport.Text = "";
            // 
            // groupBoxInclude
            // 
            this.groupBoxInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInclude.Controls.Add(this.listViewInclude);
            this.groupBoxInclude.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInclude.Name = "groupBoxInclude";
            this.groupBoxInclude.Size = new System.Drawing.Size(679, 47);
            this.groupBoxInclude.TabIndex = 13;
            this.groupBoxInclude.TabStop = false;
            this.groupBoxInclude.Text = "包含";
            // 
            // listViewInclude
            // 
            this.listViewInclude.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewInclude.CheckBoxes = true;
            this.listViewInclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInclude.Location = new System.Drawing.Point(3, 17);
            this.listViewInclude.MultiSelect = false;
            this.listViewInclude.Name = "listViewInclude";
            this.listViewInclude.Size = new System.Drawing.Size(673, 27);
            this.listViewInclude.TabIndex = 0;
            this.listViewInclude.UseCompatibleStateImageBehavior = false;
            this.listViewInclude.View = System.Windows.Forms.View.List;
            this.listViewInclude.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewInclude_ItemChecked);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 447);
            this.Controls.Add(this.groupBoxInclude);
            this.Controls.Add(this.richTextBoxReport);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码行数统计";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.groupBoxInclude.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.RichTextBox richTextBoxReport;
        private System.Windows.Forms.GroupBox groupBoxInclude;
        private System.Windows.Forms.ListView listViewInclude;
    }
}
