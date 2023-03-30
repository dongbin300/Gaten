using Gaten.Windows.MintPandaLinux.Contents;
using Gaten.Windows.MintPandaLinux.Models;
using Gaten.Windows.MintPandaLinux.Utils;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gaten.Windows.MintPandaLinux
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer mainTimer = new System.Timers.Timer(1000);
        private bool isSleep = false;
        private readonly List<Account> accounts = new();
        private bool isUsdt = true;

        public MainWindow()
        {
            InitializeComponent();
            mainTimer.Elapsed += MainTimer_Elapsed;
            mainTimer.Start();
            WebCrawler.Open();
            CheckListManager.Init();
            BinanceManager.Init();
            RefreshCheckList();

            IdComboBox.Items.Clear();
            _ = IdComboBox.Items.Add("gaten");
            _ = IdComboBox.Items.Add("dongbin30");
            _ = IdComboBox.Items.Add("dongbin300");
            _ = IdComboBox.Items.Add("dongbin30@naver.com");
            _ = IdComboBox.Items.Add("dongbin30@hanmail.net");
            _ = IdComboBox.Items.Add("dongbin300@gmail.com");

            PasswordComboBox.Items.Clear();
            _ = PasswordComboBox.Items.Add("n.d.d0n'b|n");
            _ = PasswordComboBox.Items.Add("d0n'b|n1011");
            _ = PasswordComboBox.Items.Add("d0n'b|n101!");
            _ = PasswordComboBox.Items.Add("d0n'b|n10!!");
            _ = PasswordComboBox.Items.Add("D0n'b|n1011");
            _ = PasswordComboBox.Items.Add("D0n'b|n10!!");
            _ = PasswordComboBox.Items.Add("d0n'b|n1194619");
            _ = PasswordComboBox.Items.Add("||q|l|l");
            _ = PasswordComboBox.Items.Add("||q|l|ls.m-_k");

            LoadPasswordData();
            WeatherText.Text = GetWeather();
            UnseText.Text = GetUnse();
        }

        private void MainTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var now = DateTime.Now;
            try
            {
                DispatcherService.Invoke(() =>
                {
                    if (isSleep)
                    {
                        SleepText.Text = $"{now.Hour:00}:{now.Minute:00}";
                    }
                    else
                    {
                        ClockText.Text = $"{now:yyyy-MM-dd ddd HH:mm:ss}";
                    }

                    /* 바이낸스 잔고 */
                    (var balance, var income) = BinanceManager.GetBinanceBalance(isUsdt);
                    var formatString = isUsdt ? "#,###.##" : "#,###";
                    BalanceText.Text = balance.ToString(formatString);
                    IncomeText.Text = income.ToString(formatString);
                    IncomeText.Foreground = income >= 0 ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97));

                    /* 매일 오전 5시 */
                    if (now.Hour == 5 && now.Minute == 0 && now.Second == 0)
                    {
                        var newCheckList = CheckListManager.GetTodayCheckLists();
                        CheckListDataGrid.Items.Clear();
                        foreach (var item in newCheckList)
                        {
                            item.IsNotComplete = true;
                            CheckListDataGrid.Items.Add(item);
                        }
                    }

                    /* 매시 1분 */
                    if (now.Minute == 1 && now.Second == 0)
                    {
                        WeatherText.Text = GetWeather();
                        BinanceManager.CalculateUsdKrw();
                    }

                    /* 매일 오전 0시 10분 */
                    if (now.Hour == 0 && now.Minute == 10 && now.Second == 0)
                    {
                        UnseText.Text = GetUnse();
                    }
                });
            }
            catch
            {
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #region Check List
        private void RefreshCheckList()
        {
            CheckListDataGrid.Items.Clear();
            var checkList = CheckListManager.GetTodayCheckLists();
            foreach (var item in checkList)
            {
                CheckListDataGrid.Items.Add(item);
            }
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = CheckListDataGrid.SelectedIndex;
            var selectedCheckList = CheckListDataGrid.Items[index] as CheckListModel;

            if (selectedCheckList == null)
            {
                return;
            }

            selectedCheckList.IsNotComplete = false;
            RefreshCheckList();
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

        #region Translation
        public string GetTranslation(Language language, string input)
        {
            string languageQuery = language switch
            {
                Language.Korean => "&tl=ko",
                Language.English => "&tl=en",
                Language.Japanese => "&tl=ja",
                Language.Chinese => "&tl=zh-CN",
                _ => ""
            };

            string url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto" + languageQuery + "&dt=t&dj=1&q=" + input;
            WebCrawler.SetUrl(url);
            var result = JsonSerializer.Deserialize<Translation_JsonObject>(WebCrawler.Source) ?? default!;
            var translatedText = string.Join(" ", result.sentences.Select(s => s.trans));

            return translatedText;
        }

        private void TranslationButton_Click(object sender, RoutedEventArgs e)
        {
            if (TranslationText1.Text.Length < 1)
            {
                return;
            }

            string text = GetTranslation((Language)TranslationComboBox.SelectedIndex, TranslationText1.Text);

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            TranslationText2.Text = text;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            TranslationText1.Text = "";
            TranslationText2.Text = "";
            TranslationText1.Focus();
        }

        public enum Language
        {
            Korean,
            English,
            Japanese,
            Chinese
        }

        public record ModelSpecification();

        public record ModelTracking(string checkpoint_md5, string launch_doc);

        public record TranslationEngineDebugInfo(ModelTracking model_tracking);

        public record Sentence
            (string trans, string orig, int backend, IList<ModelSpecification> model_specification, IList<TranslationEngineDebugInfo> translation_engine_debug_info);

        public record Spell();

        public record Translation_JsonObject(IList<Sentence> sentences, string src, Spell spell);
        #endregion

        #region Password Manager
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string pf = PlatformText.Text.Length < 1 ? " " : PlatformText.Text;
            string ad = DescriptionText.Text.Length < 1 ? " " : DescriptionText.Text;
            string id = IdText.Text.Length < 1 ? " " : IdText.Text;
            string pw = PasswordText.Text.Length < 1 ? " " : PasswordText.Text;
            string sp = SecondPasswordText.Text.Length < 1 ? " " : SecondPasswordText.Text;
            string dd = AdditionalDescriptionText.Text.Length < 1 ? " " : AdditionalDescriptionText.Text;

            Account? account = new(pf, ad, id, pw, sp, dd);

            Save(account);
            LoadPasswordData();

            PlatformText.Clear();
            DescriptionText.Clear();
            IdText.Clear();
            PasswordText.Clear();
            SecondPasswordText.Clear();
            AdditionalDescriptionText.Clear();
            IdComboBox.SelectedIndex = -1;
            PasswordComboBox.SelectedIndex = -1;
            _ = PlatformText.Focus();
        }

        private void IdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is not string str)
                {
                    return;
                }

                IdText.Text = str;
            }
        }

        private void PasswordComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is not string str)
                {
                    return;
                }

                PasswordText.Text = str;
            }
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = SearchText.Text.Length < 1 ? "" : SearchText.Text;

            List<Account>? filteredAccounts = accounts.Where(a => a.SerialData.ToLower().Contains(keyword.ToLower())).ToList();

            DataSource? source = new("Platform", "Description", "Id", "Password", "SecondPassword", "AdditionalDescription");
            foreach (Account? account in filteredAccounts)
            {
                source.AddRow(account.Platform, account.Description, account.ID, account.Password, account.SecondPassword, account.AdditionalDescription);
            }
            SearchDataGrid.ItemsSource = null;
            SearchDataGrid.ItemsSource = source.Data;
        }

        private void Save(Account account)
        {
            File.AppendAllText("pm.txt", Environment.NewLine + account.SerialData);
        }

        private void LoadPasswordData()
        {
            string[] data = File.ReadAllLines("pm.txt");

            accounts.Clear();
            foreach (string d in data)
            {
                string[] dd = d.Split('$');
                Account? account = new(dd[0], dd[1], dd[2], dd[3], dd[4], dd[5]);
                accounts.Add(account);
            }
        }
        #endregion

        #region Random
        #region Random Number
        private void RNGButton_Click(object sender, RoutedEventArgs e)
        {
            RNGResultText.Text = new Random().Next(int.Parse(RNGMin.Text), int.Parse(RNGMax.Text)).ToString();
        }
        #endregion
        #region Random Hanja
        /// <summary>
        /// U+3400 ~ U+4DBF (13312~19903) 6592
        /// U+4E00 ~ U+9FFF (19968~40959) 20992
        /// U+20000 ~ U+2A6DF (131072~173791) 42720
        /// U+2A700 ~ U+2B738 (173824~177976) 4153
        /// U+2B740 ~ U+2B81D (177984~178205) 222
        /// 74679
        /// </summary>
        /// <returns></returns>
        public static (string, string) GetRandomHanja()
        {
            try
            {
                int num = new Random(DateTime.Now.Millisecond).Next(74679);
                int convert =
                    num < 6592 ? num + 13312 :
                    num < 27584 ? num + 13376 :
                    num < 70304 ? num + 103488 :
                    num < 74457 ? num + 103520 :
                    num + 103527;
                string hex = convert.ToString("X");
                WebCrawler.SetUrl($"https://unicode-explorer.com/c/{hex}");
                string hanja = WebCrawler.SelectNode("div", "class", "char-big").InnerText;
                WebCrawler.SetUrl($"http://yoksa.aks.ac.kr/jsp/hh/HHBottom1.jsp?hh10_no=0-{hex}");
                var nodes = WebCrawler.SelectNodes("td", "align", "center");
                string dok = nodes != null && nodes.Count > 6 ? nodes[6].InnerText.Replace("&nbsp;", "") : string.Empty;

                return (hanja, "U+" + hex + "   " + dok);
            }
            catch
            {
                return ("에러", "에러");
            }
        }

        public void RefreshRandomHanja()
        {
            var a = GetRandomHanja();
            RandomHanjaText.Text = a.Item1;
            RandomHanjaMeanText.Text = a.Item2;
        }

        private void RandomHanjaButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshRandomHanja();
        }
        #endregion
        #region Random Word
        public static string GetRandomWord()
        {
            try
            {
                WebCrawler.SetUrl("https://randomword.com/");
                string word = WebCrawler.SelectNode("div", "id", "random_word").InnerText;
                string meaning = WebCrawler.SelectNode("div", "id", "random_word_definition").InnerText;

                return word + Environment.NewLine + meaning;
            }
            catch
            {
                return "에러";
            }
        }

        public void RefreshRandomWord()
        {
            RandomWordText.Text = GetRandomWord();
        }

        private void RandomWordButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshRandomWord();
        }
        #endregion
        #endregion

        #region Unse
        public string GetUnse()
        {
            try
            {
                WebCrawler.SetUrl($"https://www.ytn.co.kr/_ln/0121_{DateTime.Now:yyyyMMdd}0000000001");

                string[] splitSource = WebCrawler.Source.Substring(WebCrawler.Source.IndexOf("[개띠]"), 500).Split(new string[] { "<br />" }, StringSplitOptions.RemoveEmptyEntries);

                var allDog = splitSource[1].Replace("\r\n", "").Replace("\n", "");
                var dog94 = splitSource[6].Replace("1994년생, ", "").Replace("\r\n", "").Replace("\n", "");

                return $"{allDog}  /  {dog94}";
            }
            catch
            {
                return "운세 가져오기 실패";
            }
        }
        #endregion

        #region Weather
        public string GetWeather()
        {
            try
            {
                WebCrawler.SetUrl("https://weather.naver.com/today/02410105");
                var currentTemperature = WebCrawler.SelectNode("strong", "class", "current ").InnerText.Replace("현재 온도", "").Trim();
                var currentWeather = WebCrawler.SelectNode("span", "class", "weather").InnerText;
                //var currentWeatherStatus = WebCrawler.SelectNode("table", "class", "weather_table").InnerText;

                WebCrawler.SetUrl("https://weather.naver.com/air/02410105");
                var nodes = WebCrawler.SelectNodes("em", "class", "grade_value", true);
                var mise = nodes[0].InnerText.Replace("\n", "").Replace("\t", "");
                var chomise = nodes[1].InnerText.Replace("\n", "").Replace("\t", "");

                return $"{currentTemperature} {currentWeather} {mise} / {chomise}";
            }
            catch
            {
                return "날씨 가져오기 실패";
            }
        }
        #endregion

        #region Sleep
        private void SleepButton_Click(object sender, RoutedEventArgs e)
        {
            SleepGrid.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
            isSleep = true;
        }

        private void SleepGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                SleepGrid.Visibility = Visibility.Collapsed;
                MainGrid.Visibility = Visibility.Visible;
                isSleep = false;
            }
        }
        #endregion

        #region Binance Balance
        private void BinanceGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isUsdt = !isUsdt;
        }
        #endregion
    }
}
