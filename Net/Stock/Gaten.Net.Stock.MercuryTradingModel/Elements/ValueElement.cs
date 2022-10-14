using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class ValueElement : IElement
    {
        public decimal Value { get; set; }

        public ValueElement(decimal value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
