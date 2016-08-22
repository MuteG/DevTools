using System.IO;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// 标准差分文件行数计数器
    /// </summary>
    [FileInfo(".diff")]
    public class DiffCounter : AbstractCounter
    {
        public override void Count(ref CodeLineCount count)
        {
            if (File.Exists(TargetFile))
            {
                using (StreamReader reader = new StreamReader(TargetFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string currentLine = reader.ReadLine().Trim();
                        if (currentLine.StartsWith("-") || currentLine.StartsWith("+"))
                        {
                            if (!currentLine.StartsWith("---") && !currentLine.StartsWith("+++"))
                            {
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
