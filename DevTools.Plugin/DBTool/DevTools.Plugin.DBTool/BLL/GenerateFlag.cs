using System;

namespace DevTools.Plugin.DBTool.Common.Generator
{
    /// <summary>
    /// 代码生成附加条件
    /// </summary>
    [Flags]
    public enum GenerateFlag
    {
        /// <summary>
        /// 无任何附加条件
        /// </summary>
        None = 1 << 0,
        /// <summary>
        /// 智能去除前缀
        /// </summary>
        CutPrefix = 1 << 1,
        /// <summary>
        /// 生成头注释
        /// </summary>
        HeadAnnotate = 1 << 2,
        /// <summary>
        /// 生成输入参数
        /// </summary>
        HasInput = 1 << 3
    }
}
