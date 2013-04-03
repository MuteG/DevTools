using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
    public interface ICountable
    {
        void Count(ref CodeLineCount count);
    }
}
