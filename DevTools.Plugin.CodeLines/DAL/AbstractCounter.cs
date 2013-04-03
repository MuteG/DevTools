using System.IO;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
    public abstract class AbstractCounter : ICountable
    {
        /// <summary>
        /// 获取或设置当前计数器对应的文件
        /// </summary>
        public string TargetFile { get; set; }

        /// <summary>
        /// 获取或设置单行注释关键字
        /// </summary>
        public string AnnotateLineKeyWord { get; set; }

        /// <summary>
        /// 获取或设置注释块开始关键字
        /// </summary>
        public string AnnotateBlockBeginKeyWord { get; set; }

        /// <summary>
        /// 获取或设置注释块结束关键字
        /// </summary>
        public string AnnotateBlockEndKeyWord { get; set; }

        public AbstractCounter()
        {
            this.AnnotateLineKeyWord = string.Empty;
            this.AnnotateBlockBeginKeyWord = string.Empty;
            this.AnnotateBlockEndKeyWord = string.Empty;
        }

        #region ICountable 成员

        public virtual void Count(ref CodeLineCount count)
        {
            if (File.Exists(TargetFile))
            {
                using (StreamReader reader = new StreamReader(TargetFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string currentLine = reader.ReadLine().Trim();
                        CountLine(ref count, currentLine);
                    }
                }
            }
        }

        private void CountLine(ref CodeLineCount count, string currentLine)
        {
            if (0 < currentLine.Length)
            {
                int annotateLineIndex = currentLine.IndexOf(AnnotateLineKeyWord);
                int annotateBlockBeginIndex = currentLine.IndexOf(AnnotateBlockBeginKeyWord);
                int annotateBlockEndIndex = currentLine.IndexOf(AnnotateBlockEndKeyWord);

                if (!inAnnotateBlock && annotateLineIndex >= 0)
                {
                    if (0 == annotateLineIndex)
                    {
                        count.Annotate++;
                    }
                    else
                    {
                        if (annotateBlockBeginIndex >= 0 && annotateBlockBeginIndex < annotateLineIndex)
                        {
                            CheckAnnotateBlock(ref count, currentLine);
                        }
                        else
                        {
                            count.AnnotateMix++;
                        }
                    }
                }
                else
                {
                    CheckAnnotateBlock(ref count, currentLine);
                }
                count.Total++;
            }
        }

        private bool inAnnotateBlock = false;

        private void CheckAnnotateBlock(ref CodeLineCount count, string currentLine)
        {
            int annotateBlockBeginIndex = currentLine.IndexOf(AnnotateBlockBeginKeyWord);
            int annotateBlockEndIndex = currentLine.IndexOf(AnnotateBlockEndKeyWord);

            //TODO 目前还没对注释块结尾直接跟有效代码的情况进行对应
            //TODO 目前还没对注释块结尾直接跟有效代码后再跟行内注释块的情况进行对应
            if (inAnnotateBlock)
            {
                count.Annotate++;
                if (annotateBlockEndIndex >= 0)
                {
                    inAnnotateBlock = false; 
                }
            }
            else
            {
                if (annotateBlockBeginIndex >= 0)
                {
                    inAnnotateBlock = true;
                    if (annotateBlockBeginIndex > 0)
                    {
                        count.AnnotateMix++;
                    }
                    else
                    {
                        count.Annotate++;
                    }
                }
                if (annotateBlockEndIndex >= 0)
                {
                    inAnnotateBlock = false;
                }
            }
        }

        #endregion
    }
}
