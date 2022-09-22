using Binance.Net.Enums;

using Gaten.Net.Stock.Charts;
using Gaten.Stock.ChartManager.Indicators;
using Gaten.Stock.ChartManager.Utils;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.ChartManager.Charts
{
    /// <summary>
    /// 심볼 하나의 모든 차트 정보
    /// </summary>
    internal class ChartPack
    {
        private readonly KlineInterval interval = KlineInterval.OneMinute;
        public IList<ChartInfo> Charts { get; set; } = new List<ChartInfo>();
        public string Symbol => Charts.First().Symbol;
        public DateTime StartTime => Charts.Min(x => x.DateTime);
        public DateTime EndTime => Charts.Max(x => x.DateTime);
        public ChartInfo? CurrentChart;

        public ChartPack(KlineInterval interval)
        {
            this.interval = interval;
            CurrentChart = null;
        }

        public void AddChart(ChartInfo chart)
        {
            Charts.Add(chart);
        }

        public void ConvertCandle()
        {
            if (interval == KlineInterval.OneMinute)
            {
                return;
            }

            var newCandles = new List<Candle>();

            int unitCount = interval switch
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

            for (int i = 0; i < Charts.Count; i += unitCount)
            {
                var targets = Charts.Skip(i).Take(unitCount).Select(x => x.Candle).ToList();

                newCandles.Add(new Candle(
                    targets[0].Time,
                    targets[0].Open,
                    targets.Max(t => t.High),
                    targets.Min(t => t.Low),
                    targets[^1].Close,
                    targets.Sum(t => t.Volume)
                    ));
            }

            var newChart = newCandles.Select(candle => new ChartInfo(Symbol, candle)).ToList();
            Charts = newChart;
        }

        public void CalculateIndicators()
        {
            var quotes = Charts.Select(x => x.Candle.ToQuote());
            var sma = quotes.GetSma(112).ToList();
            var ema = quotes.GetEma(112).ToList();
            var rsi = quotes.GetRsi(14).ToList();
            var macd = quotes.GetMacd(12,26,9).ToList();
            var bb1 = quotes.GetBollingerBands(20,3).ToList();
            var bb2 = quotes.GetBollingerBands(20,0.5).ToList();
            var ri = quotes.GetRi(14).ToList();

            for (int i = 0; i < Charts.Count; i++)
            {
                var chart = Charts[i];
                chart.MA = sma[i];
                chart.EMA = ema[i];
                chart.RSI = rsi[i];
                chart.MACD = macd[i];
                chart.BollingerBands = bb1[i];
                chart.BollingerBands2 = bb2[i];
                chart.RI = ri[i];
            }
        }

        public ChartInfo Select()
        {
            return CurrentChart = GetChart(StartTime);
        }

        public ChartInfo Select(DateTime time)
        {
            return CurrentChart = GetChart(time);
        }

        public ChartInfo Next() => 
            CurrentChart == null ?
            CurrentChart = default! :
            CurrentChart = GetChart(interval switch
                {
                    KlineInterval.OneMinute => CurrentChart.DateTime.AddMinutes(1),
                    KlineInterval.ThreeMinutes => CurrentChart.DateTime.AddMinutes(3),
                    KlineInterval.FiveMinutes => CurrentChart.DateTime.AddMinutes(5),
                    KlineInterval.FifteenMinutes => CurrentChart.DateTime.AddMinutes(15),
                    KlineInterval.ThirtyMinutes => CurrentChart.DateTime.AddMinutes(30),
                    KlineInterval.OneHour => CurrentChart.DateTime.AddHours(1),
                    KlineInterval.TwoHour => CurrentChart.DateTime.AddHours(2),
                    KlineInterval.FourHour => CurrentChart.DateTime.AddHours(4),
                    KlineInterval.SixHour => CurrentChart.DateTime.AddHours(6),
                    KlineInterval.EightHour => CurrentChart.DateTime.AddHours(8),
                    KlineInterval.TwelveHour => CurrentChart.DateTime.AddHours(12),
                    KlineInterval.OneDay => CurrentChart.DateTime.AddDays(1),
                    _ => CurrentChart.DateTime.AddMinutes(1)
                });

        public ChartInfo GetChart(DateTime dateTime) => Charts.First(x => x.DateTime.Equals(dateTime));
    }
}
