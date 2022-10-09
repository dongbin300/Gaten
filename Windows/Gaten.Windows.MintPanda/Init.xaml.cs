using Gaten.Net.Diagnostics;
using Gaten.Net.IO;
using Gaten.Windows.MintPanda.Contents;
using Gaten.Windows.MintPanda.Utils;

using System;
using System.IO;
using System.Reflection;
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
        private string utilDirectory = string.Empty;

        public Init()
        {
            try
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
            catch (Exception ex)
            {
                GLogger.Log(nameof(Init), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is not ToggleButton toggleButton)
                {
                    return;
                }

                WindowUtil.ToggleWindow<CheckList>(toggleButton);
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Init), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void InstallFontButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GFile.CopyDirectory(utilDirectory.Down("폰트", "JP"), GPath.Fonts);
                GFile.CopyDirectory(utilDirectory.Down("폰트", "KR"), GPath.Fonts);

                MessageBox.Show("폰트 설치가 완료되었습니다.");
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Init), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            try
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

                GProcess.StartInstaller(tag, utilDirectory);
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Init), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                GLogger.Log(nameof(Init), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Init), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
