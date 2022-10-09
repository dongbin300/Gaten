using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Assets
{
    public class OrderAmount
    {
        public OrderAmountType OrderType { get; set; }
        public decimal Value { get; set; }

        public OrderAmount(OrderAmountType orderType, decimal value)
        {
            OrderType = orderType;
            Value = value;
        }
    }
}
