using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevTools.Common.Log;
using DevTools.Config;
using DevTools.Plugin.DBTool.Common;
using DevTools.Plugin.DBTool.Common.Generator;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Plugin.DBTool.Core.Entity;
using DevTools.Plugin.DBTool.Data;
using DevTools.Plugin.DBTool.Data.Operator;
using WeifenLuo.WinFormsUI.Docking;

namespace DevTools.Plugin.DBTool.USL
{
    public partial class FormMain : Form
    {
        private DBToolConnection databaseConnectionInfo = new DBToolConnection();
        private static Stopwatch watch = Stopwatch.StartNew();
        private FormDatabaseStructure dbView;
        public FormMain()
        {
            InitializeComponent();

            VS2015LightTheme theme = new VS2015LightTheme();
            this.dockPanel1.Theme = theme;

            FormDataObjectTree contentTree = new FormDataObjectTree();
            contentTree.TableSelected += dataObjectTree_TableSelected;
            contentTree.Show(this.dockPanel1, DockState.DockLeft);

            dbView = new FormDatabaseStructure();
            dbView.Show(this.dockPanel1, DockState.Document);

            FormLog log = new FormLog();
            log.Show(this.dockPanel1, DockState.DockBottom);
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            cbxDatabaseName.Enabled = false;
            cbxOperateType.Enabled = false;
            cbxTableName.Enabled = false;
            btnGenerateCSharp.Enabled = false;
            btnGenerateScript.Enabled = false;
            this.Text += " Ver " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    //Command.SetOrderList(lstOrderCode);  //更新列表
                    break;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认退出程序么?", "退出程序", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void FillDatabaseComboBox()
        {
            watch.Reset();
            watch.Start();
            cbxDatabaseName.DataSource = null;
            DataTable table = DBOperator.GetDatabase();
            if (table.Rows.Count > 0)
            {
                cbxDatabaseName.DataSource = table;
                cbxDatabaseName.DisplayMember = "NAME";
                cbxDatabaseName.ValueMember = "NAME";
            }
            else
            {
                ListLogWriter.WriteLog(LogType.LTDetail, "未找到任何数据库");
            }
            watch.Stop();
            ListLogWriter.WriteLog(LogType.LTDB,
                string.Format("查询数据库列表 耗时：{0}ms", watch.ElapsedMilliseconds));
        }

        private void cbxDatabaseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Command.SetDatabaseConnection(databaseConnectionInfo, cbxDatabaseName.Text);
            if (0 == cbxOperateType.SelectedIndex)
            {
                Command.SetComboBoxTables(cbxTableName);
            }
            else
            {
                //ReloadListView();
            }
        }

        private void cbxTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ReloadListView();
            if (cbxSqlType.SelectedIndex < 0) cbxSqlType.SelectedIndex = 0;
        }

        private void cbxOperateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lstDatabaseStructure.Clear();
            //lstDatabaseStructure.Columns.Add(string.Empty, 30);
            //lstDatabaseStructure.Columns.Add("名称", 220);
            //bool isOperateTable = 0 == cbxOperateType.SelectedIndex;
            //cbxTableName.Enabled = isOperateTable;
            //btnGenerateScript.Enabled = isOperateTable;
            //if (isOperateTable)
            //{
            //    lstDatabaseStructure.Columns.Add("类型", 90);
            //    lstDatabaseStructure.Columns.Add("长度", 60);
            //    Command.SetComboBoxTables(cbxTableName);
            //}
            //ReloadListView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //ReloadListView();
        }

        private void btnGenerateScript_Click(object sender, EventArgs e)
        {
            if (0 == cbxOperateType.SelectedIndex)
            {
                //Command.GenerateStoreProcedureScript(GetSqlType(),
                //    chkInput.Checked, chkHead.Checked, chkCutPrefix.Checked,
                //    cbxTableName.Text, lstDatabaseStructure);
            }
        }

        private SqlOperateType GetSqlType()
        {
            SqlOperateType result = SqlOperateType.Select;
            switch (cbxSqlType.SelectedIndex)
            {
                case 0:
                    result = SqlOperateType.Select;
                    break;
                case 1:
                    result = SqlOperateType.Insert;
                    break;
                case 2:
                    result = SqlOperateType.Delete;
                    break;
                case 3:
                    result = SqlOperateType.Update;
                    break;
                default :
                    break;
            }
            return result;
        }

        private void btnGenerateCSharp_Click(object sender, EventArgs e)
        {
            //if (0 == cbxOperateType.SelectedIndex)
            //{
            //    using (FormPrefix prefixDialog = new FormPrefix())
            //    {
            //        if (prefixDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            Command.GenerateTableInstanceCSharpCode(cbxTableName.Text, prefixDialog.Prefix,
            //                chkCutPrefix.Checked, lstDatabaseStructure);
            //        }
            //    }
            //}
            //else
            //{
            //    Command.MakeStoreProcedureCode(lstDatabaseStructure);
            //}
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            using (FormConfig form = new FormConfig())
            {
                form.ShowDialog(this);
            }
        }

        private void dataObjectTree_TableSelected(object sender, TreeViewEventArgs e)
        {
            Table table = e.Node.Tag as Table;
            //lstDatabaseStructure.SuspendLayout();
            //lstDatabaseStructure.Items.Clear();
            //foreach (Column column in table.Columns)
            //{
            //    ListViewItem row = lstDatabaseStructure.Items.Add(string.Empty);
            //    row.ImageKey = string.Empty;
            //    if (table.PrimaryKey.Any(k => k.Name == column.Name))
            //    {
            //        row.ImageKey = "key";
            //    }
            //    row.SubItems.Add(column.Name);
            //    row.SubItems.Add(column.Type);
            //    row.SubItems.Add(column.Length.ToString());
            //}
            //lstDatabaseStructure.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //lstDatabaseStructure.ResumeLayout(false);
            //lstDatabaseStructure.PerformLayout();

            dbView.Table = table;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}