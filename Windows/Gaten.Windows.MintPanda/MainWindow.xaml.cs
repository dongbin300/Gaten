using Gaten.Net.Network;
using Gaten.Net.Windows;
using Gaten.Net.Windows.Forms;
using Gaten.Net.Wpf;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;

using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserActivityHook2 hook = new();
        Thread worker = default!;
        //BillboardWindow billboardWindow = new();
        MonitorWindow monitorWindow = new();
        SystemMonitorWindow systemMonitorWindow = new();
        Init init;
        Monitor monitor;
        Backup backup;

        public MainWindow()
        {
            InitializeComponent();
            Boot.RegisterStartProgram("MintPanda", Environment.ProcessPath ?? "");
            systemMonitorWindow.Show();

            Left = WindowsSystem.ScreenWidth;
            Top = WindowsSystem.ScreenNoTaskBarHeight - Height;

            hook.Start();
            worker = new Thread(new ThreadStart(InputWorker));
            worker.Start();
            init = new();
            monitor = new(RefreshInfoText);
            backup = new();
        }

        private void InputWorker()
        {
            hook.MouseDown += (sender, e) =>
            {
                if (e.X >= WindowsSystem.ScreenWidth - 30)
                {
                    var storyboard = new Storyboard();
                    var doubleAnimation = new DoubleAnimation(WindowsSystem.ScreenWidth, WindowsSystem.ScreenWidth - Width, new Duration(new TimeSpan(0, 0, 0, 0, 350)));
                    Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Window.Left)"));
                    storyboard.Children.Add(doubleAnimation);
                    BeginStoryboard(storyboard);
                }
            };

            hook.KeyDown += (sender, e) =>
            {
                if (e.KeyData == Keys.Oemtilde)
                {
                    monitorWindow.Visibility = Visibility.Visible;
                }
            };

            hook.KeyUp += (sender, e) =>
            {
                if (e.KeyData == Keys.Oemtilde)
                {
                    monitorWindow.Visibility = Visibility.Collapsed;
                }
            };
        }

        private void RefreshInfoText(List<string> strings)
        {
            //billboardWindow.SetMarqueeText(string.Join("  ", strings));
            monitorWindow.SetInfoText(string.Join("\r\n", strings));
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            var storyboard = new Storyboard();
            var doubleAnimation = new DoubleAnimation(WindowsSystem.ScreenWidth - Width, WindowsSystem.ScreenWidth, new Duration(new TimeSpan(0, 0, 0, 0, 350)));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Window.Left)"));
            storyboard.Children.Add(doubleAnimation);
            BeginStoryboard(storyboard);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //billboardWindow.Close();
            monitor.CloseWindow();
            monitorWindow.Close();
            systemMonitorWindow.Close();

            worker.Join();
            hook.Stop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            control.Content = monitor;
            //billboardWindow.Show();
            //billboardWindow.Visibility = Visibility.Collapsed;
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
