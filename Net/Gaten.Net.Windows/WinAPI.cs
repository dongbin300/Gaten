using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Gaten.Net.Windows
{
    /// <summary>
    /// Windows API의 메서드 목록을 담고 있는 클래스입니다.
    /// </summary>
    public partial class WinApi
    {
        // 버전 정보
        private static string FullApiVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public readonly static string ApiVersion = FullApiVersion.Substring(0, FullApiVersion.LastIndexOf('.'));

        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("User32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr hWndChildAfter, string className, string windowTitle);

        [DllImport("User32.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

        [DllImport("User32.dll")]
        public static extern bool ClientToScreen(IntPtr hwnd, ref Point lpPoint);

        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // 메시지 핸들링
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hwnd, uint msg, int wParam, int lParam);

        [DllImport("User32.dll")]
        public static extern int PostMessage(IntPtr hwnd, uint msg, int wParam, int lParam);

        [DllImport("User32.dll", CharSet = CharSet.Ansi)]
        public static extern int SendMessageA(IntPtr hWnd, uint msg, int wParam, string lParam);

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int SendMessageW(IntPtr hWnd, uint msg, int wParam, string lParam);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessageGetTextLen(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("User32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessageGetTextW(IntPtr hWnd, uint msg, int wParam, [Out] StringBuilder lParam);

        // GDI 함수
        [DllImport("User32.dll")]
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

        // 클립보드 처리
        [DllImport("User32.dll")]
        public static extern bool OpenClipboard(IntPtr hNewOwner);

        [DllImport("User32.dll")]
        public static extern bool EmptyClipboard();

        [DllImport("User32.dll")]
        public static extern IntPtr SetClipboardData(uint format, IntPtr hMemory);

        [DllImport("User32.dll")]
        public static extern IntPtr GetClipboardData(uint format);

        [DllImport("User32.dll")]
        public static extern uint EnumClipboardFormats(uint format);

        [DllImport("User32.dll")]
        public static extern bool CloseClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetOpenClipboardWindow();

        // Process
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        // Keyboard & Mouse
        [DllImport("User32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void MouseEvent(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        // 창 다루기
        [DllImport("User32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder buffer, int maxLength);

        [DllImport("User32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int maxLength);

        [DllImport("User32.dll")]
        public static extern bool GetWindowInfo(IntPtr hWnd, ref WINDOWINFO windowInfo);

        [DllImport("User32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("User32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        [DllImport("User32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int command);

        [DllImport("User32.dll")]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("User32.dll")]
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