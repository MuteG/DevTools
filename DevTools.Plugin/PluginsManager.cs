using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DevTools.Plugin
{
    public static class PluginsManager
    {
        /// <summary>
        /// 读取所有的插件
        /// </summary>
        /// <returns></returns>
        public static List<IPlugin> LoadPlugins()
        {
            List<IPlugin> plugins = new List<IPlugin>();
            Assembly mainAssembly = Assembly.GetExecutingAssembly();
            string pluginFolder = Path.Combine(Path.GetDirectoryName(mainAssembly.Location),
                ConfigurationManager.AppSettings["pluginFolder"]);
            foreach (string pluginFile in Directory.GetFiles(pluginFolder))
            {
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
