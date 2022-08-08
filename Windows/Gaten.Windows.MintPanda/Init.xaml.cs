using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Net.Extensions;
using Gaten.Windows.MintPanda.Contents;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// Init.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Init : UserControl
    {
        CheckList checkList = new CheckList();
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

            WindowUtil.InitWindow(checkList);
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            WindowUtil.CheckVisibility(checkList, CheckListButton);
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
