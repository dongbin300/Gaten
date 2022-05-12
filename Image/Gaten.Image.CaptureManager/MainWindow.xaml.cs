using Gaten.Net.Windows;
using Gaten.Net.Wpf;

using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Forms;

namespace Gaten.Image.CaptureManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer;
        private const int DefaultScreenIndex = 0;
        private static readonly ImageFormat DefaultImageFormat = ImageFormat.Png;

        private enum SaveMode
        {
            Clipboard,
            File
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new System.Timers.Timer();
            SaveDirectoryButton.Content = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ScreenIndexText.Text = "0";
            FileRadioButton.IsChecked = true;
        }

        private void SaveDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveDirectoryButton.Content = dialog.SelectedPath;
            }
        }

        private static Process GetProcessLockingClipboard()
        {
            int processId;
            WinAPI.GetWindowThreadProcessId(WinAPI.GetOpenClipboardWindow(), out processId);

            return Process.GetProcessById(processId);
        }

        private void CaptureButton_Click(object sender, RoutedEventArgs e)
        {
            CaptureScreenshot();
        }

        void CaptureScreenshot()
        {
            int screenIndex = ScreenIndexText.Text.Length < 1 ? DefaultScreenIndex : int.Parse(ScreenIndexText.Text);

            if (screenIndex > Screen.AllScreens.Length)
            {
                string message = "Invalid Command-Line Argument (screen-index)\n";
                message += "Example : --screen-index=0";
                System.Windows.MessageBox.Show(message);
                return;
            }

            SaveMode saveMode = ClipboardRadioButton.IsChecked.Value ? SaveMode.Clipboard : SaveMode.File;

            string dirPath = (string)SaveDirectoryButton.Content;
            string fileName = "screenshot" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            var imageFormat = DefaultImageFormat;

            var bounds = Screen.AllScreens[screenIndex].Bounds;
            try
            {
                switch (saveMode)
                {
                    case SaveMode.Clipboard:
                        ScreenShot.SaveToClipboard(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
                        break;
                    case SaveMode.File:
                        ScreenShot.SaveAsFile(bounds.Left, bounds.Top, bounds.Width, bounds.Height, dirPath, fileName, imageFormat);
                        break;
                    default:
                        System.Windows.MessageBox.Show($"Unsupported Save Mode ({saveMode})");
                        return;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }

            if (saveMode == SaveMode.Clipboard)
            {
                var targetProcess = GetProcessLockingClipboard();
                if (targetProcess.Id != 0)
                {
                    string message = $"The clipboard is currently locked due to the following process.\n";
                    message += $"Process ID : {targetProcess.Id}\n";
                    message += $"Process Name : {targetProcess.ProcessName}";
                    System.Windows.MessageBox.Show(message);
                    return;
                }
                /*
                else if (// TODO : Data Availability Check)
                {
                    string message = $"Clipboard processing has failed due to an unknown process.\n";
                    message += "System restart is recommended if this problem consists.";
                    MessageBox.Show(message);
                    return;
                }
                */
            }
        }

        private void PeriodCaptureButton_Click(object sender, RoutedEventArgs e)
        {
            if (PeriodicCheckBox.IsChecked.Value)
            {
                if (!timer.Enabled)
                {
                    timer.Interval = int.Parse(IntervalText.Text) * 1000;
                    timer.Elapsed += Timer_Tick;
                    timer.Start();
                    PeriodCaptureButton.Content = "캡쳐중..";
                }
                else
                {
                    timer.Stop();
                    PeriodCaptureButton.Content = "캡쳐";
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DispatcherService.Invoke(CaptureScreenshot);
        }
    }
}
