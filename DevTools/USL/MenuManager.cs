using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DevTools.Config.USL;
using DevTools.Language;
using DevTools.Plugin;

namespace DevTools.USL
{
    /// <summary>
    /// 托盘菜单管理对象
    /// </summary>
    public class MenuManager : IDisposable
    {
        private const string MENU_SEPARATOR = "-";
        
        private NotifyIcon notifyIcon;
		private ContextMenu notificationMenu;
		
        public MenuManager()
        {
            notifyIcon = new NotifyIcon();
			notificationMenu = new ContextMenu();
			
			InitializeMenu();
			
			notifyIcon.Icon = Properties.Resources.Icon;
			notifyIcon.ContextMenu = notificationMenu;
			
			LanguageManager.LanguageChanged += new EventHandler(LanguageManager_LanguageChanged);
        }

        private void LanguageManager_LanguageChanged(object sender, EventArgs e)
        {
            foreach (MenuItem menuItem in notificationMenu.MenuItems)
            {
                LoadLanguage(menuItem);
            }
        }
        
        private void LoadLanguage(MenuItem menuItem)
        {
            LanguageManager.GetString(menuItem);
            foreach (MenuItem subMenuItem in menuItem.MenuItems)
            {
                LoadLanguage(subMenuItem);
            }
        }
        
        public void Show()
        {
            this.notifyIcon.Visible = true;
        }
        
        private void InitializeMenu()
		{
            InitializePluginMenu();

            InitializeMainMenu();
		}
        
        private void InitializeMainMenu()
        {
            AddSeparatorMenuItem();
            
            AddMenuItem("menuItemConfig", "设置", typeof(FormConfig));
            AddMenuItem("menuItemAbout", "关于", typeof(AboutBox));

            AddMenuItem("menuItemExit", "退出").Click += new EventHandler(menuExitClick);
        }
        
        private Dictionary<string, Form> singleFormMenuDict = new Dictionary<string, Form>();
        
        private void AddMenuItem(string name, string text, Type formType)
        {
            MenuItem menuItem = AddMenuItem(name, text);
            Form form = Activator.CreateInstance(formType) as Form;
            singleFormMenuDict[name] = form;
            menuItem.Click += new EventHandler(singleFormMenuItemClick);
        }

        private void singleFormMenuItemClick(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Form form = singleFormMenuDict[menuItem.Name];
            if (form.IsDisposed)
            {
                form = Activator.CreateInstance(form.GetType()) as Form;
                singleFormMenuDict[menuItem.Name] = form;
            }
            form.Show();
            form.Activate();
        }
        
        private void menuAboutClick(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        private void menuExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void InitializePluginMenu()
        {
            List<IPlugin> pluginList = PluginsManager.LoadPlugins();
            foreach (IPlugin plugin in pluginList)
            {
                string menuName = string.Format("menuItem{0}",
                                                plugin.GetType().Assembly.GetName().Name);
                MenuItem item = AddMenuItem(menuName, plugin.DisplayName);
                item.Click += new EventHandler(menuPluginClick);
                item.Tag = plugin;
            }
        }
        
        private void menuPluginClick(object sender, EventArgs e)
        {
            ((sender as MenuItem).Tag as IPlugin).StartUp();
        }
        
        private void AddSeparatorMenuItem()
        {
            AddMenuItem(string.Empty, MENU_SEPARATOR);
        }
        
        private MenuItem AddMenuItem(string name, string text)
        {
            return AddMenuItem(this.notificationMenu, name, text);
        }
        
        private MenuItem AddMenuItem(ContextMenu parent, string name, string text)
        {
            MenuItem item = new MenuItem(text);
            int index = parent.MenuItems.Add(item);
            if (string.IsNullOrEmpty(name))
            {
                name = string.Format("menuItem{0:000}", index);
            }
            item.Name = name;
            LanguageManager.GetString(item);
            return item;
        }
        
        private MenuItem AddMenuItem(MenuItem parent, string name, string text)
        {
            MenuItem item = new MenuItem(text);
            int index = parent.MenuItems.Add(item);
            if (string.IsNullOrEmpty(name))
            {
                name = string.Format("{0}SubItem{1:000}", parent.Name, index);
            }
            item.Name = name;
            LanguageManager.GetString(item);
            return item;
        }
        
        public void Dispose()
        {
            notifyIcon.Dispose();
            notificationMenu.Dispose();
        }
    }
}
