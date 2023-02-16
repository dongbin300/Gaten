using Gaten.Net.Diagnostics;
using Gaten.Net.Extensions;
using Gaten.Net.Wpf;

using System;
using System.Diagnostics;
using System.Management;
using System.Reflection;
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
        bool isReboot = false;

        public SystemMonitorWindow()
        {
            try
            {
                InitializeComponent();

                Left = 0;
                Top = WindowsSystem.ScreenHeight - 80;

                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(SystemMonitorWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                var builder = new StringBuilder();
                if (isReboot && DateTime.Now.Minute == 59 && DateTime.Now.Second <= 30)
                {
                    builder.AppendLine($"{29 - DateTime.Now.Second}초 후 재부팅.");
                }

                (var memory, var cpu) = Usage();
                var memoryMb = Math.Round((double)memory / 1000000, 1);

                builder.AppendLine($"CPU: {cpu}%");
                builder.AppendLine($"MEM: {memoryMb}MB");

                DispatcherService.Invoke(() =>
                {
                    if (isReboot && DateTime.Now.Minute == 59 && DateTime.Now.Second == 30)
                    {
                        Application.Current.Shutdown();
                        System.Windows.Forms.Application.Restart();
                    }

                    SystemInfoText1.Text = builder.ToString();
                    SystemInfoText2.Text = builder.ToString();
                    SystemInfoText3.Text = builder.ToString();
                    SystemInfoText4.Text = builder.ToString();
                    SystemInfoText5.Text = builder.ToString();
                });
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(SystemMonitorWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private (long, double) Usage()
        {
            try
            {
                var processName = Process.GetCurrentProcess().ProcessName;
                var searcher = new ManagementObjectSearcher("root\\CIMV2", $"SELECT * FROM Win32_PerfFormattedData_PerfProc_Process WHERE Name = \'{processName}\'");
                foreach (var obj in searcher.Get())
                {
                    var memory = obj["WorkingSetPrivate"].Convert<long>();
                    var cpu = obj["PercentProcessorTime"].Convert<double>();

                    return (memory, cpu);
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(SystemMonitorWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
            return default!;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            try
            {
                var window = (Window)sender;
                window.Topmost = true;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(SystemMonitorWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
