using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Triggers
{
    public class Strategy : IStrategy
    {
        public IList<ISignal> Signals { get; set; } = new List<ISignal>();
        public IList<IOrder> Orders { get; set; } = new List<IOrder>();

        public Strategy(IList<ISignal> conditions, IList<IOrder> actions)
        {
            Signals = conditions;
            Orders = actions;
        }

        public Strategy(ISignal condition, IOrder action)
        {
            Signals.Add(condition);
            Orders.Add(action);
        }
    }
}
