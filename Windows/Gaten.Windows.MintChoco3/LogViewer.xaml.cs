using Gaten.Windows.MintChoco3.Resources.Utils;

using System.Windows;

namespace Gaten.Windows.MintChoco3
{
    /// <summary>
    /// LogViewer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LogViewer : Window
    {
        string logPath = MintChoco3.Resources.Texts.PathCollection.MintChocoLogPath;

        public LogViewer()
        {
            InitializeComponent();
        }

        void GetLog()
        {
            string[] logs = System.IO.File.ReadAllLines(logPath);

            LogBox.Items.Clear();
            foreach (string log in logs)
            {
                LogBox.Items.Add(log);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetLog();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            ProcessUtil.StartProcess(logPath);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllText(logPath, "");

            GetLog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetLog();
        }
    }
}
