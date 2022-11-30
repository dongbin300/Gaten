using Gaten.Net.Extensions;

using Microsoft.Win32;

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.GameTool.osu.Mosu_.Controls
{
    /// <summary>
    /// BeatmapNoiserControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BeatmapNoiserControl : UserControl
    {
        public BeatmapNoiserControl()
        {
            InitializeComponent();
        }

        private void SelectBeatmapButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "osu 비트맵 파일|*.osu",
                Multiselect = false
            };

            if(dialog.ShowDialog() ?? true)
            {
                BeatmapPathTextBox.Text = dialog.FileName;
            }
        }

        private void NoiseButton_Click(object sender, RoutedEventArgs e)
        {
            var fileName = BeatmapPathTextBox.Text;
            var name = fileName.GetFileName();

            var dialog = new SaveFileDialog()
            {
                FileName = name
            };

            try
            {
                if (dialog.ShowDialog() ?? true &&
                int.Parse(XTextBox.Text) >= 0 &&
                int.Parse(XTextBox.Text) <= 256 &&
                int.Parse(YTextBox.Text) >= 0 &&
                int.Parse(YTextBox.Text) <= 192)
                {
                    Random rnd = new();
                    int xpos;
                    int ypos;
                    int i;
                    int check;
                    int check2;

                    int[] xvalue = new int[10000];
                    int[] yvalue = new int[10000];
                    int[] textlength = new int[10000];
                    string[] forehead = new string[10000];
                    string[] textt = new string[10000];
                    string[] printt = new string[10000];

                    FileStream fs = new(fileName, FileMode.Open);
                    StreamReader sr = new(fs);

                    for (i = 1; forehead[i - 1] != "[HitObjects]"; i++)
                    {
                        forehead[i] = sr.ReadLine();
                    }

                    check2 = i;

                    for (i = 1; sr.Peek() >= 0; i++)
                    {
                        textt[i] = sr.ReadLine();
                        /*
                         * x,y      -1-3
                         * x,yy     -1-4
                         * x,yyy    -1-5
                         * xx,y     -2-4
                         * xx,yy    -2-5
                         * xx,yyy   -2-6
                         * xxx,y    -3-5
                         * xxx,yy   -3-6
                         * xxx,yyy  -3-7
                         * */
                        if (textt[i].Substring(1, 1) == ",")
                        {
                            xvalue[i] = int.Parse(textt[i][..1]);

                            if (textt[i].Substring(3, 1) == ",")
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(2, 1));
                                textlength[i] = 4;
                            }
                            else if (textt[i].Substring(4, 1) == ",")
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(2, 2));
                                textlength[i] = 5;
                            }
                            else
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(2, 3));
                                textlength[i] = 6;
                            }
                        }
                        else if (textt[i].Substring(2, 1) == ",")
                        {
                            xvalue[i] = int.Parse(textt[i][..2]);

                            if (textt[i].Substring(4, 1) == ",")
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(3, 1));
                                textlength[i] = 5;
                            }
                            else if (textt[i].Substring(5, 1) == ",")
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(3, 2));
                                textlength[i] = 6;
                            }
                            else
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(3, 3));
                                textlength[i] = 7;
                            }
                        }
                        else
                        {
                            xvalue[i] = int.Parse(textt[i][..3]);

                            if (textt[i].Substring(5, 1) == ",")
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(4, 1));
                                textlength[i] = 6;
                            }
                            else if (textt[i].Substring(6, 1) == ",")
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(4, 2));
                                textlength[i] = 7;
                            }
                            else
                            {
                                yvalue[i] = int.Parse(textt[i].Substring(4, 3));
                                textlength[i] = 8;
                            }
                        }

                        xpos = 1000;
                        ypos = 1000;

                        while (xvalue[i] + xpos is <= 0 or >= 512)
                        {
                            xpos = rnd.Next(0, int.Parse(XTextBox.Text)) - (int.Parse(XTextBox.Text) / 2);
                        }
                        while (yvalue[i] + ypos is <= 0 or >= 384)
                        {
                            ypos = rnd.Next(0, int.Parse(YTextBox.Text)) - (int.Parse(YTextBox.Text) / 2);
                        }

                        xvalue[i] += xpos;
                        yvalue[i] += ypos;

                        //printt[i] = xvalue[i].ToString() + "," + yvalue[i].ToString() + "," + textt[i].Substring(textlength[i]);
                        printt[i] = textt[i][textlength[i]..];
                    }
                    fs.Close();
                    check = i;

                    FileStream fs2 = new(dialog.FileName, FileMode.Create);
                    StreamWriter sw = new(fs2);

                    for (i = 1; i < check2; i++)
                    {
                        sw.WriteLine(forehead[i]);
                    }

                    for (i = 1; i < check; i++)
                    {
                        //sw.Write(printt[i]);
                        sw.WriteLine(xvalue[i].ToString() + "," + yvalue[i].ToString() + "," + printt[i]);
                    }

                    sw.Flush();
                    fs2.Close();

                    MessageBox.Show("변환 완료.");
                }
                else
                {
                    XTextBox.Clear();
                    YTextBox.Clear();

                    MessageBox.Show("입력이 잘못되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
