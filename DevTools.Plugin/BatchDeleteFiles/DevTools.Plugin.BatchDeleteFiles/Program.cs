using System;
using DevTools.Plugin;
using DevTools.Plugin.BatchDeleteFiles.USL;
using System.Windows.Forms;

namespace DevTools.Plugin.BatchDeleteFiles
{
    /// <summary>
    /// 启动单元
    /// </summary>
    [Plugin(true, CanConfig = false, DisplayName = "批量删除文件")]
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
    }
}