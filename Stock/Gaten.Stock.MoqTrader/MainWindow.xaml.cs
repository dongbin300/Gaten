using Binance.Net.Enums;

using Gaten.Stock.MoqTrader.Apis;
using Gaten.Stock.MoqTrader.BinanceTrades;
using Gaten.Stock.MoqTrader.Charts;
using Gaten.Stock.MoqTrader.Utils;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using Path = System.IO.Path;
using Gaten.Stock.MoqTrader.BinanceTrades.TradeModels;
using System.ComponentModel;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Models;
using Gaten.Net.Data.Diagnostics;

namespace Gaten.Stock.MoqTrader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime mockStartTime;
        StringBuilder builder;
        List<Worker> workers;
        int c = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BinanceClientApi.Init();
            //Assets.Init();

            workers = new List<Worker>();
            for (int up = 69; up < 70; up++)
            {
                for (int down = 30; down > 29; down--)
                {
                    workers.Add(new Worker()
                    {
                        ProgressBar = SimulateProgressBar,
                        Action = DoWork,
                        Arguments = (up, down)
                    });
                }
            }

                    

            mockStartTime = DateTime.Parse(Path.GetFileNameWithoutExtension(new DirectoryInfo(Path.Combine(PathUtil.BinanceFuturesDataBasePath, "BTCUSDT")).GetFiles()[^1].FullName).Split('_')[1]);
            LastUpdateText.Text = "업데이트: " + mockStartTime.ToString("yyyy-MM-dd");
            StatusText.Text = "";

            var symbols = LocalStorageApi.GetSymbols();
            SymbolComboBox.ItemsSource = symbols;
            AllSymbolCheckBox.IsChecked = false;
            AllPeriodCheckBox.IsChecked = true;
        }

        private void DoWork(Worker worker, object obj)
        {
            (var up, var down) = (ValueTuple<int, int>)obj;

            int seed = 0;
            int divisionRate = 0;
            bool tradeLog = false;
            bool dayLog = false;
            DispatcherService.Invoke(() =>
            {
                seed = int.Parse(AmountTextBox.Text);
                divisionRate = int.Parse(DivisionRateTextBox.Text);
                tradeLog = TradeLogCheckBox.IsChecked ?? true;
                dayLog = DayLogCheckBox.IsChecked ?? true;
            });

            var tradeMarket = new TradeMarket(seed, worker);
            tradeMarket.Symbol = new Symbols.SymbolRange("BTCUSDT");
            tradeMarket.CandleInterval = KlineInterval.OneMinute;
            tradeMarket.TradePeriod = new DateTimes.Period(
                new DateTime(2021, 3, 1),
                new DateTime(2021, 3, 31));
            tradeMarket.TradeModel = new RsiTradeModel(divisionRate, up, down);
            var results = tradeMarket.Run(tradeLog, dayLog);

        }

        (DateTime, int) GetPeriod()
        {
            if (AllPeriodCheckBox.IsChecked ?? true)
            {
                var startTime = DateTime.Parse(Path.GetFileNameWithoutExtension(new DirectoryInfo(Path.Combine(PathUtil.BinanceFuturesDataBasePath, SymbolComboBox.SelectedItem.ToString())).GetFiles()[0].FullName).Split('_')[1]);
                var endTime = DateTime.Parse(Path.GetFileNameWithoutExtension(new DirectoryInfo(Path.Combine(PathUtil.BinanceFuturesDataBasePath, SymbolComboBox.SelectedItem.ToString())).GetFiles()[^1].FullName).Split('_')[1]);

                return (
                    startTime,
                    (int)(endTime - startTime).TotalDays);
            }
            else
            {
                return (
                    new DateTime(int.Parse(StartYearComboBox.Text), int.Parse(StartMonthComboBox.Text), int.Parse(StartDayComboBox.Text)),
                    int.Parse(BackTestPeriodTextBox.Text));
            }
        }

        KlineInterval GetCandleInterval() => int.Parse(CandleIntervalComboBox.Text) switch
        {
            1 => KlineInterval.OneMinute,
            3 => KlineInterval.ThreeMinutes,
            5 => KlineInterval.FiveMinutes,
            15 => KlineInterval.FifteenMinutes,
            30 => KlineInterval.ThirtyMinutes,
            60 => KlineInterval.OneHour,
            120 => KlineInterval.TwoHour,
            240 => KlineInterval.FourHour,
            360 => KlineInterval.SixHour,
            480 => KlineInterval.EightHour,
            720 => KlineInterval.TwelveHour,
            1440 => KlineInterval.OneDay,
            _ => KlineInterval.OneMinute,
        };

        async void Trading()
        {
            builder = new();

            (var startDate, var dayCount) = GetPeriod();
            var candleInterval = GetCandleInterval();
            c = 0;

            if (AllSymbolCheckBox.IsChecked ?? true)
            {
                //SimulateProgressBar.Maximum = Assets.CoinSize.Count * dayCount;
                //foreach (var coin in Assets.CoinSize)
                //{
                //    try
                //    {
                //        var results = TradingCoin(coin.Key, startDate, dayCount, candleInterval);
                //        tradingResults.AddRange(results);
                //    }
                //    catch (FileNotFoundException)
                //    {
                //        continue;
                //    }
                //}
            }
            else
            {
                //SimulateProgressBar.Maximum = 25;
                try
                {
                    foreach(var worker in workers)
                    {
                        worker.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            while (workers.Any(x=>x.IsRunning))
            {
                Thread.Sleep(10);
            }

            builder.AppendLine();
            //builder.AppendLine($"{startDate:yyyy-MM-dd} ~ {startDate.AddDays(dayCount - 1):yyyy-MM-dd} 백테스트 결과");
            //builder.AppendLine($"최저: {tradingResults.Min(r => r.EstimatedAssets)} USDT ({MathUtil.POE(Assets.Seed, tradingResults.Min(r => r.EstimatedAssets))})");
            //builder.AppendLine($"최고: {tradingResults.Max(r => r.EstimatedAssets)} USDT ({MathUtil.POE(Assets.Seed, tradingResults.Max(r => r.EstimatedAssets))})");
            //builder.AppendLine($"평균: {tradingResults.Average(r => r.EstimatedAssets)} USDT ({MathUtil.POE(Assets.Seed, tradingResults.Average(r => r.EstimatedAssets))})");
            //builder.AppendLine($"전적: {tradingResults.Count(r => r.EstimatedAssets > Assets.Seed)}승 {tradingResults.Count(r => r.EstimatedAssets < Assets.Seed)}패 {tradingResults.Count(r => r.EstimatedAssets == Assets.Seed)}무");

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MockTrader", $"MockTrader_{DateTime.Now:yyyyMMddHHmmss}.txt");
            File.WriteAllText(filePath, builder.ToString());

            GProcess.Start(filePath);

            Close();
        }

        List<TradingResult> TradingCoin(string symbol, DateTime startDate, int dayCount, KlineInterval candleInterval)
        {
            /* Init Assets */
            //Assets.Amount = Assets.Seed = double.Parse(AmountTextBox.Text);
            //Assets.DivisionRate = double.Parse(DivisionRateTextBox.Text);
            List<TradingResult> results = new List<TradingResult>();

            /* Simulate Trading */
            try
            {
                for (int d = 0; d < dayCount; d++)
                {
                    var result = new TradingResult("1", startDate); // TradeMarket.SimulateTrading(symbol, startDate.AddDays(d), candleInterval);
                    if (TradeLogCheckBox.IsChecked ?? true)
                    {
                        builder.Append(result.ToTradeString());
                    }
                    if (DayLogCheckBox.IsChecked ?? true || d == dayCount - 1)
                    {
                        builder.AppendLine(result.ToString());
                    }
                    StatusText.Text = result.ToString();
                    //SimulateProgressBar.Value = ++c;
                    results.Add(result);
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }

            return results;
        }


        private void SymbolDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var symbols = BinanceClientApi.GetExchangeInfo();

                File.WriteAllText(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "BinanceFuturesData",
                $"symbol_{DateTime.Now:yyyy-MM-dd}.txt"),
                string.Join("\r\n", symbols));

                StatusText.Text = "심볼 데이터 수집 완료";
            }
            catch (Exception ex)
            {
                StatusText.Text = ex.Message;
            }
        }

        private void CandleDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var symbols = BinanceClientApi.GetExchangeInfo();

                foreach (var symbol in symbols)
                {
                    var startTime = mockStartTime;
                    var count = 100;

                    var symbolPath = Path.Combine(PathUtil.BinanceFuturesDataBasePath, symbol);

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

                        StatusText.Text = $"{symbol}, {standardTime:yyyy-MM-dd}";

                        BinanceClientApi.GetCandleDataForOneDay(symbol, standardTime);

                        Thread.Sleep(500);
                    }
                }

                StatusText.Text = "1분봉 데이터 수집 완료";
            }
            catch (Exception ex)
            {
                StatusText.Text = ex.Message;
            }
        }

        private void BackTestButton_Click(object sender, RoutedEventArgs e)
        {
            Worker worker = new Worker()
            {
                ProgressBar = SimulateProgressBar,
                Action = InitBtcusdt,
            };
            worker.Start();

            //Trading();
        }

        private void InitBtcusdt(Worker worker, object? obj)
        {
            KlineInterval interval = KlineInterval.OneMinute;
            DispatcherService.Invoke(() =>
            {
                interval = GetCandleInterval();
            });
            BtcusdtChartManager.Init(interval, worker);
        }

        private void AllSymbolCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            SymbolComboBox.IsEnabled = !AllSymbolCheckBox.IsChecked ?? true;
        }

        private void AllPeriodCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            StartYearComboBox.IsEnabled =
                StartMonthComboBox.IsEnabled =
                StartDayComboBox.IsEnabled =
                BackTestPeriodTextBox.IsEnabled =
                !AllPeriodCheckBox.IsChecked ?? true;
        }
    }
}
