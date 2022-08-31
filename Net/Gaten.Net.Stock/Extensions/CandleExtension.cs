using Gaten.Net.Stock.Charts;

namespace Gaten.Net.Stock.Extensions
{
    public static class CandleExtension
    {
        public static double CloseAverage(this List<Candle> candles, int currentIndex, int period)
        {
            double sum = 0;
            period = System.Math.Min(period, currentIndex);
            for (int i = 0; i < period; i++)
            {
                sum += candles[currentIndex - i].Close;
            }
            return sum / period;
        }

        public static double CloseStandardDeviation(this List<Candle> candles, int currentIndex, int period)
        {
            double average = CloseAverage(candles, currentIndex, period);

            double sum = 0;
            period = System.Math.Min(period, currentIndex);
            for (int i = 0; i < period; i++)
            {
                sum += System.Math.Pow(candles[currentIndex - i].Close - average, 2);
            }
            return sum / period;
        }

        public static double CloseStandardDeviation(this List<Candle> candles, int currentIndex, int period, double average)
        {
            double sum = 0;
            period = System.Math.Min(period, currentIndex);
            for (int i = 0; i < period; i++)
            {
                sum += System.Math.Pow(candles[currentIndex - i].Close - average, 2);
            }
            return sum / period;
        }
    }
}
