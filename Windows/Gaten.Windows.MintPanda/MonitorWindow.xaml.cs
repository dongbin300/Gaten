using Gaten.Net.Diagnostics;

using System;
using System.Reflection;
using System.Windows;

namespace Gaten.Windows.MintPanda
{
    /// <summary>
    /// MonitorWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonitorWindow : Window
    {
        public MonitorWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MonitorWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        public void SetInfoText(string text)
        {
            try
            {
                InfoText.Text = text;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MonitorWindow), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}