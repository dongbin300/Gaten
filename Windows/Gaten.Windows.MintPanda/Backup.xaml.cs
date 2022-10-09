using Gaten.Net.Diagnostics;
using Gaten.Net.IO;

using System.Windows;
using System.Windows.Controls;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// Backup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Backup : UserControl
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void VsProjectButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.Users.Down("source", "repos"));
        }

        private void StarMapButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.Documents.Down("StarCraft", "Maps"));
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.Downloads);
        }

        private void PicpickButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.Desktop.Down("픽픽"));
        }

        private void OsuButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.LocalAppData.Down("osu!"));
        }

        private void HanQButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.ProgramFilesX86.Down("foxwq"));
        }

        private void GatenButton_Click(object sender, RoutedEventArgs e)
        {
            GProcess.Start(GPath.AppData.Down("Gaten"));
        }
    }
}
