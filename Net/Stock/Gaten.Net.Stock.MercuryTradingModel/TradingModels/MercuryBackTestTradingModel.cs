using Binance.Net.Enums;

using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Scenarios;
using Gaten.Net.Stock.MercuryTradingModel.Triggers;

namespace Gaten.Net.Stock.MercuryTradingModel.TradingModels
{
    /// <summary>
    /// default value
    /// asset: 100000
    /// period: -7일~현재
    /// interval: 1m
    /// target: btcusdt
    /// 
    /// 10k->10000
    /// 
    /// </summary>
    public class MercuryBackTestTradingModel
    {
        public decimal Asset { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Period { get; set; }
        public KlineInterval Interval { get; set; }
        public IList<string> Targets { get; set; } = new List<string>();
        public IList<IScenario> Scenarios { get; set; }

        public MercuryBackTestTradingModel()
        {

        }

        public void AddSignal(string scenarioName, string strategyName, ISignal signal)
        {
            var scenario = Scenarios.First(s => s.Name.Equals(scenarioName));
            if (scenario == null)
            {
                var newScenario = new Scenario(scenarioName);
                var newStrategy = new Strategy(strategyName);
                newStrategy.Signal = signal;
                Scenarios.Add(newScenario);
                return;
            }

            var strategy = scenario.Strategies.First(s => s.Name.Equals(strategyName));
            if (strategy == null)
            {
                var newStrategy = new Strategy(strategyName);
                newStrategy.Signal = signal;
                scenario.Strategies.Add(newStrategy);
                return;
            }

            strategy.Signal = signal;
        }

        public void AddOrder(string scenarioName, string strategyName, IOrder order)
        {
            var scenario = Scenarios.First(s => s.Name.Equals(scenarioName));
            if (scenario == null)
            {
                var newScenario = new Scenario(scenarioName);
                var newStrategy = new Strategy(strategyName);
                newStrategy.Order = order;
                Scenarios.Add(newScenario);
                return;
            }

            var strategy = scenario.Strategies.First(s => s.Name.Equals(strategyName));
            if (strategy == null)
            {
                var newStrategy = new Strategy(strategyName);
                newStrategy.Order = order;
                scenario.Strategies.Add(newStrategy);
                return;
            }

            strategy.Order = order;
        }
    }
}
