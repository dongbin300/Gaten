using Binance.Net.Enums;

using CryptoExchange.Net.CommonObjects;

using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Stock.MarinerX.Markets;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gaten.Stock.MarinerX.Apis
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
        public static List<Quote> GetQuotesForOneDay(string symbol, DateTime startTime)
        {
            try
            {
                var data = File.ReadAllLines(GResource.BinanceFuturesDataPath.Down("1m", symbol, $"{symbol}_{startTime:yyyy-MM-dd}.csv"));

                var quotes = new List<Quote>();

                foreach (var d in data)
                {
                    var e = d.Split(',');
                    quotes.Add(new Quote
                    {
                        Date = DateTime.Parse(e[0]),
                        Open = decimal.Parse(e[1]),
                        High = decimal.Parse(e[2]),
                        Low = decimal.Parse(e[3]),
                        Close = decimal.Parse(e[4]),
                        Volume = decimal.Parse(e[5])
                    });
                }

                return quotes;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public static List<Quote> GetOneDayQuotes(string symbol)
        {
            try
            {
                var data = File.ReadAllLines(GResource.BinanceFuturesDataPath.Down("1D", $"{symbol}.csv"));

                var quotes = new List<Quote>();

                foreach (var d in data)
                {
                    var e = d.Split(',');
                    quotes.Add(new Quote
                    {
                        Date = DateTime.Parse(e[0]),
                        Open = decimal.Parse(e[1]),
                        High = decimal.Parse(e[2]),
                        Low = decimal.Parse(e[3]),
                        Close = decimal.Parse(e[4]),
                        Volume = decimal.Parse(e[5])
                    });
                }

                return quotes;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public static Dictionary<string, List<Quote>> GetAllOneDayQuotes()
        {
            try
            {
                var result = new Dictionary<string, List<Quote>>();

                var fileNames = Directory.GetFiles(GResource.BinanceFuturesDataPath.Down("1D"), "*.csv");
                foreach (var fileName in fileNames)
                {
                    string symbol = fileName.GetOnlyFileName();
                    result.Add(symbol, GetOneDayQuotes(symbol));
                }

                return result;
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
