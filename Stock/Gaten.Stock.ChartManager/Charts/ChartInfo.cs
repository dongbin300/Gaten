using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;

namespace Gaten.Stock.ChartManager.Charts
{
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
}
