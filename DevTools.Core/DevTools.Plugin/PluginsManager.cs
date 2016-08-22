using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DevTools.Plugin
{
    public static class PluginsManager
    {
        public static string PluginFolder { get; private set; }
        
        static PluginsManager()
        {
            PluginFolder = Path.Combine(Application.StartupPath, "plugin");
            
            CheckPluginFolder();
        }
        
        private static void CheckPluginFolder()
        {
            if (!Directory.Exists(PluginFolder))
            {
                Directory.CreateDirectory(PluginFolder);
            }
        }
        
        /// <summary>
        /// 读取所有的插件
        /// </summary>
        /// <returns></returns>
        public static List<IPlugin> LoadPlugins()
        {
            List<IPlugin> plugins = new List<IPlugin>();

            foreach (string pluginFile in Directory.GetFiles(PluginFolder, "*.dll", SearchOption.TopDirectoryOnly))
            {
                if (!Path.GetFileName(pluginFile).StartsWith("DevTools.Plugin."))
                {
                    continue;
                }
                Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);
                foreach (Type publicType in pluginAssembly.GetExportedTypes())
                {
                    if (publicType.GetInterface("IPlugin") != null)
                    {
                        if (publicType.GetCustomAttributes(typeof(PluginAttribute), false).Length > 0)
                        {
                            plugins.Add((IPlugin)Activator.CreateInstance(publicType));
                            break;
                        }
                    }
                }
            }
            return plugins;
        }
    }
}
