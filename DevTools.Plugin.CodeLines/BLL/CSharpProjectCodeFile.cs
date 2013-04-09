using System;
using System.IO;
using System.Xml;
using DevTools.Plugin.CodeLines.DAL;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.BLL
{
    /// <summary>
    /// C#工程文件
    /// </summary>
    [FileInfo(".csproj")]
    public class CSharpProjectCodeFile : AbstractCodeFile
    {
        public override void Count()
        {
            XmlDocument xml = new XmlDocument();
            using (FileStream stream = new FileStream(this.File, FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite))
            {
                xml.Load(stream);
            }

            XmlNamespaceManager xmlns = new XmlNamespaceManager(xml.NameTable);
            xmlns.AddNamespace("ns", "http://schemas.microsoft.com/developer/msbuild/2003");

            string csXPath = "descendant::ns:ItemGroup/ns:Compile";
            XmlNodeList csNodeList = xml.DocumentElement.SelectNodes(csXPath, xmlns);
            CountFile(csNodeList);

            string resourceXPath = "descendant::ns:ItemGroup/ns:EmbeddedResource";
            XmlNodeList resourceNodeList = xml.DocumentElement.SelectNodes(resourceXPath, xmlns);
            CountFile(resourceNodeList);
        }

        private void CountFile(XmlNodeList csNodeList)
        {
            string fileDir = Path.GetDirectoryName(this.File);
            foreach (XmlNode node in csNodeList)
            {
                string fileName = node.Attributes["Include"].Value;
                string codeFile = Path.Combine(fileDir, fileName);
                if (System.IO.File.Exists(codeFile))
                {
                    AbstractCodeFile file = CodeFileFactory.Create(codeFile);
                    if (null != file)
                    {
                        file.Count();
                        this.IncludeFiles.Add(file);
                        this.codeLineCount = this.CodeLineCount + file.CodeLineCount;
                    }
                }
            }
        }
    }
}
