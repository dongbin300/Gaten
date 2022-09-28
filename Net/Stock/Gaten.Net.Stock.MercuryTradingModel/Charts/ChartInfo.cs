using Gaten.Net.Stock.MercuryTradingModel.Indicators;

using Skender.Stock.Indicators;

namespace Gaten.Net.Stock.MercuryTradingModel.Charts
{
    public class ChartInfo
    {
        public string Symbol { get; set; }
        public DateTime DateTime => Quote.Date;
        public Quote Quote { get; set; }
        public SmaResult MA { get; set; }
        public EmaResult EMA { get; set; }
        public RsiResult RSI { get; set; }
        public MacdResult MACD { get; set; }
        public BollingerBandsResult BollingerBands { get; set; }
        public BollingerBandsResult BollingerBands2 { get; set; }
        public RiResult RI { get; set; }

        public ChartInfo(string symbol, Quote quote)
        {
            Symbol = symbol;
            Quote = quote;
        }

        public ChartInfo(string symbol, Quote quote, SmaResult ma, EmaResult ema, RsiResult rsi, MacdResult macd, BollingerBandsResult bollingerBands, BollingerBandsResult bollingerBands2, RiResult ri)
        {
            Symbol = symbol;
            Quote = quote;
            MA = ma;
            EMA = ema;
            RSI = rsi;
            MACD = macd;
            BollingerBands = bollingerBands;
            BollingerBands2 = bollingerBands2;
            RI = ri;
        }
    }
}
