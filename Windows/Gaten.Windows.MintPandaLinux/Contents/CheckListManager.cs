using Gaten.Windows.MintPandaLinux.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gaten.Windows.MintPandaLinux.Contents
{
    public class CheckListManager
    {
        public static List<CheckListModel> CheckLists = new();

        public static void Init()
        {
            var data = File.ReadAllLines("checklist.txt");
            CheckLists.Clear();
            foreach (var item in data)
            {
                var segments = item.Split(';');
                CheckLists.Add(new CheckListModel(segments[0], segments[1]));
            }
        }

        public static List<CheckListModel> GetTodayCheckLists()
        {
            var dayOfWeek = DateTime.Today.DayOfWeek.ToDayOfWeeks();
            return CheckLists.Where(item => item.DayOfWeeks.HasFlag(dayOfWeek)).ToList();
        }
    }
}
