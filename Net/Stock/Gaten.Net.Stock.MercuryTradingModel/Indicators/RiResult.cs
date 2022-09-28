using Skender.Stock.Indicators;

namespace Gaten.Net.Stock.MercuryTradingModel.Indicators
{
    /// <summary>
    /// Rubber Index result by Gaten
    /// </summary>
    public class RiResult : ResultBase
    {
        public double Ri { get; set; }

        public RiResult(DateTime date, double ri)
        {
            Date = date;
            Ri = ri;
        }
    }
}
