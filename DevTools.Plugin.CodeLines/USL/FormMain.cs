using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AdvancedDataGridView;
using DevTools.Common.IO;
using DevTools.Common.UI;
using DevTools.Plugin.CodeLines.BLL;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.USL
{
    /// <summary>
    /// 代码统计主窗体
    /// </summary>
    public partial class FormMain : Form
    {
        private AbstractCodeFile rootFile = null;
        private ProgressPanel progressPanel = new ProgressPanel();

        public FormMain()
        {
            InitializeComponent();
            this.treeViewFile.Nodes.Clear();
            this.treeGridView.Nodes.Clear();

            InitializeInclude();
        }

        private void InitializeInclude()
        {
            this.listViewInclude.Items.Clear();
            this.treeGridView.Columns.Clear();
            this.treeGridView.Columns.Add(new TreeGridColumn()
            {
                HeaderText = "文件",
                ValueType = typeof(string),
                Width = 80,
                Name = "colFile",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            this.treeGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "总行数",
                ValueType = typeof(int),
                Width = 80,
                Name = "colTotal",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            foreach (PropertyInfo info in typeof(CodeLineCount).GetProperties())
            {
                object[] attrArray = info.GetCustomAttributes(typeof(CountInfoAttribute), false);
                if (attrArray.Length > 0)
                {
                    CountInfoAttribute attr = attrArray[0] as CountInfoAttribute;
                    if (null != attr)
                    {
                        ListViewItem item = this.listViewInclude.Items.Add(attr.DisplayName);
                        item.Checked = attr.IsInclude;
                        item.Tag = info;

                        this.treeGridView.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            HeaderText = attr.DisplayName,
                            ValueType = typeof(int),
                            Width = 80,
                            Name = "col" + info.Name,
                            SortMode = DataGridViewColumnSortMode.NotSortable
                        });
                    }
                }
            }
            this.treeGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "修正后行数",
                ValueType = typeof(int),
                Width = 80,
                Name = "colFixedCount",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                rootFile = new CodeFolder();
                rootFile.File = "全部";
                rootFile.Progress += new ProgressEventHandler(rootFile_Progress);
                progressPanel.Show(dataGridViewCount);
                foreach (string file in files)
                {
                    AbstractCodeFile codeFile = CodeFileFactory.Create(file);
                    if (null != codeFile)
                    {
                        codeFile.Parent = rootFile;
                    }
                }
                rootFile.Count();
                progressPanel.Hide();
                rootFile.Sort();
                SetTreeView();
                //OutputCount();
                SetDataGridViewValue();
            }
            Cursor = Cursors.Default;
        }

        private void rootFile_Progress(object sender, ProgressEventArgs args)
        {
            this.progressPanel.MainMessage = args.MainMessage;
            this.progressPanel.SetMainMaximum(args.MainMaximum);
            this.progressPanel.SetMainValue(args.MainValue);

            this.progressPanel.SubMessage = args.SubMessage;
            this.progressPanel.SetSubMaximum(args.SubMaximum);
            this.progressPanel.SetSubValue(args.SubValue);
        }

        private void SetTreeView()
        {
            this.treeGridView.Nodes.Clear();
            this.treeGridView.ImageList = new ImageList();
            this.treeGridView.ImageList.ImageSize = new Size(16, 16);
            this.treeGridView.ImageList.TransparentColor = Color.Black;
            this.treeGridView.ImageList.Images.Add("folderOpen", Properties.Resources.FolderOpen_16x_32);
            this.treeGridView.ImageList.Images.Add("folderClose", Properties.Resources.Folder_16x_32);
            this.treeGridView.ImageList.Images.Add("file", Properties.Resources.Generic_Document);

            TreeGridNode rootNode = this.treeGridView.Nodes.Add(Path.GetFileName(this.rootFile.File));
            rootNode.Tag = this.rootFile;
            rootNode.Checked = true;
            foreach (AbstractCodeFile codeFile in this.rootFile.IncludeFiles)
            {
                SetTreeView(codeFile, rootNode);
            }
            labelTotal.Text = "总计：" + GenerateMessage(this.rootFile.CodeLineCount).Trim();

            this.treeGridView.Nodes[0].Expand();
            //rootNode.EnsureVisible();
        }

        private void SetTreeView(AbstractCodeFile codeFile, TreeGridNode parentNode)
        {
            TreeGridNode newNode = parentNode.Nodes.Add(Path.GetFileName(codeFile.File));
            newNode.Tag = codeFile;

            if (codeFile is CodeFolder)
            {
                newNode.ImageIndex = this.treeGridView.ImageList.Images.IndexOfKey("folderOpen");
            }
            else
            {
                ImageList.ImageCollection imageList = this.treeGridView.ImageList.Images;
                string imageKey = Path.GetExtension(codeFile.File);
                if (!imageList.ContainsKey(imageKey))
                {
                    Bitmap icon = IconHelper.GetBitmap(codeFile.File);
                    
                    imageList.Add(imageKey, icon);
                }
                newNode.ImageIndex = this.treeGridView.ImageList.Images.IndexOfKey(imageKey);
            }


            foreach (AbstractCodeFile item in codeFile.IncludeFiles)
            {
                SetTreeView(item, newNode);
            }
        }

        private void SetDataGridViewValue()
        {
            if (this.treeGridView.Nodes.Count > 0)
            {
                TreeGridNode rootNode = this.treeGridView.Nodes[0];
                foreach (TreeGridNode subNode in rootNode.Nodes)
                {
                    SetDataGridViewValue(subNode);
                }
            }
        }

        private void SetDataGridViewValue(TreeGridNode node)
        {
            AbstractCodeFile codeFile = node.Tag as AbstractCodeFile;
            DataGridViewRow row = node;
            SetDataGridViewValue(codeFile, node);
            if (codeFile.IncludeFiles.Count > 0)
            {
                row.DefaultCellStyle.BackColor = Color.Aquamarine;
            }
            else if (node.Checked)
            {
                row.DefaultCellStyle.BackColor = Color.GreenYellow;
            }

            foreach (TreeGridNode subNode in node.Nodes)
            {
                SetDataGridViewValue(subNode);
            }
        }

        private DataGridViewRow SetDataGridViewValue(AbstractCodeFile codeFile, DataGridViewRow row)
        {
            CodeLineCount countObj = codeFile.CodeLineCount;
            row.Tag = codeFile;
            row.Cells["colFile"].Value = Path.GetFileName(codeFile.File);
            row.Cells["colTotal"].Value = countObj.Total;
            int fixedCount = countObj.Total;
            foreach (ListViewItem item in listViewInclude.Items)
            {
                PropertyInfo info = item.Tag as PropertyInfo;
                int count = (int)info.GetValue(countObj, null);
                row.Cells["col" + info.Name].Value = count;
                if (!item.Checked)
                {
                    fixedCount -= count;
                }
            }
            row.Cells["colFixedCount"].Value = fixedCount;
            return row;
        }

        private void OutputCount()
        {
            //richTextBoxReport.Clear();

            StringBuilder countMessage = new StringBuilder();

            CodeLineCount totalCountObj = new CodeLineCount();
            foreach (AbstractCodeFile codeFile in this.rootFile.IncludeFiles)
            {
                countMessage.Append(GenerateMessage(codeFile));
                totalCountObj.Add(codeFile.CodeLineCount);
            }
            countMessage.AppendLine("----------------------------------所有工程总计----------------------------------");
            countMessage.Append(GenerateMessage(totalCountObj));
            labelTotal.Text = "总计：" + GenerateMessage(totalCountObj).Trim();

            //richTextBoxReport.Text = countMessage.ToString();
        }

        private string GenerateMessage(AbstractCodeFile codeFile)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(codeFile.File);
            message.Append(GenerateMessage(codeFile.CodeLineCount));

            foreach (AbstractCodeFile includeCodeFile in codeFile.IncludeFiles)
            {
                message.Append(GenerateMessage(includeCodeFile));
            }

            return message.ToString();
        }

        private string GenerateMessage(CodeLineCount countObj)
        {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("总行数：{0}", countObj.Total);
            int fixedCount = countObj.Total;
            foreach (ListViewItem item in listViewInclude.Items)
            {
                PropertyInfo info = item.Tag as PropertyInfo;
                int count = (int)info.GetValue(countObj, null);
                message.AppendFormat(", {0}：{1}", item.Text, count);
                if (!item.Checked)
                {
                    fixedCount -= count;
                }
            }
            message.AppendFormat(", 修正后行数：{0}", fixedCount);
            message.AppendLine();
            return message.ToString();
        }

        private void listViewInclude_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (this.treeViewFile.Nodes.Count > 0)
            {
                RefeshDataGridViewValue();
                TreeNode rootNode = this.treeViewFile.Nodes[0];
                CodeLineCount totalCountObj = (rootNode.Tag as AbstractCodeFile).CodeLineCount;
                labelTotal.Text = "总计：" + GenerateMessage(totalCountObj).Trim();
            }
        }

        private void RefeshDataGridViewValue()
        {
            List<string> fixColumnList = new List<string>();
            foreach (ListViewItem item in listViewInclude.Items)
            {
                PropertyInfo info = item.Tag as PropertyInfo;
                if (!item.Checked)
                {
                    fixColumnList.Add("col" + info.Name);
                }
            }

            foreach (DataGridViewRow row in dataGridViewCount.Rows)
            {
                int fixedCount = (int)row.Cells["colTotal"].Value;
                foreach (string columnName in fixColumnList)
                {
                    fixedCount -= (int)row.Cells[columnName].Value;
                }
                row.Cells["colFixedCount"].Value = fixedCount;
            }
        }

        private void treeViewFile_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level > 0)
            {
                CodeLineCount count = (this.treeViewFile.Nodes[0].Tag as AbstractCodeFile).CodeLineCount;
                AbstractCodeFile codeFile = e.Node.Tag as AbstractCodeFile;
                if (codeFile.IncludeFiles.Count == 0)
                {
                    if (e.Node.Checked)
                    {
                        count.Add(codeFile.CodeLineCount);
                    }
                    else
                    {
                        count.Sub(codeFile.CodeLineCount);
                    }
                }

                foreach (DataGridViewRow row in dataGridViewCount.Rows)
                {
                    if (row.Tag.Equals(e.Node.Tag))
                    {
                        if ((e.Node.Tag as AbstractCodeFile).IncludeFiles.Count > 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Aquamarine;
                        }
                        else
                        {
                            if (e.Node.Checked)
                            {
                                row.DefaultCellStyle.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.Gray;
                            }
                        }
                        break;
                    }
                }

                if (e.Action == TreeViewAction.ByMouse ||
                    e.Action == TreeViewAction.ByKeyboard)
                {
                    NodeChecked(e.Node, e.Node.Checked);
                }
                labelTotal.Text = "总计：" + GenerateMessage(count).Trim();
            }
        }

        private void NodeChecked(TreeNode node, bool isChecked)
        {
            if (node.Checked != isChecked)
            {
                node.Checked = isChecked;
            }
            foreach (TreeNode subNode in node.Nodes)
            {
                NodeChecked(subNode, isChecked);
            }
        }

        private void treeViewFile_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is CodeFolder || e.Node.Level == 0)
            {
                e.Node.ImageKey = "folderClose";
                e.Node.SelectedImageKey = "folderClose";
            }

            if (e.Node.Level > 0)
            {
                SetRowVisible(e.Node, false);
            }
        }

        private void SetRowVisible(TreeNode node, bool visible)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                if (!visible || node.IsExpanded)
                {
                    foreach (DataGridViewRow row in dataGridViewCount.Rows)
                    {
                        if (row.Tag.Equals(subNode.Tag))
                        {
                            row.Visible = visible;
                            break;
                        }
                    }
                    SetRowVisible(subNode, visible);
                }
            }
        }

        private void treeViewFile_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is CodeFolder || e.Node.Level == 0)
            {
                e.Node.ImageKey = "folderOpen";
                e.Node.SelectedImageKey = "folderOpen";
            }

            if (e.Node.Level > 0)
            {
                SetRowVisible(e.Node, true);
            }
        }

        private void menuCollapseSubNode_Click(object sender, System.EventArgs e)
        {
            TreeNode selectNode = treeViewFile.SelectedNode;
            if (null != selectNode)
            {
                foreach (TreeNode subNode in selectNode.Nodes)
                {
                    subNode.Collapse();
                }
            }
        }

        private void menuExpandSubNode_Click(object sender, System.EventArgs e)
        {
            TreeNode selectNode = treeViewFile.SelectedNode;
            if (null != selectNode)
            {
                foreach (TreeNode subNode in selectNode.Nodes)
                {
                    subNode.Expand();
                }
            }
        }
    }
}
