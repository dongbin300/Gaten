using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class OrderAmount
    {
        public OrderAmountType OrderType { get; set; }
        public double Value { get; set; }

        public OrderAmount(OrderAmountType orderType, double value)
        {
            OrderType = orderType;
            Value = value;
        }
    }
}
