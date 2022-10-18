using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class TradeElement : IElement
    {
        public TradeElementType ElementType { get; set; }
        public decimal Value { get; set; }

        public TradeElement(TradeElementType elementType, decimal value)
        {
            ElementType = elementType;
            Value = value;
        }

        public override string ToString()
        {
            return ElementType.ToString() + " " + Value.ToString();
        }
    }
}
