namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// SQL代码行数计数器
    /// </summary>
    [FileInfo(".sql,.pro,.prc")]
    public class SQLCounter : AbstractCounter
    {
        public override string AnnotateLineKeyWord
        {
            get { return "--"; }
        }

        public override string AnnotateBlockBeginKeyWord
        {
            get { return "/*"; }
        }

        public override string AnnotateBlockEndKeyWord
        {
            get { return "*/"; }
        }
    }
}
