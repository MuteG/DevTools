
namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// XML文件行数计数器
    /// </summary>
    [FileInfo(".xml")]
    public class XmlCounter : AbstractCounter
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
