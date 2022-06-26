using Gaten.Stock.MoqTrader.Charts;
using Gaten.Stock.MoqTrader.Orders;

namespace Gaten.Stock.MoqTrader.BinanceTrades.TradeModels
{
    internal interface ITradeModel
    {
        public Order? Run(Assets assets, ChartInfo chart, int index);
    }
}
