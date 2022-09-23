namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface IStrategy
    {
        public IList<ISignal> Signals { get; set; }
        public IList<IOrder> Orders { get; set; }
    }
}
