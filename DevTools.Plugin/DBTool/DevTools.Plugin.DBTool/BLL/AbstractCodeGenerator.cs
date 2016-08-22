using System;
using System.Collections.Generic;
using System.Text;

namespace DevTools.Plugin.DBTool.Common.Generator
{
    public abstract class AbstractCodeGenerator : IGenerator
    {
        private GenerateFlag m_GenerateFlags = GenerateFlag.None;
        /// <summary>
        /// 代码生成条件标志
        /// </summary>
        public GenerateFlag GenerateFlags
        {
            get
            {
                return m_GenerateFlags;
            }
            set
            {
                m_GenerateFlags = value;
            }
        }

        #region IGenerator 成员

        private string m_TargetName = string.Empty;
        /// <summary>
        /// 生成代码的目标对象名称
        /// </summary>
        public string TargetName
        {
            get
            {
                return m_TargetName;
            }
            set
            {
                m_TargetName = value;
            }
        }

        public abstract string GenerateCode();

        #endregion
    }
}
