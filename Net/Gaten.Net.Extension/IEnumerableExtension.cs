using System.Data;

namespace Gaten.Net.Extension
{
    public static class IEnumerableExtension
    {
        public static DataTable ToDataTable(this IEnumerable<object> obj)
        {
            var dt = new DataTable();
            var t = obj.GetType();
            if (t.GenericTypeArguments.Count() == 0)
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
    }
}
