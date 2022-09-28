using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Signals.Primitives
{
    public class Signal : ISignal
    {
        public ChartInfo Chart { get; set; }

        public Signal() : this(new ChartInfo("", new Skender.Stock.Indicators.Quote()))
        {

        }

        public Signal(ChartInfo chart)
        {
            Chart = chart;
        }

        public virtual bool IsFlare()
        {
            return false;
        }
    }
}
