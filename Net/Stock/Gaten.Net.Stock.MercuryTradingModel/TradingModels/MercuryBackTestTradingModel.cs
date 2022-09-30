﻿using Binance.Net.Enums;

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
    }
}
