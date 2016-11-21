using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevTools.Common.IO;
using DevTools.Config.USL;
using DevTools.Plugin;

namespace DevTools.Config
{
    /// <summary>
    /// 配置文件管理
    /// </summary>
    public static class ConfigManager
    {
        private const bool ENCRYPT = true;
        /// <summary>
        /// 获取配置文件所在文件夹的绝对路径
        /// </summary>
        public static string ConfigFolder { get; private set; }

        internal static List<ConfigBase> ConfigList
        {
            get
            {
                return configDict.Values.ToList();
            }
        }
        
        private static Dictionary<string, ConfigBase> configDict;
        private static Dictionary<string, ConfigPanelBase> configPanelDict;
        private static Dictionary<string, string> configDisplayDict;
        
        private const string CONFIG_EXT = ".conf";
        private const string CONFIG_FOLDER = "config";
        
        static ConfigManager()
        {
            configDict = new Dictionary<string, ConfigBase>();
            configPanelDict = new Dictionary<string, ConfigPanelBase>();
            configDisplayDict = new Dictionary<string, string>();
            
            ConfigFolder = Path.Combine(Application.StartupPath, CONFIG_FOLDER);

            if (!Directory.Exists(ConfigFolder))
            {
                Directory.CreateDirectory(ConfigFolder);
            }

            LoadAppConfig();

            LoadPluginConfig();
        }
        
        private static void LoadAppConfig()
        {
            Assembly appAssembly = Assembly.GetEntryAssembly();
            ConfigBase config;
            ConfigPanelBase configPanel;
            GetAssemblyConfig(appAssembly, out config, out configPanel);
            if (null != config)
            {
                string key = config.Key;

                configDict[key] = config;
                configDisplayDict[key] = "Main";

                if (null != configPanel)
                {
                    configPanel.Config = config;
                    configPanelDict.Add(key, configPanel);
                }
            }
        }

        private static void GetAssemblyConfig(Assembly assembly,
            out ConfigBase config, out ConfigPanelBase configPanel)
        {
            config = null;
            configPanel = null;
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (config == null && type.IsSubclassOf(typeof(ConfigBase)))
                {
                    config = Activator.CreateInstance(type) as ConfigBase;
                    config = LoadConfig(config, config.Key);
                }
                if (configPanel == null && type.IsSubclassOf(typeof(ConfigPanelBase)))
                {
                    configPanel = Activator.CreateInstance(type) as ConfigPanelBase;
                }
                if (config != null && configPanel != null)
                {
                    break;
                }
            }
        }

        private static ConfigBase LoadConfig(ConfigBase config, string key)
        {
            string configFileName = key + CONFIG_EXT;
            string configFile = Path.Combine(ConfigFolder, configFileName);
            XMLHelper xml = new XMLHelper(configFile, ENCRYPT);
            if (File.Exists(configFile))
            {
                config = xml.Load(config.GetType()) as ConfigBase;
            }
            else
            {
                xml.Save(config);
            }
            return config;
        }

        private static void LoadPluginConfig()
        {
            List<IPlugin> pluginList = PluginsManager.LoadPlugins();

            foreach (IPlugin plugin in pluginList)
            {
                if (plugin.CanConfig)
                {
                    ConfigBase config;
                    ConfigPanelBase configPanel;
                    GetPluginConfigInstance(plugin, out config, out configPanel);
                    string key = config.Key;
                    configDict[key] = config;
                    configDisplayDict[key] = plugin.DisplayName;
                    if (null != configPanel)
                    {
                        configPanel.Config = config;
                        configPanelDict[key] = configPanel;
                    }
                }
            }
        }
        
        private static void GetPluginConfigInstance(IPlugin plugin,
            out ConfigBase config, out ConfigPanelBase configPanel)
        {
            config = null;
            configPanel = null;
            object[] attributes = plugin.GetType().GetCustomAttributes(typeof(PluginAttribute), false);
            if (attributes.Length > 0)
            {
                PluginAttribute attr = attributes[0] as PluginAttribute;
                config = Activator.CreateInstance(attr.ConfigType) as ConfigBase;
                config = LoadConfig(config, config.Key);
                configPanel = Activator.CreateInstance(attr.ConfigPanelType) as ConfigPanelBase;
            }
        }

        public static ConfigBase GetConfig(string key)
        {
            return configDict[key];
        }

        public static ConfigPanelBase GetConfigPanel(string key)
        {
            ConfigPanelBase panel = configPanelDict[key];
            if (panel.Config == null)
            {
                panel.Config = GetConfig(key);
            }
            return panel;
        }

        public static string GetDisplayName(string key)
        {
            return configDisplayDict[key];
        }
                
        public static void Save()
        {
            foreach (ConfigBase config in configDict.Values)
            {
                Save(config);
            }
        }

        public static void Save(ConfigBase config)
        {
            string configFileName = config.Key + CONFIG_EXT;
            string configFile = Path.Combine(ConfigFolder, configFileName);
            XMLHelper xml = new XMLHelper(configFile, ENCRYPT);
            xml.Save(config);
        }
    }
}
