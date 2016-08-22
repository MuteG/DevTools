using System;
using System.Drawing;
using System.Windows.Forms;
using DevTools.Common.Log;

namespace DevTools.Plugin.BatchDeleteFiles.USL
{
    /// <summary>
    /// Description of FormMain.
    /// </summary>
    public partial class FormMain : Form
    {
        public FormMain()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        private void CheckBoxIsDeleteRoot_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                checkBox.BackColor = Color.OrangeRed;
            }
            else
            {
                checkBox.BackColor = Color.LightGreen;
            }
        }
        
        private void TextBoxRootFolder_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO: Implement TextBoxRootFolder_KeyPress
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DTLogger logger = new DTLogger();
            logger.Debug("Delete Files");
        }
    }
}
