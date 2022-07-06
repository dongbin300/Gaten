using System;
using System.IO;

namespace Gaten.Stock.MoqTrader.Utils
{
    internal class PathUtil
    {
        public static string BinanceFuturesDataBasePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "BinanceFuturesData");
    }
}
