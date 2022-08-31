using Skender.Stock.Indicators;

using System.Collections.Generic;

namespace Gaten.Stock.ChartManager.Indicators
{
    public static class IndicatorExtension
    {
        public static IEnumerable<RiResult> GetRi(this List<Quote> quotes)
        {
            IList<RiResult> result = new List<RiResult>();

            return result;
        }
    }
}
