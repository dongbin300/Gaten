using Gaten.Net.Extensions;
using Gaten.Stock.ChartManager.Extensions;

using Skender.Stock.Indicators;

using System.Collections.Generic;

namespace Gaten.Stock.ChartManager.Indicators
{
    public static class IndicatorExtension
    {
        public static IEnumerable<RiResult> GetRi(this List<Quote> quotes, int period)
        {
            IList<RiResult> result = new List<RiResult>();

            for (int i = 0; i < quotes.Count; i++)
            {
                var average = quotes.CloseAverage(i, period);
                var ri = (quotes[i].Close.Convert<double>() - average) / average * 100;
                result.Add(new RiResult(quotes[i].Date, ri));
            }

            return result;
        }
    }
}
