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

            if(chart.RI == null)
            {
                return false;
            }

            var rsi = chart.RSI.Rsi;
            var ri = chart.RI.Ri;

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
                    ChartElement.ri => x.Comparison switch
                    {
                        Comparison.Equal => ri == x.Value,
                        Comparison.NotEqual => ri != x.Value,
                        Comparison.LessThan => ri < x.Value,
                        Comparison.LessThanOrEqual => ri <= x.Value,
                        Comparison.GreaterThan => ri > x.Value,
                        Comparison.GreaterThanOrEqual => ri >= x.Value,
                        _ => false,
                    },
                    _ => false
                },
                _ => false
            };
        }
    }
}
