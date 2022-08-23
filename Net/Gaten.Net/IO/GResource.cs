using Gaten.Net.Extensions;

namespace Gaten.Net.IO
{
    public class GResource
    {
        /// <summary>
        /// C:\Users\Gaten\AppData\Roaming\Gaten
        /// </summary>
        public static string BaseFilePath => GPath.AppData.Down("Gaten");
        public static string MintChocoDirectoryPath => BaseFilePath.Down("MintChoco");
        public static string DotNetDirectoryPath => BaseFilePath.Down("dotnet");
        public static string[] MySqlInfoText => GetTextLines("mysql_info.msq");
        public static string[] BinanceApiKeyText => GetTextLines("binance_api.txt");
        public static string BinanceFuturesDataPath => BaseFilePath.Down("BinanceFuturesData");
        public static string SolutionPath => Environment.CurrentDirectory;

        public static string GetPath(string subPath) => BaseFilePath.Down(subPath);
        public static string GetText(string subPath) => File.ReadAllText(BaseFilePath.Down(subPath));
        public static string[] GetTextLines(string subPath) => File.ReadAllLines(BaseFilePath.Down(subPath));
        public static Dictionary<string, string> GetTextDictionary(string subPath) => GFile.ReadToDictionary(BaseFilePath.Down(subPath));

        public static void SetText(string subPath, string text) => File.WriteAllText(BaseFilePath.Down(subPath), text);
        public static void SetTextLines(string subPath, string[] text) => File.WriteAllLines(BaseFilePath.Down(subPath), text);
        public static void SetTextDictionary(string subPath, Dictionary<string, string> text) => GFile.WriteByDictionary(BaseFilePath.Down(subPath), text);

        public static void AppendText(string subPath, string text) => File.AppendAllText(BaseFilePath.Down(subPath), text);
        public static void AppendTextLines(string subPath, string[] text) => File.AppendAllLines(BaseFilePath.Down(subPath), text);
        public static void AppendTextDictionary(string subPath, Dictionary<string, string> text) => GFile.AppendByDictionary(BaseFilePath.Down(subPath), text);

        public static string SmartExePath(string keyword)
        {
            var mainPath = SolutionPath[..(SolutionPath.IndexOf("\\Gaten\\") + 6)];
            var files = new DirectoryInfo(mainPath).GetFiles($"*{keyword}*.exe", SearchOption.AllDirectories);

            return files.Length > 0 ? files[0].FullName : string.Empty;
        }

        public static string SmartExePath(string keyword, string mainPath)
        {
            var files = new DirectoryInfo(mainPath).GetFiles($"*{keyword}*.exe", SearchOption.AllDirectories);

            return files.Length > 0 ? files[0].FullName : string.Empty;
        }

        public static string SmartInstallerPath(string keyword, string mainPath)
        {
            var info = new DirectoryInfo(mainPath);
            var files = info.GetFiles($"*{keyword}*.exe", SearchOption.AllDirectories).Union(
                info.GetFiles($"*{keyword}*.msi", SearchOption.AllDirectories)).ToArray();

            return files.Length > 0 ? files[0].FullName : string.Empty;
        }
    }
}
