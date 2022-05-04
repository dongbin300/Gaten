namespace Gaten.Net.GameRule.osu
{
    [Flags]
    public enum ModTypes
    {
        HardRock = 1,
        DoubleTime = 2
    }

    public class ApproachRate
    {
        public static int GetMilliseconds(double approachRate)
        {
            if (approachRate >= 5.0)
            {
                return (int)(1950 - 150 * approachRate);
            }
            else
            {
                return (int)(1800 - 120 * approachRate);
            }
        }

        private static int GetMilliseconds(double approachRate, ModTypes modTypes)
        {
            if (approachRate > 10.0 | approachRate < 0.0) return -1;

            if (modTypes.Equals(ModTypes.HardRock | ModTypes.DoubleTime))
            {
                if (approachRate <= 7.1)
                {
                    double num3 = approachRate * 1.4;
                    if (num3 <= 5.0)
                    {
                        double num4 = (1800.0 - num3 * 120.0) / 1.5;
                        if (num4 >= 1200.0)
                        {
                            return (int)num4;
                        }
                        else
                        {
                            return (int)((1200.0 - (num3 - 5.0) * 150.0) / 1.5);
                        }
                    }
                    else
                    {
                        return (int)((1200.0 - (num3 - 5.0) * 150.0) / 1.5);
                    }
                }
                else
                {
                    return 300;
                }
            }
            else if (modTypes.Equals(ModTypes.HardRock))
            {
                return (int)HR(approachRate);
            }
            else if (modTypes.Equals(ModTypes.DoubleTime))
            {
                return (int)DT(approachRate);
            }
            else
            {
                return GetMilliseconds(approachRate);
            }
        }

        private static double HR(double ar)
        {
            if (ar <= 7.1)
            {
                ar *= 1.4;
                return ar > 5.0 ? 1200.0 - (ar - 5.0) * 150.0 : 1800.0 - ar * 120.0;
            }
            else
            {
                ar = 10.0;
                return 1200.0 - (ar - 5.0) * 150.0;
            }
        }

        private static double DT(double ar)
        {
            return ar > 5.0 ? (1200.0 - (ar - 5.0) * 150.0) / 1.5 : (1800.0 - ar * 120.0) / 1.5;
        }
    }
}
