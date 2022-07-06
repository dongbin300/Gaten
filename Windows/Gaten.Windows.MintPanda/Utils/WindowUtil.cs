using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Gaten.Windows.MintPanda.Utils
{
    internal class WindowUtil
    {
        public static void InitWindow(Window window)
        {
            window.Show();
            window.Visibility = Visibility.Collapsed;
        }

        public static void CheckVisibility(Window window, ToggleButton toggleButton)
        {
            window.Visibility = toggleButton.IsChecked ?? true ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
