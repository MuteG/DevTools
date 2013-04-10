using System.Collections.Generic;
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

        /// <summary>
        /// 获取或设置包含此文件的父文件
        /// <para>如果没有父文件，此属性为null</para>
        /// </summary>
        public AbstractCodeFile Parent { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string File { get; set; }

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
            GetCount();

            AbstractCodeFile parent = this.Parent;
            while (null != parent)
            {
                parent.CodeLineCount.Add(this.CodeLineCount);
                parent = parent.Parent;
            }
        }

        protected abstract void GetCount();
    }
}
