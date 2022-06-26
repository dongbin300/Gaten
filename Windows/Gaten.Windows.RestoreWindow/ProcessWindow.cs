using System.Windows;

namespace Gaten.Windows.RestoreWindow
{
    internal class ProcessWindow
    {
        public string ProcessName { get; set; }
        public string FileName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public WindowState WindowState { get; set; }
    }
}
