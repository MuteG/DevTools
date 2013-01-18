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
