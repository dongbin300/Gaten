using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Gaten.Net.Windows
{
    /// <summary>
    /// Windows API Class
    /// </summary>
    public partial class WinApi
    {
        // Version Info
        private static string FullApiVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
        public readonly static string ApiVersion = FullApiVersion.Substring(0, FullApiVersion.LastIndexOf('.'));

        [DllImport("user32")]
        public static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("user32")]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr hWndChildAfter, string className, string windowTitle);

        [DllImport("user32")]
        public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

        [DllImport("user32")]
        public static extern bool ClientToScreen(IntPtr hwnd, ref Point lpPoint);

        [DllImport("user32")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Message Handle
        [DllImport("user32")]
        public static extern int SendMessage(IntPtr hwnd, uint msg, int wParam, int lParam);

        [DllImport("user32")]
        public static extern int PostMessage(IntPtr hwnd, uint msg, int wParam, int lParam);

        [DllImport("user32", CharSet = CharSet.Ansi)]
        public static extern int SendMessageA(IntPtr hWnd, uint msg, int wParam, string lParam);

        [DllImport("user32", CharSet = CharSet.Unicode)]
        public static extern int SendMessageW(IntPtr hWnd, uint msg, int wParam, string lParam);

        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessageGetTextLen(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessageGetTextW(IntPtr hWnd, uint msg, int wParam, [Out] StringBuilder lParam);

        // GDI
        [DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int width, int height);

        [DllImport("Gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hGdiObject);

        [DllImport("Gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("Gdi32.dll")]
        public static extern bool BitBlt(IntPtr hDestDC, int destX, int destY, int width, int height, IntPtr hSourceDC, int sourceX, int sourceY, int rasterOperationType);

        [DllImport("Gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);

        // Clipboard
        [DllImport("user32")]
        public static extern bool OpenClipboard(IntPtr hNewOwner);

        [DllImport("user32")]
        public static extern bool EmptyClipboard();

        [DllImport("user32")]
        public static extern IntPtr SetClipboardData(uint format, IntPtr hMemory);

        [DllImport("user32")]
        public static extern IntPtr GetClipboardData(uint format);

        [DllImport("user32")]
        public static extern uint EnumClipboardFormats(uint format);

        [DllImport("user32")]
        public static extern bool CloseClipboard();

        [DllImport("user32", SetLastError = true)]
        public static extern IntPtr GetOpenClipboardWindow();

        // Process
        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        // Keyboard & Mouse
        [DllImport("user32")]
        public static extern bool GetCursorPos(ref Windows.Point lpPoint);

        [DllImport("user32")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32")]
        public static extern void MouseEvent(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        // Window Handle
        [DllImport("user32")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder buffer, int maxLength);

        [DllImport("user32")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int maxLength);

        [DllImport("user32")]
        public static extern bool GetWindowInfo(IntPtr hWnd, ref WINDOWINFO windowInfo);

        [DllImport("user32")]
        public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32", SetLastError = true)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32")]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        [DllImport("user32")]
        public static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32")]
        public static extern bool ShowWindow(IntPtr hWnd, int command);

        [DllImport("user32")]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32")]
        public static extern bool ReleaseCapture();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile(
            string lpFileName,
            int dwDesiredAccess,
            int dwShareMode,
            IntPtr lpSecurityAttributes,
            int dwCreationDisposition,
            int dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetCurrentConsoleFont(
            IntPtr hConsoleOutput,
            bool bMaximumWindow,
            [Out][MarshalAs(UnmanagedType.LPStruct)] ConsoleFontInfo lpConsoleCurrentFont);

        public class NoSuchButtonException : Exception
        {
            internal NoSuchButtonException() : base("존재하지 않는 버튼 값입니다.") { }
        }
    }
}