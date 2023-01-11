using Gaten.Net.GameRule.osu;
using Gaten.Net.IO;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

using Path = System.IO.Path;

namespace Gaten.GameTool.osu.Mosu_.Controls
{
    public partial class FileExtractor : UserControl
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        string inDir = string.Empty;
        string outDir = string.Empty;

        List<BeatmapSet> beatmapSets = new();

        public FileExtractor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MusicCheckBox.IsChecked = true;

            // 디렉토리 로드
            LoadDirectoryPath();

            // 디렉토리에 있는 모든 비트맵 등록
            var di = new DirectoryInfo(inDir).GetDirectories();
            foreach (var d in di)
            {
                beatmapSets.Add(new BeatmapSet(d));
            }
        }

        private void BeatmapSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (BeatmapSearchText.Text.Length > 0)
                {
                    BeatmapListBox.Items.Clear();
                    var filteredList = beatmapSets.Where(d => d.Title.ToLower().Contains(BeatmapSearchText.Text.ToLower())).ToList();
                    foreach (var item in filteredList)
                    {
                        BeatmapListBox.Items.Add(item.Title);
                    }
                    StatusText.Text = BeatmapListBox.Items.Count + "개 검색 완료.";
                }
                else
                {
                    BeatmapListBox.Items.Clear();
                    foreach (var item in beatmapSets)
                    {
                        BeatmapListBox.Items.Add(item.Title);
                    }
                    StatusText.Text = "";
                }
            }
            catch
            {

            }
        }

        private void BeatmapListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BeatmapListBox.SelectedItem == null)
            {
                return;
            }

            string selectedTitle = BeatmapListBox.SelectedItem as string;
            var selectedBeatmapSet = beatmapSets.Find(b => b.Title.Equals(selectedTitle));
            if (selectedBeatmapSet == null)
            {
                return;
            }

            FileInfo[] fi = new DirectoryInfo(selectedBeatmapSet.FullDirectory).GetFiles();

            // 종류별 파일 찾기
            FileInfo[] musicInfo = fi.Where(f => Path.GetExtension(f.Name).Equals(".mp3") || Path.GetExtension(f.Name).Equals(".ogg")).ToArray();
            FileInfo[] bgInfo = fi.Where(f => Path.GetExtension(f.Name).Equals(".jpg")).ToArray();
            FileInfo[] osuInfo = fi.Where(f => Path.GetExtension(f.Name).Equals(".osu")).ToArray();
            FileInfo[] pngInfo = fi.Where(f => Path.GetExtension(f.Name).Equals(".png")).ToArray();
            FileInfo[] wavInfo = fi.Where(f => Path.GetExtension(f.Name).Equals(".wav")).ToArray();
            FileInfo[] videoInfo = fi.Where(f => Path.GetExtension(f.Name).Equals(".avi") || Path.GetExtension(f.Name).Equals(".mp4") || Path.GetExtension(f.Name).Equals(".flv")).ToArray();

            // 음악 재생
            mciSendString("Close MediaFile", null, 0, IntPtr.Zero);
            mciSendString("open \"" + Path.Combine(selectedBeatmapSet.FullDirectory, musicInfo[0].Name) + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
            mciSendString("play MediaFile", null, 0, IntPtr.Zero);

            // PictureBox에 맞게 사이즈 조정해서 이미지 출력
            if (bgInfo.Length > 0)
            {
                BGImage.Source = new BitmapImage(new Uri(Path.Combine(selectedBeatmapSet.FullDirectory, bgInfo[0].Name)));
            }
            // JPG 파일이 하나도 없는 경우 PNG 파일 중에 가장 사이즈가 큰 파일을 BG파일이라고 추측함
            else if (pngInfo.Length > 0)
            {
                var maybeBg = pngInfo.OrderByDescending(image => image.Length)?.First();
                BGImage.Source = new BitmapImage(new Uri(Path.Combine(selectedBeatmapSet.FullDirectory, maybeBg.Name)));
            }

            BeatmapTitleText.Text = selectedBeatmapSet.Title;
            FileCountText.Text = $"비트맵: {osuInfo.Length}, 음악: {musicInfo.Length}, jpg: {bgInfo.Length}, png: {pngInfo.Length}, 힛사: {wavInfo.Length}, 영상: {videoInfo.Length}";
            DownloadDateText.Text = "다운로드: " + selectedBeatmapSet.Directory.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ExtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (BeatmapListBox.SelectedItem == null)
            {
                return;
            }

            string selectedTitle = BeatmapListBox.SelectedItem as string;
            var selectedBeatmapSet = beatmapSets.Find(b => b.Title.Equals(selectedTitle));

            if (selectedBeatmapSet == null)
            {
                return;
            }

            ExtractFile(selectedBeatmapSet);
        }

        private void DirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.Description = $"IN: {inDir}\r\nOUT: {outDir}";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                inDir = dialog.SelectedPath;
            }
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outDir = dialog.SelectedPath;
            }

            SaveDirectoryPath();
        }

        private void AllExtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (SkinCheckBox.IsChecked.Value)
                if (MessageBox.Show("스킨을 다중추출 하실 경우 파일이 겹칠 수 있습니다. 그래도 하시겠습니까?", "경고", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;

            if (WavCheckBox.IsChecked.Value)
                if (MessageBox.Show("wav파일을 다중추출 하실 경우 파일이 겹칠 수 있습니다. 그래도 하시겠습니까?", "경고", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;

            try
            {
                for (int i = 0; i < BeatmapListBox.Items.Count; i++)
                {
                    string selectedTitle = BeatmapListBox.Items[i] as string;
                    var selectedBeatmapSet = beatmapSets.Find(b => b.Title.Equals(selectedTitle));

                    ExtractFile(selectedBeatmapSet);
                }

                StatusText.Text = BeatmapListBox.Items.Count + "개 추출 완료.";
            }
            catch
            {
                StatusText.Text = "다중추출 중 오류가 발생했습니다.";
            }
        }

        /// <summary>
        /// 디렉토리 로드
        /// </summary>
        void LoadDirectoryPath()
        {
            try
            {
                var data = GResource.GetTextDictionary("fe-dir.ini");
                inDir = data["IN"];
                outDir = data["OUT"];
            }
            catch
            {

            }
        }

        /// <summary>
        /// 디렉토리 저장
        /// </summary>
        void SaveDirectoryPath()
        {
            Dictionary<string, string> data = new()
            {
                { "IN", inDir },
                { "OUT", outDir }
            };

            GResource.SetTextDictionary("fe-dir.ini", data);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    mciSendString("Close MediaFile", null, 0, IntPtr.Zero);
                    break;
                case Key.Enter:
                    ExtractButton_Click(sender, e);
                    break;
            }
        }

        /// <summary>
        /// 파일 추출
        /// </summary>
        /// <param name="select"></param>
        void ExtractFile(BeatmapSet beatmapSet)
        {
            string title = beatmapSet.Title; // 노래 제목
            string directory = beatmapSet.FullDirectory; // 비트맵 파일 디렉토리

            FileInfo[] fi = new DirectoryInfo(directory).GetFiles();

            foreach (FileInfo info in fi)
            {
                string extension = Path.GetExtension(info.Name);

                if (MusicCheckBox.IsChecked.Value && (extension == ".mp3" || extension == ".ogg"))
                {
                    if (info.Length > 512 * 1024) // 512KB 이상인 것만 음악으로 판별
                    {
                        File.Copy(Path.Combine(directory, info.Name), Path.Combine(outDir, title + extension), true);
                        StatusText.Text = "음악 파일 추출 완료.";
                    }
                }
                if (WavCheckBox.IsChecked.Value && extension == ".wav")
                {
                    File.Copy(Path.Combine(directory, info.Name), Path.Combine(outDir, info.Name), true);
                    StatusText.Text = "wav 파일 추출 완료.";
                }
                if (JpgCheckBox.IsChecked.Value && extension == ".jpg")
                {
                    File.Copy(Path.Combine(directory, info.Name), Path.Combine(outDir, title + extension), true);
                    StatusText.Text = "jpg 파일 추출 완료.";
                }
                if (PngCheckBox.IsChecked.Value && extension == ".png")
                {
                    File.Copy(Path.Combine(directory, info.Name), Path.Combine(outDir, info.Name), true);
                    StatusText.Text = "png 파일 추출 완료.";
                }
                if (VideoCheckBox.IsChecked.Value && (extension == ".avi" || extension == ".mp4" || extension == ".flv"))
                {
                    File.Copy(Path.Combine(directory, info.Name), Path.Combine(outDir, info.Name), true);
                    StatusText.Text = "영상 파일 추출 완료.";
                }
                if (SkinCheckBox.IsChecked.Value && extension == ".png" && IsSkinFile(info.Name))
                {
                    File.Copy(Path.Combine(directory, info.Name), Path.Combine(outDir, info.Name), true);
                    StatusText.Text = "스킨 파일 추출 완료.";
                }
            }
        }

        /// <summary>
        /// 스킨파일인지 아닌지
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool IsSkinFile(string fileName)
        {
            string[] keywords = {
                "approachcircle","button","comboburst","count","cursor","default","fail","followpoint", "fruit", "go",
                "hit", "lighting", "menu", "pause", "play", "ranking", "ready", "reversearrow", "score", "section",
                "selection", "slider", "spinner", "star", "mania" };

            return keywords.Where(k => fileName.Contains(k)).Count() > 0;
        }
    }
}
