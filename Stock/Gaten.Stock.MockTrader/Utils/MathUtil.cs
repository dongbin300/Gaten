using Gaten.Stock.MockTrader.Chart;

namespace Gaten.Stock.MockTrader.Utils
{
    internal class MathUtil
    {
        public static double CloseAverage(List<Candle> candles, int currentIndex, int period)
        {
            double sum = 0;
            for (int i = 0; i < period; i++)
            {
                sum += candles[currentIndex - i].Close;
            }
            return sum / period;
        }

        public static double CloseStandardDeviation(List<Candle> candles, int currentIndex, int period)
        {
            double average = CloseAverage(candles, currentIndex, period);

            double sum = 0;
            for (int i = 0; i < period; i++)
            {
                sum += Math.Pow(candles[currentIndex - i].Close - average, 2);
            }
            return sum / period;
        }

        public static double CloseStandardDeviation(List<Candle> candles, int currentIndex, int period, double average)
        {
            double sum = 0;
            for (int i = 0; i < period; i++)
            {
                sum += Math.Pow(candles[currentIndex - i].Close - average, 2);
            }
            return sum / period;
        }

        public static string POE(double start, double end)
        {
            double value = Math.Round((end - start) / start * 100, 2);
            return value >= 0 ? "+" + value + "%" : value + "%";
        }
    }
}
