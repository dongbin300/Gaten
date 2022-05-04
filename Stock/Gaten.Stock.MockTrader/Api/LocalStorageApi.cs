using Binance.Net.Enums;

using Gaten.Stock.MockTrader.Chart;

namespace Gaten.Stock.MockTrader.Api
{
    internal class LocalStorageApi
    {
        static string BasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BinanceFuturesData");

        public static void Init()
        {

        }

        public static List<string> GetSymbols()
        {
            var symbolFile = new DirectoryInfo(BasePath).GetFiles("symbol_*.txt").FirstOrDefault();
            return File.ReadAllLines(symbolFile.FullName).ToList();
        }

        public static List<Candle> GetCandlesForOneDay(string symbol, KlineInterval candleInterval, DateTime startTime)
        {
            try
            {
                var data = File.ReadAllLines(Path.Combine(BasePath, symbol, $"{symbol}_{startTime:yyyy-MM-dd}.csv"));

                List<Candle> candles = new List<Candle>();

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
                    return ConvertTo(candles, candleInterval);
                }

                return candles;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public static List<Candle> ConvertTo(List<Candle> candles, KlineInterval candleInterval)
        {
            List<Candle> newCandles = new List<Candle>();

            int unitCount = candleInterval switch
            {
                KlineInterval.OneMinute => 1,
                KlineInterval.ThreeMinutes => 3,
                KlineInterval.FiveMinutes => 5,
                KlineInterval.FifteenMinutes => 15,
                KlineInterval.ThirtyMinutes => 30,
                KlineInterval.OneHour => 60,
                KlineInterval.TwoHour => 120,
                KlineInterval.FourHour => 240,
                KlineInterval.SixHour => 360,
                KlineInterval.EightHour => 480,
                KlineInterval.TwelveHour => 720,
                KlineInterval.OneDay => 1440,
                _ => 1
            };

            for (int i = 0; i < candles.Count; i += unitCount)
            {
                var targets = candles.Skip(i).Take(unitCount).ToList();

                newCandles.Add(new Candle(
                    targets[0].Time,
                    targets[0].Open,
                    targets.Max(t => t.High),
                    targets.Min(t => t.Low),
                    targets[^1].Close,
                    targets.Sum(t => t.Volume)
                    ));
            }

            return newCandles;
        }
    }
}
