using Gaten.Net.Windows;
using Gaten.Net.Wpf;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }


        public static void Split(int widthCount, int heightCount, bool taskBarNone, bool allProcess, string processName = "")
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

        public static void SuperKill(bool allProcess, string processName = "")
        {
            var processes = allProcess ? GetWindowProcesses() : GetWindowProcesses(processName);

            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

        static List<Process> GetWindowProcesses(string processName = "")
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

        public static List<string> GetProcessList()
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

        public void RefreshProcessList()
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

        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            var processName = AllProcessCheckBox.IsChecked ?? true ? "" : ProcessComboBox.Text;

            Split(
                int.Parse(WinSplitHComboBox.Text),
                int.Parse(WinSplitVComboBox.Text),
                ExceptTaskBarCheckBox.IsChecked ?? true,
                AllProcessCheckBox.IsChecked ?? true,
                processName);

        }

        private void KillButton_Click(object sender, RoutedEventArgs e)
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

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshProcessList();
        }

        private void AllProcessCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ProcessComboBox.IsEnabled = false;
        }

        private void AllProcessCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ProcessComboBox.IsEnabled = true;
        }
    }
}
