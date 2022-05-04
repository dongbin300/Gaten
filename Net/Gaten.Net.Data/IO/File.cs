using System.Text;

using SystemFile = System.IO.File;

namespace Gaten.Net.Data.IO
{
    public class File
    {
        //public static string ArraySeparator { get; set; } = "\r\n";
        public static string DictionarySeparator { get; set; } = ":";
        public static Encoding Encoding { get; set;} = Encoding.UTF8;


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
    }
}
