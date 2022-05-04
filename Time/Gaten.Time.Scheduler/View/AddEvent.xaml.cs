using Gaten.Time.Scheduler.Data;
using Gaten.Time.Scheduler.Util;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.Time.Scheduler.View
{
    /// <summary>
    /// AddEvent.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddEvent : UserControl
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            YearText.Text = CalendarCreator.SelectedDate.Year.ToString();
            MonthText.Text = CalendarCreator.SelectedDate.Month.ToString();
            DayText.Text = CalendarCreator.SelectedDate.Day.ToString();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (
                string.IsNullOrEmpty(YearText.Text) ||
                string.IsNullOrEmpty(MonthText.Text) ||
                string.IsNullOrEmpty(DayText.Text) ||
                string.IsNullOrEmpty(DescriptionText.Text)
                )
            {
                MessageBox.Show("내용을 입력해 주세요.");
                return;
            }

            var year = int.Parse(YearText.Text);
            var month = int.Parse(MonthText.Text);
            var day = int.Parse(DayText.Text);
            var date = $"\'{year}/{month}/{day}\'";
            var description = $"\'{DescriptionText.Text}\'";
            var everyYear = EveryYearCheckBox.IsChecked.Value ? "\'true\'" : "\'false\'";
            var holiday = HolidayCheckBox.IsChecked.Value ? "\'true\'" : "\'false\'";

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("idx", "NULL");
            data.Add("date", date);
            data.Add("description", description);
            data.Add("isEveryYear", everyYear);
            data.Add("isHoliday", holiday);
            var result = Data.MySql.Manager.Insert("SCHEDULER", data);

            if (result != string.Empty)
            {
                MessageBox.Show("서버 등록에 실패했습니다.\r\n" + result);
                return;
            }

            CalendarCreator.RefreshEventData();
            ViewManager.MainWindow.SetContent(ViewManager.DayInfo);
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.MainWindow.SetContent(ViewManager.DayInfo);
        }
    }
}
