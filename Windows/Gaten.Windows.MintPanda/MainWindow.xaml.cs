using Gaten.Net.Diagnostics;
using Gaten.Net.Network;
using Gaten.Net.Windows;
using Gaten.Net.Windows.Forms;
using Gaten.Net.Wpf;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

using Clipboard = System.Windows.Clipboard;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new();
        string memory = string.Empty;
        UserActivityHook2 hook = new();
        Thread worker = default!;
        //BillboardWindow billboardWindow = new();
        MonitorWindow monitorWindow = new();
        SystemMonitorWindow systemMonitorWindow = new();
        Init init = new();
        Monitor monitor = default!;
        Backup backup = new();
        bool windowAppear = false;

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                MintPandaPathManager.Init();

                Boot.RegisterStartProgram("MintPanda", Environment.ProcessPath ?? "");
                systemMonitorWindow.Show();

                Width = WindowsSystem.ScreenWidth;
                Height = 49;
                Left = 0;
                Top = WindowsSystem.ScreenHeight;

                hook.Start();
                worker = new Thread(new ThreadStart(InputWorker));
                worker.Start();
                init = new();
                monitor = new(RefreshInfoText);
                backup = new();

                timer.Interval = new TimeSpan(1000);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            try
            {
                var text = Clipboard.GetText();
                if (memory == text)
                {
                    return;
                }
                memory = text;

                try
                {
                    var node = JsonNode.Parse(text);

                    GProcess.Start("JsonViewer.exe", text
                        .Replace(' ', '醵')
                        .Replace('\"', '蹃')
                        .Replace('\'', '略')
                        );
                }
                catch (FormatException)
                {

                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
            {

            }
        }

        private void InputWorker()
        {
            try
            {
                hook.KeyDown += (sender, e) =>
                {
                    switch (e.KeyData)
                    {
                        case Keys.Z:
                            if (UserActivityHook2.PressingModifiers().HasFlag(Modifiers.Ctrl | Modifiers.Shift))
                            {
                                monitorWindow.Visibility = Visibility.Visible;
                            }
                            break;

                        case Keys.LWin:
                            if (UserActivityHook2.PressingModifiers().HasFlag(Modifiers.Ctrl | Modifiers.Alt))
                            {
                                WindowAppearAnimation();
                            }
                            break;
                    }
                };

                hook.KeyUp += (sender, e) =>
                {
                    switch (e.KeyData)
                    {
                        case Keys.Z:
                            monitorWindow.Visibility = Visibility.Collapsed;
                            break;

                        case Keys.LWin:
                            WindowDisappearAnimation();
                            break;
                    }
                };
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void WindowAppearAnimation()
        {
            try
            {
                if (!windowAppear)
                {
                    var storyboard = new Storyboard();
                    var doubleAnimation = new DoubleAnimation(WindowsSystem.ScreenHeight, WindowsSystem.ScreenHeight - WindowsSystem.TaskBarHeight - Height, new Duration(new TimeSpan(0, 0, 0, 0, 150)));
                    Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Window.Top)"));
                    storyboard.Children.Add(doubleAnimation);
                    BeginStoryboard(storyboard);
                    windowAppear = true;
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void WindowDisappearAnimation()
        {
            try
            {
                if (windowAppear)
                {
                    var storyboard = new Storyboard();
                    var doubleAnimation = new DoubleAnimation(WindowsSystem.ScreenHeight - WindowsSystem.TaskBarHeight - Height, WindowsSystem.ScreenHeight, new Duration(new TimeSpan(0, 0, 0, 0, 150)));
                    Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Window.Top)"));
                    storyboard.Children.Add(doubleAnimation);
                    BeginStoryboard(storyboard);
                    windowAppear = false;
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void RefreshInfoText(List<string> strings)
        {
            try
            {
                //billboardWindow.SetMarqueeText(string.Join("  ", strings));
                monitorWindow.SetInfoText(string.Join("\r\n", strings));
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                //WindowDisappearAnimation();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //billboardWindow.Close();
                monitor.CloseWindow();
                monitorWindow.Close();
                systemMonitorWindow.Close();

                worker.Join();
                hook.Stop();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                control.Content = monitor;
                //billboardWindow.Show();
                //billboardWindow.Visibility = Visibility.Collapsed;
                WebCrawler.Open();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    DragMove();
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MainWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
