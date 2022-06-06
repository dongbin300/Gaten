using Binance.Net.Enums;

using Gaten.Stock.MockTrader.Api;
using Gaten.Stock.MockTrader.Utils;

using Skender.Stock.Indicators;

namespace Gaten.Stock.MockTrader.Chart
{
    internal class BtcusdtChartManager
    {
        public static List<ChartInfo>? Charts { get; set; }
        public static ChartInfo? GetChart(DateTime date) => Charts?.Find(c => c.Date.Equals(date));

        public static void Init(KlineInterval candleInterval)
        {
            Charts = new List<ChartInfo>();

            var symbol = "BTCUSDT";
            var baseDate = new DateTime(2020, 1, 1);

            try
            {
                for (int i = 0; i < 730; i++)
                {
                    DateTime startTime = baseDate.AddDays(i);
                    var candles = LocalStorageApi.GetCandlesForOneDay(symbol, candleInterval, startTime);
                    var quotes = candles.ToQuotes();

                    Charts.Add(new ChartInfo
                    {
                        Symbol = symbol,
                        Date = startTime,
                        Candles = candles,
                        MA = quotes.GetSma(112).ToList(),
                        EMA = quotes.GetEma(112).ToList(),
                        RSI = quotes.GetRsi(14).ToList(),
                        MACD = quotes.GetMacd(12, 26, 9).ToList(),
                        BollingerBands = quotes.GetBollingerBands(20, 3).ToList(),
                        BollingerBands2 = quotes.GetBollingerBands(20, 0.5).ToList()
                    });
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

    }
}
