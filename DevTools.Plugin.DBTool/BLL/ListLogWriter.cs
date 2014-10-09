using System;
using System.Drawing;
using System.Windows.Forms;
using Been.BPO.DevTools.SqlServerHelper.Common.Helper;
using DevTools.Common.Log;

namespace DevTools.Plugin.DBTool.Common.Generator
{
    internal static class ListLogWriter
    {
        private static int textLength = 0;
        private static RichTextBox _ListLogBox;
        /// <summary>
        /// 属性 读取或者设置日志显示列表组件
        /// </summary>
        public static RichTextBox ListLogBox
        {
            set
            {
                _ListLogBox = value;
            }
            get
            {
                return _ListLogBox;
            }
        }
        /// <summary>
        /// 向日志列表组件中写日志
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="message">日志信息</param>
        public static void WriteLog(LogType logType, string message)
        {
            string msg = DateTime.Now.ToString("HH:mm:ss fff\t") + message + "\n";
            int msgLength = msg.Length;
            _ListLogBox.AppendText(msg);
            _ListLogBox.Select(textLength, msgLength);
            switch (logType)
            {
                case LogType.LTDB:
                    _ListLogBox.SelectionColor = Color.Green;
                    break;
                case LogType.LTDetail:
                    _ListLogBox.SelectionColor = Color.Black;
                    break;
                case LogType.LTError:
                    _ListLogBox.SelectionColor = Color.Red;
                    break;
                case LogType.LTProcStart:
                    _ListLogBox.SelectionColor = Color.Blue;
                    break;
                case LogType.LTProcStop:
                    _ListLogBox.SelectionColor = Color.Magenta;
                    break;
            }
            textLength += msgLength;
            _ListLogBox.Select(_ListLogBox.Text.Length, 0);
            _ListLogBox.ScrollToCaret();
            Application.DoEvents();
        }
    }
}
