namespace DevTools.Plugin.CodeLines.Entity
{
    public sealed class CodeLineCount
    {
        /// <summary>
        /// 代码和注释混杂在一起的行数
        /// </summary>
        public int AnnotateMix { get; set; }

        /// <summary>
        /// 注释行数
        /// </summary>
        public int Annotate { get; set; }

        /// <summary>
        /// 设计代码行数
        /// </summary>
        public int Design { get; set; }

        /// <summary>
        /// 资源文件行数
        /// </summary>
        public int Resource { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int Total { get; set; }
    }
}
