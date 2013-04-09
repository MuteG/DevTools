using System.IO;

namespace DevTools.Plugin.CodeLines.BLL
{
    public class CodeFolder : AbstractCodeFile
    {
        public override void Count()
        {
            string[] folders = Directory.GetDirectories(this.File);
            foreach (string folder in folders)
            {
                CodeFolder codeFolder = new CodeFolder();
                codeFolder.File = folder;
                codeFolder.Count();
                this.IncludeFiles.Add(codeFolder);
                this.CodeLineCount.Add(codeFolder.CodeLineCount);
            }

            string[] files = Directory.GetFiles(this.File, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                AbstractCodeFile codeFile = CodeFileFactory.Create(file);
                codeFile.File = file;
                codeFile.Count();
                this.IncludeFiles.Add(codeFile);
                this.CodeLineCount.Add(codeFile.CodeLineCount);
            }
        }
    }
}
