namespace DevTools.Plugin.DBTool.USL
{
    partial class FormMain
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGenerateScript = new System.Windows.Forms.Button();
            this.chkInput = new System.Windows.Forms.CheckBox();
            this.chkHead = new System.Windows.Forms.CheckBox();
            this.btnGenerateCSharp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbxGenerateCode = new System.Windows.Forms.GroupBox();
            this.chkCutPrefix = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxOperateTarget = new System.Windows.Forms.GroupBox();
            this.cbxDatabaseName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxOperateType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTableName = new System.Windows.Forms.ComboBox();
            this.cbxSqlType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxGenerateCode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbxOperateTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "key");
            // 
            // btnGenerateScript
            // 
            this.btnGenerateScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateScript.Location = new System.Drawing.Point(17, 80);
            this.btnGenerateScript.Name = "btnGenerateScript";
            this.btnGenerateScript.Size = new System.Drawing.Size(89, 23);
            this.btnGenerateScript.TabIndex = 17;
            this.btnGenerateScript.Text = "生成SQL脚本";
            this.toolTip1.SetToolTip(this.btnGenerateScript, "存入剪贴板");
            this.btnGenerateScript.UseVisualStyleBackColor = true;
            this.btnGenerateScript.Click += new System.EventHandler(this.btnGenerateScript_Click);
            // 
            // chkInput
            // 
            this.chkInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkInput.AutoSize = true;
            this.chkInput.Checked = true;
            this.chkInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInput.Location = new System.Drawing.Point(5, 18);
            this.chkInput.Name = "chkInput";
            this.chkInput.Size = new System.Drawing.Size(96, 16);
            this.chkInput.TabIndex = 22;
            this.chkInput.Text = "生成输入参数";
            this.chkInput.UseVisualStyleBackColor = true;
            // 
            // chkHead
            // 
            this.chkHead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkHead.AutoSize = true;
            this.chkHead.Checked = true;
            this.chkHead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHead.Location = new System.Drawing.Point(105, 18);
            this.chkHead.Name = "chkHead";
            this.chkHead.Size = new System.Drawing.Size(84, 16);
            this.chkHead.TabIndex = 23;
            this.chkHead.Text = "生成头注释";
            this.chkHead.UseVisualStyleBackColor = true;
            // 
            // btnGenerateCSharp
            // 
            this.btnGenerateCSharp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateCSharp.Location = new System.Drawing.Point(111, 80);
            this.btnGenerateCSharp.Name = "btnGenerateCSharp";
            this.btnGenerateCSharp.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateCSharp.TabIndex = 17;
            this.btnGenerateCSharp.Text = "生成C#代码";
            this.toolTip1.SetToolTip(this.btnGenerateCSharp, "存入剪贴板");
            this.btnGenerateCSharp.UseVisualStyleBackColor = true;
            this.btnGenerateCSharp.Click += new System.EventHandler(this.btnGenerateCSharp_Click);
            // 
            // gbxGenerateCode
            // 
            this.gbxGenerateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxGenerateCode.Controls.Add(this.chkCutPrefix);
            this.gbxGenerateCode.Controls.Add(this.chkInput);
            this.gbxGenerateCode.Controls.Add(this.chkHead);
            this.gbxGenerateCode.Controls.Add(this.btnGenerateScript);
            this.gbxGenerateCode.Controls.Add(this.btnGenerateCSharp);
            this.gbxGenerateCode.Location = new System.Drawing.Point(7, 246);
            this.gbxGenerateCode.Name = "gbxGenerateCode";
            this.gbxGenerateCode.Size = new System.Drawing.Size(195, 111);
            this.gbxGenerateCode.TabIndex = 26;
            this.gbxGenerateCode.TabStop = false;
            this.gbxGenerateCode.Text = "代码生成";
            // 
            // chkCutPrefix
            // 
            this.chkCutPrefix.AutoSize = true;
            this.chkCutPrefix.Checked = true;
            this.chkCutPrefix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCutPrefix.Location = new System.Drawing.Point(5, 40);
            this.chkCutPrefix.Name = "chkCutPrefix";
            this.chkCutPrefix.Size = new System.Drawing.Size(84, 16);
            this.chkCutPrefix.TabIndex = 24;
            this.chkCutPrefix.Text = "智能去前缀";
            this.chkCutPrefix.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 643);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(923, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(923, 25);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbxGenerateCode);
            this.panel1.Controls.Add(this.gbxOperateTarget);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(718, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 594);
            this.panel1.TabIndex = 30;
            this.panel1.Visible = false;
            // 
            // gbxOperateTarget
            // 
            this.gbxOperateTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOperateTarget.Controls.Add(this.cbxDatabaseName);
            this.gbxOperateTarget.Controls.Add(this.label4);
            this.gbxOperateTarget.Controls.Add(this.cbxOperateType);
            this.gbxOperateTarget.Controls.Add(this.label6);
            this.gbxOperateTarget.Controls.Add(this.cbxTableName);
            this.gbxOperateTarget.Controls.Add(this.cbxSqlType);
            this.gbxOperateTarget.Controls.Add(this.label7);
            this.gbxOperateTarget.Controls.Add(this.label5);
            this.gbxOperateTarget.Controls.Add(this.btnRefresh);
            this.gbxOperateTarget.Location = new System.Drawing.Point(7, 87);
            this.gbxOperateTarget.Name = "gbxOperateTarget";
            this.gbxOperateTarget.Size = new System.Drawing.Size(195, 153);
            this.gbxOperateTarget.TabIndex = 25;
            this.gbxOperateTarget.TabStop = false;
            this.gbxOperateTarget.Text = "操作对象";
            // 
            // cbxDatabaseName
            // 
            this.cbxDatabaseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatabaseName.FormattingEnabled = true;
            this.cbxDatabaseName.Location = new System.Drawing.Point(57, 19);
            this.cbxDatabaseName.Name = "cbxDatabaseName";
            this.cbxDatabaseName.Size = new System.Drawing.Size(129, 20);
            this.cbxDatabaseName.TabIndex = 9;
            this.cbxDatabaseName.SelectedIndexChanged += new System.EventHandler(this.cbxDatabaseName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "数据库";
            // 
            // cbxOperateType
            // 
            this.cbxOperateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOperateType.FormattingEnabled = true;
            this.cbxOperateType.Items.AddRange(new object[] {
            "表结构",
            "存储过程"});
            this.cbxOperateType.Location = new System.Drawing.Point(57, 45);
            this.cbxOperateType.Name = "cbxOperateType";
            this.cbxOperateType.Size = new System.Drawing.Size(129, 20);
            this.cbxOperateType.TabIndex = 13;
            this.cbxOperateType.SelectedIndexChanged += new System.EventHandler(this.cbxOperateType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "操作对象";
            // 
            // cbxTableName
            // 
            this.cbxTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTableName.FormattingEnabled = true;
            this.cbxTableName.Location = new System.Drawing.Point(57, 70);
            this.cbxTableName.Name = "cbxTableName";
            this.cbxTableName.Size = new System.Drawing.Size(129, 20);
            this.cbxTableName.TabIndex = 11;
            this.cbxTableName.SelectedIndexChanged += new System.EventHandler(this.cbxTableName_SelectedIndexChanged);
            // 
            // cbxSqlType
            // 
            this.cbxSqlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSqlType.FormattingEnabled = true;
            this.cbxSqlType.Items.AddRange(new object[] {
            "查询",
            "添加",
            "删除",
            "更新"});
            this.cbxSqlType.Location = new System.Drawing.Point(57, 96);
            this.cbxSqlType.Name = "cbxSqlType";
            this.cbxSqlType.Size = new System.Drawing.Size(129, 20);
            this.cbxSqlType.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "操作类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "表名";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(111, 122);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.dockPanel1.Location = new System.Drawing.Point(0, 49);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.Size = new System.Drawing.Size(923, 594);
            this.dockPanel1.TabIndex = 31;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(43, 20);
            this.mnuFile.Text = "文件";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "退出";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(923, 665);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库脚本生成工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.gbxGenerateCode.ResumeLayout(false);
            this.gbxGenerateCode.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbxOperateTarget.ResumeLayout(false);
            this.gbxOperateTarget.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateScript;
        private System.Windows.Forms.CheckBox chkInput;
        private System.Windows.Forms.CheckBox chkHead;
        private System.Windows.Forms.Button btnGenerateCSharp;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox gbxGenerateCode;
        private System.Windows.Forms.CheckBox chkCutPrefix;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        //private DataObjectTree dataObjectTree;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gbxOperateTarget;
        private System.Windows.Forms.ComboBox cbxDatabaseName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxOperateType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTableName;
        private System.Windows.Forms.ComboBox cbxSqlType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}

