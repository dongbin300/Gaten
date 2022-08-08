using System.Windows.Media;

using ColorUtil2 = Gaten.Net.Wpf.ColorUtil;

namespace Gaten.Time.Scheduler.Util
{
    public class ColorUtil
    {
        public static SolidColorBrush BlackColor => Brushes.Black;
        public static SolidColorBrush WhiteColor => Brushes.White;
        public static SolidColorBrush SaturdayColor => ColorUtil2.Rgb(0, 153, 255);
        public static SolidColorBrush SundayColor => ColorUtil2.Rgb(255, 0, 68);
    }
}
