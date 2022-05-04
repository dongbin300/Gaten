namespace Gaten.Net.GameRule.osu.OsuFile.Headers
{
    public class TimingPoint
    {
        public double TimingPosition;
        public double OneBeatMillisecond;
        public int A;
        public int B;
        public int C;
        public int D;
        public int E;
        public int F;

        public TimingPoint() { }

        public TimingPoint(double timingPosition, double oneBeatMillisecond, int a, int b, int c, int d, int e, int f)
        {
            TimingPosition = timingPosition;
            OneBeatMillisecond = oneBeatMillisecond;
            A = a;
            B = b;
            C = c;
            D = d;
            E = e;
            F = f;
        }
    }
}
