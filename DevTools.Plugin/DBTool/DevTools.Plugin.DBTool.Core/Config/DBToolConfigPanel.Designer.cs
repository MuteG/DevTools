namespace DevTools.Plugin.DBTool.Core.Config
{
    partial class DBToolConfigPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxDataSource = new System.Windows.Forms.TextBox();
            this.labelDataSource = new System.Windows.Forms.Label();
            this.lblDatabaseType = new System.Windows.Forms.Label();
            this.cbxDatabaseType = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblTestResult = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBoxConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxName
            // 
            this.comboBoxName.DisplayMember = "Name";
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(98, 15);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(178, 20);
            this.comboBoxName.TabIndex = 0;
            this.comboBoxName.ValueMember = "Name";
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(25, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(62, 12);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Connection";
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.textBoxPassword);
            this.groupBoxConnection.Controls.Add(this.labelPassword);
            this.groupBoxConnection.Controls.Add(this.textBoxUsername);
            this.groupBoxConnection.Controls.Add(this.labelUsername);
            this.groupBoxConnection.Controls.Add(this.textBoxDataSource);
            this.groupBoxConnection.Controls.Add(this.labelDataSource);
            this.groupBoxConnection.Location = new System.Drawing.Point(19, 67);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(257, 99);
            this.groupBoxConnection.TabIndex = 3;
            this.groupBoxConnection.TabStop = false;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(79, 68);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(172, 19);
            this.textBoxPassword.TabIndex = 5;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 71);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(54, 12);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(79, 43);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(172, 19);
            this.textBoxUsername.TabIndex = 3;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(6, 46);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(44, 12);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "User ID";
            // 
            // textBoxDataSource
            // 
            this.textBoxDataSource.Location = new System.Drawing.Point(79, 18);
            this.textBoxDataSource.Name = "textBoxDataSource";
            this.textBoxDataSource.Size = new System.Drawing.Size(172, 19);
            this.textBoxDataSource.TabIndex = 1;
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.Location = new System.Drawing.Point(6, 21);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(68, 12);
            this.labelDataSource.TabIndex = 0;
            this.labelDataSource.Text = "Data Srouce";
            // 
            // lblDatabaseType
            // 
            this.lblDatabaseType.AutoSize = true;
            this.lblDatabaseType.Location = new System.Drawing.Point(25, 44);
            this.lblDatabaseType.Name = "lblDatabaseType";
            this.lblDatabaseType.Size = new System.Drawing.Size(50, 12);
            this.lblDatabaseType.TabIndex = 5;
            this.lblDatabaseType.Text = "DB Type";
            // 
            // cbxDatabaseType
            // 
            this.cbxDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatabaseType.FormattingEnabled = true;
            this.cbxDatabaseType.Location = new System.Drawing.Point(98, 41);
            this.cbxDatabaseType.Name = "cbxDatabaseType";
            this.cbxDatabaseType.Size = new System.Drawing.Size(178, 20);
            this.cbxDatabaseType.TabIndex = 4;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(19, 172);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblTestResult
            // 
            this.lblTestResult.AutoSize = true;
            this.lblTestResult.Location = new System.Drawing.Point(100, 177);
            this.lblTestResult.Name = "lblTestResult";
            this.lblTestResult.Size = new System.Drawing.Size(29, 12);
            this.lblTestResult.TabIndex = 7;
            this.lblTestResult.Text = "      ";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(201, 172);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DBToolConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblTestResult);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblDatabaseType);
            this.Controls.Add(this.cbxDatabaseType);
            this.Controls.Add(this.groupBoxConnection);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxName);
            this.Name = "DBToolConfigPanel";
            this.Size = new System.Drawing.Size(294, 212);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxDataSource;
        private System.Windows.Forms.Label labelDataSource;
        private System.Windows.Forms.Label lblDatabaseType;
        private System.Windows.Forms.ComboBox cbxDatabaseType;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblTestResult;
        private System.Windows.Forms.Button btnDelete;
    }
}
