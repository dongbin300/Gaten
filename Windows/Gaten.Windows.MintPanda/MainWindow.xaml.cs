using Gaten.Net.Network;
using Gaten.Net.Windows;
using Gaten.Net.Wpf;
using Gaten.Windows.MintPanda.Contents;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

using static Gaten.Net.Windows.WinAPI;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool taskBarWindowOpen = false;
        TaskBarWindow taskBarWindow = new();
        BillboardWindow billboardWindow = new();
        Init init = new();
        Monitor monitor = new();
        Backup backup = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            Opacity = 1.0;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            Opacity = 0.6;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            taskBarWindow.Close();
            billboardWindow.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            control.Content = monitor;

            taskBarWindow.Show();
            taskBarWindow.Visibility = Visibility.Collapsed;
            billboardWindow.Show();
            billboardWindow.Visibility = Visibility.Collapsed;

            WebCrawler.Open();
            RefreshPowerOption();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            //WinSplitGetProcessList();
            //SearchHardwarePrice();

            //WeatherText.Text = Weather.Get();
            //StockText.Text = Stock.Get();
            //RefreshCheckList();
            //UnseText.Text = Unse.Get();
            //DiskDriveText.Text = DiskDrive.Get();
            //RandomWordButton_Click(null, null);
            //RandomHanjaButton_Click(null, null);
        }

        private void ColorPickButton_Click(object sender, RoutedEventArgs e)
        {
            //ColorDialog.ShowDialog();
        }

        #region Power Option
        private void RefreshPowerOption()
        {
            PowerOptionBorder.BorderBrush = PowerOption.Get()?.Type switch
            {
                PowerType.Balance => new SolidColorBrush(Colors.LightGreen),
                PowerType.Save => new SolidColorBrush(Colors.Gray),
                _ => new SolidColorBrush(Colors.Red),
            };
        }

        private void PowerOptionButton_Click(object sender, RoutedEventArgs e)
        {
            var powerScheme = PowerOption.Get();
            var powerSchemeInfo = Cmd.Run("powercfg /l");

            switch (powerScheme?.Type)
            {
                case PowerType.Balance:
                    string? guid = powerSchemeInfo.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList().Find(s => s.Contains("절전"))?.Split(':', '(')[1].Trim();

                    Cmd.Run($"powercfg /s {guid}");
                    break;

                case PowerType.Save:
                    string? guid2 = powerSchemeInfo.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList().Find(s => s.Contains("균형 조정"))?.Split(':', '(')[1].Trim();

                    Cmd.Run($"powercfg /s {guid2}");
                    break;
            }

            RefreshPowerOption();
        }

        #endregion

        private void ShieldButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskBarWindowOpen)
            {
                taskBarWindow.Visibility = Visibility.Collapsed;
                taskBarWindowOpen = false;
            }
            else
            {
                taskBarWindow.Visibility = Visibility.Visible;
                taskBarWindowOpen = true;
            }
        }

        private void RegeditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NotepadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PasswordManagerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsoleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ReleaseCapture();
                SendMessage(new WindowInteropHelper(this).Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F1:
                    control.Content = init;
                    break;

                case Key.F2:
                    control.Content = monitor;
                    break;

                case Key.F3:
                    control.Content = backup;
                    break;

                default:
                    break;
            }
        }
    }
}
