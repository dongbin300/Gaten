using System.Windows;
using System.Windows.Controls;

namespace Gaten.GameTool.osu.Mosu_.Controls
{
    /// <summary>
    /// NpNaxiControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NpNaxiControl : UserControl
    {
        public NpNaxiControl()
        {
            InitializeComponent();
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            string rt = ""; // Result Text
            rt += "/me is ";
            rt += DoingComboBox.SelectedIndex switch
            {
                0 => "playing",
                1 => "listening to",
                2 => "editing",
                _ => "",
            };
            rt += " [http://osu.ppy.sh/b/";
            rt += bNumberTextBox.Text;
            rt += " ";
            rt += ArtistTextBox.Text;
            rt += " - ";
            rt += TitleTextBox.Text;
            if (VersionComboBox.SelectedIndex != 0)
            {
                rt += " (";
                if (VersionComboBox.SelectedItem.ToString() == "Remix")
                {
                    rt += VersionTextBox.Text;
                    rt += " ";
                }
                rt += VersionComboBox.SelectedItem;
                rt += ")";
            }
            rt += " [";
            if (DifficultyComboBox.SelectedIndex != 0)
            {
                rt += DifficultyComboBox.SelectedItem;
            }
            else
            {
                rt += DifficultyTextBox.Text;
            }
            rt += "]] ";
            rt += GameModeComboBox.SelectedIndex switch
            {
                1 => "<Taiko>",
                2 => "<CatchTheBeat>",
                3 => "<osu!mania>",
                0 or _ => "",
            };
            rt += " ";
            if(PfCheckBox.IsChecked ?? true)
            {
                rt += ModeComboBox.SelectedIndex switch
                {
                    0 => "+Perfect",
                    1 => "+Hidden +Perfect",
                    2 => "+Perfect +HardRock",
                    3 => "+Perfect +DoubleTime",
                    4 => "+Perfect +Flashlight",
                    5 => "+Hidden +Perfect +HardRock",
                    6 => "+Hidden +Perfect +DoubleTime",
                    7 => "+Hidden +Perfect +Flashlight",
                    8 => "+Perfect +HardRock +DoubleTime",
                    9 => "+Perfect +HardRock +Flashlight",
                    10 => "+Perfect +DoubleTime +Flashlight",
                    11 => "+Hidden +Perfect +HardRock +DoubleTime",
                    12 => "+Hidden +Perfect +HardRock +Flashlight",
                    13 => "+Hidden +Perfect +DoubleTime +Flashlight",
                    14 => "+Perfect +HardRock +DoubleTime +Flashlight",
                    15 => "+Hidden +Perfect +HardRock +DoubleTime +Flashlight",
                    _ => ""
                };
            }
            else
            {
                rt += ModeComboBox.SelectedIndex switch
                {
                    0 => "",
                    1 => "+Hidden",
                    2 => "+HardRock",
                    3 => "+DoubleTime",
                    4 => "+Flashlight",
                    5 => "+Hidden +HardRock",
                    6 => "+Hidden +DoubleTime",
                    7 => "+Hidden +Flashlight",
                    8 => "+HardRock +DoubleTime",
                    9 => "+HardRock +Flashlight",
                    10 => "+DoubleTime +Flashlight",
                    11 => "+Hidden +HardRock +DoubleTime",
                    12 => "+Hidden +HardRock +Flashlight",
                    13 => "+Hidden +DoubleTime +Flashlight",
                    14 => "+HardRock +DoubleTime +Flashlight",
                    15 => "+Hidden +HardRock +DoubleTime +Flashlight",
                    _ => ""
                };
            }
            ResultTextBox.Text = rt;
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ResultTextBox.Text);
        }

        private void VersionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VersionTextBox == null || VersionComboBox.SelectedItem == null)
            {
                return;
            }

            VersionTextBox.IsEnabled = VersionComboBox.SelectedItem.ToString() == "Remix";
        }

        private void DifficultyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DifficultyTextBox == null || DifficultyComboBox.SelectedItem == null)
            {
                return;
            }

            DifficultyTextBox.IsEnabled = DifficultyComboBox.SelectedItem.ToString() == "기타";
        }
    }
}
