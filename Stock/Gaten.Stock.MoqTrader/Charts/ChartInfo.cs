
using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;

namespace Gaten.Stock.MoqTrader.Charts
{
    /// <summary>
    /// Chart information for 24 hours
    /// </summary>
    /// <param name="Symbol">Coin symbol</param>
    /// <param name="Date">Start date</param>
    /// <param name="Candles">OHLCV data</param>
    /// <param name="MA">Moving average</param>
    /// <param name="EMA">Exponential moving average</param>
    /// <param name="RSI">Relative strength index</param>
    /// <param name="MACD">Moving average convergence divergence</param>
    /// <param name="BollingerBands">First bollinger bands</param>
    /// <param name="BollingerBands2">Second bollinger bands</param>
    internal record ChartInfo(
        string Symbol,
        DateTime Date,
        IList<Candle> Candles,
        IList<SmaResult> MA,
        IList<EmaResult> EMA,
        IList<RsiResult> RSI,
        IList<MacdResult> MACD,
        IList<BollingerBandsResult> BollingerBands,
        IList<BollingerBandsResult> BollingerBands2
    )
    {
        /// <summary>
        /// Count of candle
        /// </summary>
        public int CandleCount => Candles.Count;
    }

    /// <summary>
    /// 24시간 동안의 차트 정보
    /// </summary>
    //internal class ChartInfo
    //{
    //    /// <summary>
    //    /// Coin symbol
    //    /// </summary>
    //    public string Symbol { get; set; }

    //    /// <summary>
    //    /// Start date
    //    /// </summary>
    //    public DateTime Date { get; set; }

    //    /// <summary>
    //    /// OHLCV data
    //    /// </summary>
    //    public IList<Candle> Candles { get; set; }

    //    /// <summary>
    //    /// Moving average
    //    /// </summary>
    //    public IList<SmaResult> MA { get; set; }

    //    /// <summary>
    //    /// Exponential moving average
    //    /// </summary>
    //    public IList<EmaResult> EMA { get; set; }

    //    /// <summary>
    //    /// Relative strength index
    //    /// </summary>
    //    public IList<RsiResult> RSI { get; set; }

    //    /// <summary>
    //    /// Moving average convergence divergence
    //    /// </summary>
    //    public IList<MacdResult> MACD { get; set; }

    //    /// <summary>
    //    /// First bollinger bands
    //    /// </summary>
    //    public IList<BollingerBandsResult> BollingerBands { get; set; }

    //    /// <summary>
    //    /// Second bollinger bands
    //    /// </summary>
    //    public IList<BollingerBandsResult> BollingerBands2 { get; set; }

    //    /// <summary>
    //    /// Count of candle
    //    /// </summary>
    //    public int CandleCount => Candles.Count;
    //}
}
