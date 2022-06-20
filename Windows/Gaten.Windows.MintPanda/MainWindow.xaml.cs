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
        readonly System.Timers.Timer MainTimer = new(60000);
        readonly System.Timers.Timer ClockTimer = new(1000);
        TaskBarWindow taskBarWindow = new TaskBarWindow();
        bool taskBarWindowOpen = false;

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
            Opacity = 0.5;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainTimer.Stop();
            ClockTimer.Stop();
            taskBarWindow.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainTimer.Elapsed += MainTimer_Elapsed;
            ClockTimer.Elapsed += ClockTimer_Elapsed;
            MainTimer.Start();
            ClockTimer.Start();

            WebCrawler.Open();
            DiskDriveText.Text = DiskDrive.Get();
            HardwarePrice.Init();
            CheckListCollection.Init();
            RNG.Init();
            RefreshPowerOption();

            //WinSplitHComboBox.SelectedIndex = 2;
            //WinSplitVComboBox.SelectedIndex = 2;
            TranslationComboBox.SelectedIndex = 1;

            taskBarWindow.Show();
            taskBarWindow.Visibility = Visibility.Collapsed;
        }

        private void MainTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() =>
            {
                var now = DateTime.Now;

                /* 매시 1분 */
                if (now.Minute == 1)
                {
                    WeatherText.Text = Weather.Get();
                    //RefreshHardwarePrice();
                }

                /* 평일 9~16시, 5분마다 */
                if (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (now.Hour >= 9 && now.Hour <= 16)
                    {
                        if (now.Minute % 5 == 0)
                        {
                            StockText.Text = Stock.Get();
                        }
                    }
                }

                /* 매일 0시 10분 */
                if (now.Hour == 0 && now.Minute == 10)
                {
                    DiskDriveText.Text = DiskDrive.Get();
                    UnseText.Text = Unse.Get();
                }
            });
        }

        private void ClockTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() =>
            {
                ClockText.Text = $"{DateTime.Now:yyyy'년' MMM d'일' dddd tt hh:mm:ss}";
            });
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            //WinSplitGetProcessList();
            WeatherText.Text = Weather.Get();
            StockText.Text = Stock.Get();
            //SearchHardwarePrice();
            RefreshCheckList();
            UnseText.Text = Unse.Get();
            DiskDriveText.Text = DiskDrive.Get();
            RandomWordButton_Click(null, null);
            RandomHanjaButton_Click(null, null);
        }

        private void ColorPickButton_Click(object sender, RoutedEventArgs e)
        {
            //ColorDialog.ShowDialog();
        }

        #region Baduk
        private void BadukButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((sender as Button)?.Content.ToString());
        }

        private void BadukButtonChange_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Clipboard.GetText().Replace("韩", "ㅁ").Replace("中", "韩").Replace("ㅁ", "中"));
        }
        #endregion

        #region Dictionary
        private void DictTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                WebCrawler.SetUrl($"https://dict.naver.com/search.nhn?dicQuery={DictTextBox.Text}&query={DictTextBox.Text}&target=dic&ie=utf8&query_utf=&isOnlyViewEE=");

                DictListBox.Items.Clear();
                var nodes = WebCrawler.SelectNodes("//dl[@class='dic_search_result']/dd");
                foreach (var node in nodes)
                {
                    DictListBox.Items.Add(
                        node.InnerText.Trim()
                        .Replace("\t ", "")
                        .Replace("\t", "")
                        .Replace("\r\n", ""));
                }
            }
        }
        #endregion

        #region CheckList Collection
        void RefreshCheckList()
        {
            CheckListListBox.Items.Clear();
            foreach (var checkList in CheckListCollection.CheckLists)
            {
                CheckListListBox.Items.Add(checkList);
            }
        }

        private void CheckListListBox_DoubleClick(object sender, EventArgs e)
        {
            var checkList = CheckListListBox.SelectedItem as CheckList;

            if (checkList == null)
            {
                return;
            }

            checkList.Start();
        }
        #endregion

        #region Hardware Price Monitoring
        //private void HardwareTextFileButton_Click(object sender, EventArgs e)
        //{
        //    HardwarePrice.SaveTextFile();
        //}

        //private void HardwarePriceDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    Process.Start(HardwarePrice.Devices[e.RowIndex].url);
        //}

        //public void SearchHardwarePrice()
        //{
        //    try
        //    {
        //        HardwarePriceDataGridView.Rows.Clear();

        //        foreach (Device device in HardwarePrice.Devices)
        //        {
        //            WebCrawler.SetUrl(device.url);
        //            var a = WebCrawler.SelectNode("//div[contains(@class,'lowest_price')]//em[@class='prc_c']");
        //            device.price = a == null ? "0" : a.InnerText;
        //            a = WebCrawler.SelectNode("//div[contains(@id,'lowPriceCash')]//em[@class='prc_c']");
        //            device.cashPrice = a == null ? "0" : a.InnerText;

        //            int gap = int.Parse(device.price.Replace(",", "")) - int.Parse(device.forePrice.Replace(",", ""));
        //            device.changePrice = gap >= 0 ? $"▲{Math.Abs(gap)}" : $"▼{Math.Abs(gap)}";
        //            gap = int.Parse(device.cashPrice.Replace(",", "")) - int.Parse(device.foreCashPrice.Replace(",", ""));
        //            device.changeCash = gap >= 0 ? $"▲{Math.Abs(gap)}" : $"▼{Math.Abs(gap)}";

        //            HardwarePriceDataGridView.Rows.Add(new string[] { device.name, device.price, device.changePrice });
        //        }
        //        HardwarePrice.first = false;
        //    }
        //    catch
        //    {

        //    }
        //}

        //public void RefreshHardwarePrice()
        //{
        //    // 이전에 조사했던 가격은 이전가격으로 설정
        //    foreach (Device device in HardwarePrice.Devices)
        //    {
        //        if (device.price == null) continue;
        //        device.forePrice = device.price;
        //        if (device.cashPrice == null) continue;
        //        device.foreCashPrice = device.cashPrice;
        //    }

        //    // 지우고
        //    HardwarePriceDataGridView.Rows.Clear();

        //    // 새롭게 조사
        //    SearchHardwarePrice();
        //}

        #endregion

        #region WinSplit
        //private void WinSplitGetProcessList()
        //{
        //    var processes = WinSplit.GetProcessList();
        //    WinSplitProcessComboBox.Items.Clear();
        //    foreach (var process in processes)
        //    {
        //        WinSplitProcessComboBox.Items.Add(process);
        //    }

        //    if (WinSplitProcessComboBox.Items.Count > 0)
        //    {
        //        WinSplitProcessComboBox.SelectedIndex = 0;
        //    }
        //}

        //private void WinSplitAllProcessCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    WinSplitProcessComboBox.Enabled = !WinSplitAllProcessCheckBox.Checked;
        //}

        //private void WinSplitButton_Click(object sender, EventArgs e)
        //{
        //    var processName = WinSplitAllProcessCheckBox.Checked ? "" : WinSplitProcessComboBox.Text;

        //    WinSplit.Split(
        //        int.Parse(WinSplitHComboBox.Text),
        //        int.Parse(WinSplitVComboBox.Text),
        //        WinSplitTaskBarNoneCheckBox.Checked,
        //        WinSplitAllProcessCheckBox.Checked,
        //        processName);
        //}

        //private void WinSplitSuperKillButton_Click(object sender, EventArgs e)
        //{
        //    if (WinSplitAllProcessCheckBox.Checked)
        //    {
        //        if (MessageBox.Show(this, "정말 모든 프로세스를 종료하시겠습니까?", "경고", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
        //        {
        //            return;
        //        }
        //    }

        //    var processName = WinSplitAllProcessCheckBox.Checked ? "" : WinSplitProcessComboBox.Text;

        //    WinSplit.SuperKill(WinSplitAllProcessCheckBox.Checked, processName);
        //}

        //private void WinSplitRefreshButton_Click(object sender, EventArgs e)
        //{
        //    WinSplitGetProcessList();
        //}

        #endregion

        #region Random Package
        private void RNGButton_Click(object sender, RoutedEventArgs e)
        {
            RNGResultText.Text = RNG.Get(int.Parse(RNGMin.Text), int.Parse(RNGMax.Text));
        }

        private void RandomWordButton_Click(object sender, RoutedEventArgs e)
        {
            RandomWordText.Text = RandomWord.Get();
        }

        private void RandomHanjaButton_Click(object sender, RoutedEventArgs e)
        {
            var a = RandomHanja.Get();
            RandomHanjaText.Text = a.Item1;
            RandomHanjaMeanText.Text = a.Item2;
        }
        #endregion

        #region Translation
        private void TranslationButton_Click(object sender, RoutedEventArgs e)
        {
            if (TranslationText1.Text.Length < 1)
            {
                return;
            }

            string text = Translation.Get((Language)TranslationComboBox.SelectedIndex, TranslationText1.Text);

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            TranslationText2.Text = text;
        }

        #endregion

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
    }
}
