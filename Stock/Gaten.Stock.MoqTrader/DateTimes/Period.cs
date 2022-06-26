using System;

namespace Gaten.Stock.MoqTrader.DateTimes
{
    internal class Period
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public int NumberOfDays => (int)(EndDate - StartDate).TotalDays;

        public Period() : this(DateTime.Now, DateTime.Now)
        {

        }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsValid(DateTime date)
        {
            return DateTime.Compare(date, StartDate) >= 0 && DateTime.Compare(date, EndDate) <= 0;
        }
    }
}
