using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using DevTools.USL;

namespace DevTools
{
    public sealed class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isFirstInstance;
            using (Mutex mtx = new Mutex(true, "DevTools", out isFirstInstance))
            {
                if (isFirstInstance)
                {
                    try
                    {
                        Config.ConfigBase config = new DevToolsConfig();
                        Config.ConfigManager.GetConfig(ref config);
                        Language.LanguageManager.Code = (config as DevToolsConfig).Language;
                    }
                    catch { }
                    using (MenuManager menu = new MenuManager())
                    {
                        menu.Show();
                        Application.Run();
                    }
                }
                mtx.ReleaseMutex();
            }
        }
    }
}
//TODO : 语言切换时，“关于”窗体无法立即生效（从未启动过“关于”窗体的情况下）