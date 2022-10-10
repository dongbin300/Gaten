using Gaten.Net.Stock.MercuryTradingModel.Assets;
using Gaten.Net.Stock.MercuryTradingModel.Charts;

namespace Gaten.Net.Stock.MercuryTradingModel.Interfaces
{
    public interface ISignal
    {
        public IFormula Formula { get; set; }
        public abstract bool IsFlare(Asset asset, ChartInfo chart);
    }
}
