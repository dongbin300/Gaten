using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Formulae
{
    public class CrossFormula : Formula
    {
        public IElement Element1 { get; set; } = default!;
        public Cross Cross { get; set; } = Cross.None;
        public IElement Element2 { get; set; } = default!;

        public CrossFormula()
        {

        }

        public CrossFormula(IElement element1, Cross cross, IElement element2)
        {
            Element1 = element1;
            Cross = cross;
            Element2 = element2;
        }

        public override string ToString()
        {
            return Element1.ToString() + FormulaUtil.CrossToString(Cross) + Element2.ToString();
        }
    }
}
