namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface ITrigger
    {
        public IList<ICondition> Conditions { get; set; }
        public IList<IAction> Actions { get; set; }
    }
}
