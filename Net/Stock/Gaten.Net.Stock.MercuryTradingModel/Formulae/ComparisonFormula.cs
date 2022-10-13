using Gaten.Net.Stock.MercuryTradingModel.Enums;

namespace Gaten.Net.Stock.MercuryTradingModel.Formulae
{
    public class ComparisonFormula : Formula
    {
        public ChartElement ChartElement { get; set; }
        public string? ElementName { get; set; } = null;
        public Comparison Comparison { get; set; }
        public double Value { get; set; }

        public ComparisonFormula()
        {

        }

        public ComparisonFormula(ChartElement chartElement, Comparison comparison, double value)
        {
            ChartElement = chartElement;
            Comparison = comparison;
            Value = value;
        }

        public ComparisonFormula(string? elementName, Comparison comparison, double value)
        {
            ElementName = elementName;
            Comparison = comparison;
            Value = value;
        }

        public override string ToString()
        {
            var elementString = ElementName ?? ChartElement.ToString();
            return elementString + FormulaUtil.ComparisonToString(Comparison) + Value.ToString();
        }
    }
}
