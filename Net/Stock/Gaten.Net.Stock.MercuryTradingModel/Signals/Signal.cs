using Gaten.Net.Extensions;
using Gaten.Net.Stock.MercuryTradingModel.Assets;
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

        public virtual bool IsFlare(Asset asset, ChartInfo chart) => Formula switch
        {
            ComparisonFormula x => IsFlare(x, asset, chart),
            AndFormula x => IsFlare(x.Formula1, asset, chart) && IsFlare(x.Formula2, asset, chart),
            OrFormula x => IsFlare(x.Formula1, asset, chart) || IsFlare(x.Formula2, asset, chart),
            _ => false
        };

        private bool IsFlare(IFormula? formula, Asset asset, ChartInfo chart)
        {
            var position = asset.Position.Value.Convert<double>();
            var rsi = chart.RSI.;
            var ri = chart.RI.Ri;

            return formula switch
            {
                ComparisonFormula x => x.ChartElement switch
                {
                    ChartElement.position => x.Comparison switch
                    {
                        Comparison.Equal => position == x.Value,
                        Comparison.NotEqual => position != x.Value,
                        Comparison.LessThan => position < x.Value,
                        Comparison.LessThanOrEqual => position <= x.Value,
                        Comparison.GreaterThan => position > x.Value,
                        Comparison.GreaterThanOrEqual => position >= x.Value,
                        _ => false
                    },
                    ChartElement.rsi => x.Comparison switch
                    {
                        Comparison.Equal => rsi == x.Value,
                        Comparison.NotEqual => rsi != x.Value,
                        Comparison.LessThan => rsi < x.Value,
                        Comparison.LessThanOrEqual => rsi <= x.Value,
                        Comparison.GreaterThan => rsi > x.Value,
                        Comparison.GreaterThanOrEqual => rsi >= x.Value,
                        _ => false
                    },
                    ChartElement.ri => x.Comparison switch
                    {
                        Comparison.Equal => ri == x.Value,
                        Comparison.NotEqual => ri != x.Value,
                        Comparison.LessThan => ri < x.Value,
                        Comparison.LessThanOrEqual => ri <= x.Value,
                        Comparison.GreaterThan => ri > x.Value,
                        Comparison.GreaterThanOrEqual => ri >= x.Value,
                        _ => false
                    },
                    _ => false
                },
                _ => false
            };
        }
    }
}
