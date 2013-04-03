using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

using YAXLib;

namespace DevTools.Language
{
    /// <summary>
    /// 多语言管理
    /// </summary>
    public static class LanguageManager
    {
        private static string code;
        /// <summary>
        /// 获取或设置语言代码
        /// </summary>
        public static string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                LoadLanguage(code);
                if (null != LanguageChanged)
                {
                    LanguageChanged(null, null);
                }
            }
        }
        
        public static event EventHandler LanguageChanged;
        
        /// <summary>
        /// 获取语言文件所在的文件夹绝对路径
        /// </summary>
        public static string LanguageFolder { get; private set; }
        
        /// <summary>
        /// 获取语言文件对象集合
        /// </summary>
        public static List<Language> LanguageList { get; private set; }
        
        private static Language currentLanguage = null;
        
        static LanguageManager()
        {
            LanguageList = new List<Language>();
            
            LanguageFolder = Path.Combine(Application.StartupPath, "lang");
            
            CheckLanguageFolder();
            CheckDefaultLanguageFile();
            
            LoadLanguage();
            
            Code = CultureInfo.CurrentCulture.Name;
        }
        
        private static void LoadLanguage()
        {
            LanguageList.Clear();
            string[] xmlFileList = Directory.GetFiles(LanguageFolder, "*.xml");
            foreach (string xmlFile in xmlFileList)
            {
                YAXSerializer serializer = new YAXSerializer(typeof(Language));
                Language language =
                    serializer.DeserializeFromFile(xmlFile) as Language;
                LanguageList.Add(language);
            }
        }

        private static void CheckLanguageFolder()
        {
            if (!Directory.Exists(LanguageFolder))
            {
                Directory.CreateDirectory(LanguageFolder);
            }
        }
        
        private static void CheckDefaultLanguageFile()
        {
            string defaultLanguageFile =
                Path.Combine(LanguageFolder, "language_zh-Hans.xml");
            if(!File.Exists(defaultLanguageFile))
            {
                ResourceManager manager =
                    new ResourceManager("DevTools.Language.Resource",
                                        typeof(LanguageManager).Assembly);
                using (StreamWriter writer =
                       new StreamWriter(defaultLanguageFile, false, Encoding.UTF8))
                {
                    writer.Write(manager.GetString("language_zh-Hans"));
                }
                manager.ReleaseAllResources();
            }
        }
        
        private static void LoadLanguage(string code)
        {
            if (LanguageList.Count > 0)
            {
                currentLanguage = LanguageList.Find(item => item.Name.Equals(code));
            }
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static string GetString(Control control)
        {
            string key =
                string.Format("{0}.{1}_{2}",
                              Assembly.GetCallingAssembly().GetName().Name,
                              control.FindForm().Name,
                              control.Name);
            string value = GetString(key, control.Text);
            control.Text = value;
            return value;
        }
        
        /// <summary>
        /// 自动为指定的控件以及其子控件实现多语言
        /// </summary>
        /// <param name="control">要实现多语言的控件</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void GetAllString(Control control)
        {
            string keyBase =
                string.Format("{0}.{1}_",
                              Assembly.GetCallingAssembly().GetName().Name,
                              control.FindForm().Name
                             );
            GetAllString(keyBase, control);
        }
        
        private static void GetAllString(string keyBase, Control control)
        {
            string key = keyBase + control.Name;
            control.Text = GetString(key, control.Text);
            foreach (Control subControl in control.Controls)
            {
                GetAllString(keyBase, subControl);
            }
        }
        
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static string GetString(MenuItem menuItem)
        {
            string moduleName = Assembly.GetCallingAssembly().GetName().Name;
            string formName = moduleName;
            
            Form parentForm = null;
            if (null != menuItem.GetMainMenu())
            {
                parentForm = menuItem.GetMainMenu().GetForm();
            }
            else if (null != menuItem.GetContextMenu())
            {
                Control source = menuItem.GetContextMenu().SourceControl;
                if (null != source)
                {
                    parentForm = source.FindForm();
                }
            }
            
            if (null != parentForm)
            {
                formName = parentForm.Name;
            }
            string key =
                string.Format("{0}.{1}_{2}",
                              moduleName, formName, menuItem.Name);
            string value = GetString(key, menuItem.Text);
            menuItem.Text = value;
            return value;
        }
        
        public static string GetString(string key)
        {
            return GetString(key, string.Empty);
        }
        
        public static string GetString(string key, string defaultValue)
        {
            string value = defaultValue;
            string[] keys = key.Split('.');
            if(2 == keys.Length &&
              null != currentLanguage)
            {
                string moduleName = keys[0];
                string itemName = keys[1];
                Module module =
                    currentLanguage.Modules
                    .Find(item => item.Name.Equals(moduleName));
                if (null != module)
                {
                    if (module.Items.ContainsKey(itemName))
                    {
                        value = module.Items[itemName];
                    }
                }
            }
            return value;
        }
    }
}
