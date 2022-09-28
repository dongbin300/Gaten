using Gaten.Net.Extensions;
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
    internal class BackTestBot : IBot
    {
        public MercuryBackTestTradingModel TradingModel { get; set; } = new();
        public StringBuilder TradeLog { get; set; } = new();
        public Worker Worker { get; set; } = new();

        public BackTestBot(MercuryBackTestTradingModel tradingModel, Worker worker)
        {
            TradingModel = tradingModel;
            Worker = worker;
        }

        /*
         * asset = 10000
         * period = 2022,7,17,0,0:0,0,7,0,0
         * interval = 5m
         * target = SOLUSDT
         * scenario1.strategy1.signal = rsi < 30
         * scenario1.strategy1.order = long,market,1.0
         * scenario1.strategy2.signal = rsi > 70
         * scenario1.strategy2.order = short,market,1.0
         * scenario1.strategy3.signal = SOLUSDT.poe < -20%
         * scenario1.strategy3.order = long,market,SOLUSDT.amount * 1
         */
        public string Run()
        {
            // 자산 초기화
            var asset = new Asset
            {
                Balance = TradingModel.Asset,
                Position = new Position()
            };

            var tickCount = (int)(TradingModel.Period / TradingModel.Interval.ToTimeSpan()) + 1;
            var charts = ChartLoader.GetChartPack(TradingModel.Targets[0], TradingModel.Interval); // 현재 타겟은 1개만 지원됨
            charts.Select(TradingModel.StartTime);
            Worker.SetProgressBar(1, tickCount);
            int p = 0;
            for (int i = 0; i < tickCount; i++)
            {
                Worker.Progress(++p);
                Worker.ProgressText($"{p} / {tickCount}");

                var info = charts.Next();
                foreach(var scenario in TradingModel.Scenarios)
                {
                    foreach (var strategy in scenario.Strategies)
                    {
                        if (strategy.Signal.Flare)
                        {
                            strategy.Order.Run();
                        }
                    }
                }
                if (info.RSI.Rsi > 70) // RSI가 70이상이면 매도
                {
                    var price = Convert.ToDecimal(info.Quote.Close);
                    var quantity = 1.0m;
                    asset.Sell(price, quantity);
                    var estimatedAsset = price * asset.Position.ToDecimal() + asset.Balance;
                    TradeLog.AppendLine($"{info.DateTime.ToStandardString()},Sell,{price},{quantity},현재 {asset.Balance} USDT, {asset.Position.ToString()} SOL ({estimatedAsset}USDT)");
                }
                else if (info.RSI.Rsi < 30) // RSI가 30미만이면 매수
                {
                    var price = Convert.ToDecimal(info.Quote.Close);
                    var quantity = 1.0m;
                    asset.Buy(price, quantity);
                    var estimatedAsset = price * asset.Position.ToDecimal() + asset.Balance;
                    TradeLog.AppendLine($"{info.DateTime.ToStandardString()},Buy,{price},{quantity},현재 {asset.Balance} USDT, {asset.Position.ToString()} SOL ({estimatedAsset}USDT)");
                }
            }

            return TradeLog.ToString();
        }
    }
}
