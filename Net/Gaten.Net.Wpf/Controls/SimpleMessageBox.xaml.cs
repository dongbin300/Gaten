using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Net.Wpf.Controls
{
    public enum SimpleMessageBoxType
    {
        None,
        Ok,
        OkCancel,
        YesNoCancel
    }

    public enum SimpleMessageBoxResult
    {
        None,
        Ok,
        Cancel,
        Yes,
        No
    }

    /// <summary>
    /// SimpleMessageBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SimpleMessageBox : Window
    {
        private SimpleMessageBoxResult result;

        public SimpleMessageBox(string? text, Window? owner = null, SimpleMessageBoxType type = SimpleMessageBoxType.Ok)
        {
            InitializeComponent();
            MessageText.Text = text;
            if(owner != null)
            {
                Owner = owner;
            }

            switch (type)
            {
                default:
                case SimpleMessageBoxType.Ok:
                    Button1.Content = "OK";
                    Button2.Visibility = Visibility.Collapsed;
                    Button3.Visibility = Visibility.Collapsed;
                    break;

                case SimpleMessageBoxType.OkCancel:
                    Button1.Content = "OK";
                    Button2.Content = "Cancel";
                    Button3.Visibility = Visibility.Collapsed;
                    break;

                case SimpleMessageBoxType.YesNoCancel:
                    Button1.Content = "Yes";
                    Button2.Content = "No";
                    Button3.Content = "Cancel";
                    break;
            }

            SizeToContent = SizeToContent.Height;
        }

        public new SimpleMessageBoxResult ShowDialog()
        {
            base.ShowDialog();

            return result;
        }

        private void CopyButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(MessageText.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is not Button button)
            {
                return;
            }

            result = button.Content switch
            {
                "OK" => SimpleMessageBoxResult.Ok,
                "Cancel" => SimpleMessageBoxResult.Cancel,
                "Yes" => SimpleMessageBoxResult.Yes,
                "No" => SimpleMessageBoxResult.No,
                _ => SimpleMessageBoxResult.None
            };

            Close();
        }
    }
}
