using Gaten.Net.IO;
using Gaten.Net.Wpf;
using Gaten.Visual.DataVisualizer;

using System.Windows;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CandleChartVisualizer visualizer = new CandleChartVisualizer();
            visualizer.Init(GResource.BinanceFuturesDataPath.Down("1m", "BATUSDT", "BATUSDT_2023-03-01.csv"));
            chart.Content = visualizer;
        }
    }
}
