using System.Windows;

namespace Gaten.Visual.DataVisualizer.Interfaces
{
    public interface IWaveVisualizer
    {
        public int ViewCountMin { get; }
        public int ViewCountMax { get; }
        public int TotalCount { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int ViewCount => End - Start;
        public Point CurrentMousePosition { get; set; }
    }
}
