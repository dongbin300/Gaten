using Gaten.Net.Language.APEN;

using System.Windows;
using System.Windows.Controls;

namespace Gaten.Language.APENManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EncodeBlock encodeBlock = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void plainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            apenTextBox.Text = APENUtil.EncodeSimple(plainTextBox.Text);
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(apenTextBox.Text);
        }
    }
}
