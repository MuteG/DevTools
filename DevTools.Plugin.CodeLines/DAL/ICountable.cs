using DevTools.Plugin.CodeLines.Entity;

namespace DevTools.Plugin.CodeLines.DAL
{
    /// <summary>
    /// 计数器接口
    /// </summary>
    public interface ICountable
    {
        void Count(ref CodeLineCount count);
    }
}
