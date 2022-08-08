using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Network.MySql
{
    public class MySqlTable
    {
        public string Name { get; set; }
        public List<string> ColumnName { get; set; }
        public string InsertString => Name + "(" + string.Join(",", ColumnName) + ")";

        public MySqlTable(string name, List<string> columnName)
        {
            Name = name;
            ColumnName = columnName;
        }
    }
}
