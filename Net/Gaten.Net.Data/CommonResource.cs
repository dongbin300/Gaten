namespace Gaten.Net.Data
{
    public class CommonResource
    {
        public static string BaseFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Gaten");
        public static string MySqlInfoFilePath => Path.Combine(BaseFilePath, "mysql_info.msq");
        public static string MintChocoDirectoryPath => Path.Combine(BaseFilePath, "MintChoco");
        public static string BinanceApiFilePath => Path.Combine(BaseFilePath, "binance_api.txt");

    }
}
