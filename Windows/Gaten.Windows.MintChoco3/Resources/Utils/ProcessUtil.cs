using System;
using System.Diagnostics;

namespace Gaten.Windows.MintChoco3.Resources.Utils
{
    public class ProcessUtil
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int BringWindowToTop(IntPtr hwnd);

        public static IntPtr HWND_TOPMOST = (IntPtr)(-1);
        public static IntPtr HWND_NOTOPMOST = (IntPtr)(-2);
        public static int SWP_NOSIZE = 0x1;

        public static void StartProcess(string path)
        {
            ProcessStartInfo psi = new()
            {
                FileName = path,
                UseShellExecute = true
            };

            var process = Process.Start(psi);
            process.WaitForInputIdle();

            BringWindowToTop(process.Handle);
            SetWindowPos(process.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE);
        }
    }
}
