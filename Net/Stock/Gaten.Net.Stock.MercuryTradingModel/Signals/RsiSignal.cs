using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Stock.MercuryTradingModel.Signals.Primitives;

namespace Gaten.Net.Stock.MercuryTradingModel.Signals
{
    public class RsiSignal : IndicatorSignal
    {
        public Comparison Comparison { get; set; }
        public double Value { get; set; }
        public bool Flare => IsFlare();

        public RsiSignal(ChartInfo chart) : base(chart)
        {

        }

        public override bool IsFlare() => Comparison switch
        {
            Comparison.Equal => Chart.RSI.Rsi == Value,
            Comparison.NotEqual => Chart.RSI.Rsi != Value,
            Comparison.LessThan => Chart.RSI.Rsi < Value,
            Comparison.LessThanOrEqual => Chart.RSI.Rsi <= Value,
            Comparison.GreaterThan => Chart.RSI.Rsi > Value,
            Comparison.GreaterThanOrEqual => Chart.RSI.Rsi >= Value,
            _ => false,
        };
    }
}
