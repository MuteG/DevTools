using System;
using DevTools.Plugin;
using DevTools.Plugin.CodeLines.USL;
using System.Windows.Forms;

namespace DevTools.Plugin.CodeLines
{
    /// <summary>
    /// Description of Program.
    /// </summary>
    [Plugin(true, CanConfig = false, DisplayName = "代码行数统计")]
    public class Program : AbstractPlugins
    {
        public Program()
        {
        }
        
        public override void StartUp()
        {
            FormMain formMain = new FormMain();
            formMain.Show();
        }
        
        public override void Reset()
        {
            
        }
        
        public override void Config()
        {
            
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
