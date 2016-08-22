/* *************************************************************************
 * Copyright (c)2013 NTT DATA BEEN (China) Information Technology Co.,Ltd.
 * 作成:高雲鵬
 * 機能:
 * 履歴:
 * 2013/11/13 新規 高雲鵬 新規作成
 * *************************************************************************/
namespace DevTools.Plugin.BatchDeleteFiles.USL
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
            this.labelRootFolder = new System.Windows.Forms.Label();
            this.textBoxRootFolder = new System.Windows.Forms.TextBox();
            this.checkBoxIsDeleteRoot = new System.Windows.Forms.CheckBox();
            this.labelFolderCount = new System.Windows.Forms.Label();
            this.labelFileCount = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.labelCurrentFolder = new System.Windows.Forms.Label();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRootFolder
            // 
            this.labelRootFolder.AutoSize = true;
            this.labelRootFolder.Location = new System.Drawing.Point(12, 15);
            this.labelRootFolder.Name = "labelRootFolder";
            this.labelRootFolder.Size = new System.Drawing.Size(49, 14);
            this.labelRootFolder.TabIndex = 0;
            this.labelRootFolder.Text = "根目录";
            // 
            // textBoxRootFolder
            // 
            this.textBoxRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRootFolder.Location = new System.Drawing.Point(67, 12);
            this.textBoxRootFolder.Name = "textBoxRootFolder";
            this.textBoxRootFolder.Size = new System.Drawing.Size(387, 23);
            this.textBoxRootFolder.TabIndex = 1;
            this.textBoxRootFolder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxRootFolder_KeyPress);
            // 
            // checkBoxIsDeleteRoot
            // 
            this.checkBoxIsDeleteRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxIsDeleteRoot.BackColor = System.Drawing.Color.LightGreen;
            this.checkBoxIsDeleteRoot.Location = new System.Drawing.Point(231, 41);
            this.checkBoxIsDeleteRoot.Name = "checkBoxIsDeleteRoot";
            this.checkBoxIsDeleteRoot.Size = new System.Drawing.Size(108, 46);
            this.checkBoxIsDeleteRoot.TabIndex = 2;
            this.checkBoxIsDeleteRoot.Text = "删除根目录";
            this.checkBoxIsDeleteRoot.UseVisualStyleBackColor = false;
            this.checkBoxIsDeleteRoot.CheckedChanged += new System.EventHandler(this.CheckBoxIsDeleteRoot_CheckedChanged);
            // 
            // labelFolderCount
            // 
            this.labelFolderCount.AutoSize = true;
            this.labelFolderCount.Location = new System.Drawing.Point(12, 41);
            this.labelFolderCount.Name = "labelFolderCount";
            this.labelFolderCount.Size = new System.Drawing.Size(98, 14);
            this.labelFolderCount.TabIndex = 3;
            this.labelFolderCount.Text = "文件夹数量：0";
            // 
            // labelFileCount
            // 
            this.labelFileCount.AutoSize = true;
            this.labelFileCount.Location = new System.Drawing.Point(12, 63);
            this.labelFileCount.Name = "labelFileCount";
            this.labelFileCount.Size = new System.Drawing.Size(98, 14);
            this.labelFileCount.TabIndex = 4;
            this.labelFileCount.Text = "文件数量  ：0";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(442, 17);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 5;
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(12, 148);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(442, 17);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 6;
            // 
            // labelCurrentFolder
            // 
            this.labelCurrentFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCurrentFolder.AutoSize = true;
            this.labelCurrentFolder.Location = new System.Drawing.Point(12, 94);
            this.labelCurrentFolder.Name = "labelCurrentFolder";
            this.labelCurrentFolder.Size = new System.Drawing.Size(91, 14);
            this.labelCurrentFolder.TabIndex = 7;
            this.labelCurrentFolder.Text = "删除文件夹：";
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCurrentFile.AutoSize = true;
            this.labelCurrentFile.Location = new System.Drawing.Point(12, 131);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(77, 14);
            this.labelCurrentFile.TabIndex = 8;
            this.labelCurrentFile.Text = "删除文件：";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(345, 41);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(109, 46);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "开始删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(466, 177);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.labelCurrentFolder);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelFileCount);
            this.Controls.Add(this.labelFolderCount);
            this.Controls.Add(this.checkBoxIsDeleteRoot);
            this.Controls.Add(this.textBoxRootFolder);
            this.Controls.Add(this.labelRootFolder);
            this.Font = new System.Drawing.Font("NSimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量删除文件";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelCurrentFile;
        private System.Windows.Forms.Label labelCurrentFolder;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelFileCount;
        private System.Windows.Forms.Label labelFolderCount;
        private System.Windows.Forms.CheckBox checkBoxIsDeleteRoot;
        private System.Windows.Forms.TextBox textBoxRootFolder;
        private System.Windows.Forms.Label labelRootFolder;
    }
}
