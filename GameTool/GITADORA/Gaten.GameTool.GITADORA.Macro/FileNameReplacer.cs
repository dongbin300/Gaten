namespace Gaten.GameTool.GITADORA.Macro
{
    internal class FileNameReplacer
    {
        public FileNameReplacer()
        {
            Console.Write("바꿀 문자열 검색(이전): ");
            string target = Console.ReadLine();

            FileInfo[] fi = new DirectoryInfo("디렉토리").GetFiles($"*{target}*.*", SearchOption.TopDirectoryOnly);
            Console.WriteLine("찾은 파일 개수: " + fi.Length);
            foreach (FileInfo f in fi)
            {
                Console.WriteLine(f.Name);
            }

            Console.Write("문자열 변경(이후): ");
            string modify = Console.ReadLine();

            foreach (FileInfo f in fi)
            {
                string newFileName = f.FullName.Replace(target, modify);
                f.MoveTo(newFileName);
            }
        }
    }
}
