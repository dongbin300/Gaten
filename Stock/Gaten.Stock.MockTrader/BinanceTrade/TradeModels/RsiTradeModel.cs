using Gaten.Stock.MockTrader.Chart;
using Gaten.Stock.MockTrader.Orders;

namespace Gaten.Stock.MockTrader.BinanceTrade.TradeModels
{
    internal class RsiTradeModel : ITradeModel
    {
        int weight;
        double upperThreshold;
        double lowerThreshold;
        int rsiFlag = 0;

        public RsiTradeModel(int weight, double upperThreshold, double lowerThreshold)
        {
            this.weight = weight;
            this.upperThreshold = upperThreshold;
            this.lowerThreshold = lowerThreshold;
        }

        public Order? Run(Assets assets, ChartInfo chart, int index)
        {
            Order? order = null;

            var symbol = chart.Symbol;
            var candle = chart.Candles[index];
            var rsi = chart.RSI[index].Rsi;

            if (rsi < lowerThreshold)
            {
                if (rsiFlag != 1)
                {
                    int quantity = assets.CoinSize[symbol] < 0 ?
                        (int)assets.AbsoluteSize(symbol) :
                        (int)(assets.EvaluatedAmount(symbol, candle) / candle.Close / weight);
                    order = new Order(symbol, candle.Close, quantity, PositionType.Long);
                }
                rsiFlag = 1;
            }
            else if (rsi > upperThreshold)
            {
                if (rsiFlag != 2)
                {
                    int quantity = assets.CoinSize[symbol] > 0 ?
                        (int)assets.AbsoluteSize(symbol) :
                        (int)(assets.EvaluatedAmount(symbol, candle) / candle.Close / weight);
                    order = new Order(symbol, candle.Close, quantity, PositionType.Short);
                }
                rsiFlag = 2;
            }

            return order;
        }
    }
}
