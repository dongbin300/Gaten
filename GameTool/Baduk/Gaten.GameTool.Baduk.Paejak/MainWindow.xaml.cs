using Gaten.Net.Math;
using Gaten.Net.Windows;
using Gaten.Net.Windows.Forms;

using Google.Protobuf;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace Gaten.GameTool.Baduk.Paejak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Window API
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public ShowWindowCommands showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        internal enum ShowWindowCommands : int
        {
            Hide = 0,
            Normal = 1,
            Minimized = 2,
            Maximized = 3,
        }

        internal enum WNDSTATE : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_MAX = 10
        }

        private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(hwnd, ref placement);
            return placement;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);



        // Windows 의 Position 을 가져옴.

        void GetWindowPos(IntPtr hwnd, ref int ptrPhwnd, ref int ptrNhwnd, ref System.Windows.Point ptPoint, ref Size szSize, ref WNDSTATE intShowCmd)
        {
            WINDOWPLACEMENT wInf = new WINDOWPLACEMENT();
            wInf.length = System.Runtime.InteropServices.Marshal.SizeOf(wInf);
            GetWindowPlacement(hwnd, ref wInf);
            szSize = new Size(wInf.rcNormalPosition.Right - (wInf.rcNormalPosition.Left * 2),
                wInf.rcNormalPosition.Bottom - (wInf.rcNormalPosition.Top * 2));
            ptPoint = new System.Windows.Point(wInf.rcNormalPosition.Left, wInf.rcNormalPosition.Top);
        }
        #endregion

        System.Timers.Timer timer = new System.Timers.Timer(200);
        BadukBoard board;

        bool isRunning = false;

        UserActivityHook hook;
        private Thread keyLogThread = default!;
        IntPtr hanQHandle = IntPtr.Zero;

        public MainWindow()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            hanQHandle = Process.GetProcessesByName("foxwq")[0].MainWindowHandle;
            int ptrPhWnd = 0, ptrNhwnd = 0;
            System.Windows.Point position = new System.Windows.Point();
            Size size = new Size();
            WNDSTATE intShowCmd = 0;

            GetWindowPos(hanQHandle, ref ptrPhWnd, ref ptrNhwnd, ref position, ref size, ref intShowCmd);
            var x = (int)position.X;
            var y = (int)position.Y;
            var w = (int)size.Width;
            var h = (int)size.Height;

            InputSimulator.MouseActivityInterval = 100;

            board = new BadukBoard(x, y, w, h);

            hook = new UserActivityHook();
            keyLogThread = new Thread(new ThreadStart(KeyLogger));
            keyLogThread.Start();
        }

        private void KeyLogger()
        {
            hook.KeyUp += (sender, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad1:
                        SetForegroundWindow(hanQHandle);
                        isRunning = true;
                        break;

                    case Keys.NumPad2:
                        isRunning = false;
                        break;
                }
            };
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (isRunning)
            {
                var random = new SmartRandom();
                switch (random.Next(4))
                {
                    case 0:
                        var value0 = random.Next(30);
                        var point0 = board.GetWindowPositionInteger(3 + value0 % 15, 3 + value0 / 15);
                        InputSimulator.MouseDoubleClick(point0.Item1, point0.Item2);
                        break;

                    case 1:
                        var value1 = random.Next(22);
                        var point1 = board.GetWindowPositionInteger(3 + value1 / 11, 5 + value1 % 11);
                        InputSimulator.MouseDoubleClick(point1.Item1, point1.Item2);
                        break;

                    case 2:
                        var value2 = random.Next(22);
                        var point2 = board.GetWindowPositionInteger(16 + value2 / 11, 5 + value2 % 11);
                        InputSimulator.MouseDoubleClick(point2.Item1, point2.Item2);
                        break;

                    case 3:
                        var value3 = random.Next(30);
                        var point3 = board.GetWindowPositionInteger(3 + value3 % 15, 16 + value3 / 15);
                        InputSimulator.MouseDoubleClick(point3.Item1, point3.Item2);
                        break;
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            isRunning = true;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            isRunning = false;
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            InputSimulator.MouseClick(50, 50);
        }
    }
}
