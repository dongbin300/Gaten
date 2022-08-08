using System.Text;

using Path = Gaten.Net.GameRule.GITADORA.Path;

namespace Gaten.GameTool.GITADORA.Dtx2Fumen
{
    public class Program
    {
        private static List<Path> paths;
        private static string fumenNumber;

        private static void Main(string[] args)
        {
            Console.Write("변환할 채보 번호: ");
            fumenNumber = Console.ReadLine();

            ParseDiff("bsc.dtx", "db");
            ParseDiff("adv.dtx", "da");
            ParseDiff("ext.dtx", "de");
            ParseDiff("mstr.dtx", "dm");
        }

        public static void ParseDiff(string fileName, string mod)
        {
            if (File.Exists(fileName))
            {
                using FileStream stream = new(fileName, FileMode.Open);
                using StreamReader reader = new(stream, Encoding.Default);
                List<string> data = new();
                while (reader.Peek() >= 0)
                {
                    data.Add(reader.ReadLine());
                }

                FumenParse fp = new(data);
                paths = fp.Parse();

                WriteTextFile(paths, $"{fumenNumber}{mod}.txt");
                Console.WriteLine($"{fileName} => {fumenNumber}{mod}.txt 변환 완료");
            }
        }

        public static void WriteTextFile(List<Path> paths, string fileName)
        {
            using FileStream stream = new(fileName, FileMode.Create);
            using StreamWriter writer = new(stream, Encoding.UTF8);
            writer.WriteLine($"CFG,{480},{(int)paths.Max(p => p.timing) + 100}");
            foreach (Path path in paths)
            {
                switch (path.type)
                {
                    case Path.Type.BigPhrase:
                        writer.WriteLine($"BP,{path.lineNum},{path.timing}");
                        break;
                    case Path.Type.SmallPhrase:
                        writer.WriteLine($"SP,{path.lineNum},{path.timing}");
                        break;
                    case Path.Type.Note:
                        if (path.holdLength != 0) // 홀드노트
                        {
                            writer.WriteLine($"NO,{path.lineNum},{path.timing},{path.noteNum},{path.holdLength}");
                        }
                        else
                        {
                            writer.WriteLine($"NO,{path.lineNum},{path.timing},{path.noteNum}");
                        }

                        break;
                }
            }
            writer.Flush();
        }
    }
}
