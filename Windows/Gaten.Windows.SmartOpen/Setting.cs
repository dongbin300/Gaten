using Gaten.Net.IO;
using Gaten.Net.Wpf;

using System.Collections.Generic;
using System.Windows.Media;

namespace Gaten.Windows.SmartOpen
{
    internal class Setting
    {
        public static int Count { get; set; }
        public static int Size { get; set; }
        public static int Padding { get; set; }
        public static int Margin { get; set; }
        public static SolidColorBrush MouseOverColor { get; set; } = default!;
        public static SolidColorBrush MainBackgroundColor { get; set; } = default!;
        public static SolidColorBrush MainForegroundColor { get; set; } = default!;

        public static List<Navigator> Navigators { get; set; } = new();
        public static int SelectedNavigatorsIndex { get; set; }
        public static Navigator SelectedNavigator => GetNavigator(SelectedNavigatorsIndex);

        public static void SaveSettingsData()
        {
            var contents = new List<string>();
            contents.Add(Count.ToString());
            contents.Add(Size.ToString());
            contents.Add(Padding.ToString());
            contents.Add(Margin.ToString());
            contents.Add(MouseOverColor.Color.R.ToString());
            contents.Add(MouseOverColor.Color.G.ToString());
            contents.Add(MouseOverColor.Color.B.ToString());
            contents.Add(MainBackgroundColor.Color.R.ToString());
            contents.Add(MainBackgroundColor.Color.G.ToString());
            contents.Add(MainBackgroundColor.Color.B.ToString());
            contents.Add(MainForegroundColor.Color.R.ToString());
            contents.Add(MainForegroundColor.Color.G.ToString());
            contents.Add(MainForegroundColor.Color.B.ToString());

            GResource.SetTextLines("so-set.ini", contents.ToArray());
        }

        public static void LoadSettingsData()
        {
            var data = GResource.GetTextLines("so-set.ini");

            Count = int.Parse(data[0]);
            Size = int.Parse(data[1]);
            Padding = int.Parse(data[2]);
            Margin = int.Parse(data[3]);
            MouseOverColor = ColorUtil.Rgb(int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]));
            MainBackgroundColor = ColorUtil.Rgb(int.Parse(data[7]), int.Parse(data[8]), int.Parse(data[9]));
            MainForegroundColor = ColorUtil.Rgb(int.Parse(data[10]), int.Parse(data[11]), int.Parse(data[12]));
        }

        public static void SaveDirectoryData()
        {
            var contents = new List<string>();
            foreach (var nav in Navigators)
            {
                contents.Add(nav.Index.ToString());
                contents.Add(nav.Name);
                contents.Add(nav.Directory);
            }

            GResource.SetTextLines("so-dset.ini", contents.ToArray());
        }

        public static void LoadDirectoryData()
        {
            var data = GResource.GetTextLines("so-dset.ini");

            Navigators = new List<Navigator>();
            for (int i = 0; i < data.Length; i += 3)
            {
                Navigators.Add(new Navigator(int.Parse(data[i]), data[i + 1], data[i + 2]));
            }
        }

        public static Navigator GetNavigator(int index)
        {
            var navigator = Navigators.Find(n => n.Index.Equals(index));

            if (navigator == null)
            {
                return new Navigator(index, "", "");
            }
            else
            {
                return navigator;
            }
        }
    }
}
