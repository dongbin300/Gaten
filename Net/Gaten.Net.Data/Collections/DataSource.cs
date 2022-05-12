using System.Data;

namespace Gaten.Net.Data.Collections
{
    public class DataSource
    {
        DataTable table;
        public DataView Data => table.DefaultView;

        public DataSource(params string[] columns)
        {
            table = new DataTable();
            foreach (string col in columns)
            {
                table.Columns.Add(col, typeof(string));
            }
        }

        public void AddRow(params string[] items)
        {
            table.Rows.Add(items);
        }
    }
}
