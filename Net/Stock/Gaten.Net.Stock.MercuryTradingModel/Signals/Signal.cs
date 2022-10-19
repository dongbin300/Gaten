using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Formulae;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Signals
{
    public class Signal : ISignal
    {
        public IFormula Formula { get; set; } = new Formula();

        public Signal()
        {

        }

        public Signal(IFormula formula)
        {
            Formula = formula;
        }

        private decimal? GetElementValue(IElement element, ChartInfo chart)
        {
            return element switch
            {
                ChartElement x => chart.GetChartElementValue(x.ElementType),
                NamedElement x => chart.GetNamedElementValue(x.Name),
                ValueElement x => x.Value,
                _ => null
            };
        }

        public virtual bool IsFlare(Asset asset, ChartInfo chart) => Formula switch
        {
            ComparisonFormula x => IsFlare(x, asset, chart),
            AndFormula x => IsFlare(x.Formula1, asset, chart) && IsFlare(x.Formula2, asset, chart),
            OrFormula x => IsFlare(x.Formula1, asset, chart) || IsFlare(x.Formula2, asset, chart),
            _ => false
        };

        private bool IsFlare(IFormula? formula, Asset asset, ChartInfo chart)
        {
            return formula switch
            {
                ComparisonFormula x => x.Comparison switch
                {
                    Comparison.Equal => GetElementValue(x.Element1, chart) == GetElementValue(x.Element2, chart),
                    Comparison.NotEqual => GetElementValue(x.Element1, chart) != GetElementValue(x.Element2, chart),
                    Comparison.LessThan => GetElementValue(x.Element1, chart) < GetElementValue(x.Element2, chart),
                    Comparison.LessThanOrEqual => GetElementValue(x.Element1, chart) <= GetElementValue(x.Element2, chart),
                    Comparison.GreaterThan => GetElementValue(x.Element1, chart) > GetElementValue(x.Element2, chart),
                    Comparison.GreaterThanOrEqual => GetElementValue(x.Element1, chart) >= GetElementValue(x.Element2, chart),
                    _ => false
                },
                _ => false
            };
        }
    }
}
