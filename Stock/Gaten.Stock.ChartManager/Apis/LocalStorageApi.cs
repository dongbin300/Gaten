using Binance.Net.Enums;

using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Net.Stock.Charts;
using Gaten.Stock.ChartManager.Markets;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gaten.Stock.ChartManager.Apis
{
    internal class LocalStorageApi
    {
        #region Initialize
        public static void Init()
        {

        }
        #endregion

        #region Market API
        public static List<string> GetSymbolNames()
        {
            var symbolFile = new DirectoryInfo(GResource.BinanceFuturesDataPath).GetFiles("symbol_*.txt").FirstOrDefault() ?? default!;
            return File.ReadAllLines(symbolFile.FullName).ToList();
        }

        public static List<FuturesSymbol> GetSymbols()
        {
            var symbolFile = new DirectoryInfo(GResource.BinanceFuturesDataPath).GetFiles("symbol_detail_*.csv").FirstOrDefault() ?? default!;
            var data = File.ReadAllLines(symbolFile.FullName);

            var symbols = new List<FuturesSymbol>();
            for (int i = 1; i < data.Length; i++)
            {
                var item = data[i];
                var d = item.Split(',');
                symbols.Add(new FuturesSymbol(d[0], d[1].Convert<decimal>(), d[2].Convert<DateTime>(), d[3].Convert<decimal>(), d[4].Convert<decimal>(), d[5].Convert<decimal>(), d[6].Convert<decimal>(), d[7].Convert<decimal>(), d[8].Convert<decimal>(), d[9].Convert<int>(), d[10].Convert<int>(), d[11].Convert<UnderlyingType>()));
            }

            return symbols;
        }
        #endregion

        #region Chart API
        public static List<Candle> GetCandlesForOneDay(string symbol, DateTime startTime)
        {
            try
            {
                var data = File.ReadAllLines(GResource.BinanceFuturesDataPath.Down("1m", symbol, $"{symbol}_{startTime:yyyy-MM-dd}.csv"));

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

                return candles;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }
        #endregion

        #region Account API

        #endregion
    }
}
