using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Intervals;
using Gaten.Net.Stock.MercuryTradingModel.Trades;
using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Net.Wpf;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.MarinerX.Charts;
using Gaten.Stock.MarinerX.Interfaces;
using Gaten.Stock.MarinerX.Views;

using System;
using System.Collections.Generic;

namespace Gaten.Stock.MarinerX.Bots
{
    public record BackTestTrade(DateTime time, IStrategy strategy, PositionSide side);
    public class BackTestBot : IBot
    {
        public MercuryBackTestTradingModel TradingModel { get; set; } = new();
        public Worker Worker { get; set; } = new();
        public ChartWindow ChartViewer { get; set; } = default!;
        public bool IsShowChart { get; set; }

        public BackTestBot(MercuryBackTestTradingModel tradingModel, Worker worker, bool isShowChart = false)
        {
            TradingModel = tradingModel;
            Worker = worker;
            IsShowChart = isShowChart;
            DispatcherService.Invoke(() =>
            {
                ChartViewer = new ChartWindow();
            });
        }

        public List<BackTestTradeInfo> Run()
        {
            var results = new List<BackTestTradeInfo>();

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
                ChartViewer.AddChartInfo(info);

                foreach (var scenario in TradingModel.Scenarios)
                {
                    foreach (var strategy in scenario.Strategies)
                    {
                        // No cue, just check signal
                        if (strategy.Cue == null)
                        {
                            if (strategy.Signal.IsFlare(asset, info, info0))
                            {
                                var tradeInfo = strategy.Order.Run(asset, info, strategy.Tag);
                                results.Add(tradeInfo);

                                ChartViewer.AddTradeInfo(new BackTestTrade(
                                    info.DateTime,
                                    strategy,
                                    tradeInfo.PositionSide
                                    ));
                            }
                        }
                        // At first, check cue and then check signal.
                        // If the signal is not raised in time, the life is consumed and the cue flare disappears.
                        else
                        {
                            if (strategy.Cue.CheckFlare(asset, info, info0))
                            {
                                if (strategy.Signal.IsFlare(asset, info, info0))
                                {
                                    var tradeInfo = strategy.Order.Run(asset, info, strategy.Tag);
                                    results.Add(tradeInfo);
                                    strategy.Cue.Expire();

                                    ChartViewer.AddTradeInfo(new BackTestTrade(
                                    info.DateTime,
                                    strategy,
                                    tradeInfo.PositionSide
                                    ));
                                }
                            }
                        }
                    }
                }
            }, ProgressBarDisplayOptions.Count | ProgressBarDisplayOptions.Percent | ProgressBarDisplayOptions.TimeRemaining);

            return results;
        }
    }
}
