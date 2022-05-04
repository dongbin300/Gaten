using System.Text;

namespace Gaten.Game.Ntf
{
    public partial class MainForm : Form
    {
        DateTime startTime;
        double accumulatedTime;
        double totalTime;
        int exercise1;
        int exercise2;
        int exercise3;
        int exercise4;
        int exercise5;

        public MainForm()
        {
            InitializeComponent();
            tick.Start();
            saveTimer.Start();
            startTime = DateTime.Now;

            Load();
            totalTime = accumulatedTime;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    Visible = false;
                    ShowIcon = false;
                    notifyIcon1.Visible = true;
                    break;
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            ShowIcon = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            double ex1 = 1.0 + exercise1 * 0.1;
            double ex2 = exercise2 * (0.2 + 0.1 * rnd.Next(3));
            double ex3 = exercise3 * (0.8 + 0.1 * rnd.Next(5));
            double ex4 = exercise4 * 0.01 + 1;
            int ex5 = 1000 - exercise5 * 30;
            totalTime += ex1 * ex4;
            totalTime += ex2 * ex4;
            totalTime += ex3 * ex4;
            totalTime = Math.Round(totalTime, 1);
            notifyIcon1.Text = $"{totalTime}|{ex1}|{ex2}|{ex3}|{ex4}|{ex5}";
            tick.Interval = ex5;
            label1.Text = "" + totalTime;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
            tick.Stop();
            saveTimer.Stop();
        }

        void Save()
        {
            FileStream fs = new FileStream("data.bc", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
            sw.WriteLine(totalTime);
            sw.WriteLine(exercise1);
            sw.WriteLine(exercise2);
            sw.WriteLine(exercise3);
            sw.WriteLine(exercise4);
            sw.WriteLine(exercise5);
            sw.Flush();
            fs.Close();
        }

        void Load()
        {
            FileStream fs = new FileStream("data.bc", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            accumulatedTime = double.Parse(sr.ReadLine());
            exercise1 = int.Parse(sr.ReadLine());
            exercise2 = int.Parse(sr.ReadLine());
            exercise3 = int.Parse(sr.ReadLine());
            exercise4 = int.Parse(sr.ReadLine());
            exercise5 = int.Parse(sr.ReadLine());
            sr.Close();
            fs.Close();
        }

        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            Save();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void NotifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    contextMenuStrip1.Hide();
                    break;
                case MouseButtons.Right:
                    contextMenuStrip1.Show(Cursor.Position);
                    break;
            }
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool effort(int ex, int needTime)
        {
            int needExercise = needTime * (ex + 1);
            if (totalTime >= needExercise)
            {
                totalTime -= needExercise;
                return true;
            }
            return false;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (effort(exercise1, 100))
            {
                exercise1++;
            }
        }

        private void Ex2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (effort(exercise2, 1000))
            {
                exercise2++;
            }
        }

        private void Ex3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (effort(exercise3, 10000))
            {
                exercise3++;
            }
        }

        private void Ex4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (effort(exercise4, 100000))
            {
                exercise4++;
            }
        }

        private void Ex5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (effort(exercise5, 1000000))
            {
                exercise5++;
            }
        }
    }
}