using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevTools.Plugin.CodeLines.DAL;

namespace DevTools.Plugin.CodeLines.BLL
{
    /// <summary>
    /// .NET 解决方案文件
    /// </summary>
    [FileInfo(".sln")]
    public class CSharpSolutionCodeFile : AbstractCodeFile
    {
        private readonly Dictionary<string, AbstractCodeFile> codeFileDict;

        public CSharpSolutionCodeFile()
        {
            codeFileDict = new Dictionary<string, AbstractCodeFile>();
        }

        protected override void GetCount()
        {
            codeFileDict.Clear();
            using (StreamReader reader = new StreamReader(File))
            {
                while (!reader.EndOfStream)
                {
                    string currentLine = reader.ReadLine() ?? string.Empty;
                    if (currentLine.StartsWith("Project", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] infos = currentLine.Split(',');
                        string project = Path.Combine(Path.GetDirectoryName(File),
                            infos[1].Trim().Trim('"'));
                        if (System.IO.File.Exists(project))
                        {
                            CSharpProjectCodeFile projectCodeFile = new CSharpProjectCodeFile();
                            projectCodeFile.File = project;
                            string key = GetKey(project);
                            projectCodeFile.Parent = codeFileDict.ContainsKey(key)
                                ? codeFileDict[key]
                                : this;
                        }
                    }
                }
            }
            foreach (AbstractCodeFile codeFile in IncludeFiles)
            {
                codeFile.Count();
            }
        }

        private string GetKey(string project)
        {
            string solutionFolder = Path.GetDirectoryName(File) ?? string.Empty;
            string key = Path.GetDirectoryName(project.Replace(solutionFolder, string.Empty).Trim('\\'));
            string[] keyNodes = key.Split('\\');
            for (int i = 0; i < keyNodes.Length; i++)
            {
                string node = string.Join("\\", keyNodes.Take(i + 1));
                string parentNode = string.Join("\\", keyNodes.Take(i));
                if (!codeFileDict.ContainsKey(node))
                {
                    if (Path.GetFileName(node) == Path.GetFileNameWithoutExtension(project))
                    {
                        codeFileDict.Add(node, string.IsNullOrEmpty(parentNode)
                            ? this
                            : codeFileDict[parentNode]);
                    }
                    else
                    {
                        codeFileDict.Add(node, new CodeFolder()
                        {
                            File = node
                        });
                        codeFileDict[node].Parent = i == 0
                            ? this
                            : codeFileDict[parentNode];
                    }
                    
                }
            }
            
            return key;
        }
    }
}
