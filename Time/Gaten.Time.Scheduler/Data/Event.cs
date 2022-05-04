using System;
using System.Collections.Generic;
using System.Text;

namespace Gaten.Time.Scheduler.Data
{
    public class Event
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsEveryYear { get; set; }
        public bool IsHoliday { get; set; }

        public Event(DateTime date, string description, bool isEveryYear, bool isHoliday)
        {
            Date = date;
            Description = description;
            IsEveryYear = isEveryYear;
            IsHoliday = isHoliday;
        }
    }
}
