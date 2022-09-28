using Binance.Net.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Intervals
{
    public static class IntervalExtension
    {
        public static KlineInterval ToKlineInterval(this string intervalString) => intervalString switch
        {
            "1m" => KlineInterval.OneMinute,
            "3m" => KlineInterval.ThreeMinutes,
            "5m" => KlineInterval.FiveMinutes,
            "15m" => KlineInterval.FifteenMinutes,
            "30m" => KlineInterval.ThirtyMinutes,
            "1H" => KlineInterval.OneHour,
            "2H" => KlineInterval.TwoHour,
            "4H" => KlineInterval.FourHour,
            "6H" => KlineInterval.SixHour,
            "8H" => KlineInterval.EightHour,
            "12H" => KlineInterval.TwelveHour,
            "1D" => KlineInterval.OneDay,
            "3D" => KlineInterval.ThreeDay,
            "1W" => KlineInterval.OneWeek,
            "1M" => KlineInterval.OneMonth,
            _ => KlineInterval.OneMinute
        };

        /// <summary>
        /// To Binance interval display string.
        /// default return value is "1m"
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static string ToIntervalString(this KlineInterval interval) => interval switch
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
            KlineInterval.ThreeDay => "3D",
            KlineInterval.OneWeek => "1W",
            KlineInterval.OneMonth => "1M",
            _ => "1m"
        };

        public static TimeSpan ToTimeSpan(this KlineInterval interval) => interval switch
        {
            KlineInterval.OneMinute => new TimeSpan(0, 0, 1, 0),
            KlineInterval.ThreeMinutes => new TimeSpan(0, 0, 3, 0),
            KlineInterval.FiveMinutes => new TimeSpan(0, 0, 5, 0),
            KlineInterval.FifteenMinutes => new TimeSpan(0, 0, 15, 0),
            KlineInterval.ThirtyMinutes => new TimeSpan(0, 0, 30, 0),
            KlineInterval.OneHour => new TimeSpan(0, 1, 0, 0),
            KlineInterval.TwoHour => new TimeSpan(0, 2, 0, 0),
            KlineInterval.FourHour => new TimeSpan(0, 4, 0, 0),
            KlineInterval.SixHour => new TimeSpan(0, 6, 0, 0),
            KlineInterval.EightHour => new TimeSpan(0, 8, 0, 0),
            KlineInterval.TwelveHour => new TimeSpan(0, 12, 0, 0),
            KlineInterval.OneDay => new TimeSpan(1, 0, 0, 0),
            KlineInterval.ThreeDay => new TimeSpan(3, 0, 0, 0),
            KlineInterval.OneWeek => new TimeSpan(7, 0, 0, 0),
            KlineInterval.OneMonth => new TimeSpan(30, 0, 0, 0),
            _ => new TimeSpan(0, 0, 1, 0)
        };
    }
}
