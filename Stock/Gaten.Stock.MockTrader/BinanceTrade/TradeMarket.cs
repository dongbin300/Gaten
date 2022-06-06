using Binance.Net.Enums;

using Gaten.Stock.MockTrader.BinanceTrade.TradeModels;
using Gaten.Stock.MockTrader.Chart;
using Gaten.Stock.MockTrader.DateTimes;
using Gaten.Stock.MockTrader.Orders;
using Gaten.Stock.MockTrader.Progresses;
using Gaten.Stock.MockTrader.Symbols;

namespace Gaten.Stock.MockTrader.BinanceTrade
{
    internal class TradeMarket
    {
        public ITradeModel TradeModel { get; set; }
        public Task<List<TradingResult>> TradingResults { get; set; }
        public Assets Assets { get; set; }
        public SymbolRange Symbol { get; set; }
        public Period TradePeriod { get; set; }
        public KlineInterval CandleInterval { get; set; }
        public RunProgress Progress { get; set; }

        public static readonly double BuyFee = 0.0004;
        public static readonly double SellFee = 0.0002;
        public static bool TradeLogger;

        public TradeMarket(int seed)
        {
            Assets = new Assets();
            Assets.InitTemp();
            Assets.Seed = seed;
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

        public async Task<List<TradingResult>> RunAsync(bool tradeLog, bool dayLog)
        {
            /* Init Assets */
            Assets.Amount = Assets.Seed;

            /* Simulate Trading */
            var results = new List<TradingResult>();
            try
            {
                var baseDate = TradePeriod.StartDate;
                for (int d = 0; d < TradePeriod.NumberOfDays; d++)
                {
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
