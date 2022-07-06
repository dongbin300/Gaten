namespace Gaten.Net.Data.IO
{
    public class GPath
    {
        public static string Windows => Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        public static string Desktop => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string AppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string Fonts => Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
        public static string ProgramFiles => Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        public static string ProgramFilesX86 => Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        public static string System => Environment.GetFolderPath(Environment.SpecialFolder.System);
        public static string SystemX86 => Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
    }
}
