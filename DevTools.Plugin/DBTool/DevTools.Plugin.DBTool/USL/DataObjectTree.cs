using System;
using System.Linq;
using System.Windows.Forms;
using DevTools.Config;
using DevTools.Plugin.DBTool.Core.Config;
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
                //databaseNode.Nodes.Add("INDEXES", "INDEXES", "index", "index").Tag = conn;
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            ReloadChildNodes(node);
        }

        private void ReloadChildNodes(TreeNode node)
        {
            switch (node.ImageKey)
            {
                case "table":
                    {
                        switch (node.Level)
                        {
                            case 1:
                                TableRootNodeDoubleClick(node);
                                break;
                            case 2:
                                TableNodeDoubleClick(node);
                                break;
                        }
                        break;
                    }
                case "index":
                    switch (node.Level)
                    {
                        case 3:
                            IndexNodeDoubleClick(node);
                            break;
                    }
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

        private void IndexNodeDoubleClick(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                Index index = node.Tag as Index;
                foreach (IndexColumn column in index.Columns)
                {
                    string text = string.Format("{0}({1})", column.Name, column.Sort);
                    node.Nodes.Add(column.Name, text, "column", "column").Tag = column;
                }
                node.Expand();
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            btnRefresh.Enabled = false;
            switch (node.ImageKey)
            {
                case "table":
                    {
                        switch (node.Level)
                        {
                            case 1:
                            case 2:
                                btnRefresh.Enabled = true;
                                break;
                        }
                        break;
                    }
                case "index":
                    switch (node.Level)
                    {
                        case 3:
                            btnRefresh.Enabled = true;
                            break;
                    }
                    break;
            }
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            FormConfig frmConfig = new FormConfig();
            frmConfig.ShowDialog(this.ParentForm);
            string key = new DBToolConfig().Key;
            DBToolConfig config = ConfigManager.GetConfig(key) as DBToolConfig;
            foreach (DBToolConnection conn in config.Connections)
            {
                if (!treeView.Nodes.ContainsKey(conn.Name))
                {
                    string text = string.Format("{0}({1})", conn.Name, conn.Type);
                    TreeNode databaseNode = treeView.Nodes.Add(conn.Name, text, "database", "database");
                    Database database = new Database(conn);
                    databaseNode.Tag = database;
                    databaseNode.Nodes.Add("TABLES", "TABLES", "table", "table").Tag = database;
                }
            }
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                if (!config.Connections.Any(c => c.Name.Equals(treeView.Nodes[i].Name)))
                {
                    treeView.Nodes.RemoveAt(i);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView.SelectedNode;
            node.Nodes.Clear();
            ReloadChildNodes(node);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
