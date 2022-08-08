using System.Drawing;

namespace Gaten.Net.Extensions
{
    public static class PointExtension
    {
        public static bool IsRectangleRange(this Point point, Point topLeft, Point bottomRight)
        {
            return point.X >= topLeft.X && point.X <= bottomRight.X && point.Y >= topLeft.Y && point.Y <= bottomRight.Y;
        }

        public static bool IsRectangleRange(this Point point, int top, int bottom, int left, int right)
        {
            return point.X >= left && point.X <= right && point.Y >= top && point.Y <= bottom;
        }
    }
}
