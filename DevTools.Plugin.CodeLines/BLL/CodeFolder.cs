using System.IO;

namespace DevTools.Plugin.CodeLines.BLL
{
    public class CodeFolder : AbstractCodeFile
    {
        protected override void GetCount()
        {
            string[] folders = Directory.GetDirectories(this.File);
            foreach (string folder in folders)
            {
                CodeFolder codeFolder = new CodeFolder();
                codeFolder.File = folder;
                codeFolder.Parent = this;
            }

            string[] files = Directory.GetFiles(this.File, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                AbstractCodeFile codeFile = CodeFileFactory.Create(file);
                if (null != codeFile)
                {
                    codeFile.Parent = this;
                }
            }

            foreach (AbstractCodeFile codeFile in this.IncludeFiles)
            {
                codeFile.Count();
                //OnProgress(codeFile);
            }
        }
    }
}
