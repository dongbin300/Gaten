using System.Windows;
using System.Windows.Threading;

namespace Gaten.Net.Wpf.Controls
{
    /// <summary>
    /// SimpleTimerPopup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SimpleTimerPopup : Window
    {
        DispatcherTimer timer;

        public SimpleTimerPopup(string text, int x = 0, int y = 0, int seconds = 3)
        {
            InitializeComponent();
            PopupText.Text = text;

            Left = x;
            Top = y;

            timer = new DispatcherTimer();
            timer.Interval = new System.TimeSpan(0, 0, seconds);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, System.EventArgs e)
        {
            timer.Stop();
            Close();
        }
    }
}
