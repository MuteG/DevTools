
namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// JAVA代码行数计数器
    /// </summary>
    [FileInfo(".java")]
    public class JavaCounter : AbstractCounter
    {
        public override string AnnotateLineKeyWord
        {
            get { return "//"; }
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
