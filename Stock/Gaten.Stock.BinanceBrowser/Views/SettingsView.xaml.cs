using Gaten.Stock.BinanceBrowser.Models;

using System.Windows;
using System.Windows.Controls;

namespace Gaten.Stock.BinanceBrowser.Views
{
    /// <summary>
    /// SettingsView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();

            ApiText.Text = Settings.Default.ApiKey;
            SecretText.Text = Settings.Default.SecretKey;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.ApiKey = ApiText.Text;
            Settings.Default.SecretKey = SecretText.Text;
            Settings.Default.Save();

            BinanceManager.Init(ApiText.Text, SecretText.Text);
        }
    }
}
