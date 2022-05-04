using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaten.GameTool.osu.osuBeatmapDownloader
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();

            tabListBox.SelectedIndex = 0;

            // 탭 Header 숨기기
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            // 버전
            versionLabel.Text = $"v{General.Version}";
            makeDateLabel.Text = General.Date;
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            TopMost = true;

            // 설정 가져오기
            autoStartonWindowsStartCheckBox.Checked = Settings.Default.AutoStartOnWindowsStart ? true : false;
            confirmUpdateCheckBox.Checked = Settings.Default.ConfirmUpdate ? true : false;
            closeChromeAfterCompleteDownloadCheckBox.Checked = Settings.Default.CloseChromeAfterCompleteDownload ? true : false;
            backImagePathTextBox.Text = Settings.Default.BackgroundImageFile;
            activateDownloaderCheckBox.Checked = Settings.Default.ActivateDownloader ? true : false;
            topMostCheckBox.Checked = Settings.Default.TopMostAlways ? true : false;
            transparentTrackBar.Value = Settings.Default.TransparentValue;
            transparentValueLabel.Text = Settings.Default.TransparentValue + "%";
            windowSizeXTextBox.Text = Settings.Default.WindowSize.Width.ToString();
            windowSizeYTextBox.Text = Settings.Default.WindowSize.Height.ToString();
        }

        /// <summary>
        /// 확인 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            int windowSizeX = 0;
            int windowSizeY = 0;

            // 검사
            try
            {
                windowSizeX = int.Parse(windowSizeXTextBox.Text);
                windowSizeY = int.Parse(windowSizeYTextBox.Text);
            }
            catch
            {
                MessageBox.Show("창 크기는 정수만 입력할 수 있습니다.", "오류");
                return;
            }

            if (windowSizeX < 200 || windowSizeY < 200)
            {
                MessageBox.Show("창 크기는 200 * 200 보다 커야 합니다.", "오류");
                return;
            }

            // 설정 저장하기
            Settings.Default.AutoStartOnWindowsStart = autoStartonWindowsStartCheckBox.Checked ? true : false;
            Settings.Default.ConfirmUpdate = confirmUpdateCheckBox.Checked ? true : false;
            Settings.Default.CloseChromeAfterCompleteDownload = closeChromeAfterCompleteDownloadCheckBox.Checked ? true : false;
            Settings.Default.BackgroundImageFile = backImagePathTextBox.Text;
            Settings.Default.ActivateDownloader = activateDownloaderCheckBox.Checked ? true : false;
            Settings.Default.TopMostAlways = topMostCheckBox.Checked ? true : false;
            Settings.Default.TransparentValue = transparentTrackBar.Value;
            Settings.Default.WindowSize = new Size(windowSizeX, windowSizeY);
            Settings.Default.Save();

            Close();
        }

        /// <summary>
        /// 취소 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 초기화 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultButton_Click(object sender, EventArgs e)
        {
            // 기본값으로 설정
            Settings.Default.AutoStartOnWindowsStart = false;
            Settings.Default.ConfirmUpdate = true;
            Settings.Default.CloseChromeAfterCompleteDownload = false;
            Settings.Default.BackgroundImageFile = ".\\resource\\back.png";
            Settings.Default.ActivateDownloader = true;
            Settings.Default.TopMostAlways = true;
            Settings.Default.TransparentValue = 100;
            Settings.Default.WindowSize = new Size(200, 200);
            Settings.Default.Save();

            // 새로고침
            OptionForm_Load(null, null);

            Close();
        }

        private void TabListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = (sender as ListBox).SelectedIndex;
        }

        private void TabListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            e.Graphics.DrawString(tabListBox.Items[e.Index].ToString(),
                e.Font,
                tabListBox.SelectedIndex == e.Index ? Brushes.White : Brushes.Black,
                e.Bounds.X + e.Font.Height, e.Bounds.Y + e.Font.Height - 5,
                StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void UpdateDataButton_Click(object sender, EventArgs e)
        {
            Process.Start(General.OfficialDownloadURL);
        }

        /// <summary>
        /// 배경 이미지 선택 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backImageSelectButton_Click(object sender, EventArgs e)
        {
            backImageOpenFileDialog.Title = "배경 이미지 선택";
            backImageOpenFileDialog.Filter = "이미지 파일 (*.bmp;*.jpg;*.png;*.gif)|*.bmp;*.jpg;*.png;*.gif";

            DialogResult result = backImageOpenFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string fileName = backImageOpenFileDialog.FileName;

                if (fileName != null)
                {
                    backImagePathTextBox.Text = fileName;
                }
            }
        }

        private void transparentTrackBar_Scroll(object sender, EventArgs e)
        {
            int index = transparentTrackBar.Value / transparentTrackBar.TickFrequency;

            transparentValueLabel.Text = $"{index * transparentTrackBar.TickFrequency}%";
        }

        private void transparentTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int index = transparentTrackBar.Value / transparentTrackBar.TickFrequency;

            transparentTrackBar.Value = index * transparentTrackBar.TickFrequency;
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            Process.Start(General.DonateURL);
        }

        private void twitterButton_Click(object sender, EventArgs e)
        {
            Process.Start(General.TwitterURL);
        }

        private void blogButton_Click(object sender, EventArgs e)
        {
            Process.Start(General.BlogURL);
        }
    }
}
