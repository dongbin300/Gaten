using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gaten.Data.FileManager
{
    public class Util
    {
        public static List<Node> SearchFiles(Node node, string keyword)
        {
            return NodeManager.Nodes.Where(n => n.FullPath.Contains(node.FullPath))
                .Where(n => n.FullPath.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }

        public static List<Node> SearchStrings(Node node, string keyword)
        {
            return NodeManager.Nodes.Where(n => n.FullPath.Contains(node.FullPath))
                 .Where(n => SupportsExtension(n.FullPath))
                 .Where(n => ExistsStringInTextFile(n.FullPath, keyword))
                 .ToList();
        }

        public static bool SupportsExtension(string name)
        {
            string[] extensions =
            {
                ".txt",
                ".c",
                ".cpp",
                ".cs",
                ".xaml"
                //".docx",
                //".hwp",
                //".pdf",
                //".cell",
                //".xlsx"
            };

            return extensions.Count(e => name.EndsWith(e)) > 0;
        }

        public static bool ExistsStringInTextFile(string path, string keyword)
        {
            Encoding fileEncoding = GetEncoding2(path);

            string str = File.ReadAllText(path, fileEncoding);

            return str.ToLower().Contains(keyword.ToLower());
        }

        public static Encoding GetEncoding(string filename)
        {
            byte[]? bom = new byte[4];
            using (FileStream? file = new(filename, FileMode.Open, FileAccess.Read))
            {
                _ = file.Read(bom, 0, 4);
            }

            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
            {
                return Encoding.UTF8;
            }

            if (bom[0] == 0xff && bom[1] == 0xfe)
            {
                return Encoding.Unicode; //UTF-16LE
            }

            if (bom[0] == 0xfe && bom[1] == 0xff)
            {
                return Encoding.BigEndianUnicode; //UTF-16BE
            }

            return bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff ? Encoding.UTF32 : Encoding.Default;
        }

        public static Encoding GetEncoding2(string filename)
        {
            using StreamReader? reader = new(filename, Encoding.Default, true);
            if (reader.Peek() >= 0)
            {
                _ = reader.Read();
            }

            return reader.CurrentEncoding;
        }
    }
}
