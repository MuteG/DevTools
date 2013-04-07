using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

using DevTools.Language;

namespace DevTools
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            
            LoadLanguage();
        }
        
        private void LoadLanguage()
        {
            LanguageManager.GetString(this);
            LanguageManager.GetString(buttonOK);
            LanguageManager.GetString(labelProductName);
            LanguageManager.GetString(textBoxDescription);
            LanguageManager.GetString(labelWebSite);
            
            string versionPre =
                LanguageManager.GetString("DevTools.AboutBox_labelVersion", "版本:");
            this.labelVersion.Text = versionPre + AssemblyVersion;
            
            this.labelCopyright.Text = AssemblyCopyright;
        }

        #region 程序集特性访问器

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void LabelWebSiteLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             e.Link.Visited = true;
             Process.Start("http://DevTools.CodePlex.com");
        }
    }
}
