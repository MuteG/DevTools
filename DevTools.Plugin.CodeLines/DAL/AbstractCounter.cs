using System.IO;
using DevTools.Plugin.CodeLines.Entity;
using System;

namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// 抽象的代码行数统计器对象
    /// </summary>
    public abstract class AbstractCounter : ICountable
    {
        /// <summary>
        /// 注释类型
        /// </summary>
        private enum AnnotateType
        {
            /// <summary>
            /// 无注释
            /// </summary>
            None,
            /// <summary>
            /// 单行注释
            /// </summary>
            Line,
            /// <summary>
            /// 注释块开始
            /// </summary>
            Begin,
            /// <summary>
            /// 注释块结束
            /// </summary>
            End
        }

        /// <summary>
        /// 获取或设置当前计数器对应的文件
        /// </summary>
        public string TargetFile { get; set; }

        /// <summary>
        /// 获取单行注释关键字
        /// </summary>
        public abstract string AnnotateLineKeyWord { get; }

        /// <summary>
        /// 获取注释块开始关键字
        /// </summary>
        public abstract string AnnotateBlockBeginKeyWord { get; }

        /// <summary>
        /// 获取注释块结束关键字
        /// </summary>
        public abstract string AnnotateBlockEndKeyWord { get; }

        /// <summary>
        /// 获取附加信息
        /// </summary>
        public string Message { get; private set; }

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
                        isMix = false;
                        CountLine(ref count, currentLine);
                    }
                }
            }
        }

        private bool isMix = false;

        private void CountLine(ref CodeLineCount count, string currentLine)
        {
            if (0 == currentLine.Length)
            {
                count.Space++;
            }
            else
            {
                int currentIndex = 0;
                switch (FindNextSymbol(currentLine, ref currentIndex))
                {
                    case AnnotateType.None:
                        if (inAnnotateBlock)
                        {
                            count.Annotate++;
                        }
                        break;
                    case AnnotateType.Line:
                        CheckAnnotateLine(ref count, currentLine, currentIndex);
                        break;
                    case AnnotateType.Begin:
                        CheckAnnotateBlockBegin(ref count, currentLine, currentIndex);
                        break;
                    case AnnotateType.End:
                        CheckAnnotateBlockEnd(ref count, currentLine, currentIndex);
                        break;
                }
            }
            count.Total++;
        }

        private AnnotateType FindNextSymbol(string currentLine, ref int startIndex)
        {
            int nextSymbolIndex = -1;
            AnnotateType nextAnnotateType = AnnotateType.None;

            if (AnnotateType.None == nextAnnotateType)
            {
                nextSymbolIndex = currentLine.IndexOf(this.AnnotateLineKeyWord, startIndex);
                if (nextSymbolIndex > -1)
                {
                    nextAnnotateType = AnnotateType.Line;
                    startIndex = nextSymbolIndex;
                }
            }

            if (AnnotateType.None == nextAnnotateType)
            {
                nextSymbolIndex = currentLine.IndexOf(this.AnnotateBlockBeginKeyWord, startIndex);
                if (nextSymbolIndex > -1)
                {
                    nextAnnotateType = AnnotateType.Begin;
                    startIndex = nextSymbolIndex;
                }
            }

            if (AnnotateType.None == nextAnnotateType)
            {
                nextSymbolIndex = currentLine.IndexOf(this.AnnotateBlockEndKeyWord, startIndex);
                if (nextSymbolIndex > -1)
                {
                    nextAnnotateType = AnnotateType.End;
                    startIndex = nextSymbolIndex;
                }
            }

            return nextAnnotateType;
        }

        private void CheckAnnotateLine(ref CodeLineCount count, string currentLine, int currentIndex)
        {
            if (inAnnotateBlock)
            {
                int nextEndIndex = currentLine.IndexOf(this.AnnotateBlockEndKeyWord, currentIndex);
                if (-1 == nextEndIndex)
                {
                    count.Annotate++;
                }
                else
                {
                    CheckAnnotateBlockEnd(ref count, currentLine, nextEndIndex);
                }
            }
            else
            {
                if (0 == currentIndex)
                {
                    count.Annotate++;
                }
                else
                {
                    count.AnnotateMix++;
                }
            }
        }

        private bool inAnnotateBlock = false;

        private void CheckAnnotateBlockBegin(ref CodeLineCount count, string currentLine, int currentIndex)
        {
            inAnnotateBlock = true;
            int nextEndIndex = currentLine.IndexOf(this.AnnotateBlockEndKeyWord, currentIndex);
            if (-1 == nextEndIndex)
            {
                count.Annotate++;
            }
            else
            {
                CheckAnnotateBlockEnd(ref count, currentLine, nextEndIndex);
            }
        }

        private void CheckAnnotateBlockEnd(ref CodeLineCount count, string currentLine, int currentIndex)
        {
            inAnnotateBlock = false;
            currentIndex = currentIndex + this.AnnotateBlockEndKeyWord.Length;
            if (currentIndex < currentLine.Length)
            {
                int startIndex = currentIndex;
                AnnotateType nextType = FindNextSymbol(currentLine, ref startIndex);
                switch (nextType)
                {
                    case AnnotateType.None:
                        count.AnnotateMix++;
                        break;
                    case AnnotateType.Line:
                        if (currentIndex == startIndex)
                        {
                            count.Annotate++;
                        }
                        else
                        {
                            count.AnnotateMix++;
                        }
                        break;
                    case AnnotateType.Begin:
                        if (!isMix && currentIndex != startIndex)
                        {
                            count.AnnotateMix++;
                            isMix = true;
                        }
                        CheckAnnotateBlockBegin(ref count, currentLine, currentIndex);
                        break;
                    case AnnotateType.End:
                        this.Message = "发现错误的注释块结尾";
                        break;
                }
            }
            else
            {
                if (!isMix)
                {
                    count.Annotate++;
                }
            }
        }

        #endregion
    }
}
