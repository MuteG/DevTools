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

        protected override void GetCount()
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

            string resourceNoneXPath = "descendant::ns:ItemGroup/ns:None";
            XmlNodeList resourceNoneNodeList = xml.DocumentElement.SelectNodes(resourceNoneXPath, xmlns);
            CountFile(resourceNoneNodeList);
        }

        private void CountFile(XmlNodeList csNodeList)
        {
            string fileDir = Path.GetDirectoryName(this.File);
            foreach (XmlNode node in csNodeList)
            {
                string fileName = node.Attributes["Include"].Value;
                string file = Path.Combine(fileDir, fileName);
                FileInfo fileInfo = new FileInfo(file);

                if (fileInfo.Exists && fileInfo.FullName.Contains(fileDir))
                {
                    fileName = fileInfo.FullName.Replace(fileDir, string.Empty).Trim('\\');
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
                                codeFolder.Parent = this;
                            }
                            else
                            {
                                codeFolder.Parent = this.codeFileDict[Path.GetDirectoryName(key)];
                            }
                        }
                    }

                    AbstractCodeFile codeFile = CodeFileFactory.Create(file);
                    if (null != codeFile)
                    {
                        if (this.codeFileDict.ContainsKey(key))
                        {
                            codeFile.Parent = this.codeFileDict[key];
                        }
                        else
                        {
                            codeFile.Parent = this;
                        }
                    }
                }
            }

            foreach (AbstractCodeFile codeFile in this.IncludeFiles)
            {
                codeFile.Count();
            }
        }
    }
}
