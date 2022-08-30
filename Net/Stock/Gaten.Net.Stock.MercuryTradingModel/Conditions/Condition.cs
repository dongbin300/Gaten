using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Conditions
{
    public class Condition : ICondition
    {
        public CandleInterval Interval { get; set; }
        public bool Signal { get; set; }

        public Condition(CandleInterval interval)
        {
            Interval = interval;
        }

        public Condition(string intervalFormatString)
        {
            Interval = new CandleInterval(intervalFormatString);
        }

        public Condition Max(int candleCount)
        {
            return this;
        }

        public Condition Contrast(CandleProperty property, Comparison comparison, int value)
        {
            return this;
        }

        public void Equal(CandleProperty property, double value)
        {

        }
    }
}
