using Gaten.Time.Scheduler.View;

namespace Gaten.Time.Scheduler
{
    public class ViewManager
    {
        public static MainWindow MainWindow { get; set; }
        public static Calendar Calendar { get; set; }
        public static MonthSelect MonthSelect { get; set; }
        public static YearSelect YearSelect { get; set; }
        public static DayInfo DayInfo { get; set; }
        public static AddEvent AddEvent { get; set; }

        public static void Initialize()
        {
            MainWindow = new MainWindow();
            Calendar = new Calendar();
            MonthSelect = new MonthSelect();
            YearSelect = new YearSelect();
            DayInfo = new DayInfo();
            AddEvent = new AddEvent();
        }

        //public static void Initialize(string viewName)
        //{
        //    var lowerViewName = viewName.ToLower();
        //    var view = typeof(ViewManager).GetProperties().FirstOrDefault(p=>p.Name.ToLower().Equals(lowerViewName));
        //}
    }
}
