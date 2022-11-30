using Gaten.Net.GameRule.osu.OsuFile;

using Microsoft.Win32;

using System;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.GameTool.osu.Mosu_.Controls
{
    /// <summary>
    /// Mania726Control.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Mania726Control : UserControl
    {
        public int[] ManiaXPos = { 36, 109, 182, 256, 329, 402, 475 };
        public int[] ManiaXPos6K = { 42, 128, 213, 298, 384, 469 };

        public Mania726Control()
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

            if (dialog.ShowDialog() ?? true)
            {
                BeatmapPathTextBox.Text = dialog.FileName;
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectKey =
                    Key1Button.IsChecked ?? true ? 1 :
                    Key1Button.IsChecked ?? true ? 2 :
                    Key1Button.IsChecked ?? true ? 3 :
                    Key1Button.IsChecked ?? true ? 4 :
                    Key1Button.IsChecked ?? true ? 5 :
                    Key1Button.IsChecked ?? true ? 6 :
                    7;

                var exceptType =
                    RemoveButton.IsChecked ?? true ? 1 :
                    2;

                string fileName = BeatmapPathTextBox.Text;
                OsuFileObject obj = new(fileName);
                obj.Read();

                if (obj.Difficulty["CircleSize"] != "7")
                {
                    MessageBox.Show("7키 아님 ㅅㄱ");
                    return;
                }

                // 난이도 이름 수정
                if (obj.Metadata["Version"] != null)
                {
                    obj.Metadata["Version"] += "(Gaten 6K)";
                }

                switch (exceptType)
                {
                    case 1: // 제외
                        for (int i = 0; i < obj.HitObjects.Count; i++)
                        {
                            int KeyNum = Array.IndexOf(ManiaXPos, obj.HitObjects[i].X);

                            if (KeyNum < selectKey - 1)
                            {
                                obj.HitObjects[i].X = ManiaXPos6K[KeyNum];
                            }
                            else if (KeyNum == selectKey - 1)
                            {
                                obj.HitObjects.RemoveAt(i);
                                i--;
                            }
                            else
                            {
                                obj.HitObjects[i].X = ManiaXPos6K[KeyNum - 1];
                            }
                        }
                        break;

                    case 2: // 다른 버튼으로 이동
                        for (int i = 0; i < obj.HitObjects.Count; i++)
                        {
                            if (obj.HitObjects[i].X == ManiaXPos[selectKey - 1])
                            {
                                obj.HitObjects.RemoveAt(i);
                                i--;
                            }
                        }
                        break;

                    default:
                        break;
                }

                string newFileName = fileName.Insert(fileName.LastIndexOf('\\') + 1, "[6K]");
                obj.Write(newFileName);
                MessageBox.Show("변환 완료!");
            }
            catch (Exception)
            {
                MessageBox.Show("누가 지금 버그 소리를 내었는가?");
            }
        }
    }
}
