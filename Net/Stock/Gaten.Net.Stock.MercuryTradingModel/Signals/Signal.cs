using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Conditions
{
    public class Signal : ISignal
    {
        public CandleInterval Interval { get; set; }

        public Signal(CandleInterval interval)
        {
            Interval = interval;
        }

        public Signal(string intervalFormatString)
        {
            Interval = new CandleInterval(intervalFormatString);
        }

        public Signal Max(int candleCount)
        {
            return this;
        }

        public Signal Contrast(CandleProperty property, Comparison comparison, int value)
        {
            return this;
        }

        public void Equal(CandleProperty property, double value)
        {

        }
    }
}
