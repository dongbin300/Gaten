using Gaten.Net.Extension;

using System.Data;
using System.Linq;

namespace Gaten.Net.Data.Collections
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

        public DataSource(IEnumerable<object> obj)
        {
            table = obj.ToDataTable();
        }

        public DataSource(string csvPath)
        {
            table = new DataTable();
            var data = IO.File.ReadToArray(csvPath);
            AddColumns(data[0].Split(',').Select(x=>x.Replace('ꪪ', ',')).ToArray());
            for (int i = 1; i < data.Length; i++)
            {
                var items = data[i].Split(',').Select(x => x.Replace('ꪪ', ',')).ToArray();
                AddRow(items);
            }
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

        public void SaveCsvFile(string path)
        {
            List<string> contents = new();

            contents.Add(string.Join(',', table.Columns.Cast<DataColumn>().Select(c=>c.ColumnName.Replace(',', 'ꪪ')).ToArray()));
            foreach (DataRow row in table.Rows)
            {
                contents.Add(string.Join(',', row.ItemArray.Cast<string>().Select(r=>r.Replace(',', 'ꪪ')).ToArray()));
            }
            IO.File.WriteByArray(path, contents);
        }
    }
}
