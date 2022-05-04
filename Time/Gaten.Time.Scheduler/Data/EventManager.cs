using Gaten.Net.Windows.MSQ;
using Gaten.Time.Scheduler.Util;
using Gaten.Net.Network.MySql;

using System;
using System.Collections.Generic;
using System.Windows;

namespace Gaten.Time.Scheduler.Data
{
    public class EventManager
    {
        public static List<Event> Events { get; set; }

        public EventManager()
        {

        }

        public static void Initialize()
        {
            Events = LoadEventFromDatabase();
        }

        public static void AddEvent(DateTime date, string description, bool isEveryYear, bool isHoliday)
        {
            Events.Add(new Event(date, description, isEveryYear, isHoliday));
        }

        static List<Event> LoadEventFromDatabase()
        {
            List<Event> events = new List<Event>();

            try
            {
                MySql.Manager = new MySqlManager("EXTERNAL");
                var data = MySql.Manager.SelectByTableName("SCHEDULER");

                foreach (var _event in data)
                {
                    DateTime date = DateTime.Parse(_event["date"]);
                    string description = _event["description"];
                    bool isEveryYear = _event["isEveryYear"].Equals("true");
                    bool isHoliday = _event["isHoliday"].Equals("true");

                    events.Add(new Event(date, description, isEveryYear, isHoliday));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return events;
        }
    }
}
