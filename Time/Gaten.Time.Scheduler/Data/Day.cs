using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gaten.Time.Scheduler.Data
{
    public class Day
    {
        /// <summary>
        /// 년
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 월
        /// </summary>
        public int Month { get; set; }
        
        /// <summary>
        /// 일
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// 요일
        /// 0-일, 1-월, 2-화, 3-수, 4-목, 5-금, 6-토
        /// </summary>
        public int DayOfWeek { get; set; }

        /// <summary>
        /// 쉬는날 여부
        /// </summary>
        public bool IsHoliday => Events.Count(e => e.IsHoliday) > 0;

        /// <summary>
        /// 이벤트 목록
        /// </summary>
        public List<Event> Events => GetEvents();

        public Day(int year, int month, int date, int dayOfWeek)
        {
            Year = year;
            Month = month;
            Date = date;
            DayOfWeek = dayOfWeek;
        }

        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            events.AddRange(
                EventManager.Events.Where(
                    e => e.Date.Year.Equals(Year) &&
                    e.Date.Month.Equals(Month) &&
                    e.Date.Day.Equals(Date) &&
                    !e.IsEveryYear).ToList()
                );

            events.AddRange(
                EventManager.Events.Where(
                    e=>e.Date.Month.Equals(Month) && 
                    e.Date.Day.Equals(Date) &&
                    e.IsEveryYear).ToList()
                );

            return events;
        }

        /// <summary>
        /// 같은 날짜인지
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsEqual(DateTime date)
        {
            return Year == date.Year && Month == date.Month && Date == date.Day;
        }
    }
}
