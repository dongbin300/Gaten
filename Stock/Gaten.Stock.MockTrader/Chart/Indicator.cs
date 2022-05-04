using Gaten.Stock.MockTrader.Utils;

namespace Gaten.Stock.MockTrader.Chart
{
    /// <summary>
    /// 지금은 사용하지 않음
    /// </summary>
    internal class Indicator
    {
        public static List<double> MA(List<Candle> candles, int period)
        {
            List<double> MA_VALUES = new List<double>();

            for (int i = 0; i < period - 1; i++)
            {
                MA_VALUES.Add(candles[i].Close);
            }

            for (int i = period - 1; i < candles.Count; i++)
            {
                MA_VALUES.Add(MathUtil.CloseAverage(candles, i, period));
            }

            return MA_VALUES;
        }

        public static List<double> EMA(List<Candle> candles, int period)
        {
            List<double> EMA_VALUES = new List<double>();

            double a = 2.0 / (period + 1.0);

            EMA_VALUES.Add(candles[0].Close);
            for (int i = 1; i < candles.Count; i++)
            {
                double result = candles[i].Close * a + EMA_VALUES[^1] * (1.0 - a);
                EMA_VALUES.Add(result);
            }

            return EMA_VALUES;
        }

        public static List<Band> BollingerBands(List<Candle> candles, int period, double scale)
        {
            List<Band> bands = new List<Band>();

            for (int i = 0; i < period - 1; i++)
            {
                bands.Add(new Band(0, 0, 0));
            }

            for (int i = period - 1; i < candles.Count; i++)
            {
                double middle = MathUtil.CloseAverage(candles, i, period);
                double lower = middle - scale * MathUtil.CloseStandardDeviation(candles, i, period, middle);
                double upper = middle + scale * MathUtil.CloseStandardDeviation(candles, i, period, middle);
                bands.Add(new Band(
                    Math.Round(upper, 5),
                    Math.Round(middle, 5),
                    Math.Round(lower, 5)
                    ));
            }

            return bands;
        }

        public static List<double> RSI(List<Candle> candles, int period)
        {
            List<double> RSI_VALUES = new List<double>();
            List<double> SUP_VALUES = new List<double>();
            List<double> SDOWN_VALUES = new List<double>();

            double a = 1.0 / period;

            RSI_VALUES.Add(50);
            SUP_VALUES.Add(0);
            SDOWN_VALUES.Add(0);
            for (int i = 1; i < candles.Count; i++)
            {
                double up = candles[i].Close > candles[i - 1].Close ? candles[i].Close - candles[i - 1].Close : 0;
                double down = candles[i].Close < candles[i - 1].Close ? candles[i - 1].Close - candles[i].Close : 0;
                double sup = (up - SUP_VALUES[^1]) * a + SUP_VALUES[^1];
                double sdown = (down - SDOWN_VALUES[^1]) * a + SDOWN_VALUES[^1];
                double result = 100.0 * (sup / (sup + sdown));

                RSI_VALUES.Add(result);
                SUP_VALUES.Add(sup);
                SDOWN_VALUES.Add(sdown);
            }

            return RSI_VALUES;
        }
    }
}
