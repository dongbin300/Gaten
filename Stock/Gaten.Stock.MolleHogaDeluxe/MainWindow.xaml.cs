using Gaten.Net.Windows;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gaten.Stock.MolleHogaDeluxe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum ItemType { Stock, Coin }

        System.Timers.Timer timer = new System.Timers.Timer(5000);

        public MainWindow()
        {
            InitializeComponent();

            Opacity = 0.5;
            MenuRate5.IsChecked = true;

            timer.Elapsed += Timer_Elapsed;

        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            // 개장시간(9:00~15:30)에는 5초마다 새로고침, 이외는 10분마다 새로고침
            if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 15 ||
                DateTime.Now.Hour == 15 && DateTime.Now.Minute <= 30)
            {
                timer.Interval = 5000;
            }
            else
            {
                timer.Interval = 600000;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            IntPtr windowHandle = new WindowInteropHelper(this).Handle;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                WinApi.ReleaseCapture();
                WinApi.SendMessage(windowHandle, WinApi.WM_NCLBUTTONDOWN, WinApi.HT_CAPTION, 0);
            }
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainContextMenu.Visibility = Visibility.Visible;
        }

        private void MenuInitialize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuTransparencyRate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not MenuItem menuItem)
            {
                return;
            }

            var opacity = int.Parse((string)menuItem.Header) / 10.0;
            Opacity = opacity;

            MenuRate1.IsChecked = false;
            MenuRate2.IsChecked = false;
            MenuRate3.IsChecked = false;
            MenuRate4.IsChecked = false;
            MenuRate5.IsChecked = false;
            MenuRate6.IsChecked = false;
            MenuRate7.IsChecked = false;
            MenuRate8.IsChecked = false;
            MenuRate9.IsChecked = false;
            MenuRate10.IsChecked = false;
            menuItem.IsChecked = true;
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        
    }
}
