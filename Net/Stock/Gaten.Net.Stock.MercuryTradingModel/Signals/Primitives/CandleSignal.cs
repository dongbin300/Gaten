using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Signals.Primitives
{
    public class CandleSignal : Signal
    {
        public CandleSignal(ChartInfo chart) : base(chart)
        {
        }

        public void Equal(CandleProperty property, double value)
        {

        }
    }
}
