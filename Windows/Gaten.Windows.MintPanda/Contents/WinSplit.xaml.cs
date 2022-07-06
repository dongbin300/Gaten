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
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        static int TaskBarHeight => 36;
        static Rectangle screenRectangle;

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
            if (taskBarNone)
            {
                screenRectangle.Height = SystemParameters.PrimaryScreenHeight - TaskBarHeight;
            }
            else
            {
                screenRectangle.Height = SystemParameters.PrimaryScreenHeight;
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
                    MoveWindow(handle, (int)(appWidth * (i % widthCount)), (int)(appHeight * (i / heightCount)), (int)appWidth, (int)appHeight, true);
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
            List<Process> result = new List<Process>();
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
    }
}
