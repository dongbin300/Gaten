namespace Gaten.Stock.MockTrader.Utils
{
    internal class PathUtil
    {
        public static string BinanceFuturesDataBasePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "BinanceFuturesData");


    }
}
