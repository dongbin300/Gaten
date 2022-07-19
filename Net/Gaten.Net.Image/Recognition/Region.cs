using System.Drawing;

namespace Gaten.Net.Image.Recognition
{
    public class Region
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Bottom { get; set; }
        public int Right { get; set; }
        public int Width => Right - Left;
        public int Height => Bottom - Top;
        public Color[,] Colors { get; set; }

        public Region(int top, int left, int bottom, int right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }
    }
}
