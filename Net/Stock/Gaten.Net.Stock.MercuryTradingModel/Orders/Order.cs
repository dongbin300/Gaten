using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Times;

namespace Gaten.Net.Stock.MercuryTradingModel.Actions
{
    public class Order : IOrder
    {
        public ActionTiming Timing { get; set; }
        public PositionSide Side { get; set; }
        public OrderAmount Amount { get; set; }

        public Order()
        {
            Timing = new ActionTiming(TimingType.Now);
        }

        public Order(ActionTiming timing)
        {
            Timing = timing;
        }

        public Order Position(PositionSide side, OrderAmount amount)
        {
            return this;
        }

        public Order Position(PositionSide side, OrderType orderType, double amount)
        {
            return this;
        }

        public Order Close(OrderAmount amount)
        {
            return this;
        }

        public Order Close(OrderType orderType, double amount)
        {
            return this;
        }
    }
}
