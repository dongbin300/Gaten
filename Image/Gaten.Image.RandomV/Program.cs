using System.Diagnostics;

namespace Gaten.Image.RandomV
{
    class Program
    {
        static List<FileInfo> files = new List<FileInfo>();

        static void Main()
        {
            try
            {
                DirFileSearch(".\\");

                Console.Write("Count? ");
                int count = int.Parse(Console.ReadLine());

                Random r = new();
                for (int i = 0; i < count; i++)
                {
                    int num = r.Next(files.Count);

                    var fileFullName = files[num].FullName;
                    var fileDirectoryName = files[num].DirectoryName;
                    var fileName = files[num].Name;

                    File.AppendAllText("log.txt", fileFullName + "\n");

                    ProcessStartInfo startInfo = new()
                    {
                        FileName = "cmd.exe",
                        CreateNoWindow = true,
                        Arguments = "/c start " + fileDirectoryName + "\\\"" + fileName + "\""
                    };
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", ex.Message);
            }
            DirFileSearch(".\\");
        }

        static void DirFileSearch(string cDir)
        {
            try
            {
                files.AddRange(
                        new DirectoryInfo(cDir).GetFiles("*.*", SearchOption.AllDirectories)
                        .Where(s => s.Name.EndsWith(".avi") || s.Name.EndsWith(".mp4") || s.Name.EndsWith(".flv")).ToList()
                        );
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", ex.Message);
            }
        }
    }
}
