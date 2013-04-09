using System;
using DevTools.Plugin.CodeLines.Entity;
using System.Xml;
using System.IO;

namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// .NET 资源文件代码行数计数器
    /// </summary>
    [FileInfo(".resx")]
    public class CSharpResourceCounter : AbstractCounter
    {
        public override void Count(ref CodeLineCount count)
        {
            XmlDocument resx = new XmlDocument();
            using (FileStream stream = new FileStream(this.TargetFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                resx.Load(stream);
            }
            foreach (XmlNode dataNode in resx.DocumentElement.SelectNodes("data"))
            {
                if (null == dataNode.Attributes["type"])
                {
                    int resourceLines = dataNode.SelectSingleNode("value").InnerText
                        .Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
                    count.Resource += resourceLines;
                    count.Total += resourceLines;
                }
                else if (dataNode.Attributes["type"].Value.StartsWith("System.Resources.ResXFileRef",
                    StringComparison.OrdinalIgnoreCase))
                {
                    string resourceFile = dataNode.SelectSingleNode("value").InnerText.Split(';')[0];
                    string resourceDir = Path.GetDirectoryName(this.TargetFile);
                    while (resourceFile.Contains(@"..\"))
                    {
                        resourceDir = Path.GetDirectoryName(resourceDir);
                        resourceFile = resourceFile.Substring(3);
                    }
                    string resourceTxtFile = Path.Combine(resourceDir, resourceFile);
                    using (StreamReader reader = new StreamReader(resourceTxtFile))
                    {
                        while (!reader.EndOfStream)
                        {
                            string currentLine = reader.ReadLine().Trim();
                            if (currentLine.Length > 0)
                            {
                                count.Resource++;
                                count.Total++;
                            }
                        }
                    }
                }
            }
        }

        public override string AnnotateLineKeyWord
        {
            get { return string.Empty; }
        }

        public override string AnnotateBlockBeginKeyWord
        {
            get { return string.Empty; }
        }

        public override string AnnotateBlockEndKeyWord
        {
            get { return string.Empty; }
        }
    }
}
