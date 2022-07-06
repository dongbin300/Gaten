namespace Gaten.Net.Data.IO
{
    public class GResource
    {
        /// <summary>
        /// C:\Users\Gaten\AppData\Roaming\Gaten
        /// </summary>
        public static string BaseFilePath => Path.Combine(GPath.AppData, "Gaten");
        public static string MintChocoDirectoryPath => Path.Combine(BaseFilePath, "MintChoco");
        public static string DotNetDirectoryPath => Path.Combine(BaseFilePath, "dotnet");
        public static string[] MySqlInfoText => GetTextLines("mysql_info.msq");
        public static string[] BinanceApiKeyText => GetTextLines("binance_api.txt");
        public static string SolutionPath => Environment.CurrentDirectory;

        public static string GetPath(string subPath) => Path.Combine(BaseFilePath, subPath);
        public static string GetText(string subPath) => File.ReadAllText(Path.Combine(BaseFilePath, subPath));
        public static string[] GetTextLines(string subPath) => File.ReadAllLines(Path.Combine(BaseFilePath, subPath));
        public static Dictionary<string, string> GetTextDictionary(string subPath) => GFile.ReadToDictionary(Path.Combine(BaseFilePath, subPath));

        public static void SetText(string subPath, string text) => File.WriteAllText(Path.Combine(BaseFilePath, subPath), text);
        public static void SetTextLines(string subPath, string[] text) => File.WriteAllLines(Path.Combine(BaseFilePath, subPath), text);
        public static void SetTextDictionary(string subPath, Dictionary<string, string> text) => GFile.WriteByDictionary(Path.Combine(BaseFilePath, subPath), text);

        public static void AppendText(string subPath, string text) => File.AppendAllText(Path.Combine(BaseFilePath, subPath), text);
        public static void AppendTextLines(string subPath, string[] text) => File.AppendAllLines(Path.Combine(BaseFilePath, subPath), text);
        public static void AppendTextDictionary(string subPath, Dictionary<string, string> text) => GFile.AppendByDictionary(Path.Combine(BaseFilePath, subPath), text);

        public static string SmartExePath(string keyword)
        {
            var MainPath = SolutionPath.Substring(0, SolutionPath.IndexOf("\\Gaten\\") + 6);
            var files = new DirectoryInfo(MainPath).GetFiles($"*{keyword}*.exe", SearchOption.AllDirectories);

            return files.Length > 0 ? files[0].FullName : string.Empty;
        }
    }
}
