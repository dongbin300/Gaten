using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Orders
{
    public class Order : IOrder
    {
        public PositionSide Side { get; set; }
        public OrderAmount Amount { get; set; }

        public Order()
        {
        }

        public void Run()
        {

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
