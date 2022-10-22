using Binance.Net.Enums;

using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Intervals;
using Gaten.Net.Stock.MercuryTradingModel.Strategies;
using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.MarinerX.Charts;
using Gaten.Stock.MarinerX.Interfaces;
using Gaten.Stock.MarinerX.Views;

using System;
using System.Text;

namespace Gaten.Stock.MarinerX.Bots
{
    public record BackTestTrade(DateTime time, IStrategy strategy, PositionSide side);
    public class BackTestBot : IBot
    {
        public MercuryBackTestTradingModel TradingModel { get; set; } = new();
        public StringBuilder TradeLog { get; set; } = new();
        public Worker Worker { get; set; } = new();
        public ChartWindow ChartViewer { get; set; } = default!;
        public bool IsShowChart { get; set; }

        public BackTestBot(MercuryBackTestTradingModel tradingModel, Worker worker, bool isShowChart = false)
        {
            TradingModel = tradingModel;
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
            // Asset Init
            Asset asset = new BackTestAsset(TradingModel.Asset, new Position());

            var tickCount = (int)(TradingModel.Period / TradingModel.Interval.ToTimeSpan()) + 1;
            var charts = ChartLoader.GetChartPack(TradingModel.Targets[0], TradingModel.Interval); // support only one target now

            // If you did not load the target chart data yet, at first, load the chart data.
            if (charts == null)
            {
                TrayMenu.LoadChartDataEvent(null, new EventArgs(), TradingModel.Targets[0], TradingModel.Interval, true);
                charts = ChartLoader.GetChartPack(TradingModel.Targets[0], TradingModel.Interval);
            }

            // Named Element Init
            charts.CalculateIndicators(TradingModel.ChartElements, TradingModel.NamedElements);

            // Back test start!
            ChartInfo? info = default!;
            var info0 = charts.Select(TradingModel.StartTime);
            bool first = true;
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

                foreach (var scenario in TradingModel.Scenarios)
                {
                    foreach (var strategy in scenario.Strategies)
                    {
                        // No cue, just check signal
                        if (strategy.Cue == null)
                        {
                            if (strategy.Signal.IsFlare(asset, info, info0))
                            {
                                var tradeString = strategy.Order.Run(asset, info);
                                TradeLog.Append(tradeString);
                                TradeLog.Append(" by " + strategy.Name + " : ");
                                TradeLog.Append(strategy.Signal.Formula.ToString() + Environment.NewLine);

                                ChartViewer.AddTradeInfo(new BackTestTrade(
                                    info.DateTime,
                                    strategy,
                                    tradeString.Contains("Buy") ? PositionSide.Long :
                                    tradeString.Contains("Sell") ? PositionSide.Short : PositionSide.Both
                                    ));
                            }
                        }
                        // At first, check cue and then check signal.
                        // If the signal is not raised in time, the life is consumed and the cue flare disappears.
                        else
                        {
                            if (strategy.Cue.CheckFlare(asset, info, info0))
                            {
                                TradeLog.Append(strategy.Cue.ToString() + Environment.NewLine);
                                if (strategy.Signal.IsFlare(asset, info, info0))
                                {
                                    var tradeString = strategy.Order.Run(asset, info);
                                    TradeLog.Append(tradeString);
                                    TradeLog.Append(" by " + strategy.Name + " : ");
                                    TradeLog.Append(strategy.Signal.Formula.ToString() + Environment.NewLine);
                                    strategy.Cue.Expire();

                                    ChartViewer.AddTradeInfo(new BackTestTrade(
                                    info.DateTime,
                                    strategy,
                                    tradeString.Contains("Buy") ? PositionSide.Long :
                                    tradeString.Contains("Sell") ? PositionSide.Short : PositionSide.Both
                                    ));
                                }
                            }
                        }
                    }
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
    }
}
