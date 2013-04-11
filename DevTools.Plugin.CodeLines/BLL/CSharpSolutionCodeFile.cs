using System;
using System.Collections.Generic;
using System.IO;
using DevTools.Plugin.CodeLines.DAL;

namespace DevTools.Plugin.CodeLines.BLL
{
    /// <summary>
    /// .NET 解决方案文件
    /// </summary>
    [FileInfo(".sln")]
    public class CSharpSolutionCodeFile : AbstractCodeFile
    {
        protected override void GetCount()
        {
            using (StreamReader reader = new StreamReader(this.File))
            {
                while (!reader.EndOfStream)
                {
                    string currentLine = reader.ReadLine();
                    if (currentLine.StartsWith("Project", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] infos = currentLine.Split(',');
                        string project = Path.Combine(Path.GetDirectoryName(this.File),
                            infos[1].Trim().Trim('"'));
                        if (System.IO.File.Exists(project))
                        {
                            CSharpProjectCodeFile projectCodeFile = new CSharpProjectCodeFile();
                            projectCodeFile.File = project;
                            projectCodeFile.Parent = this;
                        }
                    }
                }
            }
            foreach (CSharpProjectCodeFile projectCodeFile in this.IncludeFiles)
            {
                projectCodeFile.Count();
                //OnProgress(projectCodeFile);
            }
        }
    }
}
