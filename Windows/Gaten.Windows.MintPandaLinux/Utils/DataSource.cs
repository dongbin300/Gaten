using System.Data;

namespace Gaten.Windows.MintPandaLinux.Utils
{
    public class DataSource
    {
        public DataTable table;
        public DataView Data => table.DefaultView;

        public DataSource()
        {
            table = new DataTable();
        }

        public DataSource(params string[] columns)
        {
            table = new DataTable();
            AddColumns(columns);
        }

        public void AddColumns(params string[] columns)
        {
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
