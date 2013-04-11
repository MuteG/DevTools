using System.Collections.Generic;
using System.IO;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.BLL
{
    public abstract class AbstractCodeFile
    {
        /// <summary>
        /// 获取此文件包含的子文件对象
        /// </summary>
        public List<AbstractCodeFile> IncludeFiles { get; private set; }

        protected CodeLineCount codeLineCount;

        /// <summary>
        /// 获取代码行数计数对象
        /// </summary>
        public CodeLineCount CodeLineCount
        {
            get
            {
                return this.codeLineCount;
            }
        }

        private AbstractCodeFile parent;

        /// <summary>
        /// 获取或设置包含此文件的父文件
        /// <para>如果没有父文件，此属性为null</para>
        /// </summary>
        public AbstractCodeFile Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
                if (null != parent)
                {
                    this.parent.IncludeFiles.Add(this);
                }
            }
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// 当文件处理进度发生改变时触发此事件
        /// </summary>
        public event ProgressEventHandler Progress;

        public AbstractCodeFile()
        {
            codeLineCount = new CodeLineCount();
            IncludeFiles = new List<AbstractCodeFile>();
        }

        /// <summary>
        /// 统计当前文件的代码行数（包含子文件的代码）
        /// </summary>
        public void Count()
        {
            if (this.Parent != null)
            {
                this.Parent.CodeLineCount.Sub(this.CodeLineCount);
                this.Progress = this.Parent.Progress;
            }

            if (this.IncludeFiles.Count == 0)
            {
                GetCount();
            }
            else
            {
                foreach (AbstractCodeFile codeFile in this.IncludeFiles)
                {
                    codeFile.Count();
                    OnProgress(codeFile);
                }
            }

            if (this.Parent != null)
            {
                this.Parent.CodeLineCount.Add(this.CodeLineCount);
            }
        }

        protected abstract void GetCount();

        /// <summary>
        /// 将内容排序
        /// </summary>
        public void Sort()
        {
            Sort(this);
        }

        private void Sort(AbstractCodeFile codeFile)
        {
            codeFile.IncludeFiles.Sort((item1, item2) =>
            {
                if (item1.GetType().FullName.Equals(item2.GetType().FullName))
                {
                    return string.Compare(Path.GetFileName(item1.File), Path.GetFileName(item2.File), true);
                }
                else if (item1 is NormalCodeFile)
                {
                    return 1;
                }
                else if (item2 is NormalCodeFile)
                {
                    return -1;
                }
                return 0;
            });
            foreach (AbstractCodeFile subCodeFile in codeFile.IncludeFiles)
            {
                Sort(subCodeFile);
            }
        }

        /// <summary>
        /// 触发Progress事件
        /// </summary>
        /// <param name="codeFile">当前正在处理的文件对象</param>
        protected void OnProgress(AbstractCodeFile codeFile)
        {
            if (null != this.Progress)
            {
                ProgressEventArgs args = new ProgressEventArgs();
                AbstractCodeFile subFile = codeFile.Parent;
                if (null == subFile)
                {
                    args.MainMessage = Path.GetFileName(codeFile.File);
                }
                else
                {
                    AbstractCodeFile mainFile = subFile.Parent;
                    if (null == mainFile)
                    {
                        args.MainMessage = Path.GetFileName(codeFile.File);
                        args.MainMaximum = subFile.IncludeFiles.Count;
                        args.MainValue = subFile.IncludeFiles.IndexOf(codeFile) + 1;
                    }
                    else
                    {
                        args.SubMessage = Path.GetFileName(codeFile.File);
                        args.SubMaximum = subFile.IncludeFiles.Count;
                        args.SubValue = subFile.IncludeFiles.IndexOf(codeFile) + 1;

                        args.MainMessage = Path.GetFileName(subFile.File);
                        args.MainMaximum = mainFile.IncludeFiles.Count;
                        args.MainValue = mainFile.IncludeFiles.IndexOf(subFile) + 1;
                    }
                }
                Progress(codeFile, args);
            }
        }
    }
}
