using Gaten.Net.Extensions;

using System.Windows.Media;

namespace Gaten.Net.Wpf
{
    public class ColorUtil
    {
        public static SolidColorBrush Rgb(int r, int g, int b) =>
            new(Color.FromRgb((byte)r, (byte)g, (byte)b));
        public static SolidColorBrush HexRgb(string hex) =>
            new(Color.FromRgb(
                hex.Substring(0, 2).ToByte(),
                hex.Substring(2, 2).ToByte(),
                hex.Substring(4, 2).ToByte()
                ));
    }
}
