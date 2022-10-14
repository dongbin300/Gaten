using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Elements
{
    public class ChartElementResult
    {
        public ChartElementType Type { get; set; }
        public decimal? Value { get; set; }

        public ChartElementResult(ChartElementType type, decimal? value)
        {
            Type = type;
            Value = value;
        }
    }
}
