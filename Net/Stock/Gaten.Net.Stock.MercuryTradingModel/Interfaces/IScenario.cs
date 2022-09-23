namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface IScenario
    {
        public string Name { get; set; }
        public IList<IStrategy> Strategies { get; set; }
    }
}
