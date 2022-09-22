namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface ITradingModel
    {
        public IList<IScenario> Scenarios { get; set; }
        public string ScenarioNameInProgress { get; set; }
    }
}
