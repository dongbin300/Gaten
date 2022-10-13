using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Net.Stock.MercuryTradingModel.Indicators;

using Skender.Stock.Indicators;

namespace Gaten.Net.Stock.MercuryTradingModel.Charts
{
    public class ChartInfo
    {
        // Basic Info
        public string Symbol { get; set; }
        public string BaseAsset => Symbol.Replace("USDT", "");
        public DateTime DateTime => Quote.Date;
        public Quote Quote { get; set; }

        // Indicator Info
        public SmaResult MA { get; set; } = default!;
        public EmaResult EMA { get; set; } = default!;
        public RsiResult RSI { get; set; } = default!;
        public MacdResult MACD { get; set; } = default!;
        public BollingerBandsResult BollingerBands { get; set; } = default!;
        public RiResult RI { get; set; } = default!;
        public IList<NamedElementResult> NamedElements { get; set; } = new List<NamedElementResult>();

        public ChartInfo(string symbol, Quote quote)
        {
            Symbol = symbol;
            Quote = quote;
        }

        public NamedElementResult? GetNamedElementResult(string name) => NamedElements.FirstOrDefault(x => x != null && x.Name.Equals(name), null);
        public double? GetNamedElementValue(string name) => GetNamedElementResult(name)?.Value;
    }
}
