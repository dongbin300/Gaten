using System.Windows;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// MonitorWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonitorWindow : Window
    {
        public MonitorWindow()
        {
            InitializeComponent();
        }

        public void SetInfoText(string text)
        {
            InfoText.Text = text;
        }
    }
}