namespace Gaten.Study.TestConsole
{
    internal class FileNameChanger
    {
        public FileNameChanger()
        {
            Console.WriteLine("파일이름의 문자열을 찾아 바꿉니다. (A->B) ");
            Console.Write("A 문자열 : ");
            string targetString = Console.ReadLine();
            Console.Write("B 문자열 : ");
            string changeString = Console.ReadLine();

            string currentDirectory = System.Environment.CurrentDirectory;
            var files = new DirectoryInfo(currentDirectory).GetFiles();

            foreach (FileInfo fi in files)
            {
                fi.MoveTo(Path.Combine(currentDirectory, fi.Name.Replace(targetString, changeString)));
            }
        }
    }
}
