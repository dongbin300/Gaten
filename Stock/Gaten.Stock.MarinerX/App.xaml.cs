using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Gaten.Stock.MarinerX.Apis;
using Gaten.Stock.MarinerX.Markets;

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
            Initialize();
            var trayMenu = new TrayMenu();
        }

        void Initialize()
        {
            LocalStorageApi.Init();
            BinanceClientApi.Init();
            BinanceSocketApi.Init();
            TradingModelPath.Init();
            BinanceMarket.Init();
        }
    }
}
