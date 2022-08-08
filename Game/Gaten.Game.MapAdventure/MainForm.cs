using Gaten.Net.Windows.Forms;

namespace Gaten.Game.MapAdventure
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 캐릭터
        /// </summary>
        public Character c;

        /// <summary>
        /// 엔진이 작동 중인지 아닌지 구분
        /// </summary>
        public bool IsRunning;

        /// <summary>
        /// 업데이트 간격 (틱, 단위: ms)
        /// </summary>
        public int UpdateInterval = 20;
        private readonly Thread mainThread;
        private readonly Thread keyThread;
        private readonly UserActivityHook hook;

        public MainForm()
        {
            InitializeComponent();

            // 비동기 키보드 입력 이벤트 추가
            //KeyDown += KeyDownEvent;

            // 캐릭터 생성
            c = new Character();

            hook = new UserActivityHook();

            renderTimer.Interval = UpdateInterval;
            renderTimer.Start();

            mainThread = new Thread(new ThreadStart(MainWorker));
            mainThread.Start();

            keyThread = new Thread(new ThreadStart(KeyWorker));
            keyThread.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainWorker()
        {
            // 게임 엔진 작동
            Start();
        }

        private void KeyWorker()
        {
            hook.KeyDown += (sender, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        c.MoveUp();
                        break;
                    case Keys.Down:
                        c.MoveDown();
                        break;
                    case Keys.Left:
                        c.MoveLeft();
                        break;
                    case Keys.Right:
                        c.MoveRight();
                        break;
                    case Keys.C:
                        c.Jump();
                        break;
                }
            };
        }

        /// <summary>
        /// 게임 엔진을 작동시킨다.
        /// 게임 엔진이 작동하기 시작하면 IsRunning의 값이 false가 되기 전까지는 다른 코드에 접근할 수 없다.
        /// </summary>
        public void Start()
        {
            IsRunning = true;

            // 게임이 시작되고 나서 완전히 종료되기 전까지 IsRunning의 값은 true로 고정
            // 게임이 종료 될 때, 비정상적으로 종료될 때만 IsRunning의 값을 false로 넣어준다.
            while (IsRunning)
            {
                // UpdateInterval밀리초 대기
                Thread.Sleep(UpdateInterval);

                // 게임 데이터 업데이트
                Update();
            }
        }

        private new void Update()
        {
        }

        private void Render()
        {
            screen.Refresh();
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            Brush b = Brushes.White;

            using Graphics g = e.Graphics;
            g.FillRectangle(b, c.X, c.Y, c.Size.Width, c.Size.Height);
        }

        public async void KeyDownEvent(object sender, KeyEventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsRunning = false;

            renderTimer.Stop();

            if (mainThread.ThreadState == ThreadState.Running)
            {
                mainThread.Join();
            }

            if (keyThread.ThreadState == ThreadState.Running)
            {
                keyThread.Join();
            }

            hook.Stop();
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            Render();
        }
    }
}