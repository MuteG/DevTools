namespace DevTools.Plugin
{
    /// <summary>
    /// 描述Plugin对象的对外接口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 是否可见
        /// </summary>
        bool Visible { get; }

        /// <summary>
        /// 是否可配置
        /// </summary>
        bool CanConfig { get; }

        /// <summary>
        /// 显示名称
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Plugin开始工作
        /// </summary>
        void StartUp();
        
        /// <summary>
        /// 恢复Plugin的初始状态
        /// </summary>
        void Reset();
        
        /// <summary>
        /// 对Plugin作出设置
        /// </summary>
        void Config();
    }
}