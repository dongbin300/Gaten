using Gaten.Stock.MarinerX.Apis;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MarinerX.Markets
{
    public class BinanceMarket
    {
        public static List<SymbolBenchmark> Benchmarks = new();

        public static void Init()
        {
            #region Symbol Benchmark Calculate
            var volatilityResult = new Dictionary<string, decimal>();
            var data = LocalStorageApi.GetAllOneDayQuotes();

            foreach (var d in data)
            {
                var list = d.Value.Select(x => Math.Round((x.High - x.Low) / x.Low * 100, 2)).ToList();
                volatilityResult.Add(d.Key, Math.Round(list.Average(), 4));
            }

            var maxLeverages = BinanceClientApi.GetMaxLeverages();
            var symbolMarketCap = BinanceHttpApi.GetSymbolMarketCap();
            if (symbolMarketCap == null)
            {
                return;
            }

            foreach (var marketCap in symbolMarketCap)
            {
                var key = volatilityResult.Where(x => x.Key.Equals(marketCap.Symbol));
                var leverageKey = maxLeverages.Where(x => x.Key.Equals(marketCap.Symbol));
                if (key.Any())
                {
                    var maxLeverage = leverageKey.Any() ? leverageKey.First().Value : 0;
                    Benchmarks.Add(new SymbolBenchmark(marketCap.Symbol, key.First().Value, marketCap.marketCapWon, maxLeverage));
                }
            }
            #endregion
        }
    }
}
