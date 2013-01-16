using System;
using System.Linq;

namespace DevTools.Plugin
{
    public abstract class AbstractPlugins : IPlugin
    {
        #region IPlugin 成员

        private bool _Visible = false;

        public bool Visible
        {
            get
            {
                return _Visible;
            }
        }

        private bool _CanConfig = false;

        public bool CanConfig
        {
            get
            {
                return _CanConfig;
            }
        }

        private string _DisplayName = string.Empty;

        public string DisplayName
        {
            get
            {
                return _DisplayName;
            }
        }

        public AbstractPlugins()
        {
            object[] attributes = this.GetType().GetCustomAttributes(typeof(PluginAttribute), false);
            if (attributes.Length > 0)
            {
                PluginAttribute attribute = attributes[0] as PluginAttribute;
                _Visible = attribute.Visible;
                _CanConfig = attribute.CanConfig;
                _DisplayName = attribute.DisplayName;
            }
        }

        public abstract void StartUp();

        public abstract void Reset();

        public abstract void Config();

        #endregion
    }
}
