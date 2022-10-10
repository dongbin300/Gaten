using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Formulae
{
    public class OrFormula : Formula
    {
        public IFormula? Formula1 { get; set; }
        public IFormula? Formula2 { get; set; }

        public OrFormula(IFormula? formula1, IFormula? formula2)
        {
            Formula1 = formula1;
            Formula2 = formula2;
        }

        public override string ToString()
        {
            return Formula1?.ToString() + " or " + Formula2?.ToString();
        }
    }
}
