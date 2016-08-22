namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// HTML文件行数计数器
    /// </summary>
    [FileInfo(".html,.htm")]
    public class HtmlCounter : AbstractCounter
    {
        public override string AnnotateLineKeyWord
        {
            get { return "<!DOCTYPE"; }
        }

        public override string AnnotateBlockBeginKeyWord
        {
            get { return "<!--"; }
        }

        public override string AnnotateBlockEndKeyWord
        {
            get { return "-->"; }
        }
    }
}
