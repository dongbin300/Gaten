using Gaten.Net.Diagnostics;
using Gaten.Net.Wpf;

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// TaskBarWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TaskBarWindow : Window
    {
        public TaskBarWindow()
        {
            try
            {
                InitializeComponent();

                var image = new BitmapImage(new Uri("pack://application:,,,/MintPanda;component/Resources/Images/taskbar.png"));
                TaskBarImage.Source = image;

                Left = 0;
                Top = WindowsSystem.ScreenHeight - image.Height;
                Width = image.Width;
                Height = image.Height;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(SystemMonitorWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
