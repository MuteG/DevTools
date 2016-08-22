using System;
using System.Collections.Generic;
using System.Text;

namespace DevTools.Plugin.DBTool.Common.Generator
{
    public interface IGenerator
    {
        /// <summary>
        /// 生成代码的目标对象名称
        /// </summary>
        string TargetName
        {
            get;
            set;
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns>格式化后的代码</returns>
        string GenerateCode();
    }
}
