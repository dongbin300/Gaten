using Binance.Net.Enums;

using Gaten.Stock.MoqTrader.Utils;
using Gaten.Stock.MoqTrader.Apis;

using Skender.Stock.Indicators;

using System;
using System.IO;
using System.Linq;

namespace Gaten.Stock.MoqTrader.Charts
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
                var candles = LocalStorageApi.GetCandlesForOneDay(symbol, candleInterval, startTime);
                var quotes = candles.ToQuotes();

                return new ChartInfo
                (
                   symbol,
                   startTime,
                   candles,
                   quotes.GetSma(112).ToList(),
                   quotes.GetEma(112).ToList(),
                   quotes.GetRsi(14).ToList(),
                   quotes.GetMacd(12, 26, 9).ToList(),
                   quotes.GetBollingerBands(20, 3).ToList(),
                   quotes.GetBollingerBands(20, 0.5).ToList()
                );
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }
    }
}
