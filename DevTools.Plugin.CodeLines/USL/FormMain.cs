using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevTools.Plugin.CodeLines.BLL;
using DevTools.Plugin.CodeLines.DAL;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.USL
{
    /// <summary>
    /// 代码统计主窗体
    /// </summary>
    public partial class FormMain : Form
    {
        private Dictionary<string, CodeLineCount> _CodeLineCountDict = new Dictionary<string, CodeLineCount>();

        public FormMain()
        {
            InitializeComponent();

            this.listViewInclude.Items.Clear();
            foreach (PropertyInfo info in typeof(CodeLineCount).GetProperties())
            {
                object[] attrArray = info.GetCustomAttributes(typeof(CountAttribute), false);
                if (attrArray.Length > 0)
                {
                    CountAttribute attr = attrArray[0] as CountAttribute;
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
                _CodeLineCountDict.Clear();
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
            ICountable count = CounterFactory.Create(file);
            if (null != count)
            {
                CodeLineCount codeLineCount = new CodeLineCount();
                count.Count(ref codeLineCount);
                _CodeLineCountDict[file] = codeLineCount;
            }
            else
            {
                Count(file);
            }
        }

        private void OutputCount()
        {
            richTextBoxReport.Clear();
            StringBuilder countMessage = new StringBuilder();
            StringBuilder totalCountMessage = new StringBuilder();

            CodeLineCount totalCountObj = new CodeLineCount();
            int totalFixedCount = 0;
            foreach (string key in _CodeLineCountDict.Keys)
            {
                totalCountMessage = new StringBuilder();
                CodeLineCount countObj = _CodeLineCountDict[key];
                countMessage.AppendLine(key);
                countMessage.AppendFormat("总行数：{0}", countObj.Total);
                totalCountObj.Total += countObj.Total;
                totalCountMessage.AppendFormat("总行数：{0}", totalCountObj.Total);

                int fixedCount = _CodeLineCountDict[key].Total;
                foreach (ListViewItem item in listViewInclude.Items)
                {
                    PropertyInfo info = item.Tag as PropertyInfo;
                    int count = (int)info.GetValue(countObj, null);
                    countMessage.AppendFormat(", {0}：{1}", item.Text, count);
                    info.SetValue(totalCountObj,
                        count + (int)info.GetValue(totalCountObj, null), null);
                    totalCountMessage.AppendFormat(", {0}：{1}", item.Text, info.GetValue(totalCountObj, null));
                    if (!item.Checked)
                    {
                        fixedCount -= count;
                    }
                }

                countMessage.AppendFormat(", 修正后行数：{0}", fixedCount);
                countMessage.AppendLine();

                totalFixedCount += fixedCount;
                totalCountMessage.AppendFormat(", 修正后行数：{0}", totalFixedCount);
                totalCountMessage.AppendLine();
            }
            countMessage.AppendLine("----------------------------------所有工程总计----------------------------------");
            richTextBoxReport.Text = countMessage.ToString();
            richTextBoxReport.AppendText(totalCountMessage.ToString());
        }

        private void Count(string file)
        {
            // TODO: 提取csproj和sln的计数器
            if (0 == string.Compare(Path.GetExtension(file), ".csproj", true))
            {
                if (File.Exists(file))
                {
                    XmlDocument xml = new XmlDocument();
                    using (FileStream stream = new FileStream(file, FileMode.Open))
                    {
                        xml.Load(stream);
                    }
                    CodeLineCount codeLineCount = new CodeLineCount();
                    _CodeLineCountDict.Add(file, codeLineCount);
                    CountCSFile(file, xml, ref codeLineCount);
                    CountResourceFile(file, xml, ref codeLineCount);
                }
            }
            else if (0 == string.Compare(Path.GetExtension(file), ".sln", true))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        string currentLine = reader.ReadLine();
                        if (currentLine.StartsWith("Project", StringComparison.OrdinalIgnoreCase))
                        {
                            string[] infos = currentLine.Split(',');
                            string project = Path.Combine(Path.GetDirectoryName(file),
                                infos[1].Trim().Trim('"'));
                            Count(project);
                        }
                    }
                }
            }
        }

        private static void CountResourceFile(string file, XmlDocument xml, ref CodeLineCount codeLineCount)
        {
            if (!File.Exists(file)) return;
            XmlNamespaceManager xmlns = new XmlNamespaceManager(xml.NameTable);
            xmlns.AddNamespace("ns", "http://schemas.microsoft.com/developer/msbuild/2003");
            foreach (XmlNode node in xml.DocumentElement.SelectNodes("descendant::ns:ItemGroup/ns:EmbeddedResource", xmlns))
            {
                string resxFile = Path.Combine(Path.GetDirectoryName(file),
                    node.Attributes["Include"].Value);
                if (File.Exists(resxFile) &&
                    0 == string.Compare(Path.GetExtension(resxFile), ".resx", true))
                {
                    XmlDocument resx = new XmlDocument();
                    using (FileStream stream = new FileStream(resxFile, FileMode.Open))
                    {
                        xml.Load(stream);
                    }
                    foreach (XmlNode dataNode in xml.DocumentElement.SelectNodes("data"))
                    {
                        if (null == dataNode.Attributes["type"])
                        {
                            int resourceLines = dataNode.SelectSingleNode("value").InnerText
                                .Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
                            codeLineCount.Resource += resourceLines;
                            codeLineCount.Total += resourceLines;
                        }
                        else if (dataNode.Attributes["type"].Value.StartsWith("System.Resources.ResXFileRef",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            string resourceTxtFile = Path.Combine(Path.GetDirectoryName(file),
                                dataNode.SelectSingleNode("value").InnerText.Split(';')[0].
                                    TrimStart(@"..\".ToCharArray()));
                            using (StreamReader reader = new StreamReader(resourceTxtFile))
                            {
                                while (!reader.EndOfStream)
                                {
                                    string currentLine = reader.ReadLine().Trim();
                                    if (currentLine.Length > 0)
                                    {
                                        codeLineCount.Resource++;
                                        codeLineCount.Total++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void CountCSFile(string file, XmlDocument xml, ref CodeLineCount codeLineCount)
        {
            if (!File.Exists(file)) return;
            bool isDesignFile = false;
            bool inAnnotateBlock = false;
            XmlNamespaceManager xmlns = new XmlNamespaceManager(xml.NameTable);
            xmlns.AddNamespace("ns", "http://schemas.microsoft.com/developer/msbuild/2003");
            foreach (XmlNode node in xml.DocumentElement.SelectNodes("descendant::ns:ItemGroup/ns:Compile", xmlns))
            {
                string codeFile = Path.Combine(Path.GetDirectoryName(file),
                    node.Attributes["Include"].Value);
                if (0 == string.Compare(Path.GetExtension(codeFile), ".cs", true))
                {
                    if (!File.Exists(codeFile))
                    {
                        continue;
                    }
                    isDesignFile = codeFile.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase);
                    using (StreamReader reader = new StreamReader(codeFile))
                    {
                        while (!reader.EndOfStream)
                        {
                            string currentLine = reader.ReadLine().Trim();
                            if (0 < currentLine.Length)
                            {
                                if (currentLine.StartsWith("//", StringComparison.OrdinalIgnoreCase))
                                {
                                    codeLineCount.Annotate++;
                                }
                                else if (currentLine.StartsWith("/*"))
                                {
                                    inAnnotateBlock = true;
                                }
                                else if (inAnnotateBlock)
                                {
                                    if (currentLine.EndsWith("*/"))
                                    {
                                        inAnnotateBlock = false;
                                    }
                                    codeLineCount.Annotate++;
                                }
                                else if (isDesignFile)
                                {
                                    codeLineCount.Design++;
                                }
                                codeLineCount.Total++;
                            }
                        }
                    }
                    isDesignFile = false;
                }
            }
        }

        private void listViewInclude_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OutputCount();
        }
    }
}
