using Binance.Net.Enums;

using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Indicators;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MarinerX.Charts
{
    /// <summary>
    /// 심볼 하나의 모든 차트 정보
    /// </summary>
    internal class ChartPack
    {
        public string Symbol => Charts.First().Symbol;
        public KlineInterval Interval = KlineInterval.OneMinute;
        public IList<ChartInfo> Charts { get; set; } = new List<ChartInfo>();
        public DateTime StartTime => Charts.Min(x => x.DateTime);
        public DateTime EndTime => Charts.Max(x => x.DateTime);
        public ChartInfo? CurrentChart;

        public ChartPack(KlineInterval interval)
        {
            Interval = interval;
            CurrentChart = null;
        }

        public void AddChart(ChartInfo chart)
        {
            Charts.Add(chart);
        }

        public void ConvertCandle()
        {
            if (Interval == KlineInterval.OneMinute)
            {
                return;
            }

            var newQuotes = new List<Quote>();

            int unitCount = Interval switch
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
                var targets = Charts.Skip(i).Take(unitCount).Select(x => x.Quote).ToList();

                newQuotes.Add(new Quote
                {
                    Date = targets[0].Date,
                    Open = targets[0].Open,
                    High = targets.Max(t => t.High),
                    Low = targets.Min(t => t.Low),
                    Close = targets[^1].Close,
                    Volume = targets.Sum(t => t.Volume)
                });
            }

            var newChart = newQuotes.Select(candle => new ChartInfo(Symbol, candle)).ToList();
            Charts = newChart;
        }

        public void CalculateIndicators()
        {
            var quotes = Charts.Select(x => x.Quote);
            var sma = quotes.GetSma(120).ToList();
            var ema = quotes.GetEma(120).ToList();
            var rsi = quotes.GetRsi(14).ToList();
            var macd = quotes.GetMacd(12, 26, 9).ToList();
            var bb = quotes.GetBollingerBands(20, 2).ToList();
            var ri = quotes.GetRi(14).ToList();

            for (int i = 0; i < Charts.Count; i++)
            {
                var chart = Charts[i];
                chart.MA = sma[i];
                chart.EMA = ema[i];
                chart.RSI = rsi[i];
                chart.MACD = macd[i];
                chart.BollingerBands = bb[i];
                chart.RI = ri[i];
            }
        }

        public void CalculateCustomIndicators(IList<NamedElement> namedElements)
        {
            var quotes = Charts.Select(x => x.Quote);
            var results = new List<List<NamedElementResult>>();
            foreach (var namedElement in namedElements)
            {
                switch (namedElement.Element)
                {
                    case ChartElement.ma:
                        results.Add(quotes.GetSma((int)namedElement.Parameters[0]).Select(x => new NamedElementResult(namedElement.Name, x.Sma)).ToList());
                        break;

                    case ChartElement.ema:
                        results.Add(quotes.GetEma((int)namedElement.Parameters[0]).Select(x => new NamedElementResult(namedElement.Name, x.Ema)).ToList());
                        break;
                }

            }

            for (int j = 0; j < Charts.Count; j++)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    var chart = Charts[j];
                    chart.NamedElements.Add(results[i][j]);
                }
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
            CurrentChart = GetChart(Interval switch
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
