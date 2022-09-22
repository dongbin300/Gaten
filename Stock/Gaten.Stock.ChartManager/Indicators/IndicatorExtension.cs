using Gaten.Net.Extensions;
using Gaten.Stock.ChartManager.Extensions;

using Skender.Stock.Indicators;

using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.ChartManager.Indicators
{
    public static class IndicatorExtension
    {
        public static IEnumerable<RiResult> GetRi(this IEnumerable<Quote> quotes, int period)
        {
            IList<RiResult> result = new List<RiResult>();
            var quoteList = quotes.ToList();

            for (int i = 0; i < quoteList.Count; i++)
            {
                var average = quoteList.CloseAverage(i, period);
                var ri = (quoteList[i].Close.Convert<double>() - average) / average * 100;
                result.Add(new RiResult(quoteList[i].Date, ri));
            }

            return result;
        }
    }
}
