using Binance.Net.Enums;

using Gaten.Net.IO;
using Gaten.Net.Stock.Charts;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.ChartManager.Apis;
using Gaten.Stock.ChartManager.Utils;

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
        public static KlineInterval BaseCandleInterval { get; set; }
        public static List<ChartPack> Charts { get; set; } = new();

        /// <summary>
        /// 분봉 초기화
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="candleInterval"></param>
        /// <param name="worker"></param>
        public static void Init(string symbol, KlineInterval candleInterval, Worker worker)
        {
            try
            {
                BaseCandleInterval = candleInterval;
                var chartPack = new ChartPack(candleInterval);
                var files = new DirectoryInfo(GResource.BinanceFuturesDataPath.Down("1m", symbol)).GetFiles("*.csv");

                worker.For(0, files.Length, 1, (i) =>
                {
                    var fileName = files[i].FullName;
                    var date = SymbolUtil.GetDate(fileName);
                    var data = File.ReadAllLines(fileName);

                    foreach (var d in data)
                    {
                        var e = d.Split(',');
                        var candle = new Candle(DateTime.Parse(e[0]), double.Parse(e[1]), double.Parse(e[2]), double.Parse(e[3]), double.Parse(e[4]), double.Parse(e[5]));
                        chartPack.AddChart(new ChartInfo(symbol, candle));
                    }
                });

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
        /// 1일봉 초기화
        /// </summary>
        /// <param name="symbol"></param>
        public static void Init1D(string symbol)
        {
            try
            {
                BaseCandleInterval = KlineInterval.OneDay;
                var chartPack = new ChartPack(KlineInterval.OneDay);
                var path = GResource.BinanceFuturesDataPath.Down("1D", $"{symbol}.csv");
                var data = File.ReadAllLines(path);

                foreach (var d in data)
                {
                    var e = d.Split(',');
                    var candle = new Candle(DateTime.Parse(e[0]), double.Parse(e[1]), double.Parse(e[2]), double.Parse(e[3]), double.Parse(e[4]), double.Parse(e[5]));
                    chartPack.AddChart(new ChartInfo(symbol, candle));
                }

                chartPack.CalculateIndicators();

                Charts.Add(chartPack);
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

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
                                var candle = new Candle(DateTime.Parse(e[0]), double.Parse(e[1]), double.Parse(e[2]), double.Parse(e[3]), double.Parse(e[4]), double.Parse(e[5]));
                                chartPack.AddChart(new ChartInfo(symbol, candle));
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                    }

                    chartPack.ConvertCandle();

                    var newData = chartPack.Charts.Select(x => x.Candle).Select(x => string.Join(',', new string[] {
                            x.Time.ToString("yyyy-MM-dd HH:mm:ss"), x.Open.ToString(), x.High.ToString(), x.Low.ToString(), x.Close.ToString(), x.Volume.ToString()
                        })).ToList();

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

        public static List<string> GetLoadedSymbols => Charts.Select(x => x.Symbol).ToList();
        public static ChartPack GetChartPack(string symbol) => Charts.Find(x => x.Symbol.Equals(symbol)) ?? default!;
    }
}
