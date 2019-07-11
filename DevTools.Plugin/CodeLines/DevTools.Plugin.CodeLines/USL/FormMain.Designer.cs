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
            this.components = new System.ComponentModel.Container();
            this.groupBoxInclude = new System.Windows.Forms.GroupBox();
            this.listViewInclude = new System.Windows.Forms.ListView();
            this.contextMenuStripTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCollapseSubNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExpandSubNode = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTotal = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeGridView = new AdvancedDataGridView.TreeGridView();
            this.groupBoxInclude.SuspendLayout();
            this.contextMenuStripTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView)).BeginInit();
            this.SuspendLayout();
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
            this.listViewInclude.Location = new System.Drawing.Point(2, 15);
            this.listViewInclude.MultiSelect = false;
            this.listViewInclude.Name = "listViewInclude";
            this.listViewInclude.Size = new System.Drawing.Size(788, 29);
            this.listViewInclude.TabIndex = 0;
            this.listViewInclude.UseCompatibleStateImageBehavior = false;
            this.listViewInclude.View = System.Windows.Forms.View.List;
            this.listViewInclude.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewInclude_ItemChecked);
            // 
            // contextMenuStripTree
            // 
            this.contextMenuStripTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCollapseSubNode,
            this.menuExpandSubNode});
            this.contextMenuStripTree.Name = "contextMenuStripTree";
            this.contextMenuStripTree.Size = new System.Drawing.Size(135, 48);
            // 
            // menuCollapseSubNode
            // 
            this.menuCollapseSubNode.Name = "menuCollapseSubNode";
            this.menuCollapseSubNode.Size = new System.Drawing.Size(134, 22);
            this.menuCollapseSubNode.Text = "折叠子节点";
            this.menuCollapseSubNode.Click += new System.EventHandler(this.menuCollapseSubNode_Click);
            // 
            // menuExpandSubNode
            // 
            this.menuExpandSubNode.Name = "menuExpandSubNode";
            this.menuExpandSubNode.Size = new System.Drawing.Size(134, 22);
            this.menuExpandSubNode.Text = "展开子节点";
            this.menuExpandSubNode.Click += new System.EventHandler(this.menuExpandSubNode_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(12, 442);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(35, 12);
            this.labelTotal.TabIndex = 16;
            this.labelTotal.Text = "总计：";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // treeGridView
            // 
            this.treeGridView.AllowUserToAddRows = false;
            this.treeGridView.AllowUserToDeleteRows = false;
            this.treeGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeGridView.ContextMenuStrip = this.contextMenuStripTree;
            this.treeGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.treeGridView.ImageList = null;
            this.treeGridView.Location = new System.Drawing.Point(12, 65);
            this.treeGridView.MultiSelect = false;
            this.treeGridView.Name = "treeGridView";
            this.treeGridView.RowHeadersVisible = false;
            this.treeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.treeGridView.Size = new System.Drawing.Size(793, 374);
            this.treeGridView.TabIndex = 17;
            this.treeGridView.NodeExpanded += new AdvancedDataGridView.ExpandedEventHandler(this.treeGridView_NodeExpanded);
            this.treeGridView.NodeCollapsed += new AdvancedDataGridView.CollapsedEventHandler(this.treeGridView_NodeCollapsed);
            this.treeGridView.NodeChecked += new AdvancedDataGridView.CheckedEventHandler(this.treeGridView_NodeChecked);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(817, 463);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.treeGridView);
            this.Controls.Add(this.groupBoxInclude);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码行数统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.groupBoxInclude.ResumeLayout(false);
            this.contextMenuStripTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.GroupBox groupBoxInclude;
        private System.Windows.Forms.ListView listViewInclude;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTree;
        private System.Windows.Forms.ToolStripMenuItem menuCollapseSubNode;
        private System.Windows.Forms.ToolStripMenuItem menuExpandSubNode;
        private AdvancedDataGridView.TreeGridView treeGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
