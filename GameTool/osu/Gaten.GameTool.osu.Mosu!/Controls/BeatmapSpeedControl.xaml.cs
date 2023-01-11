using Gaten.Net.GameRule.osu.OsuFile;
using Gaten.Net.Wpf.Extensions;

using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.GameTool.osu.Mosu_.Controls
{
    /// <summary>
    /// BeatmapSpeedControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BeatmapSpeedControl : UserControl
    {
        public BeatmapSpeedControl()
        {
            InitializeComponent();

            OsuImage.Source = Settings.Default.OsuSongsPath.Length < 1 ?
                "Mosu!".ToImageSource("Resources/osu_icon_gray.png") :
                "Mosu!".ToImageSource("Resources/osu_icon.png");
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tempoValue = int.Parse(SpeedTextBox.Text);
                string sign = tempoValue >= 0 ? "+" : "";

                string selectedBeatmapPath = Settings.Default.OsuSongsPath + BeatmapListBox.SelectedItem.ToString() + "\\";
                string copyBeatmapPath = Settings.Default.OsuSongsPath + BeatmapListBox.SelectedItem.ToString() + $"({sign}{tempoValue})\\";
                FileInfo[] files = new DirectoryInfo(selectedBeatmapPath).GetFiles();

                // 디렉토리 & 비트맵 복사
                if (!Directory.Exists(copyBeatmapPath))
                {
                    Directory.CreateDirectory(copyBeatmapPath);
                }
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".mp3" || file.Extension == ".ogg" || file.Extension == ".osu")
                        continue;

                    File.Copy(file.FullName, copyBeatmapPath + file.Name, true);
                }

                var osuFiles = files.Where(f => f.Extension.Equals(".osu")).ToList();

                bool mp3Modified = false;
                foreach (FileInfo fi in osuFiles)
                {
                    OsuFileObject obj = new(fi.FullName);
                    obj.Read();

                    if (!mp3Modified)
                    {
                        string mp3FileName = obj.General["AudioFilename"];

                        Conversion.ChangeMp3Tempo(selectedBeatmapPath + mp3FileName, copyBeatmapPath + mp3FileName, tempoValue);

                        mp3Modified = true;
                    }

                    string newOsuFileName = fi.Name[..(fi.Name.LastIndexOf('.') - 1)] + $"({sign}{tempoValue})].osu";

                    Conversion.ChangeOsuTempo(fi.FullName, copyBeatmapPath + newOsuFileName, tempoValue);
                }

                MessageBox.Show("변환 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BeatmapListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string path = Settings.Default.OsuSongsPath + BeatmapListBox.SelectedItem.ToString() + "\\";
                FileInfo[] files = new DirectoryInfo(path).GetFiles();

                var osuFiles = files.Where(f => f.Extension.Equals(".osu")).ToList();

                if (osuFiles == null || osuFiles.Count == 0)
                {
                    throw new Exception("osu 파일 종범");
                }

                OsuFileObject obj = new(osuFiles[0].FullName);
                obj.Read();

                string bg = path + obj.Event?.Background.FileName;
                back.ImageSource = System.Drawing.Image.FromFile(bg).ToImageSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BeatmapTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = string.Empty;
            if (sender is TextBox textBox)
            {
                text = textBox.Text;
                return;
            }

            BeatmapListBox.Items.Clear();

            if (text.Length < 1)
            {
                return;
            }

            if (Settings.Default.OsuSongsPath.Length < 1)
            {
                MessageBox.Show("먼저 osu 설치 경로를 연동해 주세요!");
                BeatmapTextBox.Clear();
                return;
            }

            DirectoryInfo[] beatmaps = new DirectoryInfo(Settings.Default.OsuSongsPath).GetDirectories($"*{text}*", SearchOption.TopDirectoryOnly);

            foreach (DirectoryInfo di in beatmaps)
            {
                BeatmapListBox.Items.Add(di.Name);
            }
        }

        private void SpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(SpeedTextBox.Text, out int speed))
            {
                var rate = Math.Round((speed + 100m) / 100, 2);
                RateText.Text = $"x{rate}";
            }
            else
            {
                return;
            }
        }

        private void OsuImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
        }

        private void OsuImage_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (!files[0].EndsWith(".exe"))
            {
                MessageBox.Show("실행 파일이 아닙니다!");
                return;
            }

            Settings.Default.OsuSongsPath = files[0][..files[0].LastIndexOf('\\')] + @"\Songs\";
            Settings.Default.Save();

            OsuImage.Source = "Mosu!".ToImageSource("Resources/osu_icon.png");
        }
    }
}
