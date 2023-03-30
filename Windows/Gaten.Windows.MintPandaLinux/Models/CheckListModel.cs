using System;

namespace Gaten.Windows.MintPandaLinux.Models
{
    [Flags]
    public enum DayOfWeeks
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }

    public static class DayOfWeekExtension
    {
        public static DayOfWeeks ToDayOfWeeks(this DayOfWeek s)
        {
            return s switch
            {
                DayOfWeek.Sunday => DayOfWeeks.Sunday,
                DayOfWeek.Monday => DayOfWeeks.Monday,
                DayOfWeek.Tuesday => DayOfWeeks.Tuesday,
                DayOfWeek.Wednesday => DayOfWeeks.Wednesday,
                DayOfWeek.Thursday => DayOfWeeks.Thursday,
                DayOfWeek.Friday => DayOfWeeks.Friday,
                DayOfWeek.Saturday => DayOfWeeks.Saturday,
                _ => DayOfWeeks.Sunday
            };
        }
    }

    public class CheckListModel
    {
        public string Content { get; set; }
        public bool IsNotComplete { get; set; }
        public DayOfWeeks DayOfWeeks { get; set; }

        public CheckListModel(string content, DayOfWeeks dayOfWeeks)
        {
            Content = content;
            IsNotComplete = true;
            DayOfWeeks = dayOfWeeks;
        }

        public CheckListModel(string content, string dayOfWeeks)
        {
            Content = content;
            IsNotComplete = true;
            DayOfWeeks = dayOfWeeks switch
            {
                "매일" => DayOfWeeks.Sunday | DayOfWeeks.Monday | DayOfWeeks.Tuesday | DayOfWeeks.Wednesday | DayOfWeeks.Thursday | DayOfWeeks.Friday | DayOfWeeks.Saturday,
                "평일" => DayOfWeeks.Monday | DayOfWeeks.Tuesday | DayOfWeeks.Wednesday | DayOfWeeks.Thursday | DayOfWeeks.Friday,
                "주말" => DayOfWeeks.Sunday | DayOfWeeks.Saturday,
                "월" => DayOfWeeks.Monday,
                "화" => DayOfWeeks.Tuesday,
                "수" => DayOfWeeks.Wednesday,
                "목" => DayOfWeeks.Thursday,
                "금" => DayOfWeeks.Friday,
                "토" => DayOfWeeks.Saturday,
                "일" => DayOfWeeks.Sunday,
                _ => DayOfWeeks.Sunday
            };
        }
    }
}
