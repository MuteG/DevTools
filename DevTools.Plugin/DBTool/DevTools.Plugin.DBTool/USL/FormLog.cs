using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevTools.Common.Log;
using WeifenLuo.WinFormsUI.Docking;

namespace DevTools.Plugin.DBTool.USL
{
    public partial class FormLog : DockContent
    {
        public FormLog()
        {
            InitializeComponent();

            DTLogger.Instance.DTLogging += DTLogging;
        }

        private void DTLogging(string message)
        {
            int start = rtbLogList.TextLength;
            Color color = SystemColors.WindowText;
            this.rtbLogList.SuspendLayout();
            this.rtbLogList.AppendText(message);
            if (message.Contains("[Error]") ||
                message.Contains("[Fatal]"))
            {
                color = Color.Red;
            }
            else if (message.Contains("[Warn]"))
            {
                color = Color.Orange;
            }
            else if (message.Contains("[Info]"))
            {
                color = Color.Green;
            }
            if (color != SystemColors.WindowText)
            {
                rtbLogList.SelectionStart = start;
                rtbLogList.SelectionLength = rtbLogList.TextLength - start;
                rtbLogList.SelectionColor = color;
            }
            this.rtbLogList.AppendText(Environment.NewLine);
            rtbLogList.SelectionStart = rtbLogList.TextLength;
            this.rtbLogList.ScrollToCaret();
            this.rtbLogList.ResumeLayout(false);
            this.rtbLogList.PerformLayout();
        }
    }
}
