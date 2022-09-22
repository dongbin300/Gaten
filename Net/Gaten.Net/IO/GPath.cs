namespace Gaten.Net.IO
{
    public static class GPath
    {
        public static string Windows => Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        public static string Desktop => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string AppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string Fonts => Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
        public static string ProgramFiles => Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        public static string ProgramFilesX86 => Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        public static string System => Environment.GetFolderPath(Environment.SpecialFolder.System);
        public static string SystemX86 => Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
        public static string Down(this string path, params string[] downPaths)
        {
            return Path.Combine(path, Path.Combine(downPaths));
        }

        public static void TryCreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
