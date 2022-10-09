using Binance.Net.Enums;

using Gaten.Stock.MarinerX.Charts;

using System;
using System.Linq;

namespace Gaten.Stock.MarinerX.Indicators
{
    internal class IndicatorHistogram
    {
        public static void GetRiHistogram(string symbol, KlineInterval interval)
        {
            var pack = ChartLoader.GetChartPack(symbol, interval);
            var histogram = pack.Charts.GroupBy(x => Math.Round(x.RI.Ri, 2)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x=>x.ri).ToList();
            var histogram2 = pack.Charts.GroupBy(x => Math.Round(x.RI.Ri, 1)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x => x.ri).ToList();
            var histogram3 = pack.Charts.GroupBy(x => Math.Round(x.RI.Ri, 0)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x => x.ri).ToList();
        }

        public static void GetRsiHistogram(string symbol, KlineInterval interval)
        {
            var pack = ChartLoader.GetChartPack(symbol, interval);
            var histogram = pack.Charts.Where(x=>x.RSI.Rsi != null).GroupBy(x => Math.Round(x.RSI.Rsi.Value, 2)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x => x.ri).ToList();
            var histogram2 = pack.Charts.Where(x => x.RSI.Rsi != null).GroupBy(x => Math.Round(x.RSI.Rsi.Value, 1)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x => x.ri).ToList();
            var histogram3 = pack.Charts.Where(x => x.RSI.Rsi != null).GroupBy(x => Math.Round(x.RSI.Rsi.Value, 0)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x => x.ri).ToList();
        }
    }
}
