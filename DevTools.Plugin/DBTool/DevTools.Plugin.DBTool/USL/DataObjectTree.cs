using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevTools.Plugin.DBTool.Core.Config;
using DevTools.Config;
using DevTools.Plugin.DBTool.Core.Data;
using DevTools.Plugin.DBTool.Core.Entity;

namespace DevTools.Plugin.DBTool.USL
{
    public partial class DataObjectTree : UserControl
    {
        public DataObjectTree()
        {
            InitializeComponent();
        }

        private void DataObjectTree_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            string key = new DBToolConfig().Key;
            DBToolConfig config = ConfigManager.GetConfig(key) as DBToolConfig;
            foreach (DBToolConnection conn in config.Connections)
            {
                string text = string.Format("{0}({1})", conn.Name, conn.Type);
                TreeNode databaseNode = treeView.Nodes.Add(conn.Name, text, "database", "database");
                Database database = new Database(conn);
                databaseNode.Tag = database;
                databaseNode.Nodes.Add("TABLES", "TABLES", "table", "table").Tag = database;
                //databaseNode.Nodes.Add("VIEWS", "VIEWS", "view").Tag = conn;
                databaseNode.Nodes.Add("INDEXES", "INDEXES", "index", "index").Tag = conn;
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.ImageKey)
            {
                case "table":
                    {
                        switch (e.Node.Level)
	                    {
                            case 1:
                                TableRootNodeDoubleClick(e.Node);
                                break;
                            case 2:
                                TableNodeDoubleClick(e.Node);
                                break;
	                    }
                        break;
                    }
                case "index":
                    switch (e.Node.Level)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void TableRootNodeDoubleClick(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                Database database = node.Tag as Database;
                foreach (Table table in database.Tables)
                {
                    node.Nodes.Add(table.Name, table.Name, "table", "table").Tag = table;
                }
                node.Expand();
            }
        }

        private void TableNodeDoubleClick(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                Table table = node.Tag as Table;
                foreach (Index index in table.Indexes)
                {
                    node.Nodes.Add(index.Name, index.Name, "index", "index").Tag = index;
                }
                node.Expand();
            }
        }
    }
}
