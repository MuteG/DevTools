﻿using System;
using System.Threading;
using System.Windows.Forms;
using DevTools.Common.Log;
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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            bool isFirstInstance;
            using (Mutex mtx = new Mutex(true, "DevTools", out isFirstInstance))
            {
                if (isFirstInstance)
                {
                    try
                    {
                        Config.ConfigBase config = new DevToolsConfig();
                        config = Config.ConfigManager.GetConfig(config.Key);
                        Language.LanguageManager.Code = (config as DevToolsConfig).Language;
                        using (MenuManager menu = new MenuManager())
                        {
                            menu.Show();
                            Application.Run();
                        }
                    }
                    catch (Exception ex)
                    {
                        DTLogger logger = new DTLogger();
                        logger.Error(ex);
                    }
                    finally
                    {
                        mtx.ReleaseMutex();
                    }
                }
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DTLogger logger = new DTLogger();
            logger.Error(e.Exception);
        }
    }
}
//TODO : 语言切换时，“关于”窗体无法立即生效（从未启动过“关于”窗体的情况下）