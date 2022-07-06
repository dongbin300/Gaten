using Gaten.Net.Data.IO;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Gaten.Audio.Mp3Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage pauseButtonImage;
        BitmapImage resumeButtonImage;
        BitmapImage seqButtonImage;
        BitmapImage singleButtonImage;
        BitmapImage randomButtonImage;

        public List<MusicFile> musicList = new List<MusicFile>();

        public MainWindow()
        {
            InitializeComponent();
            GetMusicFile();
            InitControl();
        }

        void InitControl()
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
                    PlayListBox.Items.Add(mf.info.Name.Replace(mf.info.Extension, ""));
                }
                    
            }
            catch
            {

            }
        }

        void GetMusicFile()
        {
            try
            {
                List<FileInfo> files = new DirectoryInfo(GResource.GetText("mpp-dir.txt")).GetFiles("*.mp3").ToList();

                foreach (FileInfo fi in files)
                {
                    musicList.Add(new MusicFile() { info = fi });
                }
            }
            catch
            {

            }
        }
    }
}
