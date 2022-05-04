using Gaten.Time.Scheduler.Data;
using Gaten.Time.Scheduler.Util;

using System.Windows;
using System.Windows.Controls;

namespace Gaten.Time.Scheduler.View
{
    /// <summary>
    /// DayInfo.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DayInfo : UserControl
    {
        public DayInfo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            YearText.Text = $"{CalendarCreator.SelectedDate.Year}년";
            DateText.Text = $"{CalendarCreator.SelectedDate.Month}월 {CalendarCreator.SelectedDate.Day}일 ({CalendarCreator.ToDayOfWeekString(CalendarCreator.SelectedDate)})";

            RefreshEvent();
        }

        public void RefreshEvent()
        {
            SpecialEventPanel.Children.Clear();
            FixedEventPanel.Children.Clear();
            var day = CalendarCreator.GetDay(CalendarCreator.SelectedDate);

            DateText.Foreground = ColorUtil.BlackColor;
            if (day.DayOfWeek == 0)
            {
                DateText.Foreground = ColorUtil.SundayColor;
            }
            else if(day.DayOfWeek == 6)
            {
                DateText.Foreground = ColorUtil.SaturdayColor;
            }

            foreach (var _event in day.Events)
            {
                if (_event.IsHoliday)
                {
                    DateText.Foreground = ColorUtil.SundayColor;
                }

                TextBlock eventText = new TextBlock();
                eventText.Style = (Style)Resources["EventText"];
                eventText.Text = _event.Description;
                eventText.Foreground = _event.IsHoliday ? ColorUtil.SundayColor : ColorUtil.BlackColor;

                if (_event.IsEveryYear)
                {
                    FixedEventPanel.Children.Add(eventText);
                }
                else
                {
                    SpecialEventPanel.Children.Add(eventText);
                }
            }
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.MainWindow.SetContent(ViewManager.AddEvent);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.Calendar.Refresh();
            ViewManager.MainWindow.SetContent(ViewManager.Calendar);
        }
    }
}
