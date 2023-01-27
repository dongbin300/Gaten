using System;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.Stock.BinanceBrowser.Views
{
    /// <summary>
    /// MonitorSettingsView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonitorSettingsView : UserControl
    {
        MonitorView? monitorView = null;

        public MonitorSettingsView()
        {
            InitializeComponent();

            IntervalText.Text = "3";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                monitorView = new MonitorView();
                monitorView.Init(SymbolText1.Text + "USDT", int.Parse(IntervalText.Text));
                monitorView.Show();
                Window.GetWindow(this).WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                monitorView?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CloseMonitorView()
        {
            monitorView?.Close();
        }
    }
}
