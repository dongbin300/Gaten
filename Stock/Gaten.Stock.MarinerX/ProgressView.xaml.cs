using Gaten.Net.Wpf;

using System.Windows;

namespace Gaten.Stock.MarinerX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProgressView : Window
    {
        public ProgressView()
        {
            InitializeComponent();
            Top = 0;
            Left = 0;
            Width = WindowsSystem.ScreenWidth;
            Height = 20;
        }
    }
}
