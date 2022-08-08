using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.GameRule.NGD2.Format
{
    /// <summary>
    /// Infinity Max Converter
    /// </summary>
    public class IMConverter
    {
        public static double GetCriticalRate(long value) => System.Math.Round(GetPercent(value, 0.5), 2);
        public static double GetSpiritDropRate(long value) => System.Math.Round(GetPercent(value, 0.33), 2);
        public static double GetSkillCardDropRate(long value) => System.Math.Round(GetPercent(value, 0.2), 2);
        public static double GetKeyPieceDropRate(long value) => System.Math.Round(GetPercent(value, 0.25), 2);
        public static double GetPsychokinesisDropRate(long value) => System.Math.Round(GetPercent(value, 0.25), 2);

        public static int GetAttackSpeed(long value) => GetReverseValueByPercent(System.Math.Round(GetPercent(value, 0.5), 2), 200, 1000);

        /// <summary>
        /// 절대 수치에 해당하는 배율(%)
        /// </summary>
        /// <param name="value">10000</param>
        /// <param name="th">0.5</param>
        /// <returns>100</returns>
        public static double GetPercent(long value, double th)
        {
            return System.Math.Pow(value, th);
        }

        /// <summary>
        /// 배율에 해당하는 값
        /// </summary>
        /// <param name="value">10</param>
        /// <param name="min">500</param>
        /// <param name="max">1500</param>
        /// <returns>600</returns>
        public static int GetValueByPercent(double value, int min, int max)
        {
            if (value <= 0) return min;
            if (value >= 100) return max;
            return (int)(min + (value / 100 * (max - min)));
        }

        /// <summary>
        /// 배율에 해당하는 역값
        /// </summary>
        /// <param name="value">10</param>
        /// <param name="min">500</param>
        /// <param name="max">1500</param>
        /// <returns>1400</returns>
        public static int GetReverseValueByPercent(double value, int min, int max)
        {
            if (value <= 0) return max;
            if (value >= 100) return min;
            return (int)(max - (value / 100 * (max - min)));
        }

        /// <summary>
        /// 배수 적용 값
        /// </summary>
        /// <param name="value">100</param>
        /// <param name="multiple">60</param>
        /// <returns>160</returns>
        public static int GetMultipleValue(int value, int multiple)
        {
            return (int)(value * (1.0 + ((double)multiple / 100)));
        }

        /// <summary>
        /// 배수 적용 값
        /// </summary>
        /// <param name="value">100</param>
        /// <param name="multiple">60</param>
        /// <returns>160</returns>
        public static long GetMultipleValue(long value, int multiple)
        {
            return (long)(value * (1.0 + ((double)multiple / 100)));
        }
    }
}
