
using Skender.Stock.Indicators;

namespace Gaten.Stock.MockTrader.Chart
{
    /// <summary>
    /// 24시간 동안의 차트 정보
    /// </summary>
    internal class ChartInfo
    {
        /// <summary>
        /// Coin symbol
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// OHLCV data
        /// </summary>
        public IList<Candle> Candles { get; set; }

        /// <summary>
        /// Moving average
        /// </summary>
        public IList<SmaResult> MA { get; set; }

        /// <summary>
        /// Exponential moving average
        /// </summary>
        public IList<EmaResult> EMA { get; set; }

        /// <summary>
        /// Relative strength index
        /// </summary>
        public IList<RsiResult> RSI { get; set; }

        /// <summary>
        /// Moving average convergence divergence
        /// </summary>
        public IList<MacdResult> MACD { get; set; }

        /// <summary>
        /// First bollinger bands
        /// </summary>
        public IList<BollingerBandsResult> BollingerBands { get; set; }

        /// <summary>
        /// Second bollinger bands
        /// </summary>
        public IList<BollingerBandsResult> BollingerBands2 { get; set; }

        /// <summary>
        /// Count of candle
        /// </summary>
        public int CandleCount => Candles.Count;
    }
}
