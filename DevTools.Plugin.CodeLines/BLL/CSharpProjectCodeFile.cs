using System.Collections.Generic;
using System.IO;
using System.Xml;
using DevTools.Plugin.CodeLines.DAL;

namespace DevTools.Plugin.CodeLines.BLL
{
    /// <summary>
    /// C#工程文件
    /// </summary>
    [FileInfo(".csproj")]
    public class CSharpProjectCodeFile : AbstractCodeFile
    {
        private Dictionary<string, AbstractCodeFile> codeFileDict;

        public CSharpProjectCodeFile()
        {
            this.codeFileDict = new Dictionary<string, AbstractCodeFile>();
        }

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

            // TODO: 多级目录的情况下，只有最底层目录的计数奏效，上层目录也需要进行计数填充
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
                    string[] fileNamePart = fileName.Split('\\');
                    string key = string.Empty;
                    for (int i = 0; i < fileNamePart.Length - 1; i++)
                    {
                        key = string.Join("\\", fileNamePart, 0, i + 1);
                        if (!this.codeFileDict.ContainsKey(key))
                        {
                            CodeFolder codeFolder = new CodeFolder();
                            codeFolder.File = fileNamePart[i];
                            this.codeFileDict.Add(key, codeFolder);
                            if (0 == i)
                            {
                                this.IncludeFiles.Add(codeFolder);
                            }
                            else
                            {
                                this.codeFileDict[Path.GetDirectoryName(key)].IncludeFiles.Add(codeFolder);
                            }
                        }
                    }

                    AbstractCodeFile file = CodeFileFactory.Create(codeFile);
                    if (null != file)
                    {
                        file.Count();
                        this.codeFileDict[key].IncludeFiles.Add(file);
                        this.codeFileDict[key].CodeLineCount.Add(file.CodeLineCount);
                        this.CodeLineCount.Add(file.CodeLineCount);
                    }
                }
            }
        }
    }
}
