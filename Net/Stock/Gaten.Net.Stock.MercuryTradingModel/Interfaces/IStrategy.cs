namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface IStrategy
    {
        public string Name { get; set; }
        public ISignal Signal { get; set; }
        public IOrder Order { get; set; }
    }
}
