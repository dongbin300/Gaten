using Binance.Net.Enums;

using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Stock.MarinerX.Charts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MarinerX.Indicators
{
    internal class IndicatorHistogram
    {
        public static void GetRiHistogram(string symbol, KlineInterval interval)
        {
            var pack = ChartLoader.GetChartPack(symbol, interval);

            if (pack == null)
            {
                TrayMenu.LoadChartDataEvent(null, new EventArgs(), symbol, interval, true);
                pack = ChartLoader.GetChartPack(symbol, interval);
            }

            pack.CalculateIndicators(new List<ChartElement>
            {
                new ChartElement("ri")
            }, new List<NamedElement>());

            var histogram = pack.Charts
                .GroupBy(x => Math.Round((x.GetChartElementResult(Net.Stock.MercuryTradingModel.Enums.ChartElementType.ri) ?? default!).Value ?? default!, 0))
                .Select(x => new { ri = x.Key, c = x.Count() })
                .OrderBy(x => x.ri)
                .ToList();

            List<(decimal, int, int, double)> results = new List<(decimal, int, int, double)>();
            foreach(var item in histogram)
            {
                (decimal, int, int, double) result;
                var filter = histogram.Where(x => x.ri <= item.ri);
                result.Item1 = item.ri;
                result.Item2 = item.c;
                result.Item3 = filter.Sum(x => x.c);
                result.Item4 = (double)result.Item3 / pack.Charts.Count;
                results.Add(result);
            }
        }

        public static void GetRsiHistogram(string symbol, KlineInterval interval)
        {
            //var pack = ChartLoader.GetChartPack(symbol, interval);
            //var histogram = pack.Charts.Where(x=>x.RSI.Rsi != null).GroupBy(x => Math.Round(x.RSI.Rsi.Value, 2)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x => x.ri).ToList();
            //var histogram2 = pack.Charts.Where(x => x.RSI.Rsi != null).GroupBy(x => Math.Round(x.RSI.Rsi.Value, 1)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x => x.ri).ToList();
            //var histogram3 = pack.Charts.Where(x => x.RSI.Rsi != null).GroupBy(x => Math.Round(x.RSI.Rsi.Value, 0)).Select(x => new { ri = x.Key, c = x.Count() }).OrderBy(x => x.ri).ToList();
        }
    }
}
