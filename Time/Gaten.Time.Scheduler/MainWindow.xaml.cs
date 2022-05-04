using Gaten.Time.Scheduler.Data;

using System.Windows;
using System.Windows.Input;

namespace Gaten.Time.Scheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
            SetContent(ViewManager.Calendar);
        }

        private void PreMonthButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CalendarCreator.PrevSelectDate();
            Refresh();
        }

        private void NextMonthButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CalendarCreator.NextSelectDate();
            Refresh();
        }

        private void MonthText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SetContent(ViewManager.MonthSelect);
        }

        private void YearText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SetContent(ViewManager.YearSelect);
        }

        public void Refresh()
        {
            YearText.Text = CalendarCreator.SelectedDate.Year.ToString();
            MonthText.Text = CalendarCreator.SelectedDate.Month.ToString("00");

            ViewManager.Calendar.Refresh();
        }

        public void SetContent(object obj)
        {
            MainContent.Content = obj;
        }
    }
}
