using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// Go.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Go : Window
    {
        public Go()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void BadukButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((sender as Button)?.Content.ToString());
        }

        private void BadukButtonChange_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Clipboard.GetText().Replace("韩", "ㅁ").Replace("中", "韩").Replace("ㅁ", "中"));
        }
    }
}
