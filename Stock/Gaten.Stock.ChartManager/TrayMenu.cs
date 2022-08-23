using Gaten.Net.IO;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.ChartManager.Apis;
using Gaten.Stock.ChartManager.Charts;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gaten.Stock.ChartManager
{
    internal class TrayMenu
    {
        /// <summary>
        /// 트레이 아이콘
        /// </summary>
        private NotifyIcon trayIcon;

        /// <summary>
        /// 트레이 메뉴
        /// </summary>
        private static ContextMenuStrip menuStrip = new();

        private static ProgressView progressView = new();

        private Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/ChartManager;component/Resources/chart2.ico")).Stream;

        public TrayMenu()
        {
            trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon(iconStream);
            trayIcon.Text = $"Chart Manager By Gaten";
            trayIcon.Visible = true;

            progressView = new ProgressView();
            progressView.Hide();

            RefreshMenu();
        }

        public void RefreshMenu()
        {
            menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add(new ToolStripMenuItem("차트 매니저 By Gaten"));
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add(new ToolStripMenuItem("Binance 심볼 데이터 수집", null, new EventHandler(GetBinanceSymbolDataEvent)));
            menuStrip.Items.Add(new ToolStripMenuItem("Binance 1분봉 데이터 수집", null, new EventHandler(GetBinanceCandleDataEvent)));
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add(new ToolStripMenuItem("Binance 1일봉 데이터 추출", null, new EventHandler(Extract1DCandleEvent)));
            menuStrip.Items.Add(new ToolStripSeparator());
            var symbols = LocalStorageApi.GetSymbols();
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
                menuStrip.Items.Add(new ToolStripMenuItem(symbol + " 데이터 로드", null, new EventHandler((sender, e) => LoadChartDataEvent(sender, e, symbol))));
            }
            menuStrip.Items.Add(new ToolStripMenuItem("종료", null, Exit));

            menuStrip.Items[0].Enabled = false;
            trayIcon.ContextMenuStrip = menuStrip;
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
                ChartLoader.ExtractCandle(Binance.Net.Enums.KlineInterval.OneDay, worker);
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
                var symbols = BinanceClientApi.GetExchangeInfo();

                GFile.WriteByArray(
                    GResource.BinanceFuturesDataPath.Down($"symbol_{DateTime.Now:yyyy-MM-dd}.txt"),
                    symbols);

                MessageBox.Show("바이낸스 심볼 데이터 수집 완료");
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

        public static void LoadChartDataEvent(object? sender, EventArgs e, string symbol)
        {
            progressView.Show();
            var worker = new Worker()
            {
                ProgressBar = progressView.ProgressBar,
                Action = LoadChartData,
                Arguments = symbol
            };
            worker.Start();
        }

        public static void LoadChartData(Worker worker, object? obj)
        {
            try
            {
                if (obj?.ToString() is not string str)
                {
                    return;
                }
                ChartLoader.Init(str, Binance.Net.Enums.KlineInterval.OneMinute, worker);
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
