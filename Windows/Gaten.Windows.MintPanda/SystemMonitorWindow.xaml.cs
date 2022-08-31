using Gaten.Net.Extensions;
using Gaten.Net.Wpf;

using System;
using System.Diagnostics;
using System.Management;
using System.Text;
using System.Windows;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// SystemMonitorWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SystemMonitorWindow : Window
    {
        System.Timers.Timer timer = new(500);

        public SystemMonitorWindow()
        {
            InitializeComponent();

            Left = WindowsSystem.ScreenWidth - Width;
            Top = 10;

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var builder = new StringBuilder();
            if (DateTime.Now.Minute == 59 && DateTime.Now.Second <= 30)
            {
                builder.AppendLine($"{29 - DateTime.Now.Second}초 후 자동으로 다시 시작됩니다.");
            }

            (var memory, var cpu) = Usage();
            var memoryMb = Math.Round((double)memory / 1000000, 1);

            builder.AppendLine($"CPU: {cpu}%");
            builder.AppendLine($"MEM: {memoryMb}MB");

            DispatcherService.Invoke(() =>
            {
                if (DateTime.Now.Minute == 59 && DateTime.Now.Second == 30)
                {
                    Application.Current.Shutdown();
                    System.Windows.Forms.Application.Restart();
                }

                SystemInfoText.Text = builder.ToString();
            });
        }

        private (long, double) Usage()
        {
            var processName = Process.GetCurrentProcess().ProcessName;
            var searcher = new ManagementObjectSearcher("root\\CIMV2", $"SELECT * FROM Win32_PerfFormattedData_PerfProc_Process WHERE Name = \'{processName}\'");
            foreach (var obj in searcher.Get())
            {
                var memory = obj["WorkingSetPrivate"].Convert<long>();
                var cpu = obj["PercentProcessorTime"].Convert<double>();

                return (memory, cpu);
            }

            return default!;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            var window = (Window)sender;
            window.Topmost = true;
        }
    }
}
