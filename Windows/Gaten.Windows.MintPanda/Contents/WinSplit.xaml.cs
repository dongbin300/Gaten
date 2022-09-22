using Gaten.Net.Diagnostics;
using Gaten.Net.Windows;
using Gaten.Net.Wpf;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// WinSplit.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WinSplit : Window
    {
        static int TaskBarHeight => 36;

        static string[] blacklist =
        {
            "explorer",
            "microsoft.notes",
            "kakaotalk",
            "textinputhost",
            "applicationframehost",
            "nvidia share"
        };

        public WinSplit()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
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
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }


        public static void Split(int widthCount, int heightCount, bool taskBarNone, bool allProcess, string processName = "")
        {
            try
            {
                var screenRectangle = new Rectangle();

                if (taskBarNone)
                {
                    screenRectangle.Height = WindowsSystem.ScreenNoTaskBarHeight;
                }
                else
                {
                    screenRectangle.Height = WindowsSystem.ScreenHeight;
                }

                var appWidth = screenRectangle.Width / widthCount;
                var appHeight = screenRectangle.Height / heightCount;

                var processes = allProcess ? GetWindowProcesses() : GetWindowProcesses(processName);

                for (int i = 0; i < widthCount * heightCount; i++)
                {
                    if (i >= processes.Count)
                    {
                        break;
                    }

                    IntPtr handle = processes[i].MainWindowHandle;

                    if (handle != IntPtr.Zero)
                    {
                        WinApi.MoveWindow(handle, (int)(appWidth * (i % widthCount)), (int)(appHeight * (i / heightCount)), (int)appWidth, (int)appHeight, true);
                    }
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        public static void SuperKill(bool allProcess, string processName = "")
        {
            try
            {
                var processes = allProcess ? GetWindowProcesses() : GetWindowProcesses(processName);

                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        static List<Process> GetWindowProcesses(string processName = "")
        {
            try
            {
                List<Process> result = new();
                var processes = processName == "" ? Process.GetProcesses() : Process.GetProcessesByName(processName);

                foreach (Process process in processes)
                {
                    if (process.MainWindowHandle != IntPtr.Zero && !string.IsNullOrEmpty(process.MainWindowTitle) && process.Responding)
                    {
                        result.Add(process);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }

            return default!;
        }

        public static List<string> GetProcessList()
        {
            try
            {
                List<string> result = new();

                var processes = GetWindowProcesses();

                foreach (Process process in processes)
                {
                    string processName = process.ProcessName;

                    if (blacklist.Contains(processName.ToLower()) || result.Contains(processName))
                    {
                        continue;
                    }

                    result.Add(processName);
                }

                return result;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }

            return default!;
        }

        public void RefreshProcessList()
        {
            try
            {
                var processes = GetProcessList();
                ProcessComboBox.Items.Clear();
                foreach (var process in processes)
                {
                    ProcessComboBox.Items.Add(process);
                }

                if (ProcessComboBox.Items.Count > 0)
                {
                    ProcessComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var processName = AllProcessCheckBox.IsChecked ?? true ? "" : ProcessComboBox.Text;

                Split(
                    int.Parse(WinSplitHComboBox.Text),
                    int.Parse(WinSplitVComboBox.Text),
                    ExceptTaskBarCheckBox.IsChecked ?? true,
                    AllProcessCheckBox.IsChecked ?? true,
                    processName);
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void KillButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ProcessComboBox.Text))
                {
                    return;
                }

                if (MessageBox.Show(this, "정말 프로세스를 종료하시겠습니까?", "경고", MessageBoxButton.YesNoCancel) != MessageBoxResult.Yes)
                {
                    return;
                }

                var processName = AllProcessCheckBox.IsChecked ?? true ? "" : ProcessComboBox.Text;

                SuperKill(AllProcessCheckBox.IsChecked ?? true, processName);
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RefreshProcessList();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void AllProcessCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessComboBox.IsEnabled = false;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }

        private void AllProcessCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessComboBox.IsEnabled = true;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(WinSplit), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
