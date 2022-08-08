
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
        string entryFileName = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            entryFileName = Settings.Default.EntryFileName;

            if (string.IsNullOrEmpty(entryFileName) || !File.Exists(entryFileName))
            {
                OpenFileDialog dialog = new OpenFileDialog();
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
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.EntryFileName = entryFileName;
            Settings.Default.Save();
        }
    }
}
