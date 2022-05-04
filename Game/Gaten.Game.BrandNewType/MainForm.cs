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

            // 타이머, 스레드 시작
            hook = new UserActivityHook2();
            keyInputThread = new Thread(new ThreadStart(InputWorker));
            keyInputThread.Start();
            frameTimer.Start();

            // 게임 시작
            GameStart();
        }

        private void GameStart()
        {
            // 노트 불러오기
            LoadNotes();

            // 바 설정
            track.SetupBar();
        }

        private void LoadNotes()
        {
            no = new NoteObject(90, "동아일보는 11일 국회 행정안전위원회 등을 통해 입수한 국무회의 관련 자료를 통해 이 같이 보도했다. 동아일보에 따르면 문 대통령은 이달 2일 청와대에서 열린 국무회의를 주재하며 광화문광장 천막 철거 과정은 이해하기 어려웠다며 행정대집행이 서울시 몫이라고 하나 경찰이 충돌만 막는 역할을 한다는 것은 아름답지 못한 상황이라고 말한 것으로 알려졌다.");
            //no = new NoteObject(90, "따까빠따까짜따까빠따까짜따까빠따까짜따까빠따까짜따까빠따까짜따까빠따까짜");
        }

        private void InputWorker()
        {
            hook.KeyDown += (sender, e) =>
            {
                // 자판 입력
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
                        case Keys.F1: // 레일 속도 감소
                            rail.DecreaseServiceSpeed();
                            break;
                        case Keys.F2: // 레일 속도 증가
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
            Font noteFont = new Font("맑은 고딕", 30);

            // Rail 기본 선
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
            // 레일 운행
            rail.Position += rail.ServiceSpeed;
            railPositionLabel.Text = rail.Position + "";

            // 다시 그리기
            mainFrame.Refresh();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 타이머, 스레드 종료
            frameTimer.Stop();
            keyInputThread.Join();
        }
    }
}