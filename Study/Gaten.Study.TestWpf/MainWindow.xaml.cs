using Gaten.Net.Windows;
using Gaten.Net.Wpf;

using System.Windows;
using System.Windows.Interop;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(200);

        public MainWindow()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() => { 
                WinApi.SetWindowPos(new WindowInteropHelper(this).Handle, HWND.TopMost, 0, 0, 0, 0, SWP.NOSIZE | SWP.NOMOVE);
            });
        }
    }
}
