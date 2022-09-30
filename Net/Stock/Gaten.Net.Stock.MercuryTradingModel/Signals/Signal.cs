using Gaten.Net.Stock.MercuryTradingModel.Charts;
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

        public virtual bool IsFlare(ChartInfo chart)
        {
            if (chart.RSI == null)
            {
                return false;
            }

            var rsi = chart.RSI.Rsi;

            return Formula switch
            {
                ComparisonFormula x => x.ChartElement switch
                {
                    ChartElement.rsi => x.Comparison switch
                    {
                        Comparison.Equal => rsi == x.Value,
                        Comparison.NotEqual => rsi != x.Value,
                        Comparison.LessThan => rsi < x.Value,
                        Comparison.LessThanOrEqual => rsi <= x.Value,
                        Comparison.GreaterThan => rsi > x.Value,
                        Comparison.GreaterThanOrEqual => rsi >= x.Value,
                        _ => false,
                    },
                    _ => false
                },
                _ => false
            };
        }
    }
}
