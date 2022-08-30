using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Conditions
{
    public class IndicatorCondition : Condition
    {
        public IndicatorCondition(CandleInterval interval) : base(interval)
        {
        }

        public IndicatorCondition(string intervalFormatString) : base(intervalFormatString)
        {
        }

        public IndicatorCondition Rsi(Comparison comparison, double value)
        {
            return this;
        }
    }
}
