using Gaten.Net.Wpf;

using System.Windows;

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

            var a1 = WindowsSystem.ScreenWidth;
            var a2 = WindowsSystem.ScreenHeight;
            var a3 = WindowsSystem.ScreenNoTaskBarHeight;
            var a4 = WindowsSystem.TaskBarHeight;
        }
    }
}
