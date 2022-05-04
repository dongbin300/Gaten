using Gaten.Time.Scheduler.Data;


using System.Windows;

namespace Gaten.Time.Scheduler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CalendarCreator.Initialize();
            CalendarCreator.Create();

            ViewManager.Initialize();
            ViewManager.MainWindow.Show();
        }
    }
}
