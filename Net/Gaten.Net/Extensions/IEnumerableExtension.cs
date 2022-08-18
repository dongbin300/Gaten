using Gaten.Net.IO;

using System.Data;

namespace Gaten.Net.Extensions
{
    public static class IEnumerableExtension
    {

        public static DataTable ToDataTable<T>(this IEnumerable<T> obj)
        {
            var dt = new DataTable();
            var t = obj.GetType();
            if (t.GenericTypeArguments.Length == 0)
            {
                throw new Exception("No Type");
            }
            var innerType = t.GenericTypeArguments[0];
            var properties = innerType.GetProperties();

            foreach (var property in properties)
            {
                dt.Columns.Add(property.Name, typeof(string));
            }

            foreach (var data in obj)
            {
                var values = new List<object?>();
                foreach (var property in properties)
                {
                    values.Add(innerType.GetProperty(property.Name)?.GetValue(data, null));
                }
                dt.Rows.Add(values.ToArray());
            }

            return dt;
        }

        public static void SaveCsvFile<T>(this IEnumerable<T> obj, string path)
        {
            var contents = string.Join(Environment.NewLine, obj);
            GFile.Write(path, contents);
        }
    }
}
