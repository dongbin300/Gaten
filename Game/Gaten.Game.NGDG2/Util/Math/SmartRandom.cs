namespace Gaten.Game.NGDG2.Util.Math
{
    public class SmartRandom
    {
        private static long seed;

        public SmartRandom()
        {
            seed = 1337;
        }

        public int Next()
        {
            Thread.Sleep(1);

            long abc = System.Math.Abs(GetCurrentMicroseconds() * seed % 1_000_000_000L / 10);
            seed += 13;

            return Convert.ToInt32(abc);
        }

        public int Next(int min, int max)
        {
            return (Next() % (max - min)) + min;
        }

        public int Next(int max)
        {
            return Next() % max;
        }

        private long GetCurrentMicroseconds()
        {
            return DateTime.Now.Ticks / 10L;
        }
    }
}
