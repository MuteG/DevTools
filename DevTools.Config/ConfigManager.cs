using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using DevTools.Plugin;
using YAXLib;

namespace DevTools.Config
{
    /// <summary>
    /// 配置文件管理
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// 获取配置文件所在文件夹的绝对路径
        /// </summary>
        public static string ConfigFolder { get; private set; }
        
        private static Dictionary<string, ConfigBase> configDict;
        
        static ConfigManager()
        {
            configDict = new Dictionary<string, ConfigBase>();
            
            ConfigFolder = Path.Combine(Application.StartupPath, "config");
            
            CheckConfigFolder();
            
            LoadConfig();
        }
        
        private static void CheckConfigFolder()
        {
            if (!Directory.Exists(ConfigFolder))
            {
                Directory.CreateDirectory(ConfigFolder);
            }
        }
        
        private static void LoadConfig()
        {
            configDict.Clear();
            
            LoadAppConfig();
            
            LoadPluginConfig();
        }
        
        private static void LoadAppConfig()
        {
            Assembly appAssembly = Assembly.GetEntryAssembly();
            
            ConfigBase config = GetConfigInstance(appAssembly);
            string key = appAssembly.GetName().Name;
            
            LoadConfig(ref config, ref key);

            configDict.Add(key, config);
        }


        private static void LoadConfig(ref ConfigBase config, ref string key)
        {
            string configFileName = key + ".conf";
            string configFile = Path.Combine(ConfigFolder, configFileName);
            YAXSerializer serializer = new YAXSerializer(config.GetType());
            if (File.Exists(configFile))
            {
                config = serializer.DeserializeFromFile(configFile) as ConfigBase;
            }
            else
            {
                serializer.SerializeToFile(config, configFile);
            }
        }

        private static void LoadPluginConfig()
        {
            List<IPlugin> pluginList = PluginsManager.LoadPlugins();

            foreach (IPlugin plugin in pluginList)
            {
                ConfigBase config = GetConfigInstance(plugin);
                string key = plugin.GetType().Assembly.GetName().Name;
                
                LoadConfig(ref config, ref key);

                configDict.Add(key, config);
            }
        }
        
        private static ConfigBase GetConfigInstance(IPlugin plugin)
        {
            ConfigBase config = null;
            Assembly pluginAssembly = plugin.GetType().Assembly;
            config = GetConfigInstance(pluginAssembly);
            return config;
        }
        
        private static ConfigBase GetConfigInstance(Assembly assembly)
        {
            ConfigBase config = null;
            foreach (Type publicType in assembly.GetExportedTypes())
            {
                if (publicType.IsSubclassOf(typeof(ConfigBase)))
                {
                    config = Activator.CreateInstance(publicType) as ConfigBase;
                    break;
                }
            }
            return config;
        }
        
        public static void GetConfig(ref ConfigBase config)
        {
            string key = config.GetType().Assembly.GetName().Name;
            if (configDict.ContainsKey(key))
            {
                config = configDict[key];
            }
        }
        
        public static void Save()
        {
            foreach (ConfigBase config in configDict.Values)
            {
                string key = config.GetType().Assembly.GetName().Name;
                string configFileName = key + ".conf";
                string configFile = Path.Combine(ConfigFolder, configFileName);
                YAXSerializer serializer = new YAXSerializer(config.GetType());
                serializer.SerializeToFile(config, configFile);
            }
        }
    }
}
