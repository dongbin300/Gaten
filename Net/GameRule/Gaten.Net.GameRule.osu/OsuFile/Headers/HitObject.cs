namespace Gaten.Net.GameRule.osu.OsuFile.Headers
{
    public class HitObject
    {
        public int X;
        public int Y;
        public int TimingPosition;
        public int A;
        public int B;
        public string C;

        public HitObject()
        {

        }

        public HitObject(int x, int y, int timingPosition, int a, int b, string c)
        {
            X = x;
            Y = y;
            TimingPosition = timingPosition;
            A = a;
            B = b;
            C = c;
        }
    }
}