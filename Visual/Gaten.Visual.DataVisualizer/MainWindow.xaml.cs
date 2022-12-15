using Microsoft.Win32;

using System.IO;
using System.Windows;

namespace Gaten.Visual.DataVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CandleChartVisualizer candleChartVisualizer = new ();
        WaveVisualizer waveVisualizer = new ();
        string entryFileName = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            entryFileName = Settings.Default.EntryFileName;

            if (string.IsNullOrEmpty(entryFileName) || !File.Exists(entryFileName))
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() ?? true)
                {
                    entryFileName = dialog.FileName;
                }
                else
                {
                    return;
                }
            }

            candleChartVisualizer.Init(entryFileName);
            Screen.Content = candleChartVisualizer;

            //waveVisualizer.Init(0, 20, 100);
            //Screen.Content = waveVisualizer;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.EntryFileName = entryFileName;
            Settings.Default.Save();
        }
    }
}
