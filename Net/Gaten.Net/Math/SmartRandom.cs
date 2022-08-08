namespace Gaten.Net.Math
{
    public class SmartRandom
    {
        static long seed;

        public SmartRandom()
        {
            seed = GetCurrentMicroseconds() % 1337;
        }

        public int Next()
        {
            long abc = System.Math.Abs(GetCurrentMicroseconds() * seed % 1_000_000_000L / 10);
            seed += 13;

            return Convert.ToInt32(abc);
        }

        public int Next(int min, int max)
        {
            return Next() % (max - min) + min;
        }

        public int Next(int max)
        {
            return Next() % max;
        }

        public string Next(string str)
        {
            return str[Next(str.Length)].ToString();
        }

        public string Next(string str, int count)
        {
            string result = string.Empty;
            for(int i = 0; i < count; i++)
            {
                result += Next(str);
            }
            return result;
        }

        public T Next<T>(IEnumerable<T> values)
        {
            return values.ElementAt(Next(values.Count()));
        }

        long GetCurrentMicroseconds()
        {
            return DateTime.Now.Ticks / 10L;
        }
    }
}
