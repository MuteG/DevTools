using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevTools.Plugin.CodeLines.BLL;
using DevTools.Plugin.CodeLines.DAL;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.USL
{
    /// <summary>
    /// Description of FormMain.
    /// </summary>
    public partial class FormMain : Form
    {
        // TODO: “包含”的选项动态生成，把各个包含类型进行抽象
        private Dictionary<string, CodeLineCount> _CodeLineCountDict = new Dictionary<string, CodeLineCount>();

        public FormMain()
        {
            InitializeComponent();
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
            richTextBox1.Clear();
            StringBuilder countMessage = new StringBuilder();
            int total = 0, annotate = 0, design = 0, resource = 0, mix = 0;
            foreach (string key in _CodeLineCountDict.Keys)
            {
                countMessage.AppendLine(key);
                countMessage.AppendFormat("总行数：{0}，注释行数：{1}，注释代码混合：{5}，设计行数：{2}，资源文件行数：{3}，修正后行数：{4}",
                    _CodeLineCountDict[key].Total,
                    _CodeLineCountDict[key].Annotate,
                    _CodeLineCountDict[key].Design,
                    _CodeLineCountDict[key].Resource,
                    _CodeLineCountDict[key].Total -
                        (checkBoxAnnotate.Checked ? 0 : _CodeLineCountDict[key].Annotate) -
                        (checkBoxDesign.Checked ? 0 : _CodeLineCountDict[key].Design) -
                        (checkBoxResource.Checked ? 0 : _CodeLineCountDict[key].Resource) -
                        (checkBoxIncludeMix.Checked ? 0 : _CodeLineCountDict[key].AnnotateMix),
                    _CodeLineCountDict[key].AnnotateMix);
                countMessage.AppendLine();
                total += _CodeLineCountDict[key].Total;
                annotate += _CodeLineCountDict[key].Annotate;
                design += _CodeLineCountDict[key].Design;
                resource += _CodeLineCountDict[key].Resource;
                mix += _CodeLineCountDict[key].AnnotateMix;
            }
            countMessage.AppendLine("----------------------------------所有工程总计----------------------------------");
            countMessage.AppendFormat("总行数：{0}，注释行数：{1}，注释代码混合：{5}，设计行数：{2}，资源文件行数：{3}，修正后行数：{4}",
                total, annotate, design, resource,
                total -
                    (checkBoxAnnotate.Checked ? 0 : annotate) -
                    (checkBoxDesign.Checked ? 0 : design) -
                    (checkBoxResource.Checked ? 0 : resource) -
                    (checkBoxIncludeMix.Checked ? 0 : mix),
                mix);
            countMessage.AppendLine();
            richTextBox1.Text = countMessage.ToString();
        }

        private void Count(string file)
        {
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

        private void checkBoxAnnotate_CheckedChanged(object sender, EventArgs e)
        {
            OutputCount();
        }

    }
}
