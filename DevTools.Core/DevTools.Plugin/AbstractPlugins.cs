using System;
using System.Linq;

namespace DevTools.Plugin
{
    public abstract class AbstractPlugins : IPlugin
    {
        #region IPlugin 成员

        private bool visible = false;

        public bool Visible
        {
            get
            {
                return visible;
            }
        }

        private bool canConfig = false;

        public bool CanConfig
        {
            get
            {
                return canConfig;
            }
        }

        private string displayName = string.Empty;

        public string DisplayName
        {
            get
            {
                return displayName;
            }
        }

        public AbstractPlugins()
        {
            object[] attributes = this.GetType().GetCustomAttributes(typeof(PluginAttribute), false);
            if (attributes.Length > 0)
            {
                PluginAttribute attribute = attributes[0] as PluginAttribute;
                visible = attribute.Visible;
                canConfig = attribute.CanConfig;
                displayName = attribute.DisplayName;
            }
        }

        public abstract void StartUp();

        public abstract void Reset();

        public abstract void Config();

        #endregion
    }
}
