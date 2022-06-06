using Gaten.Stock.MockTrader.Chart;
using Gaten.Stock.MockTrader.Orders;

namespace Gaten.Stock.MockTrader.BinanceTrade.TradeModels
{
    internal interface ITradeModel
    {
        public Order? Run(Assets assets, ChartInfo chart, int index);
    }
}
