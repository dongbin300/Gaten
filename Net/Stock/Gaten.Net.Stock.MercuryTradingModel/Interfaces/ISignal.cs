using Gaten.Net.Stock.MercuryTradingModel.Charts;

namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface ISignal
    {
        public IFormula Formula { get; set; }
        public abstract bool IsFlare(ChartInfo chart);
    }
}
