using Binance.Net.Enums;

using Gaten.Net.Stock.MercuryTradingModel.Maths;
using Gaten.Net.Wpf;
using Gaten.Stock.MarinerX.Apis;
using Gaten.Stock.MarinerX.Charts;
using Gaten.Stock.MarinerX.Markets;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows;

namespace Gaten.Stock.MarinerX.Views
{
    public class QuoteMonitorData
    {
        public string Symbol { get; set; } = string.Empty;
        public string Uad { get; set; } = string.Empty;
        public double Score { get; set; }

        public QuoteMonitorData(string symbol, string uad, double score)
        {
            Symbol = symbol;
            Uad = uad;
            Score = score;
        }
    }

    public class QuoteRating
    {
        public string Symbol { get; set; } = string.Empty;
        public decimal Ma20 { get; set; }
        public decimal Ema112 { get; set; }
        public decimal Ema224 { get; set; }
        public decimal Volume { get; set; }
    }

    /// <summary>
    /// QuoteMonitorView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class QuoteMonitorView : Window
    {
        Timer timer = new Timer(500);
        Timer _timer;
        readonly KlineInterval DefaultInterval = KlineInterval.FiveMinutes;
        bool isRunning;
        List<QuoteRating> quoteRatings = new();
        readonly List<string> MonitorSymbolNames = new()
        {
            "AAVEUSDT",
            "ALGOUSDT",
            "ALICEUSDT",
            "ALPHAUSDT",
            "ANKRUSDT",
            "ANTUSDT",
            "APEUSDT",
            "API3USDT",
            "APTUSDT",
            "ARPAUSDT",
            "ARUSDT",
            "ATAUSDT",
            "ATOMUSDT",
            "AUDIOUSDT",
            "AVAXUSDT",
            "AXSUSDT",
            "BAKEUSDT",
            "BALUSDT",
            "BANDUSDT",
            "BATUSDT",
            "BELUSDT",
            "BLUEBIRDUSDT",
            "BLZUSDT",
            "BTCDOMUSDT",
            "BTCSTUSDT",
            "C98USDT",
            "CELRUSDT",
            "CHRUSDT",
            "CHZUSDT",
            "COMPUSDT",
            "COTIUSDT",
            "CRVUSDT",
            "CTKUSDT",
            "CTSIUSDT",
            "CVCUSDT",
            "DARUSDT",
            "DASHUSDT",
            "DEFIUSDT",
            "DENTUSDT",
            "DGBUSDT",
            "DOGEUSDT",
            "DOTUSDT",
            "DUSKUSDT",
            "DYDXUSDT",
            "EGLDUSDT",
            "ENJUSDT",
            "ENSUSDT",
            "ETCUSDT",
            "FETUSDT",
            "FILUSDT",
            "FLMUSDT",
            "FOOTBALLUSDT",
            "FTMUSDT",
            "FTTUSDT",
            "FXSUSDT",
            "GALAUSDT",
            "GALUSDT",
            "GMTUSDT",
            "GRTUSDT",
            "GTCUSDT",
            "HBARUSDT",
            "HNTUSDT",
            "HOOKUSDT",
            "HOTUSDT",
            "ICXUSDT",
            "IMXUSDT",
            "INJUSDT",
            "IOSTUSDT",
            "IOTAUSDT",
            "IOTXUSDT",
            "JASMYUSDT",
            "KAVAUSDT",
            "KNCUSDT",
            "KSMUSDT",
            "LDOUSDT",
            "LINAUSDT",
            "LITUSDT",
            "LPTUSDT",
            "LRCUSDT",
            "LUNA2USDT",
            "MAGICUSDT",
            "MANAUSDT",
            "MASKUSDT",
            "MATICUSDT",
            "MKRUSDT",
            "MTLUSDT",
            "NEARUSDT",
            "NKNUSDT",
            "OCEANUSDT",
            "OGNUSDT",
            "OMGUSDT",
            "ONEUSDT",
            "ONTUSDT",
            "OPUSDT",
            "PEOPLEUSDT",
            "QTUMUSDT",
            "REEFUSDT",
            "RENUSDT",
            "RLCUSDT",
            "ROSEUSDT",
            "RSRUSDT",
            "RUNEUSDT",
            "RVNUSDT",
            "SANDUSDT",
            "SFPUSDT",
            "SKLUSDT",
            "SNXUSDT",
            "SOLUSDT",
            "SRMUSDT",
            "STGUSDT",
            "STMXUSDT",
            "STORJUSDT",
            "SUSHIUSDT",
            "SXPUSDT",
            "THETAUSDT",
            "TLMUSDT",
            "TOMOUSDT",
            "TRBUSDT",
            "UNFIUSDT",
            "UNIUSDT",
            "VETUSDT",
            "WAVESUSDT",
            "WOOUSDT",
            "XEMUSDT",
            "XTZUSDT",
            "YFIUSDT",
            "ZECUSDT",
            "ZENUSDT",
            "ZILUSDT",
            "ZRXUSDT"
        };

        public QuoteMonitorView()
        {
            InitializeComponent();

            foreach (var symbol in LocalStorageApi.SymbolNames)
            {
                BinanceSocketApi.GetKlineUpdatesAsync(symbol, KlineInterval.FiveMinutes);
            }
            _timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
        }

        void SetupTimer()
        {
            DateTime now = DateTime.Now;
            var refreshMinute = now.Minute >= 55 ? 0 : (now.Minute / 5 + 1) * 5;
            DateTime oneAmTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, refreshMinute, 0);
            if (now > oneAmTime)
            {
                oneAmTime = oneAmTime.AddDays(1);
            }

            double tickTime = (oneAmTime - now).TotalMilliseconds;
            _timer = new Timer(tickTime);
            _timer.Elapsed += _Timer_Elapsed;
            _timer.Start();
        }

        private void _Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            // Recalculate when new candle appears
            if (isRunning)
            {
                quoteRatings = CalculatePast();
            }
            SetupTimer();
        }

        /// <summary>
        /// Calculate Indicators
        /// </summary>
        /// <param name="symbol"></param>
        private List<QuoteRating> CalculatePast()
        {
            var result = new List<QuoteRating>();
            foreach (var symbol in MonitorSymbolNames)
            {
                var quotes = BinanceClientApi.GetQuotes(symbol, DefaultInterval, null, null, 230);
                var ema = quotes.GetEma(224);
                var ma = quotes.GetSma(20);
                result.Add(new QuoteRating
                {
                    Symbol = symbol,
                    Ma20 = Convert.ToDecimal(ma.ElementAt(ma.Count() - 1).Sma),
                    Ema224 = Convert.ToDecimal(ema.ElementAt(ema.Count() - 1).Ema),
                    Volume = 2 * quotes[^2].Volume
                });
            }
            return result;
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                DispatcherService.Invoke(() =>
                {
                    ClockText.Text = DateTime.Now.ToString("HH:mm:ss");
                    var candleDurationRatio = (DateTime.Now.Minute % 5 * 60 + DateTime.Now.Second) / 300;

                    if (quoteRatings.Count <= 0)
                    {
                        return;
                    }

                    MonitorDataGrid.Items.Clear();

                    foreach (var symbol in MonitorSymbolNames)
                    {
                        var quote = QuoteFactory.GetQuote(symbol);
                        if (quote == null)
                        {
                            continue;
                        }

                        var rating = quoteRatings.Find(q => q.Symbol.Equals(symbol));
                        if (rating == null)
                        {
                            continue;
                        }

                        var roe = StockUtil.Roe(Net.Stock.MercuryTradingModel.Enums.PositionSide.Long, quote.Open, quote.Close);
                        var emaRoe = StockUtil.Roe(Net.Stock.MercuryTradingModel.Enums.PositionSide.Long, rating.Ema224, quote.Close);
                        var maRoe = StockUtil.Roe(Net.Stock.MercuryTradingModel.Enums.PositionSide.Long, rating.Ma20, quote.Close);

                        // long position detection
                        if (roe >= 0.3m && quote.Volume >= rating.Volume * candleDurationRatio && 
                        (emaRoe >= 0 && emaRoe <= 0.5m) &&
                        (maRoe >= 0 && maRoe <= 0.5m))
                        {
                            var uad = "+" + roe + "%";
                            var benchmark = BinanceMarket.Benchmarks.Find(b => b.Symbol.Equals(symbol));
                            if (benchmark == null)
                            {
                                continue;
                            }
                            var score = benchmark.ForceBenchmarkScore / 200;
                            MonitorDataGrid.Items.Add(new QuoteMonitorData(quote.Symbol, uad, score));
                        }

                        // short position detection
                        else if (roe <= -0.3m && quote.Volume >= rating.Volume * candleDurationRatio &&
                        (emaRoe <= 0 && emaRoe >= -0.5m) &&
                        (maRoe <= 0 && maRoe >= -0.5m))
                        {
                            var uad = roe + "%";
                            var benchmark = BinanceMarket.Benchmarks.Find(b => b.Symbol.Equals(symbol));
                            if (benchmark == null)
                            {
                                continue;
                            }
                            var score = benchmark.ForceBenchmarkScore / 200;
                            MonitorDataGrid.Items.Add(new QuoteMonitorData(quote.Symbol, uad, score));
                        }
                    }
                });
            }
            catch { }
        }

        private void MonitorStartButton_Click(object sender, RoutedEventArgs e)
        {
            quoteRatings = CalculatePast();
            isRunning = true;
            timer.Start();
            MonitorStartButton.Visibility = Visibility.Hidden;
            MonitorStopButton.Visibility = Visibility.Visible;
        }

        private void MonitorStopButton_Click(object sender, RoutedEventArgs e)
        {
            isRunning = false;
            timer.Stop();
            MonitorStartButton.Visibility = Visibility.Visible;
            MonitorStopButton.Visibility = Visibility.Hidden;
        }
    }
}
