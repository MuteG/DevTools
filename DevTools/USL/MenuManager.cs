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
			notificationMenu = new ContextMenu(InitializeMenu());
			foreach (MenuItem menuItem in notificationMenu.MenuItems)
			{
                LanguageManager.GetString(menuItem);
			}
			
			notifyIcon.Icon = Properties.Resources.Icon;
			notifyIcon.ContextMenu = notificationMenu;
        }
        
        public void Show()
        {
            this.notifyIcon.Visible = true;
        }
        
        private MenuItem[] InitializeMenu()
		{
            List<MenuItem> menu = new List<MenuItem>();
            foreach (var item in PluginsManager.LoadPlugins())
            {
                menu.Add(new MenuItem(
                    item.DisplayName,
                    menuPluginClick) { Tag = item });
            }

            menu.Add(new MenuItem(MENU_SEPARATOR));
            
            MenuItem menuItemAbout = new MenuItem("关于", menuAboutClick);
            menu.Add(menuItemAbout);
            
            MenuItem menuItemExit = new MenuItem("退出", menuExitClick);
            menu.Add(menuItemExit);
            
			return menu.ToArray();
		}
        
        private void menuPluginClick(object sender, EventArgs e)
        {
            ((sender as MenuItem).Tag as IPlugin).StartUp();
        }

        private void menuAboutClick(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        private void menuExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        public void Dispose()
        {
            notifyIcon.Dispose();
            notificationMenu.Dispose();
        }
    }
}
