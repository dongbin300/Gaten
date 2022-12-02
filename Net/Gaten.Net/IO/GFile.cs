using System.Data;
using System.Reflection;
using System.Text;

using SystemFile = System.IO.File;

namespace Gaten.Net.IO
{
    public class GFile
    {
        #region Properties
        public static string DictionarySeparator { get; set; } = ":";
        public static Encoding Encoding { get; set; } = Encoding.UTF8;
        #endregion

        #region Common
        public static bool Exists(string path)
        {
            return SystemFile.Exists(path);
        }

        public static void TryCreate(string path)
        {
            if (!Exists(path))
            {
                Write(path, string.Empty);
            }
        }
        #endregion

        #region Read
        public static string Read(string path)
        {
            return SystemFile.ReadAllText(path, Encoding);
        }

        public static string[] ReadToArray(string path)
        {
            return SystemFile.ReadAllLines(path);
        }

        public static Dictionary<string, string> ReadToDictionary(string path)
        {
            Dictionary<string, string> result = new();

            var items = ReadToArray(path);

            foreach (var item in items)
            {
                int separatorIndex = item.IndexOf(DictionarySeparator);
                var key = item[..separatorIndex];
                var value = item[(separatorIndex + 1)..];

                result.Add(key, value);
            }

            return result;
        }

        public static byte[] ReadBinary(string path)
        {
            return SystemFile.ReadAllBytes(path);
        }

        public static DataTable ReadCsv(string path)
        {
            var result = new DataTable();
            var items = ReadToArray(path);
            var columns = items[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var column in columns)
            {
                result.Columns.Add(column, typeof(string));
            }
            for (int i = 1; i < items.Length; i++)
            {
                var data = items[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                result.Rows.Add(data);
            }
            return result;
        }

        public static IList<T> ReadCsv<T>(string path)
        {
            IList<T> result = new List<T>();
            var items = ReadToArray(path);
            var columns = items[0].Split(',', StringSplitOptions.RemoveEmptyEntries);

            Type type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField);

            for (int i = 1; i < items.Length; i++)
            {
                object[] defaultParameters = new object[columns.Length];
                Array.Fill(defaultParameters, default!);
                T instance = (T)(Activator.CreateInstance(type, defaultParameters) ?? default!);
                var segments = items[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < segments.Length; j++)
                {
                    var field = fields.First(f => f.Name.Equals(columns[j]) || f.Name.Equals($"<{columns[j]}>k__BackingField"));
                    field.SetValue(instance, segments[j]);
                }
                result.Add(instance);
            }

            return result;
        }
        #endregion

        #region Write
        public static void Write(string path, string contents)
        {
            SystemFile.WriteAllText(path, contents, Encoding);
        }

        public static void WriteByArray(string path, IList<string> contents)
        {
            SystemFile.WriteAllLines(path, contents, Encoding);
        }

        public static void WriteByDictionary(string path, IDictionary<string, string> contents)
        {
            StringBuilder builder = new();

            foreach (var content in contents)
            {
                builder.AppendLine(content.Key + DictionarySeparator + content.Value);
            }

            Write(path, builder.ToString());
        }

        public static void WriteBinary(string path, byte[] contents)
        {
            SystemFile.WriteAllBytes(path, contents);
        }

        public static void WriteCsv(string path, DataTable dataTable)
        {
            var contents = new List<string>
            {
                string.Join(',', dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName.Replace(',', 'ꪪ')).ToArray())
            };
            foreach (DataRow row in dataTable.Rows)
            {
                contents.Add(string.Join(',', row.ItemArray.Cast<string>().Select(r => r.Replace(',', 'ꪪ')).ToArray()));
            }
            WriteByArray(path, contents);
        }
        #endregion

        #region Append
        public static void Append(string path, string contents)
        {
            SystemFile.AppendAllText(path, contents, Encoding);
        }

        public static void AppendLine(string path, string contents)
        {
            Append(path, contents + Environment.NewLine);
        }

        public static void AppendByArray(string path, IList<string> contents)
        {
            SystemFile.AppendAllLines(path, contents, Encoding);
        }

        public static void AppendByDictionary(string path, IDictionary<string, string> contents)
        {
            StringBuilder builder = new();

            foreach (var content in contents)
            {
                builder.AppendLine(content.Key + DictionarySeparator + content.Value);
            }

            Append(path, builder.ToString());
        }

        public static void AppendBinary(string path, byte[] contents)
        {
            using var stream = new FileStream(path, FileMode.Append);
            stream.Write(contents, 0, contents.Length);
        }
        #endregion

        #region Copy
        public static void CopyDirectory(string sourcePath, string destPath)
        {
            foreach (var dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destPath));
            }

            foreach (var newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                SystemFile.Copy(newPath, newPath.Replace(sourcePath, destPath), true);
            }
        }
        #endregion
    }
}
