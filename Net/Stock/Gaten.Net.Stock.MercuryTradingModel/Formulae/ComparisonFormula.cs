using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Formulae
{
    public class ComparisonFormula : Formula
    {
        public IElement Element1 { get; set; } = default!;
        public Comparison Comparison { get; set; } = Comparison.None;
        public IElement Element2 { get; set; } = default!;

        public ComparisonFormula()
        {

        }

        public ComparisonFormula(IElement element1, Comparison comparison, IElement element2)
        {
            Element1 = element1;
            Comparison = comparison;
            Element2 = element2;
        }

        public override string ToString()
        {
            return Element1.ToString() + FormulaUtil.ComparisonToString(Comparison) + Element2.ToString();
        }
    }
}
