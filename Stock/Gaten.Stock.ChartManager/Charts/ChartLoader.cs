using Binance.Net.Enums;

using Gaten.Net.IO;
using Gaten.Net.Stock.Charts;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.ChartManager.Apis;
using Gaten.Stock.ChartManager.Indicators;
using Gaten.Stock.ChartManager.Utils;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Gaten.Stock.ChartManager.Charts
{
    internal class ChartLoader
    {
        public static Dictionary<string, List<ChartInfo>>? Charts = new();
        public static ChartInfo? GetChart(string symbol, DateTime date) => Charts?[symbol].Find(c => c.Date.Equals(date));

        public static void Init(string symbol, KlineInterval candleInterval, Worker worker)
        {
            try
            {
                var chartInfo = new List<ChartInfo>();
                var files = new DirectoryInfo(GResource.BinanceFuturesDataPath.Down("1m", symbol)).GetFiles("*.csv");

                worker.For(0, files.Length, 1, (i) =>
                {
                    var fileName = files[i].FullName;
                    var date = SymbolUtil.GetDate(fileName);
                    var data = File.ReadAllLines(fileName);
                    var candles = new List<Candle>();

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
                        candles = ConvertTo(candles, candleInterval);
                    }

                    var quotes = candles.ToQuotes();
                    chartInfo.Add(new ChartInfo
                    (
                        symbol,
                        date,
                        candles,
                        quotes.GetSma(112).ToList(),
                        quotes.GetEma(112).ToList(),
                        quotes.GetRsi(14).ToList(),
                        quotes.GetMacd(12, 26, 9).ToList(),
                        quotes.GetBollingerBands(20, 3).ToList(),
                        quotes.GetBollingerBands(20, 0.5).ToList(),
                        quotes.GetRi(14).ToList()
                    ));
                });

                Charts?.Add(symbol, chartInfo);
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public static void ExtractCandle(KlineInterval candleInterval, Worker worker)
        {
            try
            {
                string intervalString = candleInterval.ToIntervalString();
                var startTimeTemp = candleInterval == KlineInterval.OneDay ? (File.Exists(GResource.BinanceFuturesDataPath.Down("1D", "BTCUSDT.csv")) ? SymbolUtil.GetEndDateOf1D("BTCUSDT") : SymbolUtil.GetStartDate("BTCUSDT")) : SymbolUtil.GetEndDate("BTCUSDT");
                var symbols = LocalStorageApi.GetSymbols();
                var dayCountTemp = (DateTime.Today - startTimeTemp).Days + 1;
                var csvFileCount = symbols.Count * dayCountTemp;
                worker.SetProgressBar(0, csvFileCount);

                int s = 0;
                foreach (var symbol in symbols)
                {
                    var startTime = candleInterval == KlineInterval.OneDay ? (File.Exists(GResource.BinanceFuturesDataPath.Down("1D", $"{symbol}.csv")) ? SymbolUtil.GetEndDateOf1D(symbol) : SymbolUtil.GetStartDate(symbol)) : SymbolUtil.GetEndDate(symbol);
                    var dayCount = (DateTime.Today - startTime).Days + 1;
                    var chartInfo = new List<ChartInfo>();
                    var path = GResource.BinanceFuturesDataPath.Down(intervalString, $"{symbol}.csv");

                    var newData = new List<string>();
                    try
                    {
                        for (int i = 0; i < dayCount; i++)
                        {
                            var date = startTime.AddDays(i);
                            var inputFileName = GResource.BinanceFuturesDataPath.Down("1m", symbol, $"{symbol}_{date:yyyy-MM-dd}.csv");
                            var data = File.ReadAllLines(inputFileName);
                            var candles = new List<Candle>();

                            worker.Progress(++s);
                            worker.ProgressText($"{symbol}, {i} / {dayCount}");

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

                            candles = ConvertTo(candles, candleInterval);

                            newData.Add(
                                string.Join(',', new string[] {
                                    candles[0].Time.ToString("yyyy-MM-dd HH:mm:ss"),
                                    candles[0].Open.ToString(),
                                    candles[0].High.ToString(),
                                    candles[0].Low.ToString(),
                                    candles[0].Close.ToString(),
                                    candles[0].Volume.ToString()
                                })
                                );
                        }
                    }
                    catch (FileNotFoundException)
                    {
                    }
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
                var basePath = GResource.BinanceFuturesDataPath.Down("1m");
                var getStartTime = SymbolUtil.GetEndDate("BTCUSDT");
                var symbols = LocalStorageApi.GetSymbols();
                var csvFileCount = ((DateTime.Today - getStartTime).Days + 1) * symbols.Count;
                worker.SetProgressBar(0, csvFileCount);

                int p = 0;
                foreach (var symbol in symbols)
                {
                    var startTime = getStartTime;
                    var count = 400;
                    var symbolPath = basePath.Down(symbol);

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

        public static List<Candle> ConvertTo(List<Candle> candles, KlineInterval candleInterval)
        {
            var newCandles = new List<Candle>();

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
