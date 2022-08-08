using Gaten.Net.Math;

using Skender.Stock.Indicators;

using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Gaten.Stock.ChartManager.Charts
{
    /// <summary>
    // Gateway 0 푸리에 변환
    // Gateway 1 차트예측
    // Gateway 2 수익기법
    // Gateway 3 매매모델
    // Gateway 4 매매봇


    // Gateway 0 푸리에 변환 Complete!!

    // Gateway 1 차트예측
    // 인풋데이터에 변동을 조금 줘야 할듯(주파수가 너무 작게 나옴)
    // FFT 적용 후 미래 차트 예측
    /// </summary>
    public class ChartUtil
    {
        /// <summary>
        /// Get Sine Wave Prediction
        /// </summary>
        /// <param name="quotes"></param>
        /// <returns></returns>
        public static List<int> GetSwp(List<Quote> quotes)
        {
            var newQuotes = quotes.Take(1024).ToList();

            var low = newQuotes.Min(x => x.Low);
            var high = newQuotes.Max(x => x.High);
            var mid = (low + high) / 2;

            Complex[] values = new Complex[1024];
            for (int i = 0; i < newQuotes.Count; i++)
            {
                values[i] = new Complex((double)(newQuotes[i].Open + newQuotes[i].Close) / 2 - (double)mid, 0);
            }
            FourierTransform.FFT(values, FourierTransform.Direction.Forward);
            return FourierTransform.GetSmartPeaks(values);
        }
    }
}
