namespace DevTools.Plugin
{
    using System;

    /// <summary>
    /// 指定Plugin的特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class PluginAttribute : Attribute
    {
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// 是否带有配置面板
        /// </summary>
        public bool CanConfig { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        public Type ConfigType { get; set; }

        public Type ConfigPanelType { get; set; }
        
        /// <summary>
        /// 用指定的属性来初始化Plugin特性的新实例
        /// </summary>
        /// <param name="visible"></param>
        public PluginAttribute(bool visible)
        {
            this.Visible = visible;
            this.CanConfig = true; //默认可配置
            this.DisplayName = string.Empty;
            this.ConfigType = null;
            this.ConfigPanelType = null;
        }
    }
}
