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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点3", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.groupBoxInclude = new System.Windows.Forms.GroupBox();
            this.listViewInclude = new System.Windows.Forms.ListView();
            this.treeViewFile = new System.Windows.Forms.TreeView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dataGridViewCount = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTotal = new System.Windows.Forms.Label();
            this.groupBoxInclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCount)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxReport.BackColor = System.Drawing.Color.White;
            this.richTextBoxReport.Location = new System.Drawing.Point(330, 403);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.ReadOnly = true;
            this.richTextBoxReport.Size = new System.Drawing.Size(378, 59);
            this.richTextBoxReport.TabIndex = 7;
            this.richTextBoxReport.Text = "";
            // 
            // groupBoxInclude
            // 
            this.groupBoxInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInclude.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxInclude.Controls.Add(this.listViewInclude);
            this.groupBoxInclude.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInclude.Name = "groupBoxInclude";
            this.groupBoxInclude.Padding = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.groupBoxInclude.Size = new System.Drawing.Size(793, 47);
            this.groupBoxInclude.TabIndex = 13;
            this.groupBoxInclude.TabStop = false;
            this.groupBoxInclude.Text = "包含";
            // 
            // listViewInclude
            // 
            this.listViewInclude.BackColor = System.Drawing.SystemColors.Control;
            this.listViewInclude.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewInclude.CheckBoxes = true;
            this.listViewInclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInclude.Location = new System.Drawing.Point(2, 17);
            this.listViewInclude.MultiSelect = false;
            this.listViewInclude.Name = "listViewInclude";
            this.listViewInclude.Size = new System.Drawing.Size(788, 27);
            this.listViewInclude.TabIndex = 0;
            this.listViewInclude.UseCompatibleStateImageBehavior = false;
            this.listViewInclude.View = System.Windows.Forms.View.List;
            this.listViewInclude.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewInclude_ItemChecked);
            // 
            // treeViewFile
            // 
            this.treeViewFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewFile.CheckBoxes = true;
            this.treeViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFile.ItemHeight = 18;
            this.treeViewFile.Location = new System.Drawing.Point(0, 0);
            this.treeViewFile.Name = "treeViewFile";
            treeNode1.Name = "节点1";
            treeNode1.Text = "节点1";
            treeNode2.Name = "节点2";
            treeNode2.Text = "节点2";
            treeNode3.Name = "节点0";
            treeNode3.Text = "节点0";
            treeNode4.Name = "节点4";
            treeNode4.Text = "节点4";
            treeNode5.Name = "节点5";
            treeNode5.Text = "节点5";
            treeNode6.Name = "节点3";
            treeNode6.Text = "节点3";
            treeNode7.Name = "节点6";
            treeNode7.Text = "节点6";
            this.treeViewFile.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode7});
            this.treeViewFile.Size = new System.Drawing.Size(206, 374);
            this.treeViewFile.TabIndex = 14;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 65);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeViewFile);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridViewCount);
            this.splitContainer.Size = new System.Drawing.Size(793, 374);
            this.splitContainer.SplitterDistance = 206;
            this.splitContainer.TabIndex = 15;
            // 
            // dataGridViewCount
            // 
            this.dataGridViewCount.AllowUserToAddRows = false;
            this.dataGridViewCount.AllowUserToDeleteRows = false;
            this.dataGridViewCount.AllowUserToResizeRows = false;
            this.dataGridViewCount.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCount.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCount.Name = "dataGridViewCount";
            this.dataGridViewCount.ReadOnly = true;
            this.dataGridViewCount.RowHeadersVisible = false;
            this.dataGridViewCount.RowTemplate.Height = 18;
            this.dataGridViewCount.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCount.ShowEditingIcon = false;
            this.dataGridViewCount.Size = new System.Drawing.Size(583, 374);
            this.dataGridViewCount.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(12, 442);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(41, 12);
            this.labelTotal.TabIndex = 16;
            this.labelTotal.Text = "总计：";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(817, 463);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.groupBoxInclude);
            this.Controls.Add(this.richTextBoxReport);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码行数统计";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.groupBoxInclude.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.RichTextBox richTextBoxReport;
        private System.Windows.Forms.GroupBox groupBoxInclude;
        private System.Windows.Forms.ListView listViewInclude;
        private System.Windows.Forms.TreeView treeViewFile;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridViewCount;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
