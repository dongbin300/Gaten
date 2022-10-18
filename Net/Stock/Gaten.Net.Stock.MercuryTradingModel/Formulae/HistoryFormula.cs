using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Formulae
{
    public class HistoryFormula : Formula
    {
        public RangeElement? PeriodRangeElement { get; set; }
        public RangeElement? CountRangeElement { get; set; }
        public IFormula? Formula { get; set; }

        public HistoryFormula()
        {

        }

        public HistoryFormula(RangeElement? periodRangeElement, RangeElement? countRangeElement, IFormula? formula)
        {
            PeriodRangeElement = periodRangeElement;
            CountRangeElement = countRangeElement;
            Formula = formula;
        }

        public override string ToString()
        {
            return PeriodRangeElement?.ToString() + " " + CountRangeElement?.ToString() + " " + Formula?.ToString();
        }
    }
}
