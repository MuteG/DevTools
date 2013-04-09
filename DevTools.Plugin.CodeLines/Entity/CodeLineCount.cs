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

        public static CodeLineCount operator +(CodeLineCount count1, CodeLineCount count2)
        {
            return new CodeLineCount()
            {
                Annotate = count1.Annotate + count2.Annotate,
                AnnotateMix = count1.AnnotateMix + count2.AnnotateMix,
                Design = count1.Design + count2.Design,
                Resource = count1.Resource + count2.Resource,
                Space = count1.Space + count2.Space,
                Total = count1.Total + count2.Total
            };
        }
    }
}
