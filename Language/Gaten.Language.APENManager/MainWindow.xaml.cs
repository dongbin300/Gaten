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
            //encodeBlock = APENUtil.Encode(plainTextBox.Text);
            //apenTextBox.Text = encodeBlock.ApenText;
        }

        private void plainTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //int plainStartIndex = (sender as TextBox).SelectionStart - 1;

            //if(plainStartIndex < 0)
            //{
            //    return;
            //}

            //int apenStartIndex = encodeBlock.GetApenIndex(plainStartIndex);
            //int apenHighlightLength = encodeBlock.ApenCollection[plainStartIndex].Length;

            //apenTextBox.Focus();
            //apenTextBox.Select(apenStartIndex, apenHighlightLength);
            //plainTextBox.Focus();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(apenTextBox.Text);
        }

        private void hButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
