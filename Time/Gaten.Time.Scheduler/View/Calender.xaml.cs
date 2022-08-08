using ColorUtil2 = Gaten.Net.Wpf.ColorUtil;
using Gaten.Time.Scheduler.Data;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Gaten.Time.Scheduler.Util;

namespace Gaten.Time.Scheduler.View
{
    /// <summary>
    /// Calender.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
        }

        public void ClearData()
        {
            for (int i = 1; i <= 42; i++)
            {
                var panel = (StackPanel)FindName("DAY" + i.ToString("00"));
                panel.Children.Clear();
            }
        }

        public void Refresh()
        {
            ClearData();

            var days = CalendarCreator.GetDays(CalendarCreator.SelectedDate.Year, CalendarCreator.SelectedDate.Month);
            int dayOfWeekOfFirstDay = days.Find(d => d.Date.Equals(1)).DayOfWeek;

            foreach (var day in days)
            {
                var panel = (StackPanel)FindName("DAY" + (day.Date + dayOfWeekOfFirstDay).ToString("00"));
                panel.Background =
                    day.IsEqual(CalendarCreator.Today) ? ColorUtil2.Rgb(180, 180, 180) :
                    Brushes.Transparent;

                TextBlock dateTextBlock = new TextBlock();
                dateTextBlock.Style = (Style)Resources["DayText"];
                dateTextBlock.Text = day.Date.ToString();
                dateTextBlock.Foreground =
                    day.IsHoliday ? ColorUtil.SundayColor :
                    day.DayOfWeek == 0 ? ColorUtil.SundayColor :
                    day.DayOfWeek == 6 ? ColorUtil.SaturdayColor :
                    ColorUtil.BlackColor;

                panel.Children.Add(dateTextBlock);

                foreach (var _event in day.Events)
                {
                    Border eventBorder = new Border();
                    eventBorder.Style = (Style)Resources["EventBorder"];

                    TextBlock eventTextBlock = new TextBlock();
                    eventTextBlock.Text = _event.Description;
                    eventTextBlock.Style = (Style)Resources["EventText"];

                    eventBorder.Child = eventTextBlock;
                    panel.Children.Add(eventBorder);
                }
            }
        }

        private void DayPanelMouseDown(object sender, MouseButtonEventArgs e)
        {
            int dayOfWeekOfFirstDay = CalendarCreator.GetDay(new DateTime(CalendarCreator.SelectedDate.Year, CalendarCreator.SelectedDate.Month, 1)).DayOfWeek;
            int number = int.Parse((sender as FrameworkElement).Name.Substring(3, 2));

            int dayNumber = number - dayOfWeekOfFirstDay;

            if(dayNumber < 1)
            {
                return;
            }

            CalendarCreator.SetSelectDay(dayNumber);
            ViewManager.MainWindow.MainContent.Content = ViewManager.DayInfo;
        }
    }
}
