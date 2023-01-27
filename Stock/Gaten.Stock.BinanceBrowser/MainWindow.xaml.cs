using Gaten.Net.IO;
using Gaten.Stock.BinanceBrowser.Models;
using Gaten.Stock.BinanceBrowser.Views;

using System.Windows;
using System.Windows.Controls;

namespace Gaten.Stock.BinanceBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MonitorSettingsView monitorSettings;
        PnlAnalysisView pnlAnalysis;
        SettingsView settings;

        public MainWindow()
        {
            InitializeComponent();

            var bnbText = GFile.ReadToArray(GResource.BinanceFuturesDataPath.Down("BNB.txt"));
            Common.BnbPrice = double.Parse(bnbText[1]);

            monitorSettings = new MonitorSettingsView();
            pnlAnalysis = new PnlAnalysisView();
            settings = new SettingsView();

            if (!string.IsNullOrEmpty(Settings.Default.ApiKey))
            {
                BinanceManager.Init(Settings.Default.ApiKey, Settings.Default.SecretKey);
            }

            MainContent.Content = monitorSettings;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is not RadioButton button)
            {
                return;
            }

            switch (button.Tag)
            {
                case "1":
                    MainContent.Content = monitorSettings;
                    break;

                case "2":
                    MainContent.Content = pnlAnalysis;
                    break;

                case "3":
                    MainContent.Content = settings;
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            monitorSettings.CloseMonitorView();
        }
    }
}
