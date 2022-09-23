using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Conditions
{
    public class CandleSignal : Signal
    {
        public CandleSignal(CandleInterval interval) : base(interval)
        {
        }

        public void Equal(CandleProperty property, double value)
        {

        }
    }
}
