using Binance.Net.Enums;

using Gaten.Stock.MoqTrader.Apis;
using Gaten.Stock.MoqTrader.Utils;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gaten.Stock.MoqTrader.Charts
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
                    ));
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

    }
}
