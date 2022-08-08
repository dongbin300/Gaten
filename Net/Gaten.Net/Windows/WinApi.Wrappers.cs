using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Gaten.Net.Windows
{
    public partial class WinApi
    {
        public static Size GetConsoleFontSize()
        {
            // getting the console out buffer handle
            IntPtr outHandle = CreateFile("CONOUT$", GENERIC_READ | GENERIC_WRITE,
                FILE_SHARE_READ | FILE_SHARE_WRITE,
                IntPtr.Zero,
                OPEN_EXISTING,
                0,
                IntPtr.Zero);
            int errorCode = Marshal.GetLastWin32Error();
            if (outHandle.ToInt32() == INVALID_HANDLE_VALUE)
            {
                throw new IOException("Unable to open CONOUT$", errorCode);
            }

            ConsoleFontInfo cfi = new ConsoleFontInfo();
            if (!GetCurrentConsoleFont(outHandle, false, cfi))
            {
                throw new InvalidOperationException("Unable to get font information.");
            }

            return new Size(cfi.dwFontSize.X, cfi.dwFontSize.Y);
        }

        public static string GetEditText(IntPtr hWnd)
        {
            int capacity = SendMessage(hWnd, WM_GETTEXTLENGTH, 0, 0);
            var buffer = new StringBuilder(capacity);
            SendMessageGetTextW(hWnd, WM_GETTEXT, capacity + 1, buffer);

            return buffer.ToString();
        }

        public static void SetEditText(IntPtr hWnd, string text, Encoding encoding)
        {
            if (encoding == Encoding.Ansi) SendMessageA(hWnd, WM_SETTEXT, 0, text);
            else if (encoding == Encoding.Unicode) SendMessageW(hWnd, WM_SETTEXT, 0, text);
        }

        public static void PressKeyInBackground(IntPtr hWnd, int keyCode)
        {
            PostMessage(hWnd, WM_KEYDOWN, keyCode, 0x1);
            PostMessage(hWnd, WM_KEYUP, keyCode, (int)(0x100000000 - 0xC0000001));
        }

        public static void ClickInBackground(IntPtr hWnd, MouseButton button, short x, short y)
        {
            int message1, message2;

            if (button == MouseButton.Left)
            {
                message1 = WM_LBUTTONDOWN;
                message2 = WM_LBUTTONUP;
            }
            else if (button == MouseButton.Right)
            {
                message1 = WM_RBUTTONDOWN;
                message2 = WM_RBUTTONUP;
            }
            else if (button == MouseButton.Middle)
            {
                message1 = WM_MBUTTONDOWN;
                message2 = WM_MBUTTONUP;
            }
            else throw new NoSuchButtonException();

            PostMessage(hWnd, (uint)message1, 0, (y * 0x10000) | (x & 0xFFFF));
            PostMessage(hWnd, (uint)message2, 0, (y * 0x10000) | (x & 0xFFFF));
        }

        public static void DoubleClickInBackground(IntPtr hWnd, MouseButton button, short x, short y)
        {
            int message;

            if (button == MouseButton.Left) message = WM_LBUTTONDBLCLK;
            else if (button == MouseButton.Right) message = WM_RBUTTONDBLCLK;
            else if (button == MouseButton.Middle) message = WM_MBUTTONDBLCLK;
            else throw new NoSuchButtonException();

            PostMessage(hWnd, (uint)message, 0, (y * 0x10000) | (x & 0xFFFF));
        }

        public static IntPtr GetFirstHwndWithIdentifiers(string className, string caption)
        {
            IntPtr hWndNew = IntPtr.Zero;

            EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                if (className == null || GetClassName(hWnd).Equals(className))
                {
                    if (caption == null || GetWindowText(hWnd).Equals(caption))
                    {
                        hWndNew = hWnd;
                        return false;
                    }
                }

                return true;
            }, IntPtr.Zero);

            return hWndNew;
        }

        public static List<IntPtr> GetHwndListWithIdentifiers(string className, string caption)
        {
            List<IntPtr> hWndList = new List<IntPtr>();

            EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                if (className == null || GetClassName(hWnd).Equals(className))
                {
                    if (caption == null || GetWindowText(hWnd).Equals(caption)) hWndList.Add(hWnd);
                }

                return true;
            }, IntPtr.Zero);

            return hWndList;
        }

        public static string GetWindowInfo(IntPtr hWnd)
        {
            int resultBufferCapacity = 512;
            int tempBufferCapacity = 256;
            StringBuilder resultBuffer = new StringBuilder(resultBufferCapacity);

            resultBuffer.Append("hWnd : 0x" + hWnd.ToString("X") + "\n");

            StringBuilder tempBuffer = new StringBuilder(tempBufferCapacity);
            int length = GetWindowText(hWnd, tempBuffer, tempBufferCapacity);
            resultBuffer.Append("Caption : " + tempBuffer.ToString() + "\n");
            resultBuffer.Append("Caption Length : " + length + "\n");

            tempBuffer.Clear();
            length = GetClassName(hWnd, tempBuffer, tempBufferCapacity);
            resultBuffer.Append("Class : " + tempBuffer.ToString() + "\n");
            resultBuffer.Append("Class Length : " + length + "\n");
            resultBuffer.Append("\n");

            var windowInfo = new WINDOWINFO();
            windowInfo.cbSize = (uint)Marshal.SizeOf(windowInfo);
            GetWindowInfo(hWnd, ref windowInfo);

            resultBuffer.Append("rcWindow.Left : " + windowInfo.rcWindow.left + "\n");
            resultBuffer.Append("rcWindow.Top : " + windowInfo.rcWindow.top + "\n");
            resultBuffer.Append("rcWindow.Right : " + windowInfo.rcWindow.right + "\n");
            resultBuffer.Append("rcWindow.Bottom : " + windowInfo.rcWindow.bottom + "\n");
            resultBuffer.Append("\n");

            resultBuffer.Append("rcClient.Left : " + windowInfo.rcClient.left + "\n");
            resultBuffer.Append("rcClient.Top : " + windowInfo.rcClient.top + "\n");
            resultBuffer.Append("rcClient.Right : " + windowInfo.rcClient.right + "\n");
            resultBuffer.Append("rcClient.Bottom : " + windowInfo.rcClient.bottom + "\n");
            resultBuffer.Append("\n");

            return resultBuffer.ToString();
        }

        public static RECT GetWindowRect(IntPtr hWnd)
        {
            var rect = new RECT();
            GetWindowRect(hWnd, ref rect);

            return rect;
        }

        public static WINDOWPLACEMENT GetWindowPlacement(IntPtr hWnd)
        {
            var windowPlacement = new WINDOWPLACEMENT();
            GetWindowPlacement(hWnd, ref windowPlacement);

            return windowPlacement;
        }

        public static string GetClassName(IntPtr hWnd)
        {
            int capacity = 256;
            StringBuilder buffer = new StringBuilder(capacity);
            GetClassName(hWnd, buffer, capacity);

            return buffer.ToString();
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            int capacity = 256;
            StringBuilder buffer = new StringBuilder(capacity);
            GetWindowText(hWnd, buffer, capacity);

            return buffer.ToString();
        }

        public static void ResizeWindow(IntPtr hWnd, int width, int height)
        {
            RECT rect = GetWindowRect(hWnd);
            MoveWindow(hWnd, rect.left, rect.top, width, height, true);
        }

        public static void MoveWindow(IntPtr hWnd, int x, int y)
        {
            RECT rect = GetWindowRect(hWnd);
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;
            MoveWindow(hWnd, x, y, width, height, false);
        }
    }
}
