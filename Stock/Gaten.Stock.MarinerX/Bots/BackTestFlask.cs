using Binance.Net.Enums;

using Gaten.Net.Extensions;
using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Intervals;
using Gaten.Net.Stock.MercuryTradingModel.Maths;
using Gaten.Net.Stock.MercuryTradingModel.Orders;
using Gaten.Net.Stock.MercuryTradingModel.Trades;
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
        public decimal MakerFee => 0.0002m;
        public decimal TakerFee => 0.0002m;

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

        public List<BackTestTradeInfo>? Run(decimal _asset, string _symbol, KlineInterval _interval, DateTime _startTime, TimeSpan _period, double bandwidth, decimal profitRoe)
        {
            var trades = new List<BackTestTradeInfo>();

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
                new List<ChartElement>()
                {
                    new ChartElement("rsi")
                    //new ChartElement("bb.sma"),
                    //new ChartElement($"bb.upper,20,{bandwidth}"),
                    //new ChartElement($"bb.lower,20,{bandwidth}"),
                },
                new List<NamedElement>()
                //{
                //    new NamedElement("sma", "bb.sma,20,2"),
                //    new NamedElement("long1", "bb.upper,20,0.5"),
                //    new NamedElement("loss1", "bb.lower,20,0.5"),
                //    new NamedElement("profit1", "bb.upper,20,2.5"),
                //}
                );

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

                //if (!isPositioning &&
                //info.Quote.Close > info.GetNamedElementValue("sma") &&
                //info.Quote.Close < info.GetNamedElementValue("long1"))
                //{
                //    var trade = Order(asset, info, PositionSide.Long, OrderAmountType.Fixed, 5000, "Long Entry");
                //    trades.Add(trade);
                //    isPositioning = true;
                //}
                //else if(isPositioning &&
                //asset.Position.Side == PositionSide.Long &&
                //info.Quote.High >= info.GetNamedElementValue("profit1"))
                //{
                //    var trade = Order(asset, info, PositionSide.Short, OrderAmountType.FixedSymbol, asset.Position.Value, "Take Profit", true, info.GetNamedElementValue("profit1").Value);
                //    trades.Add(trade);
                //    isPositioning = false;
                //}
                //else if (isPositioning &&
                //asset.Position.Side == PositionSide.Long &&
                //info.Quote.Low <= info.GetNamedElementValue("loss1"))
                //{
                //    var trade = Order(asset, info, PositionSide.Short, OrderAmountType.FixedSymbol, asset.Position.Value, "Stop Loss", true, info.GetNamedElementValue("loss1").Value);
                //    trades.Add(trade);
                //    isPositioning = false;
                //}

                /*
                // long signal
                if (!isPositioning &&
                info.Quote.Open < info.GetChartElementValue(ChartElementType.bb_sma) &&
                info.Quote.Close > info.GetChartElementValue(ChartElementType.bb_sma) &&
                info.Quote.Close < info.GetChartElementValue(ChartElementType.bb_upper))
                {
                    var trade = Order(asset, info, PositionSide.Long, OrderAmountType.Fixed, 5000, "Long Entry");
                    trades.Add(trade);
                    isPositioning = true;
                    entryPrice = decimal.Parse(trade.Price);
                }
                // short signal
                else if (!isPositioning &&
                info.Quote.Open > info.GetChartElementValue(ChartElementType.bb_sma) &&
                info.Quote.Close < info.GetChartElementValue(ChartElementType.bb_sma) &&
                info.Quote.Close > info.GetChartElementValue(ChartElementType.bb_lower))
                {
                    var trade = Order(asset, info, PositionSide.Short, OrderAmountType.Fixed, 5000, "Short Entry");
                    trades.Add(trade);
                    isPositioning = true;
                    entryPrice = decimal.Parse(trade.Price);
                }

                // Take profit when long position
                else if (isPositioning && asset.Position.Side == PositionSide.Long &&
                StockUtil.Roe(asset.Position.Side, entryPrice, info.Quote.High) >= profitRoe)
                {
                    var trade = Order(asset, info, PositionSide.Short, OrderAmountType.FixedSymbol, asset.Position.Value, "Take Profit", true, StockUtil.GetPriceByRoe(asset.Position.Side, entryPrice, profitRoe));
                    trades.Add(trade);
                    isPositioning = false;
                    entryPrice = 0;
                }
                // Take profit when short position
                else if (isPositioning && asset.Position.Side == PositionSide.Short &&
                StockUtil.Roe(asset.Position.Side, entryPrice, info.Quote.Low) >= profitRoe)
                {
                    var trade = Order(asset, info, PositionSide.Long, OrderAmountType.FixedSymbol, -asset.Position.Value, "Take Profit", true, StockUtil.GetPriceByRoe(asset.Position.Side, entryPrice, profitRoe));
                    trades.Add(trade);
                    isPositioning = false;
                    entryPrice = 0;
                }

                // Stop loss when long position
                else if (isPositioning && asset.Position.Side == PositionSide.Long &&
                info.Quote.Low <= info.GetChartElementValue(ChartElementType.bb_lower))
                {
                    var trade = Order(asset, info, PositionSide.Short, OrderAmountType.FixedSymbol, asset.Position.Value, "Stop Loss", true, info.GetChartElementValue(ChartElementType.bb_lower).Value);
                    trades.Add(trade);
                    isPositioning = false;
                    entryPrice = 0;
                }
                // Stop loss when short position
                else if (isPositioning && asset.Position.Side == PositionSide.Short &&
                info.Quote.High >= info.GetChartElementValue(ChartElementType.bb_upper))
                {
                    var trade = Order(asset, info, PositionSide.Long, OrderAmountType.FixedSymbol, -asset.Position.Value, "Stop Loss", true, info.GetChartElementValue(ChartElementType.bb_upper).Value);
                    trades.Add(trade);
                    isPositioning = false;
                    entryPrice = 0;
                }
                */

                if(info.GetChartElementValue(ChartElementType.rsi) <= 25)
                {
                    BackTestOrder order = new BackTestOrder(OrderType.Market, PositionSide.Long, new OrderAmount(OrderAmountType.Fixed, 5000));
                    order.Run(asset, info);

                    var trade = Order(asset, info, PositionSide.Long, OrderAmountType.Fixed, 5000, "Long");
                    trades.Add(trade);
                }
                else if (info.GetChartElementValue(ChartElementType.rsi) >= 75)
                {
                    var trade = Order(asset, info, PositionSide.Short, OrderAmountType.Fixed, 5000, "Short");
                    trades.Add(trade);
                }
                
            }, ProgressBarDisplayOptions.Count | ProgressBarDisplayOptions.Percent | ProgressBarDisplayOptions.TimeRemaining);

            return trades;
        }

        public record OrderContent(PositionSide side, decimal price, decimal quantity);

        public BackTestTradeInfo Order(Asset asset, ChartInfo chart, PositionSide side, OrderAmountType orderType, decimal amount, string tag = "", bool isManualPrice = false, decimal manualPrice = 0)
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
                    return new BackTestTradeInfo(chart.Symbol, chart.DateTime.ToStandardString(), "Buy", $"{price:#.####}", $"{quantity:#.####}", $"{buyFee:#.##}", $"{asset.Balance:#.##}", $"{asset.Position:#.####}", chart.BaseAsset, $"{estimatedAsset:#.##} USDT", tag);

                case PositionSide.Short:
                    var sellFee = Sell(asset, price, quantity);
                    var estimatedAsset2 = price * asset.Position.Value + asset.Balance;
                    return new BackTestTradeInfo(chart.Symbol, chart.DateTime.ToStandardString(), "Sell", $"{price:#.####}", $"{quantity:#.####}", $"{sellFee:#.##}", $"{asset.Balance:#.##}", $"{asset.Position:#.####}", chart.BaseAsset, $"{estimatedAsset2:#.##} USDT", tag);
            }

            return new BackTestTradeInfo("", "", "", "", "", "", "", "", "", "", "");
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
