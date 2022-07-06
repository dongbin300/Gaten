using System.Windows.Controls;

namespace Gaten.Net.Wpf.Controls
{
    /// <summary>
    /// TextProgressBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TextProgressBar : UserControl
    {
        public TextProgressBar()
        {
            InitializeComponent();
        }

        public void SetMinimum(double min)
        {
            DispatcherService.Invoke(() =>
            {
                progressBar.Minimum = min;
            });
        }

        public void SetMaximum(double max)
        {
            DispatcherService.Invoke(() =>
            {
                progressBar.Maximum = max;
            });
        }

        public void SetText(string text)
        {
            DispatcherService.Invoke(() =>
            {
                textBlock.Text = text;
            });
        }

        public void SetValue(double value)
        {
            DispatcherService.Invoke(() =>
            {
                progressBar.Value = value;
            });
        }

        public void SetValue(int percentage)
        {
            DispatcherService.Invoke(() =>
            {
                progressBar.Value = progressBar.Minimum + (progressBar.Maximum - progressBar.Minimum) * percentage / 100;
            });
        }

        public void ToMaximum()
        {
            DispatcherService.Invoke(() =>
            {
                progressBar.Value = progressBar.Maximum;
            });
        }

        public void ToMinimum()
        {
            DispatcherService.Invoke(() =>
            {
                progressBar.Value = progressBar.Minimum;
            });
        }
    }
}
