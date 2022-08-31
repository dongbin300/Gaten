using System.Data;
using System.Text;

using SystemFile = System.IO.File;

namespace Gaten.Net.IO
{
    public class GFile
    {
        //public static string ArraySeparator { get; set; } = "\r\n";
        public static string DictionarySeparator { get; set; } = ":";
        public static Encoding Encoding { get; set;} = Encoding.UTF8;

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

        public static string Read(string path)
        {
            return SystemFile.ReadAllText(path, Encoding);
        }

        public static string[] ReadToArray(string path)
        {
            return Read(path).Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
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
            var rows = items[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach(var row in rows)
            {
                result.Columns.Add(row, typeof(string));
            }
            for(int i = 1; i < items.Length; i++)
            {
                var data = items[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                result.Rows.Add(data);
            }
            return result;
        }

        public static void Write(string path, string contents)
        {
            SystemFile.WriteAllText(path, contents, Encoding);
        }

        public static void WriteByArray(string path, IList<string> contents)
        {
            StringBuilder builder = new();

            foreach (var content in contents)
            {
                builder.AppendLine(content);
            }

            Write(path, builder.ToString());
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
            StringBuilder builder = new();

            foreach (var content in contents)
            {
                builder.AppendLine(content);
            }

            Append(path, builder.ToString());
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
    }
}
