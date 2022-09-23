namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface IStrategy
    {
        public IList<ISignal> Conditions { get; set; }
        public IList<IOrder> Actions { get; set; }
    }
}
