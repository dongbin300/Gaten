using Binance.Net.Enums;

using Gaten.Net.Extensions;
using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Intervals;
using Gaten.Net.Stock.MercuryTradingModel.Maths;
using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.MarinerX.Charts;
using Gaten.Stock.MarinerX.Views;

using System;
using System.Collections.Generic;
using System.Text;

using PositionSide = Gaten.Net.Stock.MercuryTradingModel.Enums.PositionSide;

namespace Gaten.Stock.MarinerX.Bots
{
    public class BackTestFlask
    {
        public StringBuilder TradeLog { get; set; } = new();
        public Worker Worker { get; set; } = new();
        public ChartWindow ChartViewer { get; set; } = default!;
        public bool IsShowChart { get; set; }
        public decimal MakerFee => 0.00075m; // use BNB(0.075%)
        public decimal TakerFee => 0.00075m; // use BNB(0.075%)

        public BackTestFlask()
        {

        }

        public BackTestFlask(Worker worker, bool isShowChart = false)
        {
            Worker = worker;
            IsShowChart = isShowChart;
            if (IsShowChart)
            {
                DispatcherService.Invoke(() =>
                {
                    ChartViewer = new ChartWindow();
                });
            }
        }

        public string Run()
        {
            decimal _asset = 100000;
            string _symbol = "BTCUSDT";
            KlineInterval _interval = KlineInterval.FiveMinutes;
            DateTime _startTime = new(2022, 10, 1, 0, 0, 0);
            TimeSpan _period = TimeSpan.FromDays(3);

            double bandwidth = 1.0;
            decimal profitRoe = 0.5m;

            Asset asset = new BackTestAsset(_asset, new Position());
            var tickCount = (int)(_period / _interval.ToTimeSpan()) + 1;
            var charts = ChartLoader.GetChartPack(_symbol, _interval);

            // If you did not load the target chart data yet, at first, load the chart data.
            if (charts == null)
            {
                TrayMenu.LoadChartDataEvent(null, new EventArgs(), _symbol, _interval, true);
                charts = ChartLoader.GetChartPack(_symbol, _interval);
            }

            // Named Element Init
            charts.CalculateIndicators(
                new List<ChartElement>() { 
                    new ChartElement("bb.sma"), 
                    new ChartElement($"bb.upper,20,{bandwidth}"),
                    new ChartElement($"bb.lower,20,{bandwidth}") 
                },
                new List<NamedElement>());

            // Back test start!
            ChartInfo? info = default!;
            var info0 = charts.Select(_startTime);
            bool first = true;
            bool isPositioning = false;
            decimal entryPrice = default!;
            Worker.For(0, tickCount, 1, (i) =>
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    info0 = info;
                }
                info = charts.Next();
                if (IsShowChart)
                {
                    ChartViewer.AddChartInfo(info);
                }

                // long signal
                if (!isPositioning &&
                info.Quote.Open < info.GetChartElementValue(ChartElementType.bb_sma) &&
                info.Quote.Close > info.GetChartElementValue(ChartElementType.bb_sma) &&
                info.Quote.Close < info.GetChartElementValue(ChartElementType.bb_upper))
                {
                    var orderResult = Order(asset, info, PositionSide.Long, OrderAmountType.Fixed, 5000);
                    TradeLog.Append(orderResult.Item1 + "[Long Entry]" + Environment.NewLine);
                    isPositioning = true;
                    entryPrice = orderResult.Item2.price;
                }
                // short signal
                else if (!isPositioning &&
                info.Quote.Open > info.GetChartElementValue(ChartElementType.bb_sma) &&
                info.Quote.Close < info.GetChartElementValue(ChartElementType.bb_sma) &&
                info.Quote.Close > info.GetChartElementValue(ChartElementType.bb_lower))
                {
                    var orderResult = Order(asset, info, PositionSide.Short, OrderAmountType.Fixed, 5000);
                    TradeLog.Append(orderResult.Item1 + "[Short Entry]" + Environment.NewLine);
                    isPositioning = true;
                    entryPrice = orderResult.Item2.price;
                }

                // Take profit when long position
                if(isPositioning && asset.Position.Side == PositionSide.Long &&
                StockUtil.Roe(asset.Position.Side, entryPrice, info.Quote.High) >= profitRoe)
                {
                    var orderResult2 = Order(asset, info, PositionSide.Short, OrderAmountType.FixedSymbol, asset.Position.Value, true, StockUtil.GetPriceByRoe(asset.Position.Side, entryPrice, profitRoe));
                    TradeLog.Append(orderResult2.Item1 + "[Take Profit]" + Environment.NewLine);
                    isPositioning = false;
                    entryPrice = 0;
                }
                // Take profit when short position
                else if (isPositioning && asset.Position.Side == PositionSide.Short &&
                StockUtil.Roe(asset.Position.Side, entryPrice, info.Quote.Low) >= profitRoe)
                {
                    var orderResult2 = Order(asset, info, PositionSide.Long, OrderAmountType.FixedSymbol, asset.Position.Value, true, StockUtil.GetPriceByRoe(asset.Position.Side, entryPrice, profitRoe));
                    TradeLog.Append(orderResult2.Item1 + "[Take Profit]" + Environment.NewLine);
                    isPositioning = false;
                    entryPrice = 0;
                }

                // Stop loss when long position
                if (isPositioning && asset.Position.Side == PositionSide.Long &&
                info.Quote.Low <= info.GetChartElementValue(ChartElementType.bb_lower))
                {
                    var orderResult3 = Order(asset, info, PositionSide.Short, OrderAmountType.FixedSymbol, asset.Position.Value, true, info.GetChartElementValue(ChartElementType.bb_lower).Value);
                    TradeLog.Append(orderResult3.Item1 + "[Stop Loss]" + Environment.NewLine);
                    isPositioning = false;
                    entryPrice = 0;
                }
                // Stop loss when short position
                else if (isPositioning && asset.Position.Side == PositionSide.Short &&
                info.Quote.High >= info.GetChartElementValue(ChartElementType.bb_upper))
                {
                    var orderResult3 = Order(asset, info, PositionSide.Long, OrderAmountType.FixedSymbol, asset.Position.Value, true, info.GetChartElementValue(ChartElementType.bb_upper).Value);
                    TradeLog.Append(orderResult3.Item1 + "[Stop Loss]" + Environment.NewLine);
                    isPositioning = false;
                    entryPrice = 0;
                }
            }, ProgressBarDisplayOptions.Count | ProgressBarDisplayOptions.Percent | ProgressBarDisplayOptions.TimeRemaining);

            if (TradeLog.ToString().Length < 4)
            {
                return "-NO TRADING--NO TRADING--NO TRADING--NO TRADING-\n" +
                    "-NO TRADING--NO TRADING--NO TRADING--NO TRADING-\n" +
                    "-NO TRADING--NO TRADING--NO TRADING--NO TRADING-\n" +
                    "-NO TRADING--NO TRADING--NO TRADING--NO TRADING-\n";
            }

            return TradeLog.ToString();
        }

        public record OrderContent(PositionSide side, decimal price, decimal quantity);

        public (string, OrderContent) Order(Asset asset, ChartInfo chart, PositionSide side, OrderAmountType orderType, decimal amount, bool isManualPrice = false, decimal manualPrice = 0)
        {
            var price = isManualPrice ? manualPrice : chart.Quote.Close;

            decimal quantity;
            switch (orderType)
            {
                case OrderAmountType.Fixed:
                    quantity = decimal.Round(amount / price, 2);
                    break;

                case OrderAmountType.FixedSymbol:
                    quantity = amount;
                    break;

                case OrderAmountType.Seed:
                    var transactionAmount = decimal.Round(asset.Seed * amount, 2);
                    quantity = decimal.Round(transactionAmount / price, 2);
                    break;

                case OrderAmountType.Balance:
                    var transactionAmount2 = decimal.Round(asset.Balance * amount, 2);
                    quantity = decimal.Round(transactionAmount2 / price, 2);
                    break;

                case OrderAmountType.Asset:
                    var estimatedAsset = price * asset.Position.Value + asset.Balance;
                    var transactionAmount3 = decimal.Round(estimatedAsset * amount, 2);
                    quantity = decimal.Round(transactionAmount3 / price, 2);
                    break;

                case OrderAmountType.BalanceSymbol:
                    var symbolAmount = asset.Position.Amount;
                    var transactionAmount4 = decimal.Round(symbolAmount * amount, 2);
                    quantity = decimal.Round(transactionAmount4 / price, 2);
                    break;

                default:
                    quantity = 0;
                    break;
            }

            switch (side)
            {
                case PositionSide.Long:
                    var buyFee = Buy(asset, price, quantity);
                    var estimatedAsset = price * asset.Position.Value + asset.Balance;
                    return ($"{chart.DateTime.ToStandardString()},Buy,{price},{quantity:#.##} (Fee {buyFee:#.##}USDT)" +
                        $" | {asset.Balance:#.##} USDT, {asset.Position:#.##} {chart.BaseAsset} ({estimatedAsset:#.##}USDT?)", new OrderContent(side, price, quantity));

                case PositionSide.Short:
                    var sellFee = Sell(asset, price, quantity);
                    var estimatedAsset2 = price * asset.Position.Value + asset.Balance;
                    return ($"{chart.DateTime.ToStandardString()},Sell,{price},{quantity:#.##} (Fee {sellFee:#.##}USDT)" +
                        $" | {asset.Balance:#.##} USDT, {asset.Position:#.##} {chart.BaseAsset} ({estimatedAsset2:#.##}USDT?)", new OrderContent(side, price, quantity));
            }

            return (string.Empty, new OrderContent(PositionSide.None, 0, 0));
        }

        public decimal Buy(Asset asset, decimal price, decimal quantity)
        {
            var transactionAmount = price * quantity;
            var fee = transactionAmount * TakerFee;
            asset.Balance -= transactionAmount + fee;
            asset.Position.Long(quantity);

            return fee;
        }

        public decimal Sell(Asset asset, decimal price, decimal quantity)
        {
            var transactionAmount = price * quantity;
            var fee = transactionAmount * TakerFee;
            asset.Balance += transactionAmount;
            asset.Balance -= fee;
            asset.Position.Short(quantity);

            return fee;
        }
    }
}
