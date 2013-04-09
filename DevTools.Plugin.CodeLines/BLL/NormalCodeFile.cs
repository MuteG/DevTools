using DevTools.Plugin.CodeLines.DAL;

namespace DevTools.Plugin.CodeLines.BLL
{
    public class NormalCodeFile : AbstractCodeFile
    {
        public override void Count()
        {
            ICountable count = CounterFactory.Create(this.File);
            if (null != count)
            {
                this.codeLineCount = new Entity.CodeLineCount();
                count.Count(ref this.codeLineCount);
            }
        }
    }
}
