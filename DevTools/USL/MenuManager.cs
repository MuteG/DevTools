using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            
            AddMenuItem("设置").Click += new EventHandler(menuConfigClick);
            AddMenuItem("关于").Click += new EventHandler(menuAboutClick);
            AddMenuItem("退出").Click += new EventHandler(menuExitClick);
        }

        private void menuConfigClick(object sender, EventArgs e)
        {
            new FormConfig().Show();
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
                MenuItem item = AddMenuItem(plugin.DisplayName);
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
            AddMenuItem(MENU_SEPARATOR);
        }
        
        private MenuItem AddMenuItem(string text)
        {
            return AddMenuItem(this.notificationMenu, text);
        }
        
        private MenuItem AddMenuItem(ContextMenu parent, string text)
        {
            MenuItem item = new MenuItem(text);
            parent.MenuItems.Add(item);
            LanguageManager.GetString(item);
            return item;
        }
        
        private MenuItem AddMenuItem(MenuItem parent, string text)
        {
            MenuItem item = new MenuItem(text);
            parent.MenuItems.Add(item);
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
