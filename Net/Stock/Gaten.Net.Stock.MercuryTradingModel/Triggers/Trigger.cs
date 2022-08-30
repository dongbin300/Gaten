using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Triggers
{
    public class Trigger : ITrigger
    {
        public IList<ICondition> Conditions { get; set; } = new List<ICondition>();
        public IList<IAction> Actions { get; set; } = new List<IAction>();

        public Trigger(IList<ICondition> conditions, IList<IAction> actions)
        {
            Conditions = conditions;
            Actions = actions;
        }

        public Trigger(ICondition condition, IAction action)
        {
            Conditions.Add(condition);
            Actions.Add(action);
        }
    }
}
