using Binance.Net.Enums;

using Gaten.Net.Wpf.Models;
using Gaten.Stock.MoqTrader.BinanceTrades.TradeModels;
using Gaten.Stock.MoqTrader.Charts;
using Gaten.Stock.MoqTrader.DateTimes;
using Gaten.Stock.MoqTrader.Orders;
using Gaten.Stock.MoqTrader.Progresses;
using Gaten.Stock.MoqTrader.Symbols;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Gaten.Stock.MoqTrader.BinanceTrades
{
    internal class TradeMarket
    {
        public ITradeModel TradeModel { get; set; } = default!;
        public Task<List<TradingResult>> TradingResults { get; set; } = default!;
        public Assets Assets { get; set; } = default!;
        public SymbolRange Symbol { get; set; } = default!;
        public Period TradePeriod { get; set; } = default!;
        public KlineInterval CandleInterval { get; set; }
        public RunProgress Progress { get; set; } = default!;
        Worker worker;

        public static readonly double BuyFee = 0.0004;
        public static readonly double SellFee = 0.0002;

        public TradeMarket(int seed, Worker worker)
        {
            Assets = new Assets();
            Assets.InitTemp();
            Assets.Seed = seed;
            this.worker = worker;
        }

        public Trade? Trade(PositionType position, string symbol, double price, double quantity)
        {
            double tradeAmount = price * quantity;

            switch (position)
            {
                case PositionType.Long:
                    Assets.Amount -= tradeAmount + Math.Round(tradeAmount * BuyFee, 8);
                    Assets.CoinSize[symbol] += quantity;
                    return new Trade(symbol, price, quantity, SideType.Long);

                case PositionType.Short:
                    Assets.Amount += tradeAmount - Math.Round(tradeAmount * SellFee, 8);
                    Assets.CoinSize[symbol] -= quantity;
                    return new Trade(symbol, price, quantity, SideType.Short);

                default:
                    return null;
            }
        }

        public List<TradingResult> Run(bool tradeLog, bool dayLog)
        {
            /* Init Assets */
            Assets.Amount = Assets.Seed;

            /* Simulate Trading */
            var results = new List<TradingResult>();
            try
            {
                var baseDate = TradePeriod.StartDate;
                Progress = new RunProgress(TradePeriod.NumberOfDays);
                for (int d = 0; d < TradePeriod.NumberOfDays; d++)
                {
                    Progress.Progress();
                    worker.ProgressByPercent((int)Progress.Percent);
                    var symbol = Symbol.Symbols[0];
                    var startDate = baseDate.AddDays(d);
                    var tradingResult = new TradingResult(symbol, startDate);
                    var trades = new List<Trade>();

                    var chart = BtcusdtChartManager.GetChart(startDate);
                    for (int i = 0; i < chart.CandleCount; i++)
                    {
                        var order = TradeModel.Run(Assets, chart, i);

                        if (order != null)
                        {
                            tradingResult.Trades.Add(
                                Trade(order.Position, order.Symbol, order.Price, order.Size)
                                );
                        }
                    }

                    tradingResult.EstimatedAssets = Assets.EvaluatedAmount(chart.Symbol, chart.Candles[^1]);

                    if (tradeLog)
                    {
                        //builder.Append(result.ToTradeString());
                    }
                    if (dayLog || d == TradePeriod.NumberOfDays - 1)
                    {
                        //builder.AppendLine(result.ToRsiString((int)A, (int)B));
                    }
                    //StatusText.Text = result.ToString();
                    results.Add(tradingResult);
                }
            }
            catch
            {
                throw;
            }

            return results;
        }

        public async Task<List<TradingResult>> RunAsync(bool tradeLog, bool dayLog)
        {
            /* Init Assets */
            Assets.Amount = Assets.Seed;

            /* Simulate Trading */
            var results = new List<TradingResult>();
            try
            {
                var baseDate = TradePeriod.StartDate;
                Progress = new RunProgress(TradePeriod.NumberOfDays);
                for (int d = 0; d < TradePeriod.NumberOfDays; d++)
                {
                    Progress.Progress();
                    worker.ProgressByPercent((int)Progress.Percent);
                    var result = await Task.Run(() =>
                    {
                        var symbol = Symbol.Symbols[0];
                        var startDate = baseDate.AddDays(d);
                        var tradingResult = new TradingResult(symbol, startDate);
                        var trades = new List<Trade>();

                        var chart = BtcusdtChartManager.GetChart(startDate);
                        for (int i = 0; i < chart.CandleCount; i++)
                        {
                            var order = TradeModel.Run(Assets, chart, i);

                            if (order != null)
                            {
                                tradingResult.Trades.Add(
                                    Trade(order.Position, order.Symbol, order.Price, order.Size)
                                    );
                            }
                        }

                        tradingResult.EstimatedAssets = Assets.EvaluatedAmount(chart.Symbol, chart.Candles[^1]);

                        return tradingResult;
                    });

                    if (tradeLog)
                    {
                        //builder.Append(result.ToTradeString());
                    }
                    if (dayLog || d == TradePeriod.NumberOfDays - 1)
                    {
                        //builder.AppendLine(result.ToRsiString((int)A, (int)B));
                    }
                    //StatusText.Text = result.ToString();
                    //SimulateProgressBar.Value = ++c;
                    results.Add(result);
                }
            }
            catch
            {
                throw;
            }

            return results;
        }
    }
}
