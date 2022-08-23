using Gaten.Net.IO;

using System;
using System.IO;
using System.Linq;

namespace Gaten.Stock.ChartManager.Utils
{
    internal class SymbolUtil
    {
        public static DateTime GetStartDate(string symbol)
        {
            var fileNames = new DirectoryInfo(GResource.BinanceFuturesDataPath.Down("1m", symbol)).GetFiles("*.csv").OrderBy(x=>x.Name);
            return GetDate(fileNames.First().Name);
        }

        public static DateTime GetEndDate(string symbol)
        {
            var fileNames = new DirectoryInfo(GResource.BinanceFuturesDataPath.Down("1m", symbol)).GetFiles("*.csv").OrderByDescending(x => x.Name);
            return GetDate(fileNames.First().Name);
        }

        public static DateTime GetEndDateOf1D(string symbol)
        {
            var data = GFile.ReadToArray(GResource.BinanceFuturesDataPath.Down("1D", $"{symbol}.csv"));
            return DateTime.Parse(data[^1].Split(',')[0].Split(' ')[0]);
        }

        public static DateTime GetDate(string fileName)
        {
            return DateTime.Parse(fileName.Split('_', '.')[1]);
        }
    }
}
