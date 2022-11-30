using Gaten.GameTool.osu.Mosu_.Models;
using Gaten.Net.GameRule.osu;
using Gaten.Net.GameRule.osu.OsuFile;

using Microsoft.WindowsAPICodePack.Dialogs;

using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.GameTool.osu.Mosu_.Controls
{
    /// <summary>
    /// BeatmapDifficultyCalculatorControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BeatmapDifficultyCalculatorControl : UserControl
    {
        List<BeatmapDifficulty> results = new();

        public BeatmapDifficultyCalculatorControl()
        {
            InitializeComponent();
        }

        private void SelectBeatmapButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Multiselect = false
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                results.Clear();
                var fileNames = Directory.GetFiles(dialog.FileName, "*.osu");
                foreach(var fileName in fileNames)
                {
                    var result = new CatchTheBeatCalculator(new OsuFileObject(fileName));
                    results.Add(new BeatmapDifficulty(fileName, $"{result.Calculate(CatchTheBeatCalculator.CalculateRule.SumNote):#.##}"));
                }

                DifficultyDataGrid.ItemsSource = null;
                DifficultyDataGrid.ItemsSource = results;
            }
        }
    }
}
