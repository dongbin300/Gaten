using Gaten.Net.IO;

using System.Data;
using System.Reflection;

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
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField);
            var fieldNames = fields.Select(x => x.Name.Replace(',', alternativeColonChar).Replace("k__BackingField", "").Replace("<", "").Replace(">", "")).ToList();

            var contents = new List<string>
            {
                string.Join(',', fieldNames)
            };

            foreach (var data in obj)
            {
                var values = new List<string>();
                for(int i = 0; i < fields.Length; i++)
                {
                    var value = type.GetProperty(fieldNames[i])?.GetValue(data, null);
                    values.Add(value?.ToString()?.Replace(',', alternativeColonChar) ?? default!);
                }
                contents.Add(string.Join(',', values.ToArray()));
            }

            GFile.WriteByArray(path, contents);
        }

        public static double StandardDeviation(this IEnumerable<int> values) => System.Math.Sqrt(values.Average(v => System.Math.Pow(v - values.Average(), 2)));
        public static double StandardDeviation(this IEnumerable<long> values) => System.Math.Sqrt(values.Average(v => System.Math.Pow(v - values.Average(), 2)));
        public static double StandardDeviation(this IEnumerable<float> values) => System.Math.Sqrt(values.Average(v => System.Math.Pow(v - values.Average(), 2)));
        public static double StandardDeviation(this IEnumerable<double> values) => System.Math.Sqrt(values.Average(v => System.Math.Pow(v - values.Average(), 2)));
        public static double StandardDeviation(this IEnumerable<decimal> values) => System.Math.Sqrt(values.Average(v => System.Math.Pow(decimal.ToDouble(v - values.Average()), 2)));

        public static IEnumerable<IEnumerable<T>> Combinate<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { Enumerable.Empty<T>() } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinate(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        public static IEnumerable<T[]> Permutate<T>(this IEnumerable<T> elements)
        {
            return permutate(elements, Enumerable.Empty<T>());
            IEnumerable<T[]> permutate(IEnumerable<T> reminder, IEnumerable<T> prefix) =>
                !reminder.Any() ? new[] { prefix.ToArray() } :
                reminder.SelectMany((c, i) => permutate(
                    reminder.Take(i).Concat(reminder.Skip(i + 1)).ToArray(),
                    prefix.Append(c)));
        }
    }
}
