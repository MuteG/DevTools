using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AdvancedDataGridView;
using DevTools.Common.IO;
using DevTools.Common.UI;
using DevTools.Plugin.CodeLines.BLL;
using DevTools.Plugin.CodeLines.Entity;
using DevTools.Plugin.CodeLines.Properties;

namespace DevTools.Plugin.CodeLines.USL
{
    /// <summary>
    /// 代码统计主窗体
    /// </summary>
    public partial class FormMain : Form
    {
        private AbstractCodeFile rootFile;
        private ProgressPanel progressPanel = new ProgressPanel();

        public FormMain()
        {
            InitializeComponent();
            //this.treeViewFile.Nodes.Clear();
            treeGridView.Nodes.Clear();

            InitializeInclude();
        }

        private void InitializeInclude()
        {
            listViewInclude.Items.Clear();
            treeGridView.Columns.Clear();
            treeGridView.Columns.Add(new TreeGridColumn
            {
                HeaderText = "文件",
                ValueType = typeof(string),
                Width = 80,
                Name = "colFile",
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            treeGridView.Columns.Add(new DataGridViewTextBoxColumn
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
                        ListViewItem item = listViewInclude.Items.Add(attr.DisplayName);
                        item.Checked = attr.IsInclude;
                        item.Tag = info;

                        treeGridView.Columns.Add(new DataGridViewTextBoxColumn
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
            treeGridView.Columns.Add(new DataGridViewTextBoxColumn
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
                rootFile.Progress += rootFile_Progress;
                progressPanel.Show(treeGridView);
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
            progressPanel.MainMessage = args.MainMessage;
            progressPanel.SetMainMaximum(args.MainMaximum);
            progressPanel.SetMainValue(args.MainValue);

            progressPanel.SubMessage = args.SubMessage;
            progressPanel.SetSubMaximum(args.SubMaximum);
            progressPanel.SetSubValue(args.SubValue);
        }

        private void SetTreeView()
        {
            treeGridView.Nodes.Clear();
            treeGridView.ImageList = new ImageList();
            treeGridView.ImageList.ImageSize = new Size(16, 16);
            treeGridView.ImageList.TransparentColor = Color.Black;
            treeGridView.ImageList.Images.Add("folderOpen", Resources.FolderOpen_16x_32);
            treeGridView.ImageList.Images.Add("folderClose", Resources.Folder_16x_32);
            treeGridView.ImageList.Images.Add("file", Resources.Generic_Document);

            TreeGridNode rootNode = treeGridView.Nodes.Add(Path.GetFileName(rootFile.File));
            rootNode.Tag = rootFile;
            rootNode.Checked = true;
            foreach (AbstractCodeFile codeFile in rootFile.IncludeFiles.OrderBy(f => f.File))
            {
                SetTreeView(codeFile, rootNode);
            }
            labelTotal.Text = "总计：" + GenerateMessage(rootFile.CodeLineCount).Trim();

            treeGridView.Nodes[0].Expand();
            //rootNode.EnsureVisible();
        }

        private void SetTreeView(AbstractCodeFile codeFile, TreeGridNode parentNode)
        {
            TreeGridNode newNode = parentNode.Nodes.Add(Path.GetFileName(codeFile.File));
            newNode.Tag = codeFile;

            if (codeFile is CodeFolder)
            {
                newNode.ImageIndex = treeGridView.ImageList.Images.IndexOfKey("folderOpen");
            }
            else
            {
                ImageList.ImageCollection imageList = treeGridView.ImageList.Images;
                string imageKey = Path.GetExtension(codeFile.File);
                if (!imageList.ContainsKey(imageKey))
                {
                    Bitmap icon = IconHelper.GetBitmap(codeFile.File);
                    
                    imageList.Add(imageKey, icon);
                }
                newNode.ImageIndex = treeGridView.ImageList.Images.IndexOfKey(imageKey);
            }


            foreach (AbstractCodeFile item in codeFile.IncludeFiles.OrderBy(f => f.File))
            {
                SetTreeView(item, newNode);
            }
        }

        private void SetDataGridViewValue()
        {
            if (treeGridView.Nodes.Count > 0)
            {
                TreeGridNode rootNode = treeGridView.Nodes[0];
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
            foreach (AbstractCodeFile codeFile in rootFile.IncludeFiles)
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
            if (treeGridView.Nodes.Count > 0)
            {
                RefeshDataGridViewValue();
                TreeGridNode rootNode = treeGridView.Nodes[0];
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

            foreach (DataGridViewRow row in treeGridView.Rows)
            {
                if (row.Cells["colTotal"].Value != null)
                {
                    int fixedCount = (int)row.Cells["colTotal"].Value;
                    foreach (string columnName in fixColumnList)
                    {
                        fixedCount -= (int)row.Cells[columnName].Value;
                    }

                    row.Cells["colFixedCount"].Value = fixedCount;
                }
            }
        }

        private void SetRowVisible(TreeNode node, bool visible)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                if (!visible || node.IsExpanded)
                {
                    foreach (DataGridViewRow row in treeGridView.Rows)
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

        private void menuCollapseSubNode_Click(object sender, EventArgs e)
        {
            TreeGridNode selectNode = treeGridView.SelectedNode;
            if (null != selectNode)
            {
                foreach (TreeGridNode subNode in selectNode.Nodes)
                {
                    subNode.Collapse();
                }
            }
        }

        private void menuExpandSubNode_Click(object sender, EventArgs e)
        {
            TreeGridNode selectNode = treeGridView.SelectedNode;
            if (null != selectNode)
            {
                foreach (TreeGridNode subNode in selectNode.Nodes)
                {
                    subNode.Expand();
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void treeGridView_NodeCollapsed(object sender, CollapsedEventArgs e)
        {
            if (e.Node.Tag is CodeFolder || e.Node.Level == 0)
            {
                e.Node.ImageIndex = 1;
            }
        }

        private void treeGridView_NodeExpanded(object sender, ExpandedEventArgs e)
        {
            if (e.Node.Tag is CodeFolder || e.Node.Level == 0)
            {
                e.Node.ImageIndex = 0;
            }
        }

        private void treeGridView_NodeChecked(object sender, CheckedEventArgs e)
        {
            if (e.Node.Level > 1)
            {
                CodeLineCount count = (treeGridView.Nodes[0].Tag as AbstractCodeFile).CodeLineCount;
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

                foreach (DataGridViewRow row in treeGridView.Rows)
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

                if (e.IsChangedByProgram)
                {
                    NodeChecked(e.Node, e.Node.Checked);
                }
                labelTotal.Text = "总计：" + GenerateMessage(count).Trim();
            }
        }

        private void NodeChecked(TreeGridNode node, bool isChecked)
        {
            if (node.Checked != isChecked)
            {
                node.Checked = isChecked;
            }
            foreach (TreeGridNode subNode in node.Nodes)
            {
                NodeChecked(subNode, isChecked);
            }
        }
    }
}
