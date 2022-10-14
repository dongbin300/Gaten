using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Intervals;
using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.MarinerX.Charts;
using Gaten.Stock.MarinerX.Interfaces;

using System;
using System.Text;

namespace Gaten.Stock.MarinerX.Bots
{
    public class BackTestBot : IBot
    {
        public MercuryBackTestTradingModel TradingModel { get; set; } = new();
        public StringBuilder TradeLog { get; set; } = new();
        public Worker Worker { get; set; } = new();

        public BackTestBot(MercuryBackTestTradingModel tradingModel, Worker worker)
        {
            TradingModel = tradingModel;
            Worker = worker;
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
            charts.Select(TradingModel.StartTime);
            Worker.For(0, tickCount, 1, (i) =>
            {
                var info = charts.Next();
                foreach (var scenario in TradingModel.Scenarios)
                {
                    foreach (var strategy in scenario.Strategies)
                    {
                        if (strategy.Signal.IsFlare(asset, info))
                        {
                            TradeLog.Append(strategy.Order.Run(asset, info));
                            TradeLog.Append(" by " + strategy.Name + " : ");
                            TradeLog.Append(strategy.Signal.Formula.ToString() + Environment.NewLine);
                        }
                    }
                }
            }, ProgressBarDisplayOptions.Count | ProgressBarDisplayOptions.Percent | ProgressBarDisplayOptions.TimeRemaining);

            return TradeLog.ToString();
        }
    }
}
