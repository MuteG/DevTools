using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevTools.Plugin.DBTool.Core.Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace DevTools.Plugin.DBTool.USL
{
    public partial class FormDatabaseStructure : DockContent
    {
        public FormDatabaseStructure()
        {
            InitializeComponent();
        }

        private Table table;

        public Table Table
        {
            get
            {
                return table;
            }
            set
            {
                SetTable(value);
            }
        }

        private void SetTable(Table value)
        {
            table = value;
            lstDatabaseStructure.SuspendLayout();
            lstDatabaseStructure.Items.Clear();
            foreach (Column column in table.Columns)
            {
                ListViewItem row = lstDatabaseStructure.Items.Add(string.Empty);
                row.ImageKey = string.Empty;
                if (table.PrimaryKey.Any(k => k.Name == column.Name))
                {
                    row.ImageKey = "key";
                }
                row.SubItems.Add(column.Name);
                row.SubItems.Add(column.Type);
                row.SubItems.Add(column.Length.ToString());
            }
            lstDatabaseStructure.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstDatabaseStructure.ResumeLayout(false);
            lstDatabaseStructure.PerformLayout();
        }

        private void mnuItemSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDatabaseStructure.Items.Count; i++)
            {
                lstDatabaseStructure.Items[i].Checked = true;
            }
        }

        private void mnuItemSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDatabaseStructure.Items.Count; i++)
            {
                lstDatabaseStructure.Items[i].Checked = false;
            }
        }

        private void mnuItemSelectAgainst_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDatabaseStructure.Items.Count; i++)
            {
                lstDatabaseStructure.Items[i].Checked = !lstDatabaseStructure.Items[i].Checked;
            }
        }
    }
}
