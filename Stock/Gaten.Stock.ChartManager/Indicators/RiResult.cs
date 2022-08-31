using System;

namespace Gaten.Stock.ChartManager.Indicators
{
    public class RiResult
    {
        public DateTime Date { get; set; }
        public double Ri { get; set; }

        public RiResult(DateTime date, double ri)
        {
            Date = date;
            Ri = ri;
        }
    }
}
