using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Orders
{
    public class Order : IOrder
    {
        public OrderType Type { get; set; } = OrderType.None;
        public PositionSide Side { get; set; } = PositionSide.None;
        public OrderAmount Amount { get; set; }
        public decimal? Price { get; set; } = null;
        public decimal MakerFee => 0.00075m; // use BNB(0.075%)
        public decimal TakerFee => 0.00075m; // use BNB(0.075%)

        public Order()
        {
        }

        public string Run(Asset asset, ChartInfo chart)
        {
            return string.Empty;
        }

        public Order Position(PositionSide side, OrderAmount amount)
        {
            return this;
        }

        public Order Position(PositionSide side, OrderAmountType orderType, double amount)
        {
            return this;
        }

        public Order Close(OrderAmount amount)
        {
            return this;
        }

        public Order Close(OrderAmountType orderType, double amount)
        {
            return this;
        }
    }
}
