using Binance.Net.Enums;

namespace Gaten.Stock.ChartManager.Utils
{
    internal static class Extensions
    {
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
