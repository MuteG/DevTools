using System;
using System.Windows.Forms;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.USL;

namespace DevTools.Plugin.DBTool
{
    /// <summary>
    /// 模块入口
    /// </summary>
    [Plugin(true, CanConfig = true, ConfigType = typeof(DBToolConfig), ConfigPanelType = typeof(DBToolConfigPanel), DisplayName = "数据库工具")]
    public class Program : AbstractPlugins
    {
        public override void StartUp()
        {
            FormMain formMain = new FormMain();
            formMain.Show();
        }

        public override void Reset()
        {
            //throw new NotImplementedException();
        }

        public override void Config()
        {
            //throw new NotImplementedException();
        }

#if DEBUG
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
#endif
    }
}
