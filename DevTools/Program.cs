using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using DevTools.Plugin;

namespace DevTools
{
    public sealed class Program
    {
        private NotifyIcon notifyIcon;
		private ContextMenu notificationMenu;
		
		#region Initialize icon and menu
        public Program()
		{
			notifyIcon = new NotifyIcon();
			notificationMenu = new ContextMenu(InitializeMenu());            
			
			notifyIcon.Icon = Properties.Resources.Icon;
			notifyIcon.ContextMenu = notificationMenu;
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

            menu.Add(new MenuItem("-"));
            menu.Add(new MenuItem("关于", menuAboutClick));
            menu.Add(new MenuItem("退出", menuExitClick));
			return menu.ToArray();
		}
		#endregion

        #region Main - Program entry point
        /// <summary>Program entry point.</summary>
        /// <param name="args">Command Line Arguments</param>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isFirstInstance;
            // Please use a unique name for the mutex to prevent conflicts with other programs
            using (Mutex mtx = new Mutex(true, "DevTools", out isFirstInstance))
            {
                if (isFirstInstance)
                {
                    Program notificationIcon = new Program();
                    notificationIcon.notifyIcon.Visible = true;

                    Application.Run();
                    notificationIcon.notifyIcon.Dispose();
                }
                else
                {
                    // The application is already running
                    // TODO: Display message box or change focus to existing application instance
                }
            } // releases the Mutex
        }
        #endregion

        #region Event Handlers

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
        #endregion
    }
}
