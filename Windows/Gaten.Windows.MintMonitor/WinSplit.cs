using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Windows.MintMonitor
{
    internal class WinSplit
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

        public static void Split(int widthCount, int heightCount, bool taskBarNone, bool allProcess, string processName = "")
        {
            if (taskBarNone)
            {
                screenRectangle = Screen.PrimaryScreen.Bounds;
                screenRectangle.Height = Screen.PrimaryScreen.Bounds.Height - TaskBarHeight;
            }
            else
            {
                screenRectangle = Screen.PrimaryScreen.Bounds;
                screenRectangle.Height = Screen.PrimaryScreen.Bounds.Height;
            }

            int appWidth = screenRectangle.Width / widthCount;
            int appHeight = screenRectangle.Height / heightCount;

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
                    MoveWindow(handle, appWidth * (i % widthCount), appHeight * (i / heightCount), appWidth, appHeight, true);
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
