using Gaten.Net.Wpf;

using MySqlX.XDevAPI;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace Gaten.Windows.SuperMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(777);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOACTIVATE = 0x0010;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        bool isFirst = true;

        public MainWindow()
        {
            InitializeComponent();
            SetWindowPosition();

            BinanceManager.Init();
            XCommasManager.Init();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void SetWindowPosition()
        {
            Width = 270;
            Height = 180;
            Left = 0;
            Top = WindowsSystem.ScreenNoTaskBarHeight - Height;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                (var total, var available) = BinanceManager.GetBinanceBalance();
                (var longSize, var shortSize) = BinanceManager.GetBinancePosition();
                var todayProfit = XCommasManager.GetTodayRealizedProfit();
                var todayProfitString = todayProfit >= 0 ? "+" + todayProfit : todayProfit.ToString();
                var topRoe = XCommasManager.GetTopRoe();
                var topRoeString = topRoe >= 0 ? "+" + topRoe + "%" : topRoe + "%";

                DispatcherService.Invoke(() =>
                {
                    BtcusdtChangeText.Text = BinanceManager.BtcusdtChangePercent + "%";
                    BtcusdtChangeText.Foreground = BinanceManager.BtcusdtChangePercent >= 0 ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97));
                    PositionLongText.Text = (int)longSize + " ";
                    PositionShortText.Text = " " + (int)shortSize;
                    TodayProfitText.Foreground = todayProfit >= 0 ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97));
                    TodayProfitText.Text = $"{todayProfitString} ({topRoeString})";
                    TotalBalanceText.Text = total.ToString();
                    AvailableBalanceText.Text = available.ToString();
                    ClockText.Text = DateTime.Now.ToString("HH:mm");

                    SetWindowPosition();
                    Process[] processes = Process.GetProcessesByName("SuperMonitor");
                    if (processes.Length > 0)
                    {
                        IntPtr handle = processes[0].MainWindowHandle;
                        if (isFirst)
                        {
                            isFirst = false;
                            SetForegroundWindow(handle);
                        }
                        SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
                    }
                });
            }
            catch
            {
            }
        }
    }
}
