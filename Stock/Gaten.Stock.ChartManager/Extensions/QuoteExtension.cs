using Gaten.Net.Extensions;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;

namespace Gaten.Stock.ChartManager.Extensions
{
    public static class QuoteExtension
    {
        public static double CloseAverage(this List<Quote> quotes, int currentIndex, int period)
        {
            double sum = 0;
            period = Math.Min(period, currentIndex);
            for (int i = 0; i < period; i++)
            {
                sum += quotes[currentIndex - i].Close.Convert<double>();
            }
            return sum / period;
        }

        public static double CloseStandardDeviation(this List<Quote> quotes, int currentIndex, int period)
        {
            double average = CloseAverage(quotes, currentIndex, period);

            double sum = 0;
            period = Math.Min(period, currentIndex);
            for (int i = 0; i < period; i++)
            {
                sum += Math.Pow(quotes[currentIndex - i].Close.Convert<double>() - average, 2);
            }
            return sum / period;
        }

        public static double CloseStandardDeviation(this List<Quote> quotes, int currentIndex, int period, double average)
        {
            double sum = 0;
            period = Math.Min(period, currentIndex);
            for (int i = 0; i < period; i++)
            {
                sum += Math.Pow(quotes[currentIndex - i].Close.Convert<double>() - average, 2);
            }
            return sum / period;
        }
    }
}
