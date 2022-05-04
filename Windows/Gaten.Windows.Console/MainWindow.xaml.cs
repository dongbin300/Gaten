using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Gaten.Windows.Console
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(200);
        ConsoleManager consoleManager;

        public MainWindow()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            /* 최근 텍스트 박스 포커스를 항상 유지 */
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                var currentPanel = GetCurrentPanel();
                var currentTextBox = GetCurrentTextBox(currentPanel);

                if (currentTextBox == null)
                {
                    return;
                }

                currentTextBox.CustomTextBox.Focus();
            }));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            consoleManager = new ConsoleManager(panel);
            consoleManager.Input("Main", Command);
        }

        private void Command(object sender, KeyEventArgs e)
        {
            var currentPanel = GetCurrentPanel();
            var currentTextBox = GetCurrentTextBox(currentPanel);

            if (currentTextBox == null)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Up:
                    var inputUp = consoleManager.GetInputUp();
                    currentTextBox.SetText(inputUp);
                    break;

                case Key.Down:
                    var inputDown = consoleManager.GetInputDown();
                    currentTextBox.SetText(inputDown);
                    break;

                case Key.Enter:
                    var input = currentTextBox.GetText();

                    if (!string.IsNullOrEmpty(input))
                    {
                        consoleManager.AddInputLog(input);

                        Commander.Execute(consoleManager, input.ToLower());
                    }

                    currentPanel.IsEnabled = false;
                    currentTextBox.IsEnabled = false;

                    consoleManager.Input("Main", Command);
                    break;
            }
        }

        StackPanel GetCurrentPanel()
        {
            var panels = panel.Children.OfType<StackPanel>().Where(c => c.IsEnabled);

            if (panels.Any())
            {
                return panels.First();
            }

            return null;
        }

        ConsoleCaretTextBox GetCurrentTextBox(StackPanel currentPanel)
        {
            if (currentPanel == null)
            {
                return null;
            }

            var textBox = currentPanel.Children.OfType<ConsoleCaretTextBox>().Where(c => c.IsEnabled);

            if (textBox.Any())
            {
                return textBox.First();
            }

            return null;
        }
    }
}
