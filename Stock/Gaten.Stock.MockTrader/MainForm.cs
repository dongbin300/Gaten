using Binance.Net.Enums;

using Gaten.Stock.MockTrader.Api;
using Gaten.Stock.MockTrader.BinanceTrade;
using Gaten.Stock.MockTrader.BinanceTrade.TradeModels;
using Gaten.Stock.MockTrader.Chart;
using Gaten.Stock.MockTrader.Utils;

using System.Text;

namespace Gaten.Stock.MockTrader
{
    public partial class MainForm : Form
    {
        DateTime mockStartTime;
        StringBuilder builder;
        int c = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BinanceClientApi.Init();
            //Assets.Init();

            mockStartTime = DateTime.Parse(Path.GetFileNameWithoutExtension(new DirectoryInfo(Path.Combine(PathUtil.BinanceFuturesDataBasePath, "BTCUSDT")).GetFiles()[^1].FullName).Split('_')[1]);
            BinanceDataUpdateText.Text = "업데이트: " + mockStartTime.ToString("yyyy-MM-dd");

            StartYearComboBox.SelectedIndex = 3;
            StartMonthComboBox.SelectedIndex = 3;
            StartDayComboBox.SelectedIndex = 0;
            CandleIntervalComboBox.SelectedIndex = 0;
            StatusText.Text = "";

            var symbols = LocalStorageApi.GetSymbols();
            SymbolComboBox.DataSource = symbols;
            AllSymbolCheckBox.Checked = false;
            AllPeriodCheckBox.Checked = true;
        }

        (DateTime, int) GetPeriod()
        {
            if (AllPeriodCheckBox.Checked)
            {
                var startTime = DateTime.Parse(Path.GetFileNameWithoutExtension(new DirectoryInfo(Path.Combine(PathUtil.BinanceFuturesDataBasePath, SymbolComboBox.SelectedItem.ToString())).GetFiles()[0].FullName).Split('_')[1]);
                var endTime = DateTime.Parse(Path.GetFileNameWithoutExtension(new DirectoryInfo(Path.Combine(PathUtil.BinanceFuturesDataBasePath, SymbolComboBox.SelectedItem.ToString())).GetFiles()[^1].FullName).Split('_')[1]);

                return (
                    startTime,
                    (int)(endTime - startTime).TotalDays);
            }
            else
            {
                return (
                    new DateTime(int.Parse(StartYearComboBox.Text), int.Parse(StartMonthComboBox.Text), int.Parse(StartDayComboBox.Text)),
                    int.Parse(BackTestPeriodTextBox.Text));
            }
        }

        KlineInterval GetCandleInterval() => int.Parse(CandleIntervalComboBox.Text) switch
        {
            1 => KlineInterval.OneMinute,
            3 => KlineInterval.ThreeMinutes,
            5 => KlineInterval.FiveMinutes,
            15 => KlineInterval.FifteenMinutes,
            30 => KlineInterval.ThirtyMinutes,
            60 => KlineInterval.OneHour,
            120 => KlineInterval.TwoHour,
            240 => KlineInterval.FourHour,
            360 => KlineInterval.SixHour,
            480 => KlineInterval.EightHour,
            720 => KlineInterval.TwelveHour,
            1440 => KlineInterval.OneDay,
            _ => KlineInterval.OneMinute,
        };

        async void Trading()
        {
            builder = new();
            var tradeMarkets = new List<TradeMarket>();

            (var startDate, var dayCount) = GetPeriod();
            var candleInterval = GetCandleInterval();
            c = 0;

            if (AllSymbolCheckBox.Checked)
            {
                //SimulateProgressBar.Maximum = Assets.CoinSize.Count * dayCount;
                //foreach (var coin in Assets.CoinSize)
                //{
                //    try
                //    {
                //        var results = TradingCoin(coin.Key, startDate, dayCount, candleInterval);
                //        tradingResults.AddRange(results);
                //    }
                //    catch (FileNotFoundException)
                //    {
                //        continue;
                //    }
                //}
            }
            else
            {
                //SimulateProgressBar.Maximum = 25;
                try
                {
                    for (int up = 69; up < 70; up++)
                    {
                        for (int down = 30; down > 29; down--)
                        {
                            var tradeMarket = new TradeMarket(int.Parse(AmountTextBox.Text));

                            tradeMarket.Symbol = new Symbols.SymbolRange("BTCUSDT");
                            tradeMarket.CandleInterval = KlineInterval.OneMinute;
                            tradeMarket.TradePeriod = new DateTimes.Period(
                                new DateTime(2021, 1, 1),
                                new DateTime(2021, 6, 30));
                            tradeMarket.TradeModel = new RsiTradeModel(int.Parse(DivisionRateTextBox.Text), up, down);

                            tradeMarkets.Add(tradeMarket);
                        }
                    }

                    var tasks = new List<Task<List<TradingResult>>>();
                    foreach (var market in tradeMarkets)
                    {
                        tasks.Add(market.RunAsync(TradeLogCheckBox.Checked, DayLogCheckBox.Checked));
                    }

                    var result = await Task.WhenAll(tasks);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            builder.AppendLine();
            //builder.AppendLine($"{startDate:yyyy-MM-dd} ~ {startDate.AddDays(dayCount - 1):yyyy-MM-dd} 백테스트 결과");
            //builder.AppendLine($"최저: {tradingResults.Min(r => r.EstimatedAssets)} USDT ({MathUtil.POE(Assets.Seed, tradingResults.Min(r => r.EstimatedAssets))})");
            //builder.AppendLine($"최고: {tradingResults.Max(r => r.EstimatedAssets)} USDT ({MathUtil.POE(Assets.Seed, tradingResults.Max(r => r.EstimatedAssets))})");
            //builder.AppendLine($"평균: {tradingResults.Average(r => r.EstimatedAssets)} USDT ({MathUtil.POE(Assets.Seed, tradingResults.Average(r => r.EstimatedAssets))})");
            //builder.AppendLine($"전적: {tradingResults.Count(r => r.EstimatedAssets > Assets.Seed)}승 {tradingResults.Count(r => r.EstimatedAssets < Assets.Seed)}패 {tradingResults.Count(r => r.EstimatedAssets == Assets.Seed)}무");

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MockTrader", $"MockTrader_{DateTime.Now:yyyyMMddHHmmss}.txt");
            File.WriteAllText(filePath, builder.ToString());

            Net.Data.Process.Start(filePath);

            Close();
        }

        List<TradingResult> TradingCoin(string symbol, DateTime startDate, int dayCount, KlineInterval candleInterval)
        {
            /* Init Assets */
            //Assets.Amount = Assets.Seed = double.Parse(AmountTextBox.Text);
            //Assets.DivisionRate = double.Parse(DivisionRateTextBox.Text);
            List<TradingResult> results = new List<TradingResult>();

            /* Simulate Trading */
            try
            {
                for (int d = 0; d < dayCount; d++)
                {
                    var result = new TradingResult("1", startDate); // TradeMarket.SimulateTrading(symbol, startDate.AddDays(d), candleInterval);
                    if (TradeLogCheckBox.Checked)
                    {
                        builder.Append(result.ToTradeString());
                    }
                    if (DayLogCheckBox.Checked || d == dayCount - 1)
                    {
                        builder.AppendLine(result.ToString());
                    }
                    StatusText.Text = result.ToString();
                    SimulateProgressBar.Value = ++c;
                    results.Add(result);
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }

            return results;
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            BtcusdtChartManager.Init(GetCandleInterval());
            Trading();
        }

        private void GetSymbolDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                var symbols = BinanceClientApi.GetExchangeInfo();

                File.WriteAllText(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "BinanceFuturesData",
                $"symbol_{DateTime.Now:yyyy-MM-dd}.txt"),
                string.Join("\r\n", symbols));

                StatusText.Text = "심볼 데이터 수집 완료";
            }
            catch (Exception ex)
            {
                StatusText.Text = ex.Message;
            }
        }

        private void GetCandleDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                var symbols = BinanceClientApi.GetExchangeInfo();

                foreach (var symbol in symbols)
                {
                    var startTime = mockStartTime;
                    var count = 100;

                    var symbolPath = Path.Combine(PathUtil.BinanceFuturesDataBasePath, symbol);

                    if (!Directory.Exists(symbolPath))
                    {
                        Directory.CreateDirectory(symbolPath);
                    }

                    for (int i = 0; i < count; i++)
                    {
                        var standardTime = startTime.AddDays(i);

                        if (DateTime.Compare(standardTime, DateTime.Today) > 0)
                        {
                            break;
                        }

                        StatusText.Text = $"{symbol}, {standardTime:yyyy-MM-dd}";

                        BinanceClientApi.GetCandleDataForOneDay(symbol, standardTime);

                        Thread.Sleep(500);
                    }
                }

                StatusText.Text = "1분봉 데이터 수집 완료";
            }
            catch (Exception ex)
            {
                StatusText.Text = ex.Message;
            }
        }

        private void AllSymbolCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SymbolComboBox.Enabled = !AllSymbolCheckBox.Checked;
        }

        private void AllPeriodCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            StartYearComboBox.Enabled = !AllPeriodCheckBox.Checked;
            StartMonthComboBox.Enabled = !AllPeriodCheckBox.Checked;
            StartDayComboBox.Enabled = !AllPeriodCheckBox.Checked;
            BackTestPeriodTextBox.Enabled = !AllPeriodCheckBox.Checked;
        }
    }
}