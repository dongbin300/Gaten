using Gaten.Game.CoinChartSimulator.Controls;
using Gaten.Net.Math;
using Gaten.Net.Stock.Charts;
using Gaten.Net.Wpf;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Gaten.Game.CoinChartSimulator
{
    public enum SimulateType
    {
        None,
        Agc,
        Rpc
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimulateType simulateType = SimulateType.None;
        ChartViewer chart = new();
        SmartRandom r = new();
        System.Timers.Timer timer = new();
        List<Candle> candles = new();

        int tick = 0;
        int tickCount = 600;
        double maxUad = 2.0; // 추후 구현
        double listingPrice = 10;
        int digit = 0;

        double currentPrice = 10;
        double prevCandlePrice = 10; // 추후 구현

        /// <summary>
        /// 잔고
        /// 항상 +
        /// </summary>
        double balance = 0;
        string symbol = "TRCUSDT";

        /// <summary>
        /// 코인 보유 수량
        /// 롱 포지션일 경우 +
        /// 숏 포지션일 경우 -
        /// </summary>
        double size;
        string sizeString => string.Format($"{size:#.###} TRC");

        /// <summary>
        /// 평균단가
        /// 항상 +
        /// </summary>
        double entry => amount / size;

        /// <summary>
        /// 포지션 총 대금
        /// 롱 포지션일 경우 +
        /// 숏 포지션일 경우 -
        /// </summary>
        double amount;

        /// <summary>
        /// 평가(추정)자산
        /// 항상 +
        /// </summary>
        double avbl => balance + currentPrice * size;

        public MainWindow()
        {
            InitializeComponent();

            balance = Settings.Default.Balance;
            if (balance == 0)
            {
                balance = 1000;
            }

            TickIntervalTextBox.Text = "50";
            TickCountTextBox.Text = "200";
            MaxUadTextBox.Text = "2.0";
            ListingPriceTextBox.Text = "10";
            DigitTextBox.Text = "4";
            SymbolText.Text = symbol;

            timer.Elapsed += Timer_Elapsed;

            Content.Content = chart;
            PositionGrid.Visibility = Visibility.Hidden;
        }

        private void Save()
        {
            Settings.Default.Balance = balance;
            Settings.Default.Save();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            tick++;

            var sign = r.Next(2) == 1 ? "+" : "-";
            var _base = Math.Pow((double)(r.Next(1000) + 1) / 1000, 3.5);
            var per = sign == "+" ? Math.Round(_base * 3.0, 2) : Math.Round(_base * (-2.9), 2);
            var afterPrice = Math.Round(currentPrice * (1 + per / 100), digit);
            var afterPer = (afterPrice / currentPrice - 1) * 100;

            currentPrice = afterPrice;

            DispatcherService.Invoke(() =>
            {
                if (tick % tickCount == 0) // New candle
                {
                    var candle = new Candle(DateTime.Now, currentPrice, currentPrice, currentPrice, currentPrice, 0);
                    candles.Add(candle);
                    chart.AddCandle(candles[^1]);
                }
                else // Update Candle
                {
                    candles[^1].Close = currentPrice;
                    candles[^1].High = Math.Max(candles[^1].High, currentPrice);
                    candles[^1].Low = Math.Min(candles[^1].Low, currentPrice);
                    chart.UpdateCandle(candles[^1]);
                }

                MainCurrentPriceText.Text = currentPrice.ToString();
                MainCurrentPriceText.Foreground = sign == "+" ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97));
                AvblText.Text = Math.Round(avbl, 2).ToString();
                CurrentPriceText.Text = currentPrice.ToString();
                var pnl = Math.Round(currentPrice * size - amount, 2);

                if (pnl >= 0)
                {
                    var per = (amount < 0 ? -1 : 1) * Math.Round((pnl / amount) * 100, 2);
                    PnlText.Foreground = new SolidColorBrush(Color.FromRgb(59, 207, 134));
                    PnlText.Text = $"{pnl:f2} USDT\r\n({per:f2}%)";
                    chart.IsYang = true;
                }
                else
                {
                    var per = (amount < 0 ? -1 : 1) * Math.Round((pnl / amount) * 100, 2);
                    PnlText.Foreground = new SolidColorBrush(Color.FromRgb(237, 49, 97));
                    PnlText.Text = $"{pnl:f2} USDT\r\n({per:f2}%)";
                    chart.IsYang = false;
                }

                if (avbl < 0) // Liquidation
                {
                    size = 0;
                    amount = 0;
                    PositionGrid.Visibility = Visibility.Hidden;
                    chart.EntryPrice = -1;
                    balance = 0;

                    Save();
                }
            });
        }

        private void AgcStartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (AgcStartButton.Content)
                {
                    case "START":
                        simulateType = SimulateType.Agc;
                        tickCount = int.Parse(TickCountTextBox.Text);
                        maxUad = double.Parse(MaxUadTextBox.Text);
                        listingPrice = double.Parse(ListingPriceTextBox.Text);
                        digit = int.Parse(DigitTextBox.Text);

                        if (candles.Count == 0)
                        {
                            currentPrice = prevCandlePrice = listingPrice;
                            var candle = new Candle(DateTime.Now, currentPrice, currentPrice, currentPrice, currentPrice, 0);
                            candles.Add(candle);
                            chart.AddCandle(candles[^1]);
                        }

                        timer.Interval = int.Parse(TickIntervalTextBox.Text);
                        timer.Start();

                        TickIntervalTextBox.IsEnabled = false;
                        TickCountTextBox.IsEnabled = false;
                        MaxUadTextBox.IsEnabled = false;
                        ListingPriceTextBox.IsEnabled = false;
                        DigitTextBox.IsEnabled = false;
                        AgcStartButton.Content = "STOP";
                        MainSymbolText.Text = symbol;
                        break;

                    case "STOP":
                        simulateType = SimulateType.None;
                        timer.Stop();

                        TickIntervalTextBox.IsEnabled = true;
                        TickCountTextBox.IsEnabled = true;
                        MaxUadTextBox.IsEnabled = true;
                        ListingPriceTextBox.IsEnabled = true;
                        DigitTextBox.IsEnabled = true;
                        AgcStartButton.Content = "START";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AgcResetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentPrice = prevCandlePrice = listingPrice;
                tick = 0;
                chart.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var quantity = double.Parse(OrderQuantityTextBox.Text);
                var amount = currentPrice * quantity;
                if (avbl < amount)
                {
                    MessageBox.Show("Not enough balance.");
                    return;
                }

                balance -= amount;
                size += quantity;
                this.amount += amount;
                PositionGrid.Visibility = size == 0 ? Visibility.Hidden : Visibility.Visible;
                chart.EntryPrice = size == 0 ? -1 : entry;
                SizeText.Text = sizeString;
                SizeText.Foreground = size > 0 ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97));
                PositionGradient.Color = size > 0 ? Color.FromRgb(59, 207, 134) : Color.FromRgb(237, 49, 97);
                EntryPriceText.Text = string.Format($"{entry:f2}");
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var quantity = double.Parse(OrderQuantityTextBox.Text);
                var amount = currentPrice * quantity;
                if (avbl < amount)
                {
                    MessageBox.Show("Not enough balance.");
                    return;
                }

                balance += amount;
                size -= quantity;
                this.amount -= amount;
                PositionGrid.Visibility = size == 0 ? Visibility.Hidden : Visibility.Visible;
                chart.EntryPrice = size == 0 ? -1 : entry;
                SizeText.Text = sizeString;
                SizeText.Foreground = size > 0 ? new SolidColorBrush(Color.FromRgb(59, 207, 134)) : new SolidColorBrush(Color.FromRgb(237, 49, 97));
                PositionGradient.Color = size > 0 ? Color.FromRgb(59, 207, 134) : Color.FromRgb(237, 49, 97);
                EntryPriceText.Text = string.Format($"{entry:f2}");
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderButton25_Click(object sender, RoutedEventArgs e)
        {
            var q = Math.Round((avbl / currentPrice) * 25 / 100, 2);
            OrderQuantityTextBox.Text = q.ToString();
        }

        private void OrderButton50_Click(object sender, RoutedEventArgs e)
        {
            var q = Math.Round((avbl / currentPrice) * 50 / 100, 2);
            OrderQuantityTextBox.Text = q.ToString();
        }

        private void OrderButton75_Click(object sender, RoutedEventArgs e)
        {
            var q = Math.Round((avbl / currentPrice) * 75 / 100, 2);
            OrderQuantityTextBox.Text = q.ToString();
        }

        private void OrderButtonMax_Click(object sender, RoutedEventArgs e)
        {
            var q = Math.Round(avbl / currentPrice, 2);
            OrderQuantityTextBox.Text = q.ToString();
        }

        private void PositionCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (size == 0)
            {
                return;
            }

            balance += size * currentPrice;
            size = 0;
            amount = 0;
            PositionGrid.Visibility = Visibility.Hidden;
            chart.EntryPrice = -1;

            Save();
        }

        private void RpcResetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                chart.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RpcStartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (RpcStartButton.Content)
                {
                    case "START":
                        simulateType = SimulateType.Rpc;
                        tickCount = int.Parse(TickCountTextBox.Text);
                        maxUad = double.Parse(MaxUadTextBox.Text);
                        listingPrice = double.Parse(ListingPriceTextBox.Text);
                        digit = int.Parse(DigitTextBox.Text);

                        if (candles.Count == 0)
                        {
                            currentPrice = prevCandlePrice = listingPrice;
                            var candle = new Candle(DateTime.Now, currentPrice, currentPrice, currentPrice, currentPrice, 0);
                            candles.Add(candle);
                            chart.AddCandle(candles[^1]);
                        }

                        timer.Interval = 1000 / int.Parse(SpeedTextBox.Text);
                        timer.Start();

                        SpeedTextBox.IsEnabled = false;
                        IntervalComboBox.IsEnabled = false;
                        AgcStartButton.Content = "STOP";
                        break;

                    case "STOP":
                        simulateType = SimulateType.None;
                        timer.Stop();

                        SpeedTextBox.IsEnabled = true;
                        IntervalComboBox.IsEnabled = true;
                        AgcStartButton.Content = "START";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
