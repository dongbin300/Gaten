using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Interop;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Gaten.Net.Wpf;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);

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

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() =>
            {
                Process[] processes = Process.GetProcessesByName("Gaten.Study.TestWpf");

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
    }
}
