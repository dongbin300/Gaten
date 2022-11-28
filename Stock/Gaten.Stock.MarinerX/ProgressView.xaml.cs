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

        public ProgressView(int top, int left, int width, int height)
        {
            InitializeComponent();
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }
    }
}
