using Gaten.Windows.MintPandaConsole.Contents;
using Gaten.Windows.MintPandaConsole.Models;
using Gaten.Windows.MintPandaConsole.Utils;

using System.Text.Json;

namespace Gaten.Windows.MintPandaConsole
{
    /// <summary>
    /// 뒤로 가기 ESC
    /// 종료 exit
    /// 모니터 모드 m - 시계, 날씨, 바이낸스 잔고
    /// 수면모드 . - 시계
    /// 바이낸스 잔고 b
    /// 날씨 w
    /// 체크리스트 c
    /// 운세 u
    /// 사전 d [word]
    /// 번역 t [k|e|j|c] [sentence]
    /// 패스워드 매니저 p [keyword], 등록은 지원안함
    /// 랜덤 3종 r [n|e|h] [n?min-max]
    /// </summary>
    internal class Program
    {
        static bool isExit = false;
        static bool isSleep = false;
        static bool isMonitor = false;
        static bool isBinanceBalance = false;
        static WeatherModel weatherBuffer = default!;
        static readonly List<Account> accounts = new();
        static System.Timers.Timer mainTimer = new System.Timers.Timer(1000);

        static void Main(string[] args)
        {
            WebCrawler.Open();
            BinanceManager.Init();
            CheckListManager.Init();
            mainTimer.Elapsed += MainTimer_Elapsed;
            mainTimer.Start();
            LoadPasswordData();
            weatherBuffer = GetWeather();

            while (true)
            {
                try
                {
                    if (isSleep || isMonitor || isBinanceBalance)
                    {
                        var key = Console.ReadKey(false);
                        if (key.Key == ConsoleKey.Escape)
                        {
                            isSleep = false;
                            isMonitor = false;
                            isBinanceBalance = false;

                            Console.Clear();
                            continue;
                        }
                    }

                    Console.Write("> ");
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        continue;
                    }
                    var inputs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (inputs.Length == 1)
                    {
                        switch (inputs[0].ToLower())
                        {
                            case "exit":
                                isExit = true;
                                break;

                            case "?":
                                Console.WriteLine("Help > ?");
                                Console.WriteLine("Version > v");
                                Console.WriteLine("Monitor Off [ESC]");
                                Console.WriteLine("MPC Off > exit");
                                Console.WriteLine("Sleep Mode > .");
                                Console.WriteLine("Monitor Mode > m");
                                Console.WriteLine("Binance Balance > b");
                                Console.WriteLine("Weather > w");
                                Console.WriteLine("Checklist > c");
                                Console.WriteLine("Unse > u");
                                Console.WriteLine("Dictionary > d [word]");
                                Console.WriteLine("Translation > t [k|e|j|c] [sentence]");
                                Console.WriteLine("Password > p [keyword]");
                                Console.WriteLine("Random > r [n|e|h] [n?min-max]");
                                break;

                            case "v":
                                Console.WriteLine("v1.1.1");
                                break;

                            case ".":
                                isSleep = true;
                                break;

                            case "m":
                                isMonitor = true;
                                break;

                            case "b":
                                isBinanceBalance = true;
                                break;

                            case "w":
                                DisplayWeather(weatherBuffer);
                                break;

                            case "u":
                                GetUnse();
                                break;

                            case "c":
                                GetCheckList();
                                break;
                        }

                        if (isExit)
                        {
                            break;
                        }
                    }
                    else
                    {
                        switch (inputs[0].ToLower())
                        {
                            case "d":
                                GetDictionary(inputs[1]);
                                break;

                            case "t":
                                GetTranslation(inputs[1].ToLower(), inputs[2]);
                                break;

                            case "p":
                                GetPasswordData(inputs[1]);
                                break;

                            case "r":
                                switch (inputs[1].ToLower())
                                {
                                    case "n":
                                        var min = int.Parse(inputs[2].Split('-')[0].Trim());
                                        var max = int.Parse(inputs[2].Split('-')[1].Trim());
                                        GetRandomNumber(min, max);
                                        break;

                                    case "e":
                                    case "w":
                                        GetRandomWord();
                                        break;

                                    case "h":
                                        GetRandomHanja();
                                        break;
                                }
                                break;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        static void MainTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                var now = DateTime.Now;
                if (now.Minute == 1 && now.Second == 0) // 매시 1분
                {
                    weatherBuffer = GetWeather();
                    BinanceManager.CalculateUsdKrw();
                }

                /* 수면 모드 */
                if (isSleep)
                {
                    Console.Clear();
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd dddd"));
                    Console.WriteLine(DateTime.Now.ToString("HH:mm"));
                }

                /* 모니터 모드 */
                if (isMonitor)
                {
                    Console.Clear();
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd dddd"));
                    Console.WriteLine(DateTime.Now.ToString("HH:mm"));
                    DisplayWeather(weatherBuffer);
                    (var balance, var income) = BinanceManager.GetBinanceBalance(false);
                    var formatString = "#,###";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(balance.ToString(formatString) + " ");
                    Console.ForegroundColor = income >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(income.ToString(formatString));
                    Console.ForegroundColor = ConsoleColor.White;
                }

                /* 바이낸스 잔고 */
                if (isBinanceBalance)
                {
                    (var balance, var income) = BinanceManager.GetBinanceBalance(false);
                    var formatString = "#,###";
                    //var formatString = isUsdt ? "#,###.##" : "#,###";
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(balance.ToString(formatString) + " ");
                    Console.ForegroundColor = income >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(income.ToString(formatString));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
            catch
            {
            }
        }

        #region Weather
        static void DisplayWeather(WeatherModel weather)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{weather.Temperature} {weather.Weather} ");
            Console.ForegroundColor = weather.Mise.Contains("좋음") ? ConsoleColor.Green : weather.Mise.Contains("나쁨") ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(weather.Mise);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" / ");
            Console.ForegroundColor = weather.Chomise.Contains("좋음") ? ConsoleColor.Green : weather.Chomise.Contains("나쁨") ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(weather.Chomise);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static WeatherModel GetWeather()
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

                return new WeatherModel(currentTemperature, currentWeather, mise, chomise);
            }
            catch
            {
                return new WeatherModel("WEATHER ERROR", "", "", "");
            }
        }
        #endregion

        #region Unse
        static void GetUnse()
        {
            try
            {
                WebCrawler.SetUrl($"https://www.ytn.co.kr/_ln/0121_{DateTime.Now:yyyyMMdd}0000000001");

                string[] splitSource = WebCrawler.Source.Substring(WebCrawler.Source.IndexOf("[개띠]"), 500).Split(new string[] { "<br />" }, StringSplitOptions.RemoveEmptyEntries);

                var allDog = splitSource[1].Replace("\r\n", "").Replace("\n", "");
                var dog94 = splitSource[6].Replace("1994년생, ", "").Replace("\r\n", "").Replace("\n", "");

                Console.WriteLine($"{allDog}  /  {dog94}");
            }
            catch
            {
                Console.WriteLine("운세 가져오기 실패");
            }
        }
        #endregion

        #region Dictionary
        static void GetDictionary(string keyword)
        {
            WebCrawler.SetUrl($"https://dict.naver.com/search.nhn?dicQuery={keyword}&query={keyword}&target=dic&ie=utf8&query_utf=&isOnlyViewEE=");
            var nodes = WebCrawler.SelectNodes("//dl[@class='dic_search_result']/dd");
            foreach (var node in nodes)
            {
                Console.WriteLine(
                    node.InnerText.Trim()
                    .Replace("\t ", "")
                    .Replace("\t", "")
                    .Replace("\r\n", ""));
            }
        }
        #endregion

        #region Translation
        static void GetTranslation(string language, string input)
        {
            if (input.Length < 1)
            {
                Console.WriteLine("No Data");
                return;
            }

            string languageQuery = language switch
            {
                "k" => "&tl=ko",
                "e" => "&tl=en",
                "j" => "&tl=ja",
                "c" => "&tl=zh-CN",
                _ => ""
            };

            string url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto" + languageQuery + "&dt=t&dj=1&q=" + input;
            WebCrawler.SetUrl(url);
            var result = JsonSerializer.Deserialize<Translation_JsonObject>(WebCrawler.Source) ?? default!;
            var translatedText = string.Join(" ", result.sentences.Select(s => s.trans));

            if (string.IsNullOrEmpty(translatedText))
            {
                return;
            }

            Console.WriteLine(translatedText);
        }

        record ModelSpecification();

        record ModelTracking(string checkpoint_md5, string launch_doc);

        record TranslationEngineDebugInfo(ModelTracking model_tracking);

        record Sentence
            (string trans, string orig, int backend, IList<ModelSpecification> model_specification, IList<TranslationEngineDebugInfo> translation_engine_debug_info);

        record Spell();

        record Translation_JsonObject(IList<Sentence> sentences, string src, Spell spell);
        #endregion

        #region Password Manager
        static void LoadPasswordData()
        {
            string[] data = File.ReadAllLines("resources/pm.txt");

            accounts.Clear();
            foreach (string d in data)
            {
                string[] dd = d.Split('$');
                Account? account = new(dd[0], dd[1], dd[2], dd[3], dd[4], dd[5]);
                accounts.Add(account);
            }
        }

        static void GetPasswordData(string keyword)
        {
            List<Account>? filteredAccounts = accounts.Where(a => a.SerialData.ToLower().Contains(keyword.ToLower())).ToList();

            foreach (Account? account in filteredAccounts)
            {
                Console.WriteLine($"{account.Platform}, {account.Description}, {account.ID}, {account.Password}, {account.SecondPassword}, {account.AdditionalDescription}");
            }
        }
        #endregion

        #region Random
        #region Random Number
        static void GetRandomNumber(int min, int max)
        {
            Console.WriteLine(new Random().Next(min, max).ToString());
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
        static void GetRandomHanja()
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

                Console.WriteLine($"{hanja}{Environment.NewLine}U+{hex}{Environment.NewLine}{dok}");
            }
            catch
            {
                Console.WriteLine("한자 불러오기 실패");
            }
        }
        #endregion
        #region Random Word
        static void GetRandomWord()
        {
            try
            {
                WebCrawler.SetUrl("https://randomword.com/");
                string word = WebCrawler.SelectNode("div", "id", "random_word").InnerText;
                string meaning = WebCrawler.SelectNode("div", "id", "random_word_definition").InnerText;

                Console.WriteLine(word + Environment.NewLine + meaning);
            }
            catch
            {
                Console.WriteLine("단어 가져오기 실패");
            }
        }
        #endregion
        #endregion

        #region Check List
        static void GetCheckList()
        {
            var checkList = CheckListManager.GetTodayCheckLists();
            foreach (var item in checkList)
            {
                Console.ForegroundColor = item.IsNotComplete ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine(item.Content);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //private void CompleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        int index = CheckListDataGrid.SelectedIndex;
        //        var selectedCheckList = CheckListDataGrid.Items[index] as CheckListModel;

        //        if (selectedCheckList == null)
        //        {
        //            return;
        //        }

        //        selectedCheckList.IsNotComplete = false;
        //        RefreshCheckList();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        #endregion
    }
}