using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Times
{
    public class ActionTiming
    {
        public TimingType TimingType { get; set; }
        public double Value { get; set; }

        public ActionTiming(TimingType type, double value = 0)
        {
            TimingType = type;
            Value = value;
        }
    }
}
