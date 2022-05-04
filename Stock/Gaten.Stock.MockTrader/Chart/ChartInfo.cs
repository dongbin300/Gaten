
using Skender.Stock.Indicators;

namespace Gaten.Stock.MockTrader.Chart
{
    internal class ChartInfo
    {
        public string Symbol { get; set; }
        public List<Candle> Candles { get; set; }
        public IEnumerable<SmaResult> MA { get; set; }
        public IEnumerable<EmaResult> EMA { get; set; }
        public IEnumerable<RsiResult> RSI { get; set; }
        public IEnumerable<MacdResult> MACD { get; set; }
        public IEnumerable<BollingerBandsResult> BollingerBands { get; set; }
        public IEnumerable<BollingerBandsResult> BollingerBands2 { get; set; }

        public int CandleCount => Candles.Count;
    }
}
