using System;
using System.IO;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
    public class CSharpCounter : AbstractCounter
    {
        public override void Count(ref CodeLineCount count)
        {
            bool isDesignFile = false;
            bool inAnnotateBlock = false;
            if (File.Exists(TargetFile))
            {
                isDesignFile = TargetFile.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase);
                using (StreamReader reader = new StreamReader(TargetFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string currentLine = reader.ReadLine().Trim();
                        if (0 < currentLine.Length)
                        {
                            if (currentLine.StartsWith(this.AnnotateLineKeyWord, StringComparison.OrdinalIgnoreCase))
                            {
                                count.Annotate++;
                            }
                            else if (currentLine.StartsWith(this.AnnotateBlockBeginKeyWord))
                            {
                                inAnnotateBlock = true;
                                if (currentLine.EndsWith(this.AnnotateBlockEndKeyWord))
                                {
                                    inAnnotateBlock = false;
                                }
                                count.Annotate++;
                            }
                            else if (inAnnotateBlock)
                            {
                                if (currentLine.EndsWith(this.AnnotateBlockEndKeyWord))
                                {
                                    inAnnotateBlock = false;
                                }
                                count.Annotate++;
                            }
                            else if (isDesignFile)
                            {
                                count.Design++;
                            }
                            count.Total++;
                        }
                    }
                }
                isDesignFile = false;
            }
        }
    }
}
