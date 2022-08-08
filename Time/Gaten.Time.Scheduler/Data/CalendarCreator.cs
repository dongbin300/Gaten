using System;
using System.Collections.Generic;
using System.Linq;

namespace Gaten.Time.Scheduler.Data
{
    public class CalendarCreator
    {
        public static readonly int MIN_YEAR = 1901;
        public static readonly int MAX_YEAR = 2100;

        public static DateTime Today { get; set; }
        public static DateTime SelectedDate { get; set; }
        public static List<Day> Days { get; set; } = new();


        public CalendarCreator()
        {
        }

        public static void Initialize()
        {
            Today = DateTime.Now;
            SelectedDate = Today;

            EventManager.Initialize();
        }

        public static void RefreshEventData()
        {
            EventManager.Initialize();
        }

        public static Day GetDay(DateTime date)
        {
            return Days.FirstOrDefault(d => d.Year.Equals(date.Year) && d.Month.Equals(date.Month) && d.Date.Equals(date.Day));
        }

        public static List<Day> GetDays(int year, int month)
        {
            return Days.Where(d => d.Year.Equals(year) && d.Month.Equals(month)).ToList();
        }

        public static void Create()
        {
            // 최초 생성은 1901년 1월 1일 (화)
            int year = 1901;
            int month = 1;
            int date = 1;
            int dayOfWeek = 2;

            while (year < 2101)
            {
                Days.Add(new Day(year, month, date, dayOfWeek));

                date++;
                dayOfWeek++;

                dayOfWeek %= 7;
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                        if (date == 32)
                        {
                            month++;
                            date = 1;
                        }
                        break;

                    case 12:
                        if (date == 32)
                        {
                            year++;
                            month = 1;
                            date = 1;
                        }
                        break;

                    case 2:
                        if (IsLeapYear(year))
                        {
                            if (date == 30)
                            {
                                month++;
                                date = 1;
                            }
                        }
                        else
                        {
                            if (date == 29)
                            {
                                month++;
                                date = 1;
                            }
                        }
                        break;

                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (date == 31)
                        {
                            month++;
                            date = 1;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        public static bool IsLeapYear(int year)
        {
            return year % 400 == 0 || year % 4 == 0 && year % 100 != 0;
        }

        public static void PrevSelectDate()
        {
            SelectedDate = SelectedDate.AddMonths(-1);
        }

        public static void NextSelectDate()
        {
            SelectedDate = SelectedDate.AddMonths(1);
        }

        public static void SetSelectMonth(int month)
        {
            int interval = month - SelectedDate.Month;
            SelectedDate = SelectedDate.AddMonths(interval);
        }

        public static void SetSelectYear(int year)
        {
            int interval = year - SelectedDate.Year;
            SelectedDate = SelectedDate.AddYears(interval);
        }

        public static void SetSelectDay(int day)
        {
            int interval = day - SelectedDate.Day;
            SelectedDate = SelectedDate.AddDays(interval);
        }

        public static string ToDayOfWeekString(DateTime date)
        {
            return date.DayOfWeek switch
            {
                DayOfWeek.Monday => "월",
                DayOfWeek.Tuesday => "화",
                DayOfWeek.Wednesday => "수",
                DayOfWeek.Thursday => "목",
                DayOfWeek.Friday => "금",
                DayOfWeek.Saturday => "토",
                DayOfWeek.Sunday => "일",
                _ => ""
            };
        }
    }
}
