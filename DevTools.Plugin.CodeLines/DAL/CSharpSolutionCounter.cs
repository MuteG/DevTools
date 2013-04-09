using System;
using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// .NET 解决方案代码行数计数器
    /// </summary>
    [FileInfo(".sln")]
    public class CSharpSolutionCounter : AbstractCounter
    {
        public override void Count(ref CodeLineCount count)
        {
            throw new NotImplementedException();
        }

        public override string AnnotateLineKeyWord
        {
            get { return string.Empty; }
        }

        public override string AnnotateBlockBeginKeyWord
        {
            get { return string.Empty; }
        }

        public override string AnnotateBlockEndKeyWord
        {
            get { return string.Empty; }
        }
    }
}
