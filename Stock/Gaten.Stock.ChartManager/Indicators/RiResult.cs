using System;

using Skender.Stock.Indicators;

namespace Gaten.Stock.ChartManager.Indicators
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
