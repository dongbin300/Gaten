using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Net.Network;
using Gaten.Net.Wpf;
using Gaten.Windows.MintPanda.Contents;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.Collections.Generic;
using System.Reflection;
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
        Action<List<string>> action = default!;

        string ClockText = string.Empty;
        string WeatherText = string.Empty;
        string DiskDriveText = string.Empty;
        string StockText = string.Empty;
        string UnseText = string.Empty;
        #endregion

        #region Initialize
        public Monitor(Action<List<string>> action)
        {
            try
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
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void InitStatus()
        {
            try
            {
                ClockButton.IsChecked = true;
                WeatherButton.IsChecked = true;
                DiskDriveButton.IsChecked = true;
                StockButton.IsChecked = true;
                UnseButton.IsChecked = true;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void InitLazy()
        {
            try
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
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is not ToggleButton toggleButton)
                {
                    return;
                }

                switch (toggleButton.Tag)
                {
                    case "201": WindowUtil.ToggleWindow<CheckList>(CheckListButton); break;
                    case "202": WindowUtil.ToggleWindow<TaskBarWindow>(CamoBarButton); break;
                    case "203": WindowUtil.ToggleWindow<Go>(GoButton); break;
                    case "204": WindowUtil.ToggleWindow<HardwarePrice>(HardwarePriceButton); break;
                    case "205": WindowUtil.ToggleWindow<RandomHanja>(RandomHanjaButton); break;
                    case "206": WindowUtil.ToggleWindow<RandomWord>(RandomWordButton); break;
                    case "207": WindowUtil.ToggleWindow<RNG>(RNGButton); break;
                    case "208": WindowUtil.ToggleWindow<Translation>(TranslationButton); break;
                    case "209": WindowUtil.ToggleWindow<WinSplit>(WinSplitButton); break;
                    case "210": WindowUtil.ToggleWindow<ColorPick>(ColorPickButton); break;
                    case "211": WindowUtil.ToggleWindow<Dictionary>(DictionaryButton); break;
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonGrid.Columns = (int)(WindowsSystem.ScreenWidth / 49);

                DiskDriveText = DiskDrive.Get();
                HardwarePrice.Init();
                CheckList.Init();
                RNG.Init();

                MainTimer.Elapsed += MainTimer_Elapsed;
                MainTimer.Start();
                ClockTimer.Elapsed += ClockTimer_Elapsed;
                ClockTimer.Start();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
        #endregion

        #region Timer
        private void ClockTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DispatcherService.Invoke(() =>
                {
                    ClockText = Clock.Get();
                    RefreshInfoText();
                });
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void MainTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
        #endregion

        #region Billboard & Monitor
        private void RefreshInfoText()
        {
            try
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
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RefreshInfoText();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
        #endregion

        #region Power Option
        private void RefreshPowerOption()
        {
            try
            {
                PowerOptionButton.IsChecked = PowerOption.Get()?.Type switch
                {
                    PowerType.Balance => true,
                    PowerType.Save => false,
                    _ => false,
                };
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void PowerOptionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PowerOption.Switch();
                RefreshPowerOption();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
        #endregion

        #region Application
        public void CloseWindow()
        {
            try
            {
                for (int i = 1; i <= 30; i++)
                {
                    WindowUtil.CloseWindow(string.Format("2{0:00}", i));
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InitLazy();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
                System.Windows.Forms.Application.Restart();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
        #endregion

        private void RegistryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GProcess.Start(GPath.Windows.Down("regedit.exe"));
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void NotepadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GProcess.Start(GPath.Windows.Down("notepad.exe"));
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void PasswordManagerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GProcess.StartExe("passwordmanager");
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void MintConsoleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GProcess.StartExe("windows.console");
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void TaskmgrButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GProcess.Start(GPath.System.Down("taskmgr.exe"));
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void EventViewerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GProcess.Start(GPath.System.Down("eventvwr.msc"));
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Monitor), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
