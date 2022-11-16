using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows;
using Gaten.Net.Wpf.Extensions;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            var handle = Process.GetProcessesByName("notepad")[0].MainWindowHandle;
            var sc = new ScreenCapture();
            var img = sc.CaptureWindow(handle);
            TopImage.Source = img.ToImageSource();
            sc.CaptureWindowToFile(handle, "test.png", ImageFormat.Png);
        }
    }
}
