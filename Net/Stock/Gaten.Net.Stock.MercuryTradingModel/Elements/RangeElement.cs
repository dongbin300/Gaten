using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class RangeElement : IElement
    {
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }

        public RangeElement(decimal startValue, decimal endValue)
        {
            StartValue = startValue;
            EndValue = endValue;
        }

        public override string ToString()
        {
            return StartValue.ToString() + "~" + EndValue.ToString();
        }
    }
}
