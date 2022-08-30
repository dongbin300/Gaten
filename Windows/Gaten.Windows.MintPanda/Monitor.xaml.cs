using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Net.Network;
using Gaten.Net.Wpf;
using Gaten.Windows.MintPanda.Contents;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// Monitor.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Monitor : UserControl
    {
        #region Variables
        readonly System.Timers.Timer MainTimer = new(60000);
        readonly System.Timers.Timer ClockTimer = new(1000);
        Action<List<string>> action;

        string ClockText = string.Empty;
        string WeatherText = string.Empty;
        string DiskDriveText = string.Empty;
        string StockText = string.Empty;
        string UnseText = string.Empty;
        #endregion

        #region Initialize
        public Monitor(Action<List<string>> action)
        {
            InitializeComponent();
            InitStatus();

            this.action = action;
            RefreshPowerOption();

            WebCrawler.Open();
            DiskDriveText = DiskDrive.Get();
            HardwarePrice.Init();
            CheckList.Init();
            RNG.Init();
            RefreshPowerOption();
        }

        private void InitStatus()
        {
            ClockButton.IsChecked = true;
            WeatherButton.IsChecked = true;
            DiskDriveButton.IsChecked = true;
            StockButton.IsChecked = true;
            UnseButton.IsChecked = true;
        }

        private void InitLazy()
        {
            //winSplit.RefreshProcessList();
            WeatherText = Weather.Get();
            StockText = Stock.Get();
            //hardwarePrice.SearchHardwarePrice();
            //checkList.RefreshCheckList();
            UnseText = Unse.Get();
            DiskDriveText = DiskDrive.Get();
            //randomHanja.Refresh();
            //randomWord.Refresh();
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not ToggleButton toggleButton)
            {
                return;
            }

            WindowUtil.ToggleWindow<CheckList>(CheckListButton);
            WindowUtil.ToggleWindow<TaskBarWindow>(CamoBarButton);
            WindowUtil.ToggleWindow<Go>(GoButton);
            WindowUtil.ToggleWindow<HardwarePrice>(HardwarePriceButton);
            WindowUtil.ToggleWindow<RandomHanja>(RandomHanjaButton);
            WindowUtil.ToggleWindow<RandomWord>(RandomWordButton);
            WindowUtil.ToggleWindow<RNG>(RNGButton);
            WindowUtil.ToggleWindow<Translation>(TranslationButton);
            WindowUtil.ToggleWindow<WinSplit>(WinSplitButton);
            WindowUtil.ToggleWindow<ColorPick>(ColorPickButton);
            WindowUtil.ToggleWindow<Dictionary>(DictionaryButton);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DiskDriveText = DiskDrive.Get();
            HardwarePrice.Init();
            CheckList.Init();
            RNG.Init();

            MainTimer.Elapsed += MainTimer_Elapsed;
            MainTimer.Start();
            ClockTimer.Elapsed += ClockTimer_Elapsed;
            ClockTimer.Start();
        }
        #endregion

        #region Timer
        private void ClockTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() =>
            {
                ClockText = Clock.Get();
                RefreshInfoText();
            });
        }

        private void MainTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() =>
            {
                var now = DateTime.Now;

                /* 매시 1분 */
                if (now.Minute == 1)
                {
                    WeatherText = Weather.Get();
                    //RefreshHardwarePrice();
                }

                /* 평일 9~16시, 5분마다 */
                if (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (now.Hour >= 9 && now.Hour <= 16)
                    {
                        if (now.Minute % 5 == 0)
                        {
                            StockText = Stock.Get();
                        }
                    }
                }

                /* 매일 0시 10분 */
                if (now.Hour == 0 && now.Minute == 10)
                {
                    DiskDriveText = DiskDrive.Get();
                    UnseText = Unse.Get();
                }
            });
        }
        #endregion

        #region Billboard & Monitor
        private void RefreshInfoText()
        {
            var strings = new List<string>
            {
                ClockButton.IsChecked ?? true ? ClockText : "",
                WeatherButton.IsChecked ?? true ? WeatherText : "",
                DiskDriveButton.IsChecked ?? true ? DiskDriveText : "",
                StockButton.IsChecked ?? true ? StockText : "",
                UnseButton.IsChecked ?? true ? UnseText : ""
            };

            action(strings);
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshInfoText();
        }
        #endregion

        #region Power Option
        private void RefreshPowerOption()
        {
            PowerOptionButton.IsChecked = PowerOption.Get()?.Type switch
            {
                PowerType.Balance => true,
                PowerType.Save => false,
                _ => false,
            };
        }

        private void PowerOptionButton_Click(object sender, RoutedEventArgs e)
        {
            PowerOption.Switch();
            RefreshPowerOption();
        }
        #endregion

        #region Application
        public void CloseWindow()
        {
            for (int i = 1; i <= 30; i++)
            {
                WindowUtil.CloseWindow(string.Format("2{0:00}", i));
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            InitLazy();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Windows.Forms.Application.Restart();
        }
        #endregion

        private void RegistryButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.Windows.Down("regedit.exe"));
        }

        private void NotepadButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.Windows.Down("notepad.exe"));
        }

        private void PasswordManagerButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.StartExe("passwordmanager");
        }

        private void MintConsoleButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.StartExe("windows.console");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TaskmgrButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.System.Down("taskmgr.exe"));
        }

        private void EventViewerButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.System.Down("eventvwr.msc"));
        }
    }
}
