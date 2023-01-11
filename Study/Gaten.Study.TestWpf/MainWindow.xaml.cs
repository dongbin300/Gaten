using System.Windows;
using System.Windows.Automation;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("버튼 클릭");
        }

        private void Button_AccessKeyPressed(object sender, System.Windows.Input.AccessKeyPressedEventArgs e)
        {
            MessageBox.Show("버튼 액세스 키 눌러짐");
        }

        private void Window_AccessKeyPressed(object sender, System.Windows.Input.AccessKeyPressedEventArgs e)
        {
            MessageBox.Show("윈도우 액세스 키 눌러짐");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("버튼2 클릭");
        }
    }
}
