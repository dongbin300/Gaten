using Binance.Net.Enums;

using Gaten.Net.IO;
using Gaten.Net.Extensions;
using Gaten.Stock.ChartManager.Charts;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gaten.Stock.ChartManager.Apis
{
    internal class LocalStorageApi
    {
        public static string BasePath => GPath.Desktop.Down("BinanceFuturesData");

        public static void Init()
        {

        }

        public static List<string> GetSymbols()
        {
            var symbolFile = new DirectoryInfo(BasePath).GetFiles("symbol_*.txt").FirstOrDefault() ?? default!;
            return File.ReadAllLines(symbolFile.FullName).ToList();
        }

        public static List<Candle> GetCandlesForOneDay(string symbol, KlineInterval candleInterval, DateTime startTime)
        {
            try
            {
                var data = File.ReadAllLines(Path.Combine(BasePath, symbol, $"{symbol}_{startTime:yyyy-MM-dd}.csv"));

                var candles = new List<Candle>();

                foreach (var d in data)
                {
                    var e = d.Split(',');
                    candles.Add(new Candle(
                        DateTime.Parse(e[0]),
                        double.Parse(e[1]),
                        double.Parse(e[2]),
                        double.Parse(e[3]),
                        double.Parse(e[4]),
                        double.Parse(e[5])
                        ));
                }

                if (candleInterval != KlineInterval.OneMinute)
                {
                    //return ConvertTo(candles, candleInterval);
                }

                return candles;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        
    }
}
