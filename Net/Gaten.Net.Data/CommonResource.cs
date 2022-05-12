namespace Gaten.Net.Data
{
    public class CommonResource
    {
        /// <summary>
        /// C:\Users\Gaten\AppData\Roaming\Gaten
        /// </summary>
        public static string BaseFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Gaten");
        public static string MintChocoDirectoryPath => Path.Combine(BaseFilePath, "MintChoco");
        public static string[] MySqlInfoText => GetTextLines("mysql_info.msq");
        public static string[] BinanceApiKeyText => GetTextLines("binance_api.txt");

        public static string GetPath(string subPath) => Path.Combine(BaseFilePath, subPath);
        public static string GetText(string subPath) => File.ReadAllText(Path.Combine(BaseFilePath, subPath));
        public static string[] GetTextLines(string subPath) => File.ReadAllLines(Path.Combine(BaseFilePath, subPath));
        public static Dictionary<string, string> GetTextDictionary(string subPath) => IO.File.ReadToDictionary(Path.Combine(BaseFilePath, subPath));

        public static void SetText(string subPath, string text) => File.WriteAllText(Path.Combine(BaseFilePath, subPath), text);
        public static void SetTextLines(string subPath, string[] text) => File.WriteAllLines(Path.Combine(BaseFilePath, subPath), text);
        public static void SetTextDictionary(string subPath, Dictionary<string, string> text) => IO.File.WriteByDictionary(Path.Combine(BaseFilePath, subPath), text);
    }
}
