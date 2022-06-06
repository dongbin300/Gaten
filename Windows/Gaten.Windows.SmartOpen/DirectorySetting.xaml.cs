using System.Windows;

namespace Gaten.Windows.SmartOpen
{
    /// <summary>
    /// DirectorySetting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DirectorySetting : Window
    {
        public DirectorySetting()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameText.Text = Setting.SelectedNavigator.Name;
            DirectoryText.Text = Setting.SelectedNavigator.Directory;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var n = Setting.SelectedNavigator;
            if (n != null)
            {
                Setting.Navigators.Remove(n);
            }

            DialogResult = true;
            Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var n = Setting.SelectedNavigator;
            if (n != null)
            {
                Setting.Navigators.Remove(n);
            }

            Setting.Navigators.Add(new Navigator(Setting.SelectedNavigatorsIndex, NameText.Text, DirectoryText.Text));

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
