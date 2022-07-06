using Gaten.Net.Network;

using System;
using System.Windows;
using System.Windows.Input;


namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BillboardWindow billboardWindow = new();
        Init init;
        Monitor monitor;
        Backup backup;

        public MainWindow()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double taskbarHeight = 40;

            Left = screenWidth - Width;
            Top = screenHeight - taskbarHeight - Height;

            init = new();
            monitor = new(RefreshMarquee);
            backup = new();
        }

        private void RefreshMarquee(string text)
        {
            billboardWindow.SetMarqueeText(text);
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            Opacity = 1.0;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            Opacity = 0.25;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            billboardWindow.Close();
            monitor.CloseWindow();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            control.Content = monitor;

            billboardWindow.Show();
            billboardWindow.Visibility = Visibility.Collapsed;

            WebCrawler.Open();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Environment.Exit(0);
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
