using Gaten.Net.Windows;

using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Gaten.Net.Wpf.Controls
{
    /// <summary>
    /// ContentWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContentWindow : Window
    {
        public ContentWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(new WindowInteropHelper(this).Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
        }
    }
}
