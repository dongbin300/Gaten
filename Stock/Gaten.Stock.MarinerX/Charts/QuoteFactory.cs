using Gaten.Net.Stock.MercuryTradingModel.Charts;

using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MarinerX.Charts
{
    public class QuoteFactory
    {
        public static List<RealtimeQuote> Quotes = new();

        public static void Init()
        {

        }

        public static void UpdateQuote(RealtimeQuote quote)
        {
            try
            {
                if (quote == null)
                {
                    return;
                }

                var currentQuote = Quotes.Where(q => q != null).ToList().Find(q => q.Symbol.Equals(quote.Symbol));
                if (currentQuote != null)
                {
                    Quotes.Remove(currentQuote);
                }
                Quotes.Add(quote);
            }
            catch
            {
            }
        }

        public static RealtimeQuote? GetQuote(string symbol)
        {
            try
            {
                return Quotes.Where(q => q != null).ToList().Find(q => q.Symbol.Equals(symbol));
            }
            catch
            {
            }
            return null;
        }
    }
}
