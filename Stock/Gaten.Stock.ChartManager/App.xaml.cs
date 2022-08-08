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
            var trayMenu = new TrayMenu();
        }
    }
}
