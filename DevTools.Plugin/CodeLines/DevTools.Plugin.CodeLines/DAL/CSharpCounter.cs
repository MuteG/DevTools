using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// C#代码行数计数器
    /// </summary>
    [FileInfo(".cs")]
    public class CSharpCounter : AbstractCounter
    {
        public override void Count(ref CodeLineCount count)
        {
            base.Count(ref count);
            if (this.TargetFile.EndsWith(".Designer.cs"))
            {
                count.Design = count.Total - count.Annotate - count.AnnotateMix - count.Space;
            }
        }

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
