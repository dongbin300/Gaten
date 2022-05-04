using Gaten.Time.Scheduler.Data;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Time.Scheduler.View
{
    /// <summary>
    /// MonthSelect.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonthSelect : UserControl
    {
        public MonthSelect()
        {
            InitializeComponent();
        }

        private void _MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int number = int.Parse((sender as FrameworkElement).Name.Substring(4, 2));
            CalendarCreator.SetSelectMonth(number);

            ViewManager.MainWindow.Refresh();
            ViewManager.MainWindow.MainContent.Content = ViewManager.Calendar;
        }
    }
}
