using Binance.Net.Enums;

using Gaten.Stock.MockTrader.Api;
using Gaten.Stock.MockTrader.Utils;

using Skender.Stock.Indicators;

namespace Gaten.Stock.MockTrader.Chart
{
    internal class ChartManager
    {
        public static void Init()
        {

        }

        /// <summary>
        /// 차트 분석
        /// 이 부분은 지속적으로 수정될 수 있음
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static ChartInfo AnalyzeChart(string symbol, DateTime startTime, KlineInterval candleInterval)
        {
            try
            {
                /* Candle */
                //var candles = BinanceClientApi.GetCandles(symbol, KlineInterval.OneMinute,
                //    startTime,
                //    startTime.AddDays(1),
                //    1500);

                var candles = LocalStorageApi.GetCandlesForOneDay(symbol, candleInterval, startTime);
                var quotes = candles.ToQuotes();

                return new ChartInfo
                {
                    Symbol = symbol,
                    Candles = candles,
                    MA = quotes.GetSma(112),
                    EMA = quotes.GetEma(112),
                    RSI = quotes.GetRsi(14),
                    MACD = quotes.GetMacd(12, 26, 9),
                    BollingerBands = quotes.GetBollingerBands(20, 3),
                    BollingerBands2 = quotes.GetBollingerBands(20, 0.5)
                };
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }
    }
}
