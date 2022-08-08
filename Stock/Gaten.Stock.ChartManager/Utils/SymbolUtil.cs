using Gaten.Net.IO;
using Gaten.Stock.ChartManager.Apis;

using System;
using System.IO;
using System.Linq;

namespace Gaten.Stock.ChartManager.Utils
{
    internal class SymbolUtil
    {
        public static DateTime GetStartDate(string symbol)
        {
            var fileNames = new DirectoryInfo(LocalStorageApi.BasePath.Down(symbol)).GetFiles("*.csv").OrderBy(x=>x.Name);
            return GetDate(fileNames.First().Name);
        }

        public static DateTime GetEndDate(string symbol)
        {
            var fileNames = new DirectoryInfo(LocalStorageApi.BasePath.Down(symbol)).GetFiles("*.csv").OrderByDescending(x => x.Name);
            return GetDate(fileNames.First().Name);
        }

        public static DateTime GetDate(string fileName)
        {
            return DateTime.Parse(fileName.Split('_', '.')[1]);
        }
    }
}
