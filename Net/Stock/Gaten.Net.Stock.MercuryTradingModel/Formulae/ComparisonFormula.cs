using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Formulae
{
    public class ComparisonFormula : Formula
    {
        public ChartElement ChartElement { get; set; }
        public Comparison Comparison { get; set; }
        public double Value { get; set; }

        public ComparisonFormula(ChartElement chartElement, Comparison comparison, double value)
        {
            ChartElement = chartElement;
            Comparison = comparison;
            Value = value;
        }
    }
}
