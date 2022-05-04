using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Gaten.GameTool.osu.CatchTheBeatKeyDisplayer
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys key);

        Thread inputWorker1;
        Thread inputWorker2;
        Thread inputWorker3;

        bool leftPressed, leftTemp;
        bool rightPressed, rightTemp;
        bool shiftPressed, shiftTemp;

        public MainForm()
        {
            InitializeComponent();

            inputWorker1 = new Thread(new ThreadStart(hook1)); inputWorker1.Start();
            inputWorker2 = new Thread(new ThreadStart(hook2)); inputWorker2.Start();
            inputWorker3 = new Thread(new ThreadStart(hook3)); inputWorker3.Start();

            TransparencyKey = Color.Black;

            Location = new Point(10, 10);
        }

        void hook1()
        {
            while (true)
            {
                leftPressed = GetAsyncKeyState(Keys.Left) < 0;
                if (leftPressed != leftTemp)
                {
                    leftTemp = leftPressed;
                    leftKeyPanel.Invalidate();
                }

                Thread.Sleep(5);
            }
        }

        void hook2()
        {
            while (true)
            {
                rightPressed = GetAsyncKeyState(Keys.Right) < 0;
                if (rightPressed != rightTemp)
                {
                    rightTemp = rightPressed;
                    rightKeyPanel.Invalidate();
                }

                Thread.Sleep(5);
            }
        }

        void hook3()
        {
            while (true)
            {
                shiftPressed = GetAsyncKeyState(Keys.LShiftKey) < 0;
                if (shiftPressed != shiftTemp)
                {
                    shiftTemp = shiftPressed;
                    shiftKeyPanel.Invalidate();
                }

                Thread.Sleep(5);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inputWorker1.Abort();
            inputWorker2.Abort();
            inputWorker3.Abort();
        }

        private void LeftKeyPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            if (leftPressed)
                DrawRoundRect(v, Pens.Black, Brushes.Gold, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            else
                DrawRoundRect(v, Pens.Black, Brushes.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void RightKeyPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            if (rightPressed)
                DrawRoundRect(v, Pens.Black, Brushes.Gold, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            else
                DrawRoundRect(v, Pens.Black, Brushes.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void ShiftKeyPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            if (shiftPressed)
                DrawRoundRect(v, Pens.Black, Brushes.DeepPink, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            else
                DrawRoundRect(v, Pens.Black, Brushes.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        public void DrawRoundRect(Graphics g, Pen p, Brush brush, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            g.FillPath(brush, gp);
            gp.Dispose();
        }
    }
}