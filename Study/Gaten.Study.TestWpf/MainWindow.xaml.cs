using Gaten.Net.Wpf;

using System.Windows;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(200);

        public MainWindow()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DispatcherService.Invoke(() =>
            {
                NumberTextBox.Text = Clipboard.GetText();
            });
        }

        private void NumberTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                var result = 4905;
                for (int i = 0; i < NumberTextBox.Text.Length; i += 2)
                {
                    result -= int.Parse(NumberTextBox.Text.Substring(i, 2));
                }

                AnswerText.Text = result.ToString();
            }
            catch
            {
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            NumberTextBox.Text = Clipboard.GetText();
        }
    }
}
