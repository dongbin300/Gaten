using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class OrderAmount
    {
        public OrderType OrderType { get; set; }
        public double Value { get; set; }

        public OrderAmount(OrderType orderType, double value)
        {
            OrderType = orderType;
            Value = value;
        }
    }
}
