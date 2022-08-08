using Gaten.Stock.ChartManager.Charts;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.ChartManager.Utils
{
    internal static class Extensions
    {
        public static List<Quote> ToQuotes(this List<Candle> candles) => candles.Select(x => new Quote()
        {
            Date = x.Time,
            Open = Convert.ToDecimal(x.Open),
            High = Convert.ToDecimal(x.High),
            Low = Convert.ToDecimal(x.Low),
            Close = Convert.ToDecimal(x.Close),
            Volume = Convert.ToDecimal(x.Volume)
        }).ToList();
    }
}
