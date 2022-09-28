using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Formulae;
using Gaten.Net.Stock.MercuryTradingModel.Interfaces;

namespace Gaten.Net.Stock.MercuryTradingModel.Signals
{
    public class Signal : ISignal
    {
        public ChartInfo Chart { get; set; } = new ChartInfo("", new Skender.Stock.Indicators.Quote());
        public bool Flare => IsFlare();
        public IFormula Formula { get; set; } = new Formula();

        public Signal()
        {

        }

        public Signal(ChartInfo chart)
        {
            Chart = chart;
        }

        public Signal(IFormula formula)
        {
            Formula = formula;
        }

        public virtual bool IsFlare() => Formula switch
        {
            ComparisonFormula x => x.ChartElement switch
            {
                ChartElement.rsi => x.Comparison switch
                {
                    Comparison.Equal => Chart.RSI.Rsi == x.Value,
                    Comparison.NotEqual => Chart.RSI.Rsi != x.Value,
                    Comparison.LessThan => Chart.RSI.Rsi < x.Value,
                    Comparison.LessThanOrEqual => Chart.RSI.Rsi <= x.Value,
                    Comparison.GreaterThan => Chart.RSI.Rsi > x.Value,
                    Comparison.GreaterThanOrEqual => Chart.RSI.Rsi >= x.Value,
                    _ => false,
                },
                _ => false
            },
            _ => false
        };
    }
}
