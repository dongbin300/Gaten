using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Conditions
{
    public class IndicatorSignal : Signal
    {
        public IndicatorSignal(CandleInterval interval) : base(interval)
        {
        }

        public IndicatorSignal(string intervalFormatString) : base(intervalFormatString)
        {
        }

        public IndicatorSignal Rsi(Comparison comparison, double value)
        {
            return this;
        }
    }
}
