using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

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
        public ISignal RevertCondition { get; set; }

        /// <summary>
        /// 이 시나리오의 트리거
        /// </summary>
        public IList<IStrategy> Strategies { get; set; } = new List<IStrategy>();

        public RsiScenario()
        {

        }

        public void Init()
        {

        }

        public IScenario AddStrategy(IStrategy strategy)
        {
            return this;
        }
    }
}
