using Gaten.Net.Stock.MercuryTradingModel.Conditions;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Triggers;

using Action = Gaten.Net.Stock.MercuryTradingModel.Actions.Action;

namespace Gaten.Net.Stock.MercuryTradingModel.Scenarios
{
    /// <summary>
    /// 1. RSI 30 이하면 시드의 5% Long
    /// 2. RSI 70 이상이면 시드의 5% Short
    /// </summary>
    public class RsiScenario : IScenario
    {
        public string Name { get; set; }

        /// <summary>
        /// 이 시나리오가 진행중인지
        /// </summary>
        public bool IsWatching { get; set; }

        /// <summary>
        /// 이 시나리오가 진행중일 때 원래 상태로 되돌아가는 조건(신호 단계 초기화)
        /// </summary>
        public ICondition RevertCondition { get; set; }

        /// <summary>
        /// 이 시나리오의 트리거
        /// </summary>
        public IList<ITrigger> Triggers { get; set; } = new List<ITrigger>();

        public RsiScenario()
        {

        }

        public void Init()
        {
            var condition1 = new IndicatorCondition("5m").Rsi(Comparison.LessThanOrEqual, 30);
            var condition2 = new IndicatorCondition("5m").Rsi(Comparison.GreaterThanOrEqual, 70);
            var action1 = new Action().Position(PositionSide.Long, OrderType.Seed, 5);
            var action2 = new Action().Position(PositionSide.Short, OrderType.Seed, 5);
            var trigger1 = new Trigger(condition1, action1);
            var trigger2 = new Trigger(condition2, action2);
            Triggers.Add(trigger1);
            Triggers.Add(trigger2);
        }
    }
}
