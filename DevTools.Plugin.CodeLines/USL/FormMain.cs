using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevTools.Plugin.CodeLines.BLL;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.USL
{
    /// <summary>
    /// 代码统计主窗体
    /// </summary>
    public partial class FormMain : Form
    {
        private List<AbstractCodeFile> codeFileList = new List<AbstractCodeFile>();

        public FormMain()
        {
            InitializeComponent();
            this.treeViewFile.Nodes.Clear();

            InitializeInclude();
        }

        private void InitializeInclude()
        {
            this.listViewInclude.Items.Clear();
            this.dataGridViewCount.Columns.Clear();
            this.dataGridViewCount.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "文件",
                ValueType = typeof(string),
                Width = 80,
                Name = "colFile"
            });
            this.dataGridViewCount.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "总行数",
                ValueType = typeof(int),
                Width = 80,
                Name = "colTotal"
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

                        this.dataGridViewCount.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            HeaderText = attr.DisplayName,
                            ValueType = typeof(int),
                            Width = 80,
                            Name = "col" + info.Name
                        });
                    }
                }
            }
            this.dataGridViewCount.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "修正后行数",
                ValueType = typeof(int),
                Width = 80,
                Name = "colFixedCount"
            });
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                codeFileList.Clear();
                Cursor = Cursors.WaitCursor;
                foreach (string file in files)
                {
                    AbstractCodeFile codeFile = CodeFileFactory.Create(file);
                    if (null != codeFile)
                    {
                        codeFile.Count();
                        this.codeFileList.Add(codeFile);
                    }
                }
                Cursor = Cursors.Default;
                SetTreeView();
                //OutputCount();
                SetDataGridViewValue();
            }
        }

        private void SetTreeView()
        {
            this.treeViewFile.Nodes.Clear();
            this.treeViewFile.ImageList = new ImageList();
            this.treeViewFile.ImageList.Images.Add("folderOpen", Properties.Resources.folder_open);
            this.treeViewFile.ImageList.Images.Add("folderClose", Properties.Resources.folder_closed_16x16);
            this.treeViewFile.ImageList.Images.Add("file", Properties.Resources.Generic_Document);
            this.treeViewFile.ImageKey = "file";

            TreeNode rootNode = this.treeViewFile.Nodes.Add("全部");
            CodeLineCount totalCountObj = new CodeLineCount();
            rootNode.Tag = totalCountObj;
            rootNode.Checked = true;
            foreach (AbstractCodeFile codeFile in codeFileList)
            {
                SetTreeView(codeFile, rootNode);
                totalCountObj.Add(codeFile.CodeLineCount);
            }
            labelTotal.Text = "总计：" + GenerateMessage(totalCountObj).Trim();

            this.treeViewFile.ExpandAll();
            rootNode.EnsureVisible();
        }

        private void SetTreeView(AbstractCodeFile codeFile, TreeNode parentNode)
        {
            TreeNode newNode = parentNode.Nodes.Add(Path.GetFileName(codeFile.File));
            newNode.Tag = codeFile;
            newNode.Checked = true;

            if (codeFile is CodeFolder)
            {
                newNode.ImageKey = "folderOpen";
            }
            else
            {
                ImageList.ImageCollection imageList = this.treeViewFile.ImageList.Images;
                string imageKey = Path.GetExtension(codeFile.File);
                if (!imageList.ContainsKey(imageKey))
                {
                    Icon icon = Icon.ExtractAssociatedIcon(codeFile.File);
                    imageList.Add(imageKey, icon);
                }
                newNode.ImageKey = imageKey;
            }
            

            foreach (AbstractCodeFile item in codeFile.IncludeFiles)
            {
                SetTreeView(item, newNode);
            }
        }

        private void SetDataGridViewValue()
        {
            this.dataGridViewCount.Rows.Clear();
            if (this.treeViewFile.Nodes.Count > 0)
            {
                TreeNode rootNode = this.treeViewFile.Nodes[0];
                foreach (TreeNode subNode in rootNode.Nodes)
                {
                    SetDataGridViewValue(subNode);
                }
            }
        }

        private void SetDataGridViewValue(TreeNode node)
        {
            AbstractCodeFile codeFile = node.Tag as AbstractCodeFile;
            DataGridViewRow row = SetDataGridViewValue(codeFile);
            if (codeFile.IncludeFiles.Count > 0)
            {
                row.DefaultCellStyle.BackColor = Color.Aquamarine;
            }
            else if (node.Checked)
            {
                row.DefaultCellStyle.BackColor = Color.GreenYellow;
            }

            // TODO: 统计代码行数时，显示进度条

            foreach (TreeNode subNode in node.Nodes)
            {
                SetDataGridViewValue(subNode);
            }
        }

        private DataGridViewRow SetDataGridViewValue(AbstractCodeFile codeFile)
        {
            CodeLineCount countObj = codeFile.CodeLineCount;
            int rowIndex = this.dataGridViewCount.Rows.Add();
            DataGridViewRow row = this.dataGridViewCount.Rows[rowIndex];
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
            foreach (AbstractCodeFile codeFile in codeFileList)
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
                CodeLineCount totalCountObj = rootNode.Tag as CodeLineCount;
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
                CodeLineCount count = this.treeViewFile.Nodes[0].Tag as CodeLineCount;
                AbstractCodeFile codeFile = e.Node.Tag as AbstractCodeFile;
                if (e.Node.Checked)
                {
                    count.Add(codeFile.CodeLineCount);
                }
                else
                {
                    count.Sub(codeFile.CodeLineCount);
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
            node.Checked = isChecked;
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

        private void treeViewFile_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is CodeFolder || e.Node.Level == 0)
            {
                e.Node.ImageKey = "folderOpen";
            }

            if (e.Node.Level > 0)
            {
                SetRowVisible(e.Node, true);
            }
        }
    }
}
