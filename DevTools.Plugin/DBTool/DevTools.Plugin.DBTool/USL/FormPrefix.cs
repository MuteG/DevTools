using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DevTools.Plugin.DBTool.USL
{
    public partial class FormPrefix : Form
    {
        public string Prefix
        {
            get { return tbxPrefix.Text.Trim(); }
            set { tbxPrefix.Text = value; }
        }

        public FormPrefix()
        {
            InitializeComponent();
            this.Prefix = "m_";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
