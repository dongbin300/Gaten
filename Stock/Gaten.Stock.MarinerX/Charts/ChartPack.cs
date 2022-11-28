using Binance.Net.Enums;

using Gaten.Net.Extensions;
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

        public void CalculateIndicators(IList<ChartElement> chartElements, IList<NamedElement> namedElements)
        {
            var quotes = Charts.Select(x => x.Quote);

            // calculate chart elements
            var chartElementResults = new List<List<ChartElementResult>>();
            foreach (var chartElement in chartElements)
            {
                IEnumerable<ChartElementResult> result = chartElement.ElementType switch
                {
                    ChartElementType.ma => quotes.GetSma((int)chartElement.Parameters[0]).Select(x => new ChartElementResult(chartElement.ElementType, x.Sma.Convert<decimal>())),
                    ChartElementType.ema => quotes.GetEma((int)chartElement.Parameters[0]).Select(x => new ChartElementResult(chartElement.ElementType, x.Ema.Convert<decimal>())),
                    ChartElementType.ri => quotes.GetRi((int)chartElement.Parameters[0]).Select(x => new ChartElementResult(chartElement.ElementType, x.Ri.Convert<decimal>())),
                    ChartElementType.rsi => quotes.GetRsi((int)chartElement.Parameters[0]).Select(x => new ChartElementResult(chartElement.ElementType, x.Rsi.Convert<decimal>())),
                    ChartElementType.macd_macd => quotes.GetMacd((int)chartElement.Parameters[0], (int)chartElement.Parameters[1], (int)chartElement.Parameters[2]).Select(x => new ChartElementResult(chartElement.ElementType, x.Macd.Convert<decimal>())),
                    ChartElementType.macd_signal => quotes.GetMacd((int)chartElement.Parameters[0], (int)chartElement.Parameters[1], (int)chartElement.Parameters[2]).Select(x => new ChartElementResult(chartElement.ElementType, x.Signal.Convert<decimal>())),
                    ChartElementType.macd_hist => quotes.GetMacd((int)chartElement.Parameters[0], (int)chartElement.Parameters[1], (int)chartElement.Parameters[2]).Select(x => new ChartElementResult(chartElement.ElementType, x.Histogram.Convert<decimal>())),
                    ChartElementType.bb_sma => quotes.GetBollingerBands((int)chartElement.Parameters[0], (double)chartElement.Parameters[1]).Select(x => new ChartElementResult(chartElement.ElementType, x.Sma.Convert<decimal>())),
                    ChartElementType.bb_upper => quotes.GetBollingerBands((int)chartElement.Parameters[0], (double)chartElement.Parameters[1]).Select(x => new ChartElementResult(chartElement.ElementType, x.UpperBand.Convert<decimal>())),
                    ChartElementType.bb_lower => quotes.GetBollingerBands((int)chartElement.Parameters[0], (double)chartElement.Parameters[1]).Select(x => new ChartElementResult(chartElement.ElementType, x.LowerBand.Convert<decimal>())),
                    _ => default!
                };
                chartElementResults.Add(result.ToList());
            }
            for (int j = 0; j < Charts.Count; j++)
            {
                var chart = Charts[j];
                chart.ChartElements.Clear();
                for (int i = 0; i < chartElementResults.Count; i++)
                {
                    chart.ChartElements.Add(chartElementResults[i][j]);
                }
            }

            // calculate named elements
            var namedElementResults = new List<List<NamedElementResult>>();
            foreach (var namedElement in namedElements)
            {
                IEnumerable<NamedElementResult> result = namedElement.ElementType switch
                {
                    ChartElementType.ma => quotes.GetSma((int)namedElement.Parameters[0]).Select(x => new NamedElementResult(namedElement.Name, x.Sma.Convert<decimal>())),
                    ChartElementType.ema => quotes.GetEma((int)namedElement.Parameters[0]).Select(x => new NamedElementResult(namedElement.Name, x.Ema.Convert<decimal>())),
                    ChartElementType.ri => quotes.GetRi((int)namedElement.Parameters[0]).Select(x => new NamedElementResult(namedElement.Name, x.Ri.Convert<decimal>())),
                    ChartElementType.rsi => quotes.GetRsi((int)namedElement.Parameters[0]).Select(x => new NamedElementResult(namedElement.Name, x.Rsi.Convert<decimal>())),
                    ChartElementType.macd_macd => quotes.GetMacd((int)namedElement.Parameters[0], (int)namedElement.Parameters[1], (int)namedElement.Parameters[2]).Select(x => new NamedElementResult(namedElement.Name, x.Macd.Convert<decimal>())),
                    ChartElementType.macd_signal => quotes.GetMacd((int)namedElement.Parameters[0], (int)namedElement.Parameters[1], (int)namedElement.Parameters[2]).Select(x => new NamedElementResult(namedElement.Name, x.Signal.Convert<decimal>())),
                    ChartElementType.macd_hist => quotes.GetMacd((int)namedElement.Parameters[0], (int)namedElement.Parameters[1], (int)namedElement.Parameters[2]).Select(x => new NamedElementResult(namedElement.Name, x.Histogram.Convert<decimal>())),
                    ChartElementType.bb_sma => quotes.GetBollingerBands((int)namedElement.Parameters[0], (double)namedElement.Parameters[1]).Select(x => new NamedElementResult(namedElement.Name, x.Sma.Convert<decimal>())),
                    ChartElementType.bb_upper => quotes.GetBollingerBands((int)namedElement.Parameters[0], (double)namedElement.Parameters[1]).Select(x => new NamedElementResult(namedElement.Name, x.UpperBand.Convert<decimal>())),
                    ChartElementType.bb_lower => quotes.GetBollingerBands((int)namedElement.Parameters[0], (double)namedElement.Parameters[1]).Select(x => new NamedElementResult(namedElement.Name, x.LowerBand.Convert<decimal>())),
                    _ => default!
                };
                namedElementResults.Add(result.ToList());
            }
            for (int j = 0; j < Charts.Count; j++)
            {
                var chart = Charts[j];
                chart.NamedElements.Clear();
                for (int i = 0; i < namedElementResults.Count; i++)
                {
                    chart.NamedElements.Add(namedElementResults[i][j]);
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
