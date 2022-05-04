using Gaten.Net.GameRule.osu.OsuFile;

namespace Gaten.GameTool.osu.osuBeatmapSpeedChanger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            osuPanel.BackgroundImage = Image.FromFile(Settings.Default.OsuSongsPath.Length < 1 ? "lll/osu_icon_gray.png" : "lll/osu_icon.png");
        }

        private void beatmapListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string path = Settings.Default.OsuSongsPath + beatmapListBox.SelectedItem.ToString() + "\\";
                FileInfo[] files = new DirectoryInfo(path).GetFiles();

                var osuFiles = files.Where(f => f.Extension.Equals(".osu")).ToList();

                if (osuFiles == null || osuFiles.Count == 0)
                    throw new Exception("osu 파일 종범");

                OsuFileObject obj = new(osuFiles[0].FullName);
                obj.Read();

                string bg = path + obj.Event?.Background.FileName;

                BackgroundImage = Image.FromFile(bg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void beatmapTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox).Text;

            beatmapListBox.Items.Clear();

            if (text.Length < 1)
            {
                return;
            }

            if (Settings.Default.OsuSongsPath.Length < 1)
            {
                MessageBox.Show("먼저 osu 설치 경로를 연동해 주세요!");
                beatmapTextBox.Clear();
                return;
            }

            DirectoryInfo[] beatmaps = new DirectoryInfo(Settings.Default.OsuSongsPath).GetDirectories($"*{text}*", SearchOption.TopDirectoryOnly);

            foreach (DirectoryInfo di in beatmaps)
            {
                beatmapListBox.Items.Add(di.Name);
            }
        }

        private void beatmapListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e = new DrawItemEventArgs(e.Graphics,
                                              e.Font,
                                              e.Bounds,
                                              e.Index,
                                              e.State ^ DrawItemState.Selected,
                                              e.ForeColor,
                                              Color.White);

                e.DrawBackground();

                e.Graphics.DrawString(
                    beatmapListBox.Items[e.Index].ToString(),
                    new Font("Verdana", 11, FontStyle.Regular, GraphicsUnit.Point),
                    beatmapListBox.SelectedIndex == e.Index ? Brushes.Black : Brushes.White,
                    e.Bounds.X + e.Font.Height,
                    e.Bounds.Y + e.Font.Height - 10,
                    StringFormat.GenericDefault
                    );

                e.DrawFocusRectangle();
            }
            catch
            {

            }
        }

        void FindOsuPath()
        {

        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tempoValue = (int)tempoValueTextBox.Value;
                string sign = tempoValue >= 0 ? "+" : "";

                string selectedBeatmapPath = Settings.Default.OsuSongsPath + beatmapListBox.SelectedItem.ToString() + "\\";
                string copyBeatmapPath = Settings.Default.OsuSongsPath + beatmapListBox.SelectedItem.ToString() + $"({sign}{tempoValue})\\";
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

        private void tempoValueTextBox_ValueChanged(object sender, EventArgs e)
        {
            var rate = Math.Round((tempoValueTextBox.Value + 100) / 100, 2);
            rateLabel.Text = $"x{rate}";
        }

        private void osuPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void osuPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (!files[0].EndsWith(".exe"))
            {
                MessageBox.Show("실행 파일이 아닙니다!");
                return;
            }

            Settings.Default.OsuSongsPath = files[0][..files[0].LastIndexOf('\\')] + @"\Songs\";
            Settings.Default.Save();

            osuPanel.BackgroundImage = Image.FromFile("lll/osu_icon.png");
        }
    }
}