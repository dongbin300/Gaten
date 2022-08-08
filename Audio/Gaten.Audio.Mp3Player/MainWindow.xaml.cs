using Gaten.Net.IO;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Gaten.Audio.Mp3Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage pauseButtonImage = new();
        private BitmapImage resumeButtonImage = new();
        private BitmapImage seqButtonImage = new();
        private BitmapImage singleButtonImage = new();
        private BitmapImage randomButtonImage = new();

        public List<MusicFile> musicList = new();

        public MainWindow()
        {
            InitializeComponent();
            GetMusicFile();
            InitControl();
        }

        private void InitControl()
        {
            try
            {
                pauseButtonImage = new BitmapImage(new Uri("pack://application:,,,/Gaten.Audio.Mp3Player;component/Resources/Button/pause_button.png"));
                resumeButtonImage = new BitmapImage(new Uri("pack://application:,,,/Gaten.Audio.Mp3Player;component/Resources/Button/play_button.png"));
                seqButtonImage = new BitmapImage(new Uri("pack://application:,,,/Gaten.Audio.Mp3Player;component/Resources/Button/seq_button.png"));
                singleButtonImage = new BitmapImage(new Uri("pack://application:,,,/Gaten.Audio.Mp3Player;component/Resources/Button/single_button.png"));
                randomButtonImage = new BitmapImage(new Uri("pack://application:,,,/Gaten.Audio.Mp3Player;component/Resources/Button/random_button.png"));

                PauseResumeButton.Source = pauseButtonImage;
                PlayRuleButton.Source = seqButtonImage;

                foreach (MusicFile mf in musicList)
                {
                    _ = PlayListBox.Items.Add(mf.Info.Name.Replace(mf.Info.Extension, ""));
                }

            }
            catch
            {

            }
        }

        private void GetMusicFile()
        {
            try
            {
                List<FileInfo> files = new DirectoryInfo(GResource.GetText("mpp-dir.txt")).GetFiles("*.mp3").ToList();

                foreach (FileInfo fi in files)
                {
                    musicList.Add(new MusicFile() { Info = fi });
                }
            }
            catch
            {

            }
        }
    }
}
