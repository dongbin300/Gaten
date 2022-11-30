using Gaten.GameTool.osu.Mosu_.Controls;

using System.Windows;
using System.Windows.Controls;

namespace Gaten.GameTool.osu.Mosu_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BeatmapDifficultyCalculatorControl beatmapDifficultyCalculatorControl = new();
        BeatmapNoiserControl beatmapNoiserControl = new();
        ArCalculatorControl arCalculatorControl = new();
        Mania726Control mania726Control = new();
        NpNaxiControl npNaxiControl = new();
        RankingManagerControl rankingManagerControl = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Set(int row, int col)
        {
            CurrentTabRectangle.SetValue(Grid.RowProperty, row);
            CurrentTabRectangle.SetValue(Grid.ColumnProperty, col);
        }

        private void BeatmapDifficultyCalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = beatmapDifficultyCalculatorControl;
            Set(1, 0);
        }

        private void BeatmapNoiserButton_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = beatmapNoiserControl;
            Set(3, 0);
        }

        private void Mania726Button_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = mania726Control;
            Set(3, 1);
        }

        private void NpNaxiButton_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = npNaxiControl;
            Set(1, 1);
        }

        private void ArCalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = arCalculatorControl;
            Set(1, 2);
        }

        private void BeatmapDownloaderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BeatmapSpeedChangerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileExtractorButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RankingManagerButton_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = rankingManagerControl;
            Set(5, 2);
        }

        private void RandomBeatmapCreatorButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
