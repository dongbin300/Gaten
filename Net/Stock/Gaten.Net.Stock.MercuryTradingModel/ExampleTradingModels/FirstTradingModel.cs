using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Scenarios;

namespace Gaten.Net.Stock.MercuryTradingModel.ExampleTradingModels
{
    public class FirstTradingModel : ITradingModel
    {
        public IList<IScenario> Scenarios { get; set; } = new List<IScenario>();

        public FirstTradingModel()
        {
            //var scenario = new ReversalTradingScenario();
            var scenario = new RsiScenario();
            scenario.Init();
            Scenarios.Add(scenario);
        }
    }
}
