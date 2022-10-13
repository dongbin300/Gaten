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
        public IList<SmaResult> MA { get; set; } = new List<SmaResult>();
        public IList<EmaResult> EMA { get; set; } = new List<EmaResult>();
        public IList<RsiResult> RSI { get; set; } = new List<RsiResult>();
        public IList<MacdResult> MACD { get; set; } = new List<MacdResult>();
        public IList<BollingerBandsResult> BollingerBands { get; set; } = new List<BollingerBandsResult>();
        public IList<RiResult> RI { get; set; } = new List<RiResult>();

        public ChartInfo(string symbol, Quote quote)
        {
            Symbol = symbol;
            Quote = quote;
        }
    }
}
