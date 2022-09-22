using Gaten.Stock.ChartManager.Apis;

using System.Windows;

namespace Gaten.Stock.ChartManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            BinanceClientApi.Init();
            var trayMenu = new TrayMenu();
        }
    }
}
