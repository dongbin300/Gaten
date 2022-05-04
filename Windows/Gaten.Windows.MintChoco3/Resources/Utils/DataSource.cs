using System.Data;

namespace Gaten.Windows.MintChoco3.Resources.Utils
{
    public class DataSource
    {
        DataTable table;
        public DataView Data => table.DefaultView;

        public DataSource(params string[] columns)
        {
            table = new DataTable();
            foreach(string col in columns)
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
