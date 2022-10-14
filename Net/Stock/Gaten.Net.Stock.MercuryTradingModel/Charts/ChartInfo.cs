using Gaten.Net.Stock.MercuryTradingModel.Elements;
using Gaten.Net.Stock.MercuryTradingModel.Enums;

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
        public IList<ChartElementResult> ChartElements { get; set; } = new List<ChartElementResult>();
        public IList<NamedElementResult> NamedElements { get; set; } = new List<NamedElementResult>();

        public ChartInfo(string symbol, Quote quote)
        {
            Symbol = symbol;
            Quote = quote;
        }

        public ChartElementResult? GetChartElementResult(ChartElementType type) => ChartElements.FirstOrDefault(x => x != null && x.Type.Equals(type), null);
        public decimal? GetChartElementValue(ChartElementType type) => type switch
        {
            ChartElementType.candle_open => Quote.Open,
            ChartElementType.candle_high => Quote.High,
            ChartElementType.candle_low => Quote.Low,
            ChartElementType.candle_close => Quote.Close,
            ChartElementType.volume => Quote.Volume,
            _ => GetChartElementResult(type)?.Value,
        };
        public NamedElementResult? GetNamedElementResult(string name) => NamedElements.FirstOrDefault(x => x != null && x.Name.Equals(name), null);
        public decimal? GetNamedElementValue(string name) => GetNamedElementResult(name)?.Value;
    }
}
