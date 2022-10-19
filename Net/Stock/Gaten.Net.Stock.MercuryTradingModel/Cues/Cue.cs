using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Formulae;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;
using Gaten.Net.Stock.MercuryTradingModel.Signals;

using Newtonsoft.Json;

namespace Gaten.Net.Stock.MercuryTradingModel.Cues
{
    public class Cue : ICue
    {
        public IFormula Formula { get; set; } = new Formula();
        public int Life { get; set; }
        [JsonIgnore]
        public int CurrentLife { get; set; }

        public Cue()
        {

        }

        public Cue(IFormula formula, int life)
        {
            Formula = formula;
            Life = life;
        }

        public virtual bool CheckFlare(Asset asset, ChartInfo chart)
        {
            var formula = new Signal(Formula);
            if (formula.IsFlare(asset, chart))
            {
                CurrentLife = Life;
                return true;
            }

            return --CurrentLife > 0;
        }

        public virtual void Expire()
        {
            CurrentLife = 0;
        }

        public override string ToString()
        {
            return Formula.ToString() + " " + Life.ToString();
        }
    }
}
