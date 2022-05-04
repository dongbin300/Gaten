using Gaten.Net.Windows.Forms;

namespace Gaten.Game.BrandNewType
{
    public partial class MainForm : Form
    {
        UserActivityHook2 hook;
        Thread keyInputThread;
        Rail rail = new Rail();
        Track track = new Track();
        NoteObject no;

        public int Score = 0;
        public int Combo = 0;
        public int PerfectCount = 0;
        public int MissCount = 0;

        public bool ShiftMode = false;

        public MainForm()
        {
            InitializeComponent();

            // Ÿ�̸�, ������ ����
            hook = new UserActivityHook2();
            keyInputThread = new Thread(new ThreadStart(InputWorker));
            keyInputThread.Start();
            frameTimer.Start();

            // ���� ����
            GameStart();
        }

        private void GameStart()
        {
            // ��Ʈ �ҷ�����
            LoadNotes();

            // �� ����
            track.SetupBar();
        }

        private void LoadNotes()
        {
            no = new NoteObject(90, "�����Ϻ��� 11�� ��ȸ ������������ȸ ���� ���� �Լ��� ����ȸ�� ���� �ڷḦ ���� �� ���� �����ߴ�. �����Ϻ��� ������ �� ������� �̴� 2�� û�ʹ뿡�� ���� ����ȸ�Ǹ� �����ϸ� ��ȭ������ õ�� ö�� ������ �����ϱ� ������ٸ� ������������ ����� ���̶�� �ϳ� ������ �浹�� ���� ������ �Ѵٴ� ���� �Ƹ����� ���� ��Ȳ�̶�� ���� ������ �˷�����.");
            //no = new NoteObject(90, "���������¥���������¥���������¥���������¥���������¥���������¥");
        }

        private void InputWorker()
        {
            hook.KeyDown += (sender, e) =>
            {
                // ���� �Է�
                if ((int)Keys.A <= (int)e.KeyCode && (int)e.KeyCode <= (int)Keys.Z)
                {
                    int hitResult = no.Hit(e.KeyCode, rail, ShiftMode);
                    switch (hitResult)
                    {
                        case -1:
                            MissCount++;
                            Combo = 0;
                            judgmentLabel.Text = "MISS";
                            comboLabel.Text = Combo + " Combo";
                            break;
                        case 0:
                            break;
                        case 1:
                            PerfectCount++;
                            Combo++;
                            Score += Combo * 1000 + new Random().Next(3000);
                            judgmentLabel.Text = "PERFECT!";
                            comboLabel.Text = Combo + " Combo";
                            scoreLabel.Text = Score + "";
                            break;
                    }
                }
                else
                {
                    switch (e.KeyCode)
                    {
                        case Keys.F1: // ���� �ӵ� ����
                            rail.DecreaseServiceSpeed();
                            break;
                        case Keys.F2: // ���� �ӵ� ����
                            rail.IncreaseServiceSpeed();
                            break;
                        case Keys.LShiftKey:
                        case Keys.RShiftKey:
                            ShiftMode = true;
                            break;
                    }
                }
            };

            hook.KeyUp += (sender, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.LShiftKey:
                    case Keys.RShiftKey:
                        ShiftMode = false;
                        break;
                }
            };
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainFrame_Paint(object sender, PaintEventArgs e)
        {
            Pen gray1 = new Pen(Brushes.Gray, 1);
            Pen lime2 = new Pen(Brushes.Lime, 2);
            Pen black1 = new Pen(Brushes.Black, 1);
            Pen black2 = new Pen(Brushes.Black, 2);
            Font noteFont = new Font("���� ���", 30);

            // Rail �⺻ ��
            e.Graphics.DrawLine(black2,
                Rail.Margin, Rail.Margin,
                mainFrame.Width - Rail.Margin, Rail.Margin);
            e.Graphics.DrawLine(black2,
                Rail.Margin, mainFrame.Height - Rail.Margin,
                mainFrame.Width - Rail.Margin, mainFrame.Height - Rail.Margin);
            e.Graphics.DrawLine(black2,
                Rail.HitPosition, Rail.Margin,
                Rail.HitPosition, mainFrame.Height - Rail.Margin);
            e.Graphics.DrawLine(lime2,
                Rail.HitPosition - NoteObject.gap * 3 * rail.ServiceSpeed, Rail.Margin,
                Rail.HitPosition - NoteObject.gap * 3 * rail.ServiceSpeed, mainFrame.Height - Rail.Margin);
            e.Graphics.DrawLine(lime2,
                Rail.HitPosition + NoteObject.gap * 5 * rail.ServiceSpeed, Rail.Margin,
                Rail.HitPosition + NoteObject.gap * 5 * rail.ServiceSpeed, mainFrame.Height - Rail.Margin);

            // Bar
            foreach (Bar bar in track.Bars)
            {
                int barPosX = Rail.HitPosition + (rail.ServiceSpeed * bar.Position - rail.Position);
                if (barPosX > 0 && barPosX < mainFrame.Width)
                    e.Graphics.DrawLine(gray1,
                    barPosX, 10,
                    barPosX, 190);
            }

            // Note
            foreach (Note note in no.Notes)
            {
                int notePosX = Rail.HitPosition + (rail.ServiceSpeed * note.Position - rail.Position);
                if (notePosX > 0 && notePosX < mainFrame.Width)
                    e.Graphics.DrawString(note.Value, noteFont, Brushes.Black, notePosX, 70);
            }
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            // ���� ����
            rail.Position += rail.ServiceSpeed;
            railPositionLabel.Text = rail.Position + "";

            // �ٽ� �׸���
            mainFrame.Refresh();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Ÿ�̸�, ������ ����
            frameTimer.Stop();
            keyInputThread.Join();
        }
    }
}