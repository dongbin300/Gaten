using System.Windows;
using System.Windows.Controls.Primitives;

namespace Gaten.Windows.MintPanda.Utils
{
    internal class WindowUtil
    {
        public static void ToggleWindow<T>(ToggleButton toggleButton) where T : new()
        {
            if (toggleButton.IsChecked ?? true)
            {
                if (new T() is Window window)
                {
                    window.Tag = toggleButton.Tag;
                    window.Show();
                }
            }
            else
            {
                if (toggleButton.Tag is not string tag)
                {
                    return;
                }

                CloseWindow(tag);
            }
        }

        public static void CloseWindow(string tag)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Tag == null)
                {
                    continue;
                }
                if (window.Tag.Equals(tag))
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
