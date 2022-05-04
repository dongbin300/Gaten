using Gaten.Net.GameRule.osu.OsuFile;
using Gaten.Net.Windows.Forms;

using System.Runtime.InteropServices;

using WindowsInput;

namespace Gaten.Game.osu
{
    public partial class MainForm : Form
    {
        public GameManager game;
        public FrameTimer t = new FrameTimer();

        long prevTick = 0;
        int c = 0;

        bool beatmapSet;
        bool start;

        int targetFps = 20;

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);

        bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }

        public MainForm()
        {
            InitializeComponent();
            Application.Idle += HandleApplicationIdle;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            //StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Opacity = 0.3;
        }

        void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                int fps = CheckFps();
                if (fps > targetFps)
                {
                    Thread.Sleep((int)(1000.0 / targetFps - 1000.0 / fps));
                }
                else
                {
                    Thread.Sleep(40);
                }

                Update();
                Render();
            }
        }

        void Update()
        {
            if (start)
            {
                if (game.Proceed())
                {
                    Delegater.PanelRefresh(mainPanel);
                }
                else
                {
                    game.Dispose();
                    start = false;
                }
            }
        }

        void Render()
        {
            if (start)
            {

            }
        }

        private void mainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // .NET 6.0에서 지원안함 (InputSimulator)
            //InputSimulator i = new InputSimulator();
            //Point globalPosition = new Point(Location.X + e.X + 8, Location.Y + e.Y + 31);

            //WindowState = FormWindowState.Minimized;

            //Thread.Sleep(100);

            //Cursor.Position = globalPosition;
            //i.Mouse.LeftButtonClick();

            //Thread.Sleep(100);

            //WindowState = FormWindowState.Normal;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (game != null)
                game.Draw(e);
        }

        int CheckFps()
        {
            long tick = DateTime.Now.Ticks;
            int fps = (int)(10000000 / (tick - prevTick));
            prevTick = tick;
            c++;

            if (c > 5)
            {
                Delegater.TextSet(fpsLabel, fps + "fps");
                c = 0;
            }

            return fps;
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            CheckFps();

            if (start)
            {
                if (game.Proceed())
                {
                    mainPanel.Refresh();
                }
                else
                {
                    game.Dispose();
                    start = false;
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainTimer.Stop();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Space:
                    if (!beatmapSet)
                    {
                        OsuFileObject ofo = new OsuFileObject(@"test3.osu");
                        game = new GameManager(ofo);
                        game.TrackPosition = -4000;

                        /*t.Interval = 52;
                        t.TimerEvent = delegate ()
                        {
                            CheckFps();

                            if (start)
                            {
                                if (game.Proceed())
                                {
                                    DelegateMaster.PanelRefresh(mainPanel);
                                }
                                else
                                {
                                    game.Dispose();
                                    start = false;
                                }
                            }
                        };
                        t.Start();*/
                        //mainTimer.Interval = 31;
                        //mainTimer.Start();

                        beatmapSet = true;
                        start = true;
                    }
                    else
                    {
                        if (start)
                        {
                            start = false;
                            //t.Stop();
                            //mainTimer.Stop();
                        }
                        else
                        {
                            start = true;
                            //t.Start();
                            //mainTimer.Start();
                        }
                    }
                    break;
            }
        }
    }
}