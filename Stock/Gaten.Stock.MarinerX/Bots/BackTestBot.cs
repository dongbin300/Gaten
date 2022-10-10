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
            // 자산 초기화
            Asset asset = new BackTestAsset(TradingModel.Asset, new Position());

            var tickCount = (int)(TradingModel.Period / TradingModel.Interval.ToTimeSpan()) + 1;
            var charts = ChartLoader.GetChartPack(TradingModel.Targets[0], TradingModel.Interval); // 현재 타겟은 1개만 지원됨

            if (charts == null)
            {
                return "차트 정보가 없습니다.";
            }

            charts.Select(TradingModel.StartTime);
            Worker.SetProgressBar(1, tickCount);
            int p = 0;
            for (int i = 0; i < tickCount; i++)
            {
                Worker.Progress(++p);
                Worker.ProgressText($"{p} / {tickCount}");

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
            }

            return TradeLog.ToString();
        }
    }
}
