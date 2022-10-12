using System.Windows;

namespace Gaten.Data.JsonViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow(e.Args[0]);
            MainWindow.Show();
        }
    }
}
