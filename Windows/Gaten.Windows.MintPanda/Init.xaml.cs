using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Windows.MintPanda.Contents;
using Gaten.Windows.MintPanda.Utils;

using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// Init.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Init : UserControl
    {
        private string utilDirectory;

        public Init()
        {
            InitializeComponent();

            if (Directory.Exists("D:\\유틸"))
            {
                utilDirectory = "D:\\유틸";
            }
            else if (Directory.Exists("E:\\유틸"))
            {
                utilDirectory = "E:\\유틸";
            }
            else
            {
                utilDirectory = string.Empty;
            }
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender is not ToggleButton toggleButton)
            {
                return;
            }

            WindowUtil.ToggleWindow<CheckList>(toggleButton);
        }

        private void InstallFontButton_Click(object sender, RoutedEventArgs e)
        {
            GFile.CopyDirectory(utilDirectory.Down("폰트", "JP"), GPath.Fonts);
            GFile.CopyDirectory(utilDirectory.Down("폰트", "KR"), GPath.Fonts);
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender is not Button button)
            {
                return;
            }

            var tag = button.Tag.ToString();

            if (string.IsNullOrWhiteSpace(tag))
            {
                MessageBox.Show("존재하지 않는 태그입니다.");
                return;
            }

            GProcess.StartInstaller(tag, utilDirectory);
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            var tag = button.Tag.ToString();

            if (string.IsNullOrWhiteSpace(tag))
            {
                MessageBox.Show("존재하지 않는 태그입니다.");
                return;
            }

            GProcess.StartExe(tag, utilDirectory);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
