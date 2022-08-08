using System;
using System.Drawing;
using System.Windows.Forms;

using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.ChartManager.Apis;
using Gaten.Stock.ChartManager.Charts;

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

        private System.IO.Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/ChartManager;component/Resources/chart2.ico")).Stream;

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
            if(obj?.ToString() is not string str)
            {
                return;
            }
            ChartLoader.Init(str, Binance.Net.Enums.KlineInterval.OneMinute, worker);
            DispatcherService.Invoke(() =>
            {
                progressView.Hide();
            });
        }

        private void Exit(object? sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
