using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Conditions
{
    public class CandleCondition : Condition
    {
        public CandleCondition(CandleInterval interval) : base(interval)
        {
        }

        public void Equal(CandleProperty property, double value)
        {

        }
    }
}
