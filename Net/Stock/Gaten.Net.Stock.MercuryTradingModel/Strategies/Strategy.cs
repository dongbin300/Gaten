using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Triggers
{
    public class Strategy : IStrategy
    {
        public IList<ISignal> Conditions { get; set; } = new List<ISignal>();
        public IList<IOrder> Actions { get; set; } = new List<IOrder>();

        public Strategy(IList<ISignal> conditions, IList<IOrder> actions)
        {
            Conditions = conditions;
            Actions = actions;
        }

        public Strategy(ISignal condition, IOrder action)
        {
            Conditions.Add(condition);
            Actions.Add(action);
        }
    }
}
