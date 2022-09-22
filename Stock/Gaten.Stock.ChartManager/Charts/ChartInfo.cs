using Gaten.Net.Stock.Charts;
using Gaten.Stock.ChartManager.Indicators;

using Skender.Stock.Indicators;

using System;

namespace Gaten.Stock.ChartManager.Charts
{
    //internal record _ChartInfo(
    //     string Symbol,
    //     DateTime Date,
    //     IList<Candle> Candles,
    //     IList<SmaResult> MA,
    //     IList<EmaResult> EMA,
    //     IList<RsiResult> RSI,
    //     IList<MacdResult> MACD,
    //     IList<BollingerBandsResult> BollingerBands,
    //     IList<BollingerBandsResult> BollingerBands2,
    //     IList<RiResult> RI
    // )
    //{
    //    /// <summary>
    //    /// Count of candle
    //    /// </summary>
    //    public int CandleCount => Candles.Count;
    //}

    internal class ChartInfo
    {
        public string Symbol { get; set; }
        public DateTime DateTime => Candle.Time;
        public Candle Candle { get; set; }
        public SmaResult MA { get; set; }
        public EmaResult EMA { get; set; }
        public RsiResult RSI { get; set; }
        public MacdResult MACD { get; set; }
        public BollingerBandsResult BollingerBands { get; set; }
        public BollingerBandsResult BollingerBands2 { get; set; }
        public RiResult RI { get; set; }

        public ChartInfo(string symbol, Candle candle)
        {
            Symbol = symbol;
            Candle = candle;
        }

        public ChartInfo(string symbol, Candle candle, SmaResult ma, EmaResult ema, RsiResult rsi, MacdResult macd, BollingerBandsResult bollingerBands, BollingerBandsResult bollingerBands2, RiResult ri)
        {
            Symbol = symbol;
            Candle = candle;
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
