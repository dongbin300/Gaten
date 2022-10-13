using Gaten.Net.Extensions;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Skender.Stock.Indicators;

namespace Gaten.Net.Stock.MercuryTradingModel.Indicators
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
                var ri = (quoteList[i].Close.Convert<double>() - average) / average * 1000;
                result.Add(new RiResult(quoteList[i].Date, ri));
            }

            return result;
        }
    }
}
