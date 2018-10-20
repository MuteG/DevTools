namespace DevTools.Plugin.DBTool.USL
{
    partial class FormDatabaseStructure
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabaseStructure));
            this.lstDatabaseStructure = new System.Windows.Forms.ListView();
            this.colCheckBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSelectAgainst = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDatabaseStructure
            // 
            this.lstDatabaseStructure.CheckBoxes = true;
            this.lstDatabaseStructure.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCheckBox,
            this.colName,
            this.colType,
            this.colLength});
            this.lstDatabaseStructure.ContextMenuStrip = this.contextMenuStrip1;
            this.lstDatabaseStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDatabaseStructure.FullRowSelect = true;
            this.lstDatabaseStructure.GridLines = true;
            this.lstDatabaseStructure.Location = new System.Drawing.Point(0, 0);
            this.lstDatabaseStructure.Name = "lstDatabaseStructure";
            this.lstDatabaseStructure.Size = new System.Drawing.Size(435, 408);
            this.lstDatabaseStructure.SmallImageList = this.imageList1;
            this.lstDatabaseStructure.TabIndex = 16;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "key");
            // 
            // FormDatabaseStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 408);
            this.Controls.Add(this.lstDatabaseStructure);
            this.Name = "FormDatabaseStructure";
            this.Text = "表结构";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstDatabaseStructure;
        private System.Windows.Forms.ColumnHeader colCheckBox;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colLength;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectNone;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectAgainst;
        private System.Windows.Forms.ImageList imageList1;
    }
}