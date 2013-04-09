using System.Collections.Generic;
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

            InitializeInclude();
        }

        private void InitializeInclude()
        {
            this.listViewInclude.Items.Clear();
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
                    }
                }
            }
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
                    FileInfo info = new FileInfo(file);
                    if ((info.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        CountFolder(file);
                    }
                    else
                    {
                        CountFile(file);
                    }
                }
                Cursor = Cursors.Default;
                OutputCount();
            }
        }

        private void CountFolder(string folder)
        {
            foreach (string file in Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories))
            {
                CountFile(file);
            }
        }

        private void CountFile(string file)
        {
            AbstractCodeFile codeFile = CodeFileFactory.Create(file);
            if (null != codeFile)
            {
                codeFile.Count();
                this.codeFileList.Add(codeFile);
            }
        }

        private void OutputCount()
        {
            richTextBoxReport.Clear();
            StringBuilder countMessage = new StringBuilder();

            CodeLineCount totalCountObj = new CodeLineCount();
            foreach (AbstractCodeFile codeFile in codeFileList)
            {
                countMessage.Append(GenerateMessage(codeFile));
                totalCountObj = totalCountObj + codeFile.CodeLineCount;
            }
            countMessage.AppendLine("----------------------------------所有工程总计----------------------------------");
            countMessage.Append(GenerateMessage(totalCountObj));

            richTextBoxReport.Text = countMessage.ToString();
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
            OutputCount();
        }
    }
}
