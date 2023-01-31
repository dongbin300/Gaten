using Gaten.Net.Windows;
using Gaten.Net.Wpf;
using Gaten.Stock.MarinerX.Apis;

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace Gaten.Stock.MarinerX.Views
{
    /// <summary>
    /// PositionMonitorView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PositionMonitorView : Window
    {
        private string symbol = string.Empty;
        private int interval = 15;
        private System.Timers.Timer timer = new System.Timers.Timer();

        public PositionMonitorView()
        {
            InitializeComponent();
            Left = 0;
            Top = 0;

            var hWnd = new WindowInteropHelper(this).Handle;
            WinApi.SetWindowPos(hWnd, HWND.TopMost, 0, 0, 0, 0, SWP.NOMOVE | SWP.NOSIZE);
        }

        public void Init(string symbol, int interval)
        {
            this.symbol = symbol;
            this.interval = interval;

            SymbolText.Text = symbol;
            timer.Interval = interval * 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var info = BinanceClientApi.GetPositioningInformation(symbol);
            foreach (var item in info)
            {
                var margin = item.EntryPrice * item.Quantity / item.Leverage;
                var upnlPer = item.UnrealizedPnl / margin * 100;
                DispatcherService.Invoke(() =>
                {
                    SymbolText.Text = item.Symbol;
                    PnlText.Foreground = item.UnrealizedPnl >= 0 ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97));
                    PnlText.Text = (item.UnrealizedPnl >= 0 ? "+" : "") + decimal.Round(item.UnrealizedPnl, 2);
                    //PnlPercentText.Foreground = upnlPer >= 0 ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97));
                    //PnlPercentText.Text = (upnlPer >= 0 ? "+" : "") + decimal.Round(upnlPer, 2) + "%";
                });
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            var window = (Window)sender;
            window.Topmost = true;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPlus)
            {
                SymbolText.FontSize++;
                PnlText.FontSize++;
            }
            else if (e.Key == Key.OemMinus)
            {
                SymbolText.FontSize--;
                PnlText.FontSize--;
            }
        }
    }
}
