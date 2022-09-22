using Binance.Net.Enums;

using Gaten.Net.Stock.Charts;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.ChartManager.Utils
{
    internal static class Extensions
    {
        public static Quote ToQuote(this Candle candle) => new()
        {
            Date = candle.Time,
            Open = Convert.ToDecimal(candle.Open),
            High = Convert.ToDecimal(candle.High),
            Low = Convert.ToDecimal(candle.Low),
            Close = Convert.ToDecimal(candle.Close),
            Volume = Convert.ToDecimal(candle.Volume),
        };

        public static List<Quote> ToQuotes(this List<Candle> candles) => candles.Select(x => new Quote()
        {
            Date = x.Time,
            Open = Convert.ToDecimal(x.Open),
            High = Convert.ToDecimal(x.High),
            Low = Convert.ToDecimal(x.Low),
            Close = Convert.ToDecimal(x.Close),
            Volume = Convert.ToDecimal(x.Volume)
        }).ToList();

        /// <summary>
        /// To Binance interval display string.
        /// default return value is "1m"
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static string ToIntervalString(this KlineInterval interval)
        {
            return interval switch
            {
                KlineInterval.OneMinute => "1m",
                KlineInterval.ThreeMinutes => "3m",
                KlineInterval.FiveMinutes => "5m",
                KlineInterval.FifteenMinutes => "15m",
                KlineInterval.ThirtyMinutes => "30m",
                KlineInterval.OneHour => "1H",
                KlineInterval.TwoHour => "2H",
                KlineInterval.FourHour => "4H",
                KlineInterval.SixHour => "6H",
                KlineInterval.EightHour => "8H",
                KlineInterval.TwelveHour => "12H",
                KlineInterval.OneDay => "1D",
                _ => "1m"
            };
        }
    }
}
