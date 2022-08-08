using Gaten.Time.Scheduler.View;

namespace Gaten.Time.Scheduler
{
    public class ViewManager
    {
        public static MainWindow MainWindow { get; set; } = new();
        public static Calendar Calendar { get; set; } = new();
        public static MonthSelect MonthSelect { get; set; } = new();
        public static YearSelect YearSelect { get; set; } = new();
        public static DayInfo DayInfo { get; set; } = new();
        public static AddEvent AddEvent { get; set; } = new();

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
