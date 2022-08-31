using System.Windows;

namespace Gaten.Net.Wpf
{
    public class WindowsSystem
    {
        public static double ScreenWidth => SystemParameters.PrimaryScreenWidth;
        public static double ScreenHeight => SystemParameters.PrimaryScreenHeight;
        public static double ScreenNoTaskBarHeight => SystemParameters.FullPrimaryScreenHeight + SystemParameters.WindowCaptionHeight;
        public static double TaskBarHeight => ScreenHeight - ScreenNoTaskBarHeight;
    }
}
