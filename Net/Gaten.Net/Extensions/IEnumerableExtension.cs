using Gaten.Net.IO;

using System.Data;
using System.Reflection.Metadata.Ecma335;

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
            var alternativeColonChar = 'ꪪ';
            var type = typeof(T);
            var properties = type.GetProperties();
            var contents = new List<string>
            {
                string.Join(',', properties.Select(x=>x.Name.Replace(',', alternativeColonChar)).ToArray())
            };

            foreach (var data in obj)
            {
                var values = new List<string>();
                foreach (var property in properties)
                {
                    var value = type.GetProperty(property.Name)?.GetValue(data, null);
                    values.Add(value?.ToString()?.Replace(',', alternativeColonChar) ?? default!);
                }
                contents.Add(string.Join(',', values.ToArray()));
            }

            GFile.WriteByArray(path, contents);
        }
    }
}
