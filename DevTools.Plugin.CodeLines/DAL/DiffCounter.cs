using System.IO;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
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
    }
}
