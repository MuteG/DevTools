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
            this.cbxAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDatabaseName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxTableName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxOperateType = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstDatabaseStructure = new System.Windows.Forms.ListView();
            this.colCheckBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSelectAgainst = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbLogList = new System.Windows.Forms.RichTextBox();
            this.btnGenerateScript = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxSqlType = new System.Windows.Forms.ComboBox();
            this.chkInput = new System.Windows.Forms.CheckBox();
            this.chkHead = new System.Windows.Forms.CheckBox();
            this.btnGenerateCSharp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbxDatabaseConnection = new System.Windows.Forms.GroupBox();
            this.gbxOperateTarget = new System.Windows.Forms.GroupBox();
            this.gbxGenerateCode = new System.Windows.Forms.GroupBox();
            this.chkCutPrefix = new System.Windows.Forms.CheckBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.gbxDatabaseConnection.SuspendLayout();
            this.gbxOperateTarget.SuspendLayout();
            this.gbxGenerateCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxAddress
            // 
            this.cbxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAddress.FormattingEnabled = true;
            this.cbxAddress.Location = new System.Drawing.Point(47, 19);
            this.cbxAddress.Name = "cbxAddress";
            this.cbxAddress.Size = new System.Drawing.Size(139, 20);
            this.cbxAddress.TabIndex = 0;
            this.cbxAddress.SelectedIndexChanged += new System.EventHandler(this.cbxAddress_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "地址";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(111, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "表名";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "操作对象";
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
            // lstDatabaseStructure
            // 
            this.lstDatabaseStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDatabaseStructure.CheckBoxes = true;
            this.lstDatabaseStructure.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCheckBox,
            this.colName,
            this.colType,
            this.colLength});
            this.lstDatabaseStructure.ContextMenuStrip = this.contextMenuStrip1;
            this.lstDatabaseStructure.FullRowSelect = true;
            this.lstDatabaseStructure.GridLines = true;
            this.lstDatabaseStructure.Location = new System.Drawing.Point(10, 10);
            this.lstDatabaseStructure.Name = "lstDatabaseStructure";
            this.lstDatabaseStructure.Size = new System.Drawing.Size(406, 400);
            this.lstDatabaseStructure.TabIndex = 15;
            this.lstDatabaseStructure.UseCompatibleStateImageBehavior = false;
            this.lstDatabaseStructure.View = System.Windows.Forms.View.Details;
            // 
            // colCheckBox
            // 
            this.colCheckBox.Text = "";
            this.colCheckBox.Width = 30;
            // 
            // colName
            // 
            this.colName.Text = "名称";
            this.colName.Width = 220;
            // 
            // colType
            // 
            this.colType.Text = "类型";
            this.colType.Width = 80;
            // 
            // colLength
            // 
            this.colLength.Text = "长度";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSelectAll,
            this.mnuItemSelectNone,
            this.mnuItemSelectAgainst});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 70);
            // 
            // mnuItemSelectAll
            // 
            this.mnuItemSelectAll.Name = "mnuItemSelectAll";
            this.mnuItemSelectAll.Size = new System.Drawing.Size(111, 22);
            this.mnuItemSelectAll.Text = "全选";
            this.mnuItemSelectAll.Click += new System.EventHandler(this.mnuItemSelectAll_Click);
            // 
            // mnuItemSelectNone
            // 
            this.mnuItemSelectNone.Name = "mnuItemSelectNone";
            this.mnuItemSelectNone.Size = new System.Drawing.Size(111, 22);
            this.mnuItemSelectNone.Text = "全不选";
            this.mnuItemSelectNone.Click += new System.EventHandler(this.mnuItemSelectNone_Click);
            // 
            // mnuItemSelectAgainst
            // 
            this.mnuItemSelectAgainst.Name = "mnuItemSelectAgainst";
            this.mnuItemSelectAgainst.Size = new System.Drawing.Size(111, 22);
            this.mnuItemSelectAgainst.Text = "反选";
            this.mnuItemSelectAgainst.Click += new System.EventHandler(this.mnuItemSelectAgainst_Click);
            // 
            // rtbLogList
            // 
            this.rtbLogList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLogList.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.rtbLogList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLogList.Location = new System.Drawing.Point(10, 416);
            this.rtbLogList.Name = "rtbLogList";
            this.rtbLogList.Size = new System.Drawing.Size(406, 99);
            this.rtbLogList.TabIndex = 16;
            this.rtbLogList.Text = "";
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
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(453, 492);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 18;
            this.btnClearLog.Text = "清空日志";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(533, 492);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "退出程序";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            // gbxDatabaseConnection
            // 
            this.gbxDatabaseConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDatabaseConnection.Controls.Add(this.btnConfig);
            this.gbxDatabaseConnection.Controls.Add(this.cbxAddress);
            this.gbxDatabaseConnection.Controls.Add(this.label1);
            this.gbxDatabaseConnection.Controls.Add(this.btnConnect);
            this.gbxDatabaseConnection.Location = new System.Drawing.Point(422, 10);
            this.gbxDatabaseConnection.Name = "gbxDatabaseConnection";
            this.gbxDatabaseConnection.Size = new System.Drawing.Size(195, 78);
            this.gbxDatabaseConnection.TabIndex = 24;
            this.gbxDatabaseConnection.TabStop = false;
            this.gbxDatabaseConnection.Text = "数据库连接";
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
            this.gbxOperateTarget.Location = new System.Drawing.Point(422, 142);
            this.gbxOperateTarget.Name = "gbxOperateTarget";
            this.gbxOperateTarget.Size = new System.Drawing.Size(195, 153);
            this.gbxOperateTarget.TabIndex = 25;
            this.gbxOperateTarget.TabStop = false;
            this.gbxOperateTarget.Text = "操作对象";
            // 
            // gbxGenerateCode
            // 
            this.gbxGenerateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxGenerateCode.Controls.Add(this.chkCutPrefix);
            this.gbxGenerateCode.Controls.Add(this.chkInput);
            this.gbxGenerateCode.Controls.Add(this.chkHead);
            this.gbxGenerateCode.Controls.Add(this.btnGenerateScript);
            this.gbxGenerateCode.Controls.Add(this.btnGenerateCSharp);
            this.gbxGenerateCode.Location = new System.Drawing.Point(422, 301);
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
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(30, 49);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 8;
            this.btnConfig.Text = "设定";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(629, 527);
            this.Controls.Add(this.lstDatabaseStructure);
            this.Controls.Add(this.gbxGenerateCode);
            this.Controls.Add(this.gbxOperateTarget);
            this.Controls.Add(this.gbxDatabaseConnection);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.rtbLogList);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库脚本生成工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbxDatabaseConnection.ResumeLayout(false);
            this.gbxDatabaseConnection.PerformLayout();
            this.gbxOperateTarget.ResumeLayout(false);
            this.gbxOperateTarget.PerformLayout();
            this.gbxGenerateCode.ResumeLayout(false);
            this.gbxGenerateCode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDatabaseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxTableName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxOperateType;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lstDatabaseStructure;
        private System.Windows.Forms.RichTextBox rtbLogList;
        private System.Windows.Forms.Button btnGenerateScript;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxSqlType;
        private System.Windows.Forms.CheckBox chkInput;
        private System.Windows.Forms.CheckBox chkHead;
        private System.Windows.Forms.ColumnHeader colCheckBox;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colLength;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectNone;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectAgainst;
        private System.Windows.Forms.Button btnGenerateCSharp;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox gbxDatabaseConnection;
        private System.Windows.Forms.GroupBox gbxOperateTarget;
        private System.Windows.Forms.GroupBox gbxGenerateCode;
        private System.Windows.Forms.CheckBox chkCutPrefix;
        private System.Windows.Forms.Button btnConfig;
    }
}

