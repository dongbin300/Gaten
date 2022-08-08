namespace Gaten.Game.NGDG2.Util.Math
{
    public class Bounds
    {
        /// <summary>
        /// 최소값
        /// </summary>
        public long Min;

        /// <summary>
        /// 최대값
        /// </summary>
        public long Max;

        /// <summary>
        /// 최소값과 최대값의 범위
        /// </summary>
        public long Range => Max - Min;

        /// <summary>
        /// int type 생성자
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public Bounds(int min, int max)
        {
            if (min > max)
            {
                throw new Exception("Min value cannot be larger than Max value.");
            }

            Min = min;
            Max = max;
        }

        /// <summary>
        /// long type 생성자
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public Bounds(long min, long max)
        {
            if (min > max)
            {
                throw new Exception("Min value cannot be larger than Max value.");
            }

            Min = min;
            Max = max;
        }

        /// <summary>
        /// int type(32bit) 난수 추출
        /// </summary>
        /// <returns></returns>
        public int Get()
        {
            SmartRandom? r = new();

            return r.Next(Convert.ToInt32(Min), Convert.ToInt32(Max));
        }

        /// <summary>
        /// long type(64bit) 구간 난수 추출
        /// </summary>
        /// <param name="section">구간, 1을 넣을 경우 무조건 최소값이나 최대값이 나오고, 0이하를 넣으면 무조건 최소값이 나온다. Max-Min 값보다 클 수 없다.</param>
        /// <returns></returns>
        public long Get(int section)
        {
            if (section < 1)
            {
                return Min;
            }

            if (section > Max - Min)
            {
                throw new Exception("Sections cannot be larger than the Max-Min value.");
            }

            SmartRandom? r = new();

            try
            {
                long val = (Max - Min) / section;

                return Min + (val * r.Next(section + 1));
            }
            catch
            {
                return 0;
            }
        }
    }
}
