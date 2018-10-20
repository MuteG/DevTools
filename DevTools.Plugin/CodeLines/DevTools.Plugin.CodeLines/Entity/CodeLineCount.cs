using DevTools.Plugin.CodeLines.BLL;

namespace DevTools.Plugin.CodeLines.Entity
{
    /// <summary>
    /// 代码行数统计对象
    /// </summary>
    public sealed class CodeLineCount
    {
        /// <summary>
        /// 代码和注释混杂在一起的行数
        /// </summary>
        [CountInfo("混合注释", IsInclude = true)]
        public int AnnotateMix { get; set; }

        /// <summary>
        /// 注释行数
        /// </summary>
        [CountInfo("注释", IsInclude = false)]
        public int Annotate { get; set; }

        /// <summary>
        /// 设计代码行数
        /// </summary>
        [CountInfo("设计代码", IsInclude = false)]
        public int Design { get; set; }

        /// <summary>
        /// 资源文件行数
        /// </summary>
        [CountInfo("资源文件", IsInclude = true)]
        public int Resource { get; set; }

        /// <summary>
        /// 空白行数
        /// </summary>
        [CountInfo("空白行", IsInclude = false)]
        public int Space { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int Total { get; set; }

        public void Add(CodeLineCount count)
        {
            this.Annotate += count.Annotate;
            this.AnnotateMix += count.AnnotateMix;
            this.Design += count.Design;
            this.Resource += count.Resource;
            this.Space += count.Space;
            this.Total += count.Total;
        }

        public void Sub(CodeLineCount count)
        {
            this.Annotate -= count.Annotate;
            this.AnnotateMix -= count.AnnotateMix;
            this.Design -= count.Design;
            this.Resource -= count.Resource;
            this.Space -= count.Space;
            this.Total -= count.Total;
        }
    }
}
