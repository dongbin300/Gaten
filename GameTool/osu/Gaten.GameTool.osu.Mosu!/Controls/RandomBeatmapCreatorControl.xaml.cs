using Gaten.Net.Extensions;

using Microsoft.Win32;

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.GameTool.osu.Mosu_.Controls
{
    /// <summary>
    /// RandomBeatmapCreatorControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RandomBeatmapCreatorControl : UserControl
    {
        public RandomBeatmapCreatorControl()
        {
            InitializeComponent();
        }

        private void SelectMusicButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = false
            };

            if(dialog.ShowDialog() ?? true)
            {
                MusicPathTextBox.Text = dialog.FileName;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var fileName = MusicPathTextBox.Text;
            var name = fileName.GetFileName();
            var dialog = new SaveFileDialog
            {
                FileName = fileName
            };
            
            if (dialog.ShowDialog() ?? true)
            {
                Random rnd = new Random();
                float onebeat; // 1비트(osu에선 하얀색 한칸)간격(ex. 0.3125초)
                int offset; // 오프셋
                int xpos, ypos; // 현재 x,y 좌표 (BPM200기준 SM2.00 x1.0 디스턴스 1/2비트(0.15s)->100)->333->1.665
                                //               (BPM192기준 SM2.20 x1.0 디스턴스 1/2비트(0.15625s)->110)->320->1.666
                                //               (BPM177기준 SM1.60 x1.0 디스턴스 1/2비트(0.1695s)->79)->291->1.644
                                //               (BPM177기준 SM1.60 x1.2 디스턴스 1/2비트(0.1695s)->95)->292->1.650
                int xnext, ynext;
                int distance;
                FileStream fs = new FileStream(dialog.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                onebeat = 1.0f / float.Parse(BpmTextBox.Text) * 60.0f;
                offset = int.Parse(OffsetTextBox.Text);
                distance = (int)(1.65f * float.Parse(BpmTextBox.Text) * onebeat / 2.0f * float.Parse(SmTextBox.Text) * float.Parse(DistanceTextBox.Text));

                sw.WriteLine("osu file format v12");
                sw.WriteLine();
                sw.WriteLine("[General]");
                sw.WriteLine("AudioFilename: " + name);
                sw.WriteLine("AudioLeadIn: 0");
                sw.WriteLine("PreviewTime: 0");
                sw.WriteLine("Countdown: 0");
                sw.WriteLine("SampleSet: Soft");
                sw.WriteLine("StackLeniency: 0.7");
                sw.WriteLine("Mode: 0");
                sw.WriteLine("LetterboxInBreaks: 1");
                sw.WriteLine("WidescreenStoryboard: 0");
                sw.WriteLine();
                sw.WriteLine("[Editor]");
                sw.WriteLine("DistanceSpacing: " + DistanceTextBox.Text);
                sw.WriteLine("BeatDivisor: " + BeatComboBox.SelectedItem);
                sw.WriteLine("GridSize: 4");
                sw.WriteLine();
                sw.WriteLine("[Metadata]");
                sw.WriteLine("Title:" + TitleTextBox.Text);
                sw.WriteLine("TitleUnicode:" + TitleTextBox.Text);
                sw.WriteLine("Artist:" + ArtistTextBox.Text);
                sw.WriteLine("ArtistUnicode:" + ArtistTextBox.Text);
                sw.WriteLine("Creator:" + CreatorTextBox.Text);
                sw.WriteLine("Version:" + VersionTextBox.Text);
                sw.WriteLine("Source:" + SourceTextBox.Text);
                sw.WriteLine("Tags:" + TagsTextBox.Text);
                sw.WriteLine();
                sw.WriteLine("[Difficulty]");
                sw.WriteLine("HPDrainRate:" + HpComboBox.SelectedItem);
                sw.WriteLine("CircleSize:" + CsComboBox.SelectedItem);
                sw.WriteLine("OverallDifficulty:" + OdComboBox.SelectedItem);
                sw.WriteLine("ApproachRate:" + ArComboBox.SelectedItem);
                sw.WriteLine("SliderMultiplier:" + SmTextBox.Text);
                sw.WriteLine("SliderTickRate:" + StrComboBox.SelectedItem);
                sw.WriteLine();
                sw.WriteLine("[Events]");
                sw.WriteLine("//Background and Video events");
                sw.WriteLine("//Break Periods");
                sw.WriteLine("//Storyboard Layer 0 (Background)");
                sw.WriteLine("//Storyboard Layer 1 (Fail)");
                sw.WriteLine("//Storyboard Layer 2 (Pass)");
                sw.WriteLine("//Storyboard Layer 3 (Foreground)");
                sw.WriteLine("//Storyboard Sound Samples");
                sw.WriteLine("//Background Colour Transformations");
                sw.WriteLine("3,100,0,0,0");
                sw.WriteLine();
                sw.WriteLine("[TimingPoints]");
                sw.WriteLine(OffsetTextBox.Text + ",382,4,1,1,70,1,0");
                sw.WriteLine();
                sw.WriteLine("[Colours]");
                sw.WriteLine("Combo1 : " + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255));
                sw.WriteLine("Combo2 : " + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255));
                sw.WriteLine("Combo3 : " + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255));
                sw.WriteLine("Combo4 : " + rnd.Next(0, 255) + "," + rnd.Next(0, 255) + "," + rnd.Next(0, 255));
                sw.WriteLine();
                sw.WriteLine("[HitObjects]");
                xpos = rnd.Next(0, 512);
                ypos = rnd.Next(0, 384);
                sw.WriteLine(xpos + "," + ypos + "," + offset + ",1,0,0:0:0:0:");
                for (int i = 0; i < 3200; i++)
                {
                    xnext = rnd.Next(0, distance);
                    ynext = (int)(Math.Sqrt(Math.Pow((double)distance, 2.0) - Math.Pow((double)xnext, 2.0)));

                    if (xpos - xnext > 0 && xpos + xnext < 512)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            xpos -= xnext;
                        }
                        else
                        {
                            xpos += xnext;
                        }
                    }
                    else if (xpos - xnext > 0)
                    {
                        xpos -= xnext;
                    }
                    else
                    {
                        xpos += xnext;
                    }
                    if (ypos - ynext > 0 && ypos + ynext < 384)
                    {
                        if (rnd.Next(0, 2) == 0)
                        {
                            ypos -= ynext;
                        }
                        else
                        {
                            ypos += ynext;
                        }
                    }
                    else if (ypos - ynext > 0)
                    {
                        ypos -= ynext;
                    }
                    else
                    {
                        ypos += ynext;
                    }

                    offset += (int)(onebeat * 1000 / 4);

                    if (i % 8 == 7)
                        sw.WriteLine(xpos + "," + ypos + "," + offset + ",5,0,0:0:0:0:");
                    else
                        sw.WriteLine(xpos + "," + ypos + "," + offset + ",1,0,0:0:0:0:");
                }
                sw.Flush();
                fs.Close();
            }
        }
    }
}
