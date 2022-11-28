﻿using Binance.Net.Enums;

using Gaten.Net.Diagnostics;
using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Net.Stock.MercuryTradingModel.IO;
using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.MarinerX.Apis;
using Gaten.Stock.MarinerX.Bots;
using Gaten.Stock.MarinerX.Charts;
using Gaten.Stock.MarinerX.Indicators;
using Gaten.Stock.MarinerX.Views;

using MySqlX.XDevAPI.Common;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

using MessageBox = System.Windows.MessageBox;

namespace Gaten.Stock.MarinerX
{
    internal class TrayMenu
    {
        private NotifyIcon trayIcon;
        private static ContextMenuStrip menuStrip = new();
        private static ProgressView progressView = new();
        private static ProgressView[] progressViews = new ProgressView[80];
        private string iconFileName = "Resources/Images/chart2.ico";
        private Image iconImage;
        private List<BackTestTmFile> tmBackTestFiles = new();
        private List<string> tmMockTradeFileNames = new();
        private List<string> tmRealTradeFileNames = new();
        private List<string> backTestResultFileNames = new();

        public TrayMenu()
        {
            iconImage = Image.FromFile(iconFileName);

            trayIcon = new NotifyIcon
            {
                Icon = new Icon(iconFileName),
                Text = $"MarinerX By Gaten",
                Visible = true
            };

            var watcher = new FileSystemWatcher
            {
                Path = TradingModelPath.InspectedDirectory,
                NotifyFilter = NotifyFilters.FileName,
                Filter = "*.json"
            };
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;

            progressView = new ProgressView();
            progressView.Hide();

            for (int i = 0; i < progressViews.Length; i++)
            {
                progressViews[i] = new ProgressView(i * 15, 0, (int)WindowsSystem.ScreenWidth, 15);
                progressViews[i].Hide();
            }

            RefreshTmFile();
            RefreshMenu();
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            RefreshTmFile();
            RefreshMenu();
        }

        private void RefreshTmFile()
        {
            tmBackTestFiles = Directory.GetFiles(TradingModelPath.InspectedBackTestDirectory).Select(x => new BackTestTmFile(x)).ToList();
            tmMockTradeFileNames = Directory.GetFiles(TradingModelPath.InspectedMockTradeDirectory).ToList();
            tmRealTradeFileNames = Directory.GetFiles(TradingModelPath.InspectedRealTradeDirectory).ToList();
            backTestResultFileNames = Directory.GetFiles(GPath.Desktop.Down("MarinerX"), "*.csv").ToList();
        }

        public void RefreshMenu()
        {
            menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add(new ToolStripMenuItem("MarinerX By Gaten", iconImage));
            menuStrip.Items.Add(new ToolStripSeparator());

            var menu1 = new ToolStripMenuItem("데이터 수집");
            menu1.DropDownItems.Add("Binance 심볼 데이터 수집", null, new EventHandler(GetBinanceSymbolDataEvent));
            menu1.DropDownItems.Add("Binance 1분봉 데이터 수집", null, new EventHandler(GetBinanceCandleDataEvent));
            menu1.DropDownItems.Add("Binance 1일봉 데이터 추출", null, new EventHandler(Extract1DCandleEvent));
            menuStrip.Items.Add(menu1);

            menuStrip.Items.Add(new ToolStripSeparator());

            var menu2 = new ToolStripMenuItem("1분봉 데이터 로드");
            menuStrip.Items.Add(menu2);

            var menu3 = new ToolStripMenuItem("5분봉 데이터 로드");
            foreach (var symbol in new string[] {
                "BTCUSDT",
                "ETHUSDT",
                "BNBUSDT",
                "XRPUSDT",
                "ADAUSDT",
                "SOLUSDT"
            })
            {
                menu2.DropDownItems.Add(new ToolStripMenuItem(symbol, null, new EventHandler((sender, e) => LoadChartDataEvent(sender, e, symbol, KlineInterval.OneMinute))));
                menu3.DropDownItems.Add(new ToolStripMenuItem(symbol, null, new EventHandler((sender, e) => LoadChartDataEvent(sender, e, symbol, KlineInterval.FiveMinutes))));
            }
            menuStrip.Items.Add(menu3);

            menuStrip.Items.Add(new ToolStripSeparator());

            menuStrip.Items.Add(new ToolStripMenuItem("Mercury Editor 열기", null, MercuryEditorOpenEvent));

            menuStrip.Items.Add(new ToolStripMenuItem("Mercury Simple Editor 열기", null, MercurySimpleEditorOpenEvent));

            menuStrip.Items.Add(new ToolStripSeparator());

            var menu4 = new ToolStripMenuItem("백테스트");
            foreach (var file in tmBackTestFiles)
            {
                menu4.DropDownItems.Add(new ToolStripMenuItem(file.MenuString, null, BackTestBotRunEvent, file.ToString() + "|+|false"));
            }

            var menu41 = new ToolStripMenuItem("백테스트 차트");
            foreach (var file in tmBackTestFiles)
            {
                menu41.DropDownItems.Add(new ToolStripMenuItem(file.MenuString, null, BackTestBotRunEvent, file.ToString() + "|+|true"));
            }

            var menu42 = new ToolStripMenuItem("백테스트 결과");
            foreach (var file in backTestResultFileNames)
            {
                menu42.DropDownItems.Add(new ToolStripMenuItem(file, null, BackTestResultViewEvent));
            }

            menuStrip.Items.Add(menu4);
            menuStrip.Items.Add(menu41);
            menuStrip.Items.Add(menu42);

            menuStrip.Items.Add(new ToolStripSeparator());

            var menu5 = new ToolStripMenuItem("테스트");
            menu5.DropDownItems.Add(new ToolStripMenuItem("RI Histogram", null, RiHistogramEvent));
            menu5.DropDownItems.Add(new ToolStripMenuItem("Check Volatility", null, CheckVolatilityEvent));
            menu5.DropDownItems.Add(new ToolStripMenuItem("Check MarketCap", null, CheckMarketCapEvent));
            menu5.DropDownItems.Add(new ToolStripMenuItem("Run Back Test Flask", null, RunBackTestFlaskEvent));
            menu5.DropDownItems.Add(new ToolStripMenuItem("Run Back Test Flask Multi", null, RunBackTestFlaskMultiEvent));
            menuStrip.Items.Add(menu5);

            menuStrip.Items.Add(new ToolStripSeparator());

            menuStrip.Items.Add(new ToolStripMenuItem("종료", null, Exit));

            menuStrip.Items[0].Enabled = false;
            trayIcon.ContextMenuStrip = menuStrip;
        }

        #region 데이터 수집
        public static void GetBinanceSymbolDataEvent(object? sender, EventArgs e)
        {
            try
            {
                var symbolNames = BinanceClientApi.GetFuturesSymbolNames();
                GFile.WriteByArray(
                    GResource.BinanceFuturesDataPath.Down($"symbol_{DateTime.Now:yyyy-MM-dd}.txt"),
                    symbolNames);

                var symbolData = BinanceClientApi.GetFuturesSymbols();
                symbolData.SaveCsvFile(GResource.BinanceFuturesDataPath.Down($"symbol_detail_{DateTime.Now:yyyy-MM-dd}.csv"));

                var bnbPrice = BinanceClientApi.GetCurrentBnbPrice();
                GFile.WriteByArray(
                    GResource.BinanceFuturesDataPath.Down("BNB.txt"),
                    new List<string> { DateTime.Now.ToStandardFileName(), bnbPrice.ToString() });

                MessageBox.Show("바이낸스 심볼 데이터 수집 완료");

                GProcess.Start(GResource.BinanceFuturesDataPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetBinanceCandleDataEvent(object? sender, EventArgs e)
        {
            progressView.Show();
            var worker = new Worker()
            {
                ProgressBar = progressView.ProgressBar,
                Action = GetBinanceCandleData
            };
            worker.Start();
        }

        public static void GetBinanceCandleData(Worker worker, object? obj)
        {
            try
            {
                ChartLoader.GetCandleDataFromBinance(worker);
                DispatcherService.Invoke(() =>
                {
                    progressView.Hide();
                });

                MessageBox.Show("바이낸스 1분봉 데이터 수집 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Extract1DCandleEvent(object? sender, EventArgs e)
        {
            progressView.Show();
            var worker = new Worker()
            {
                ProgressBar = progressView.ProgressBar,
                Action = Extract1DCandle
            };
            worker.Start();
        }

        public static void Extract1DCandle(Worker worker, object? obj)
        {
            try
            {
                ChartLoader.ExtractCandle(KlineInterval.OneDay, worker);
                DispatcherService.Invoke(() =>
                {
                    progressView.Hide();
                });

                MessageBox.Show("바이낸스 1일봉 데이터 추출 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 데이터 로드
        record ChartDataType(string symbol, KlineInterval interval, bool isExternal);

        public static void LoadChartDataEvent(object? sender, EventArgs e, string symbol, KlineInterval interval, bool external = false)
        {
            if (!external)
            {
                progressView.Show();
            }
            var worker = new Worker()
            {
                ProgressBar = progressView.ProgressBar,
                Action = LoadChartData,
                Arguments = new ChartDataType(symbol, interval, external)
            };
            if (external)
            {
                worker.Start().Wait();
            }
            else
            {
                worker.Start();
            }
        }

        public static void LoadChartData(Worker worker, object? obj)
        {
            try
            {
                if (obj is not ChartDataType chartDataType)
                {
                    return;
                }
                ChartLoader.Init(chartDataType.symbol, chartDataType.interval, worker);
                if (!chartDataType.isExternal)
                {
                    DispatcherService.Invoke(() =>
                    {
                        progressView.Hide();
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Mercury Editor
        private void MercuryEditorOpenEvent(object? sender, EventArgs e)
        {
            try
            {
                GProcess.Start("MercuryEditor.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MercurySimpleEditorOpenEvent(object? sender, EventArgs e)
        {
            try
            {
                GProcess.Start("MercuryEditor.exe", "simple");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 백테스트
        record BackTestParameter(MercuryBackTestTradingModel? model, bool isShowChart);

        private void BackTestBotRunEvent(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem menuItem)
            {
                return;
            }

            var menuNameSegments = menuItem.Name.Split("|+|");
            var jsonString = GFile.Read(menuNameSegments[0]);
            var isShowChart = bool.Parse(menuNameSegments[3]);
            var result = JsonConvert.DeserializeObject<MercuryBackTestTradingModel>(jsonString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });

            progressView.Show();
            var worker = new Worker()
            {
                ProgressBar = progressView.ProgressBar,
                Action = BackTestBotRun,
                Arguments = new BackTestParameter(result, isShowChart)
            };
            worker.Start();
        }

        public static void BackTestBotRun(Worker worker, object? obj)
        {
            BackTestBot? bot = default!;
            try
            {
                if (obj is not BackTestParameter param)
                {
                    DispatcherService.Invoke(() =>
                    {
                        progressView.Hide();
                    });
                    return;
                }

                if (param.model == null)
                {
                    throw new Exception("BackTest Trading Model Null");
                }

                bot = new BackTestBot(param.model, worker, param.isShowChart);
                var result = bot.Run();
                DispatcherService.Invoke(() =>
                {
                    progressView.Hide();
                });

                if (result.Length < 32)
                {
                    throw new Exception(result);
                }

                var path = GPath.Desktop.Down("MarinerX", $"BackTest_{DateTime.Now.ToStandardFileName()}.txt");
                GFile.Write(path, result);

                if (param.isShowChart)
                {
                    DispatcherService.Invoke(() =>
                    {
                        bot.ChartViewer.Show();
                    });
                }
                else
                {
                    GProcess.Start(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                var path = GPath.Desktop.Down("MarinerX", $"BackTest_Error_{DateTime.Now.ToStandardFileName()}.txt");
                GFile.Write(path, bot.TradeLog.ToString());

                GProcess.Start(path);
            }
        }

        public static void BackTestResultViewEvent(object? sender, EventArgs e)
        {
            if(sender is not ToolStripMenuItem item)
            {
                return;
            }

            var fileName = item.Text;
            var historyView = new BackTestTradingHistoryView();
            historyView.Init(fileName);
            historyView.Show();
        }
        #endregion

        #region 테스트
        private void RiHistogramEvent(object? sender, EventArgs e)
        {
            try
            {
                IndicatorHistogram.GetRiHistogram("BTCUSDT", KlineInterval.FiveMinutes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckMarketCapEvent(object? sender, EventArgs e)
        {
            try
            {
                BinanceClientApi.GetMaxLeverages();
                BinanceHttpApi.GetSymbolMarketCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckVolatilityEvent(object? sender, EventArgs e)
        {
            try
            {
                var result = new Dictionary<string, decimal>();
                var data = LocalStorageApi.GetAllOneDayQuotes();

                foreach (var d in data)
                {
                    var list = d.Value.Select(x => Math.Round((x.High - x.Low) / x.Low * 100, 2)).ToList();
                    result.Add(d.Key, Math.Round(list.Average(), 4));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RunBackTestFlaskEvent(object? sender, EventArgs e)
        {
            try
            {
                progressView.Show();
                var worker = new Worker()
                {
                    ProgressBar = progressView.ProgressBar,
                    Action = BackTestFlaskRun
                };
                worker.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void BackTestFlaskRun(Worker worker, object? obj)
        {
            try
            {
                var flask = new BackTestFlask(worker);
                var result = flask.Run(100000, "BTCUSDT", KlineInterval.FiveMinutes, new DateTime(2022, 10, 1, 0, 0, 0), TimeSpan.FromDays(3), 0.5, 0.5m);

                DispatcherService.Invoke(() =>
                {
                    progressView.Hide();
                });

                if (result == null)
                {
                    throw new Exception("Back Test No Trading!!!");
                }

                var path = GPath.Desktop.Down("MarinerX", $"BackTestFlask_{DateTime.Now.ToStandardFileName()}.csv");
                result.SaveCsvFile(path);

                DispatcherService.Invoke(() =>
                {
                    var historyView = new BackTestTradingHistoryView();
                    historyView.Init(result);
                    historyView.Show();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RunBackTestFlaskMultiEvent(object? sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 10; j++)
                    {
                        var pv = progressViews[i * 10 + j];

                        pv.Show();
                        var worker = new Worker()
                        {
                            ProgressBar = pv.ProgressBar,
                            Action = BackTestFlaskMultiRun,
                            Arguments = new _temp_bb(0.3 + 0.1 * i, 0.1m + 0.1m * j)
                        };
                        worker.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        record _temp_bb(double bw, decimal pr);

        public static void BackTestFlaskMultiRun(Worker worker, object? obj)
        {
            try
            {
                if(obj is not _temp_bb tb)
                {
                    return;
                }

                var bandwidth = tb.bw;
                var profitRoe = tb.pr;

                var flask = new BackTestFlask(worker);
                var result = flask.Run(100000, "XRPUSDT", KlineInterval.FiveMinutes, new DateTime(2022, 10, 1, 0, 0, 0), TimeSpan.FromDays(30), bandwidth, profitRoe);

                DispatcherService.Invoke(() =>
                {
                    Window.GetWindow(worker.ProgressBar).Hide();
                });

                if (result == null)
                {
                    throw new Exception("Back Test No Trading!!!");
                }

                var path = GPath.Desktop.Down("MarinerX", $"BackTestFlask_{DateTime.Now.ToStandardFileName()}_b{bandwidth}_r{profitRoe}.csv");
                result.SaveCsvFile(path);

                //DispatcherService.Invoke(() =>
                //{
                //    var historyView = new BackTestTradingHistoryView();
                //    historyView.Init(result);
                //    historyView.Show();
                //});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Exit
        private void Exit(object? sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
    }
}
