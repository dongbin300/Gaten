using Binance.Net.Enums;

using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Scenarios;
using Gaten.Net.Stock.MercuryTradingModel.Strategies;

namespace Gaten.Net.Stock.MercuryTradingModel.TradingModels
{
    public class MercuryBackTestTradingModel
    {
        public decimal Asset { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Period { get; set; }
        public KlineInterval Interval { get; set; }
        public IList<string> Targets { get; set; } = new List<string>();
        public IList<IScenario> Scenarios { get; set; } = new List<IScenario>();
        public IList<ChartElement> ChartElements { get; set; } = new List<ChartElement>();
        public IList<NamedElement> NamedElements { get; set; } = new List<NamedElement>();

        public MercuryBackTestTradingModel()
        {

        }

        public void AddSignal(string scenarioName, string strategyName, ISignal signal)
        {
            var scenario = Scenarios.FirstOrDefault(s => s.Name.Equals(scenarioName));
            if (scenario == null)
            {
                Scenarios.Add(
                    new Scenario(scenarioName)
                    .AddStrategy(new Strategy(strategyName, signal))
                    );
                return;
            }

            var strategy = scenario.Strategies.FirstOrDefault(s => s.Name.Equals(strategyName));
            if (strategy == null)
            {
                scenario.AddStrategy(new Strategy(strategyName, signal));
                return;
            }

            strategy.Signal = signal;
        }

        public void AddOrder(string scenarioName, string strategyName, IOrder order)
        {
            var scenario = Scenarios.FirstOrDefault(s => s.Name.Equals(scenarioName));
            if (scenario == null)
            {
                Scenarios.Add(
                new Scenario(scenarioName)
                   .AddStrategy(new Strategy(strategyName, order))
                   );
                return;
            }

            var strategy = scenario.Strategies.FirstOrDefault(s => s.Name.Equals(strategyName));
            if (strategy == null)
            {
                scenario.AddStrategy(new Strategy(strategyName, order));
                return;
            }

            strategy.Order = order;
        }

        public string AddNamedElement(string name, string parameterString)
        {
            if (NamedElements.Any(x => x.Name.Equals(name)))
            {
                return "이미 존재하는 이름입니다.";
            }

            NamedElements.Add(new NamedElement(name, parameterString));
            return string.Empty;
        }

        public bool AnyNamedElement(string name) => NamedElements.Any(x => x.Name.Equals(name));
        public NamedElement? GetNamedElement(string name) => NamedElements.FirstOrDefault(x => x.Name.Equals(name));
    }
}
