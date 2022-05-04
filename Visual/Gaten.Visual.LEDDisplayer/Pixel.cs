namespace Gaten.Visual.LEDDisplayer
{
    public class Pixel : IEquatable<Pixel>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public Pixel()
        {

        }

        public Pixel(int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public void Move(int dx, int dy, int duration)
        {
            Thread.Sleep(duration);
            X += dx;
            Y += dy;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }

        public bool Equals(Pixel other)
        {
            return X == other.X && Y == other.Y;
        }
    }

    public class PixelEqualityComparer : IEqualityComparer<Pixel>
    {
        public bool Equals(Pixel x, Pixel y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Pixel obj)
        {
            return (obj.X, obj.Y).GetHashCode();
        }
    }
}
