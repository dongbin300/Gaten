using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Conditions;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Triggers;

namespace Gaten.Net.Stock.MercuryTradingModel.Scenarios
{
    /// <summary>
    /// 1. 5분봉기준 200봉내 신고가 -> 장대양봉+거래량급증 | 윗꼬리길게+거래량급증 -> 다음봉에 신고가부근에 Short 주문
    /// - (Signal)Step, And, Or
    /// - OrderType: Seed n(%), Asset n(%), Balance n(%), Symbol balance n(%), Fixed n($), Fixed n(Count)
    /// 2. -25% 부근에서 100% 추가 Short
    /// - Position Status
    /// - Additional Trade
    /// 3. -50% 부근에서 200% 추가 Short
    /// 4. 224/112 근접 | RSI 30이하 -> 포지션 정리
    /// - Indicator Compare
    /// - Close Position
    /// 
    /// 스텝 초기화 조건, 지표 혹은 시간 혹은 일정가격대
    /// 5m, 200, Max, Step, Open<Close & Volume>PrevVolume*3 | Open<High & Volume>PrevVolume*3 = Next Candle, High, Short, Seed 5%
    /// Position Status<-25% = Now, Market, Short, Symbol balance 100%
    /// Position Status<-50% = Now, Market, Short, Symbol balance 100%
    /// Indicator, EMA, 112, Cross | Indicator, EMA, 224, Cross | Indicator, RSI, 30, Cross = Now, Market, Close Position, 100%
    /// 
    /// </summary>
    public class ReversalTradingScenario : IScenario
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
        public IList<IStrategy> Triggers { get; set; } = new List<IStrategy>();

        public ReversalTradingScenario()
        {
            
        }

        public void Init()
        {
            //var trigger = new Trigger();
            var condition1 = new Signal("5m").Max(200);
            var condition2 = new Signal("5m").Contrast(CandleProperty.Close, Comparison.GreaterThan, 1);
            var condition3 = new Signal("5m").Contrast(CandleProperty.Volume, Comparison.GreaterThan, 200);
            var condition4 = new Signal("5m").Contrast(CandleProperty.High, Comparison.GreaterThan, 1);

        }
    }
}
