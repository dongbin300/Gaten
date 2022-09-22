using Gaten.Net.Diagnostics;

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// Go.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Go : Window
    {
        public Go()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Go), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    DragMove();
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Go), MethodBase.GetCurrentMethod()?.Name, ex);
            }

        }

        private void BadukButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText((sender as Button)?.Content.ToString());
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Go), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void BadukButtonChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(Clipboard.GetText().Replace("韩", "ㅁ").Replace("中", "韩").Replace("ㅁ", "中"));
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Go), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
