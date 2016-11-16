using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using DevTools.Config.USL;
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
        
        internal static List<ConfigBase> ConfigList { get; private set; }
        
        private static Dictionary<string, ConfigBase> configDict;
        private static Dictionary<string, ConfigPanelBase> configPanelDict;
        private static Dictionary<string, string> configDisplayDict;
        
        private const string CONFIG_EXT = ".conf";
        private const string CONFIG_FOLDER = "config";
        
        static ConfigManager()
        {
            ConfigList = new List<ConfigBase>();
            configDict = new Dictionary<string, ConfigBase>();
            configPanelDict = new Dictionary<string, ConfigPanelBase>();
            configDisplayDict = new Dictionary<string, string>();
            
            ConfigFolder = Path.Combine(Application.StartupPath, CONFIG_FOLDER);
            
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
            LoadConfig(appAssembly);
        }
        
        private static void LoadConfig(Assembly assembly)
        {
            ConfigBase config = GetConfigInstance(assembly);
            if (null != config)
            {
                string key = config.GetType().Assembly.GetName().Name;
                
                LoadConfig(ref config, key);
    
                configDict.Add(key, config);
                ConfigList.Add(config);
                
                ConfigPanelBase configPanel = GetConfigPanelInstance(assembly);
                if (null != configPanel)
                {
                    configPanel.Config = config;
                    configPanelDict.Add(key, configPanel);
                }
            }
        }

        private static void LoadConfig(ref ConfigBase config, string key)
        {
            string configFileName = key + CONFIG_EXT;
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
                if (plugin.CanConfig)
                {
                    Assembly pluginAssembly = plugin.GetType().Assembly;
                    LoadConfig(pluginAssembly);

                    ConfigBase config = GetConfigInstance(pluginAssembly);
                    string key = config.GetType().Assembly.GetName().Name;
                    configDisplayDict[key] = plugin.DisplayName;
                }
            }
        }
        
        private static ConfigBase GetConfigInstance(Assembly assembly)
        {
            ConfigBase config = null;
            foreach (Type publicType in assembly.GetExportedTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(publicType))
                {
                    object[] attributes = publicType.GetCustomAttributes(typeof(PluginAttribute), false);
                    if (attributes.Length > 0)
                    {
                        PluginAttribute attr = attributes[0] as PluginAttribute;
                        config = Activator.CreateInstance(attr.ConfigType) as ConfigBase;
                    }
                    break;
                }
            }
            return config;
        }
        
        private static ConfigPanelBase GetConfigPanelInstance(Assembly assembly)
        {
            ConfigPanelBase configPanel = null;
            foreach (Type publicType in assembly.GetExportedTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(publicType))
                {
                    object[] attributes = publicType.GetCustomAttributes(typeof(PluginAttribute), false);
                    if (attributes.Length > 0)
                    {
                        PluginAttribute attr = attributes[0] as PluginAttribute;
                        configPanel = Activator.CreateInstance(attr.ConfigPanelType) as ConfigPanelBase;
                    }
                    break;
                }
            }
            return configPanel;
        }
        
        public static void GetConfig(ref ConfigBase config)
        {
            string key = config.GetType().Assembly.GetName().Name;
            if (configDict.ContainsKey(key))
            {
                config = configDict[key];
            }
        }
        
        public static ConfigPanelBase GetConfigPanel(ConfigBase config)
        {
            ConfigPanelBase configPanel = null;
            string key = config.GetType().Assembly.GetName().Name;
            if (configPanelDict.ContainsKey(key))
            {
                configPanel = configPanelDict[key];
            }
            else
            {
                configPanel = new SmartConfigPanel() { Config = config };
                configPanelDict.Add(key, configPanel);
            }
            return configPanel;
        }

        public static string GetDisplayName(ConfigBase config)
        {
            string key = config.GetType().Assembly.GetName().Name;
            return configDisplayDict[key];
        }
        
        internal static ConfigBase GetConfig(string moduleName)
        {
            ConfigBase config = null;
            string key = moduleName;
            if (configDict.ContainsKey(key))
            {
                config = configDict[key];
            }
            return config;
        }
        
        public static void Save()
        {
            foreach (ConfigBase config in configDict.Values)
            {
                string key = config.GetType().Assembly.GetName().Name;
                string configFileName = key + CONFIG_EXT;
                string configFile = Path.Combine(ConfigFolder, configFileName);
                YAXSerializer serializer = new YAXSerializer(config.GetType());
                serializer.SerializeToFile(config, configFile);
            }
        }
    }
}
