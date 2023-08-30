using Gaten.Net.Wpf;

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Gaten.Windows.Magnifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        System.Timers.Timer refreshTimer = new System.Timers.Timer(500);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOACTIVATE = 0x0010;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        bool isFirst = true;

        int _width = 300;
        int _height = 30;
        int _x = 1800;
        int _y = 2100;

        public MainWindow()
        {
            InitializeComponent();
            SetWindowPosition();

            timer.Elapsed += Timer_Elapsed;
            //refreshTimer.Elapsed += RefreshTimer_Elapsed;
            timer.Start();
            //refreshTimer.Start();
        }

        private void SetWindowPosition()
        {
            Width = 1000;
            Height = 200;
            Left = 1400;
            Top = 50;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DispatcherService.Invoke(() =>
                {
                    SetWindowPosition();
                    Process[] processes = Process.GetProcessesByName("Magnifier");
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

                    var bitmap = new Bitmap(_width, _height);

                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(_x, _y, 0, 0, bitmap.Size);
                    }

                    image.Source = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                });
            }
            catch
            {
            }
        }
    }
}
