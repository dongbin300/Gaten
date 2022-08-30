using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Times;

namespace Gaten.Net.Stock.MercuryTradingModel.Actions
{
    public class Action : IAction
    {
        public ActionTiming Timing { get; set; }
        public PositionSide Side { get; set; }
        public OrderAmount Amount { get; set; }

        public Action()
        {
            Timing = new ActionTiming(TimingType.Now);
        }

        public Action(ActionTiming timing)
        {
            Timing = timing;
        }

        public Action Position(PositionSide side, OrderAmount amount)
        {
            return this;
        }

        public Action Position(PositionSide side, OrderType orderType, double amount)
        {
            return this;
        }

        public Action Close(OrderAmount amount)
        {
            return this;
        }

        public Action Close(OrderType orderType, double amount)
        {
            return this;
        }
    }
}
