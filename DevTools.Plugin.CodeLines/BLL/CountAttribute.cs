using System;

namespace DevTools.Plugin.CodeLines.BLL
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    internal class CountAttribute : Attribute
    {
        /// <summary>
        /// 计数时是否包含
        /// </summary>
        public bool IsInclude { get; set; }
        
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// 用指定的属性来初始化Count特性的新实例
        /// </summary>
        /// <param name="name">显示名称</param>
        public CountAttribute(string name)
        {
            this.IsInclude = true;
            this.DisplayName = name;
        }
    }
}
