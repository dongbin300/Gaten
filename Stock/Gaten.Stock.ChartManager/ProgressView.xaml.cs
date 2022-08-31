using Gaten.Net.Wpf;

using System.Windows;

namespace Gaten.Stock.ChartManager
{
    /// <summary>
    /// ProgressView.xaml에 대한 상호 작용 논리
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
