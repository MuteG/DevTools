namespace DevTools.Plugin.CodeLines.DAL
{
    [FileInfo(".txt")]
    public class TxtCounter : AbstractCounter
    {
        /// <summary>
        /// 获取单行注释关键字
        /// </summary>
        public override string AnnotateLineKeyWord
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 获取注释块开始关键字
        /// </summary>
        public override string AnnotateBlockBeginKeyWord
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 获取注释块结束关键字
        /// </summary>
        public override string AnnotateBlockEndKeyWord
        {
            get { return string.Empty; }
        }
    }
}