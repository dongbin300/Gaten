using Binance.Net.Enums;

using Gaten.Net.Diagnostics;
using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.MarinerX.Apis;
using Gaten.Stock.MarinerX.Bots;
using Gaten.Stock.MarinerX.Charts;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gaten.Stock.MarinerX
{
    internal class TrayMenu
    {
        private NotifyIcon trayIcon;
        private static ContextMenuStrip menuStrip = new();
        private static ProgressView progressView = new();
        private string iconFileName = "Resources/Images/chart2.ico";
        private Image iconImage;

        public TrayMenu()
        {
            iconImage = Image.FromFile(iconFileName);

            trayIcon = new NotifyIcon
            {
                Icon = new Icon(iconFileName),
                Text = $"MarinerX By Gaten",
                Visible = true
            };

            progressView = new ProgressView();
            progressView.Hide();

            RefreshMenu();
        }

        public void RefreshMenu()
        {
            menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add(new ToolStripMenuItem("MarinerX By Gaten", iconImage));
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add(new ToolStripMenuItem("Binance 심볼 데이터 수집", null, new EventHandler(GetBinanceSymbolDataEvent)));
            menuStrip.Items.Add(new ToolStripMenuItem("Binance 1분봉 데이터 수집", null, new EventHandler(GetBinanceCandleDataEvent)));
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add(new ToolStripMenuItem("Binance 1일봉 데이터 추출", null, new EventHandler(Extract1DCandleEvent)));
            menuStrip.Items.Add(new ToolStripSeparator());
            var symbolNames = LocalStorageApi.GetSymbolNames();
            var symbols = LocalStorageApi.GetSymbols();
            var accountInfo = BinanceClientApi.GetFuturesAccountInfo();
            var positionInformation = BinanceClientApi.GetPositionInformation();
            var balance = BinanceClientApi.GetBalance();
            BinanceClientApi.ChangeInitialLeverage("BTCUSDT", 5);
            //BinanceClientApi.Order("BTCUSDT", Binance.Net.Enums.OrderSide.Buy, Binance.Net.Enums.FuturesOrderType.Market, (decimal)0.002);
            var majorSymbols = new string[]
            {
                "BTCUSDT",
                "ETHUSDT",
                "BNBUSDT",
                "XRPUSDT",
                "ADAUSDT",
                "SOLUSDT"
            };
            foreach (var symbol in majorSymbols)
            {
                menuStrip.Items.Add(new ToolStripMenuItem(symbol + " 1분봉 데이터 로드", null, new EventHandler((sender, e) => LoadChartDataEvent(sender, e, symbol, KlineInterval.OneMinute))));
            }
            menuStrip.Items.Add(new ToolStripSeparator());
            foreach (var symbol in majorSymbols)
            {
                menuStrip.Items.Add(new ToolStripMenuItem(symbol + " 5분봉 데이터 로드", null, new EventHandler((sender, e) => LoadChartDataEvent(sender, e, symbol, KlineInterval.FiveMinutes))));
            }
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add(new ToolStripMenuItem("Mercury Editor 열기", null, MercuryEditorOpenEvent));
            menuStrip.Items.Add(new ToolStripMenuItem("Back Test Bot Run", null, BackTestBotRunEvent));
            menuStrip.Items.Add(new ToolStripMenuItem("종료", null, Exit));

            menuStrip.Items[0].Enabled = false;
            trayIcon.ContextMenuStrip = menuStrip;
        }

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

        private void BackTestBotRunEvent(object? sender, EventArgs e)
        {
            progressView.Show();
            var worker = new Worker()
            {
                ProgressBar = progressView.ProgressBar,
                Action = BackTestBotRun
            };
            worker.Start();
        }

        public static void BackTestBotRun(Worker worker, object? obj)
        {
            try
            {
                //var bot = new BackTestBot(worker);
                //var result = bot.Run();
                //DispatcherService.Invoke(() =>
                //{
                //    progressView.Hide();
                //});

                //var path = GPath.Desktop.Down("MarinerX", $"BackTestBot_{DateTime.Now.ToStandardFileName()}.txt");
                //GFile.Write(path, result);

                //GProcess.Start(path);
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

        record ChartDataType(string symbol, KlineInterval interval);

        public static void LoadChartDataEvent(object? sender, EventArgs e, string symbol, KlineInterval interval)
        {
            progressView.Show();
            var worker = new Worker()
            {
                ProgressBar = progressView.ProgressBar,
                Action = LoadChartData,
                Arguments = new ChartDataType(symbol, interval)
            };
            worker.Start();
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
                DispatcherService.Invoke(() =>
                {
                    progressView.Hide();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit(object? sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
