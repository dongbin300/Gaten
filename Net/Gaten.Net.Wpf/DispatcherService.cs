using System;
using System.Windows;
using System.Windows.Threading;

namespace Gaten.Net.Wpf
{
    public class DispatcherService
    {
        public static void Invoke(Action action) => Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
    }
}
