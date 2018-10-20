using System.Collections.Generic;

namespace DevTools.Plugin.DBTool.Core.Entity
{
    public class Index
    {
        public string Name { get; set; }

        public List<IndexColumn> Columns { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool Enable { get; set; }
    }
}
