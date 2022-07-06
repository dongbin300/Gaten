using Gaten.Net.Data.Diagnostics;
using Gaten.Net.Data.IO;
using Gaten.Net.Extension;
using Gaten.Net.Network;
using Gaten.Net.Wpf;
using Gaten.Windows.MintPanda.Contents;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
        Action<string> action;

        string ClockText = string.Empty;
        string WeatherText = string.Empty;
        string DiskDriveText = string.Empty;
        string StockText = string.Empty;
        string UnseText = string.Empty;

        Go go = new();
        RandomHanja randomHanja = new();
        RandomWord randomWord = new();
        CheckList checkList = new();
        ColorPick colorPick = new();
        Dictionary dictionary = new();
        HardwarePrice hardwarePrice = new();
        RNG rng = new();
        Translation translation = new();
        WinSplit winSplit = new();
        TaskBarWindow taskBarWindow = new();
        #endregion

        #region Initialize
        public Monitor(Action<string> action)
        {
            InitializeComponent();
            InitContentWindow();

            this.action = action;
            RefreshPowerOption();

            WebCrawler.Open();
            DiskDriveText = DiskDrive.Get();
            HardwarePrice.Init();
            CheckList.Init();
            RNG.Init();
            RefreshPowerOption();
        }

        private void InitLazy()
        {
            WinSplit.GetProcessList();
            WeatherText = Weather.Get();
            StockText = Stock.Get();
            hardwarePrice.SearchHardwarePrice();
            checkList.RefreshCheckList();
            UnseText = Unse.Get();
            DiskDriveText = DiskDrive.Get();
            randomHanja.Refresh();
            randomWord.Refresh();
        }

        void InitContentWindow()
        {
            WindowUtil.InitWindow(go);
            WindowUtil.InitWindow(randomHanja);
            WindowUtil.InitWindow(randomWord);
            WindowUtil.InitWindow(checkList);
            WindowUtil.InitWindow(colorPick);
            WindowUtil.InitWindow(dictionary);
            WindowUtil.InitWindow(hardwarePrice);
            WindowUtil.InitWindow(rng);
            WindowUtil.InitWindow(translation);
            WindowUtil.InitWindow(winSplit);
            WindowUtil.InitWindow(taskBarWindow);
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.CheckVisibility(go, GoButton);
            WindowUtil.CheckVisibility(randomHanja, RandomHanjaButton);
            WindowUtil.CheckVisibility(randomWord, RandomWordButton);
            WindowUtil.CheckVisibility(checkList, CheckListButton);
            WindowUtil.CheckVisibility(colorPick, ColorPickButton);
            WindowUtil.CheckVisibility(dictionary, DictionaryButton);
            WindowUtil.CheckVisibility(hardwarePrice, HardwarePriceButton);
            WindowUtil.CheckVisibility(rng, RNGButton);
            WindowUtil.CheckVisibility(translation, TranslationButton);
            WindowUtil.CheckVisibility(winSplit, WinSplitButton);
            WindowUtil.CheckVisibility(taskBarWindow, CamoBarButton);
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
                RefreshMarqueeText();
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

        #region Billboard
        private void RefreshMarqueeText()
        {
            List<string> strings = new List<string>();

            strings.Add(ClockButton.IsChecked ?? true ? ClockText : "");
            strings.Add(WeatherButton.IsChecked ?? true ? WeatherText : "");
            strings.Add(DiskDriveButton.IsChecked ?? true ? DiskDriveText : "");
            strings.Add(StockButton.IsChecked ?? true ? StockText : "");
            strings.Add(UnseButton.IsChecked ?? true ? UnseText : "");

            action(string.Join("  ", strings));
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshMarqueeText();
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
            go.Close();
            randomHanja.Close();
            randomWord.Close();
            checkList.Close();
            colorPick.Close();
            dictionary.Close();
            hardwarePrice.Close();
            rng.Close();
            translation.Close();
            winSplit.Close();
            taskBarWindow.Close();
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
            GProcess.StartLocalExe("passwordmanager");
        }

        private void MintConsoleButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.StartLocalExe("windows.console");
        }
    }
}
