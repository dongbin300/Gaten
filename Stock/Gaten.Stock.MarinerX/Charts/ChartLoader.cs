using Binance.Net.Enums;

using Gaten.Net.IO;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Intervals;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.MarinerX.Apis;
using Gaten.Stock.MarinerX.Utils;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Gaten.Stock.MarinerX.Charts
{
    internal class ChartLoader
    {
        public static List<ChartPack> Charts { get; set; } = new();

        /// <summary>
        /// 분봉 초기화
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="worker"></param>
        public static void Init(string symbol, KlineInterval interval, Worker worker)
        {
            try
            {
                var chartPack = new ChartPack(interval);

                switch (interval)
                {
                    case KlineInterval.OneMinute:
                    case KlineInterval.ThreeMinutes:
                    case KlineInterval.FiveMinutes:
                    case KlineInterval.FifteenMinutes:
                    case KlineInterval.ThirtyMinutes:
                    case KlineInterval.OneHour:
                    case KlineInterval.TwoHour:
                    case KlineInterval.FourHour:
                    case KlineInterval.SixHour:
                    case KlineInterval.EightHour:
                    case KlineInterval.TwelveHour:
                        var files = new DirectoryInfo(GResource.BinanceFuturesDataPath.Down("1m", symbol)).GetFiles("*.csv");

                        worker.For(0, files.Length, 1, (i) =>
                        {
                            var fileName = files[i].FullName;
                            var date = SymbolUtil.GetDate(fileName);
                            var data = File.ReadAllLines(fileName);

                            foreach (var d in data)
                            {
                                var e = d.Split(',');
                                var quote = new Quote
                                {
                                    Date = DateTime.Parse(e[0]),
                                    Open = decimal.Parse(e[1]),
                                    High = decimal.Parse(e[2]),
                                    Low = decimal.Parse(e[3]),
                                    Close = decimal.Parse(e[4]),
                                    Volume = decimal.Parse(e[5])
                                };
                                chartPack.AddChart(new ChartInfo(symbol, quote));
                            }
                        }, ProgressBarDisplayOptions.Count | ProgressBarDisplayOptions.Percent | ProgressBarDisplayOptions.TimeRemaining);
                        break;

                    case KlineInterval.OneDay:
                    case KlineInterval.ThreeDay:
                    case KlineInterval.OneWeek:
                    case KlineInterval.OneMonth:
                        var path = GResource.BinanceFuturesDataPath.Down("1D", $"{symbol}.csv");
                        var data = File.ReadAllLines(path);

                        foreach (var d in data)
                        {
                            var e = d.Split(',');
                            var quote = new Quote
                            {
                                Date = DateTime.Parse(e[0]),
                                Open = decimal.Parse(e[1]),
                                High = decimal.Parse(e[2]),
                                Low = decimal.Parse(e[3]),
                                Close = decimal.Parse(e[4]),
                                Volume = decimal.Parse(e[5])
                            };
                            chartPack.AddChart(new ChartInfo(symbol, quote));
                        }
                        break;

                    default:
                        break;
                }

                chartPack.ConvertCandle();
                chartPack.CalculateIndicators();

                Charts.Add(chartPack);
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        /// <summary>
        /// 1분봉 데이터를 이용해 다른봉 데이터를 파일로 생성
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="worker"></param>
        public static void ExtractCandle(KlineInterval interval, Worker worker)
        {
            try
            {
                string intervalString = interval.ToIntervalString();
                var startTimeTemp = interval == KlineInterval.OneDay ? (File.Exists(GResource.BinanceFuturesDataPath.Down("1D", "BTCUSDT.csv")) ? SymbolUtil.GetEndDateOf1D("BTCUSDT") : SymbolUtil.GetStartDate("BTCUSDT")) : SymbolUtil.GetEndDate("BTCUSDT");
                var symbols = LocalStorageApi.GetSymbolNames();
                var dayCountTemp = (DateTime.Today - startTimeTemp).Days + 1;
                var csvFileCount = symbols.Count * dayCountTemp;
                worker.SetProgressBar(0, csvFileCount);

                int s = 0;
                foreach (var symbol in symbols)
                {
                    var startTime = interval == KlineInterval.OneDay ? (File.Exists(GResource.BinanceFuturesDataPath.Down("1D", $"{symbol}.csv")) ? SymbolUtil.GetEndDateOf1D(symbol) : SymbolUtil.GetStartDate(symbol)) : SymbolUtil.GetEndDate(symbol);
                    var dayCount = (DateTime.Today - startTime).Days + 1;
                    var chartPack = new ChartPack(interval);
                    var path = GResource.BinanceFuturesDataPath.Down(intervalString, $"{symbol}.csv");

                    try
                    {
                        for (int i = 0; i < dayCount; i++)
                        {
                            var date = startTime.AddDays(i);
                            var inputFileName = GResource.BinanceFuturesDataPath.Down("1m", symbol, $"{symbol}_{date:yyyy-MM-dd}.csv");
                            var data = File.ReadAllLines(inputFileName);

                            worker.Progress(++s);
                            worker.ProgressText($"{symbol}, {i} / {dayCount}");

                            foreach (var d in data)
                            {
                                var e = d.Split(',');
                                var quote = new Quote
                                {
                                    Date = DateTime.Parse(e[0]),
                                    Open = decimal.Parse(e[1]),
                                    High = decimal.Parse(e[2]),
                                    Low = decimal.Parse(e[3]),
                                    Close = decimal.Parse(e[4]),
                                    Volume = decimal.Parse(e[5])
                                };
                                chartPack.AddChart(new ChartInfo(symbol, quote));
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                    }

                    chartPack.ConvertCandle();

                    var newData = chartPack.Charts
                        .Select(x => x.Quote)
                        .Select(x => string.Join(',', new string[] {
                            x.Date.ToString("yyyy-MM-dd HH:mm:ss"), x.Open.ToString(), x.High.ToString(), x.Low.ToString(), x.Close.ToString(), x.Volume.ToString()
                        }))
                        .ToList();

                    GFile.TryCreate(path);
                    var prevData = GFile.ReadToArray(path);
                    if (prevData.Length < 1)
                    {
                        GFile.WriteByArray(path, newData);
                    }
                    else
                    {
                        var currentData = prevData.Take(prevData.Length - 1).ToList();
                        currentData.AddRange(newData);
                        GFile.WriteByArray(path, currentData);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public static void GetCandleDataFromBinance(Worker worker)
        {
            try
            {
                var getStartTime = SymbolUtil.GetEndDate("BTCUSDT");
                var symbols = LocalStorageApi.GetSymbolNames();
                var csvFileCount = ((DateTime.Today - getStartTime).Days + 1) * symbols.Count;
                worker.SetProgressBar(0, csvFileCount);

                int p = 0;
                foreach (var symbol in symbols)
                {
                    var startTime = getStartTime;
                    var count = 400;
                    var symbolPath = GResource.BinanceFuturesDataPath.Down("1m", symbol);

                    if (!Directory.Exists(symbolPath))
                    {
                        Directory.CreateDirectory(symbolPath);
                    }

                    for (int i = 0; i < count; i++)
                    {
                        var standardTime = startTime.AddDays(i);

                        if (DateTime.Compare(standardTime, DateTime.Today) > 0)
                        {
                            break;
                        }

                        worker.Progress(++p);
                        worker.ProgressText($"{symbol}, {standardTime:yyyy-MM-dd}");

                        BinanceClientApi.GetCandleDataForOneDay(symbol, standardTime);

                        Thread.Sleep(500);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<(string, KlineInterval)> GetLoadedSymbols => Charts.Select(x => (x.Symbol, x.Interval)).ToList();
        public static ChartPack GetChartPack(string symbol, KlineInterval interval) => Charts.Find(x => x.Symbol.Equals(symbol) && x.Interval.Equals(interval)) ?? default!;
    }
}
