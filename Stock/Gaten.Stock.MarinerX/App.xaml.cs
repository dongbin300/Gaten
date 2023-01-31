using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Stock.MarinerX.Apis;

using System.Windows;

namespace Gaten.Stock.MarinerX
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            BinanceClientApi.Init();
            BinanceSocketApi.Init();
            TradingModelPath.Init();
            var trayMenu = new TrayMenu();
        }
    }
}
