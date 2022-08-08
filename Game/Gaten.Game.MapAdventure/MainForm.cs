using Gaten.Net.Windows.Forms;

namespace Gaten.Game.MapAdventure
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// ĳ����
        /// </summary>
        public Character c;

        /// <summary>
        /// ������ �۵� ������ �ƴ��� ����
        /// </summary>
        public bool IsRunning;

        /// <summary>
        /// ������Ʈ ���� (ƽ, ����: ms)
        /// </summary>
        public int UpdateInterval = 20;
        private readonly Thread mainThread;
        private readonly Thread keyThread;
        private readonly UserActivityHook hook;

        public MainForm()
        {
            InitializeComponent();

            // �񵿱� Ű���� �Է� �̺�Ʈ �߰�
            //KeyDown += KeyDownEvent;

            // ĳ���� ����
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
            // ���� ���� �۵�
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
        /// ���� ������ �۵���Ų��.
        /// ���� ������ �۵��ϱ� �����ϸ� IsRunning�� ���� false�� �Ǳ� �������� �ٸ� �ڵ忡 ������ �� ����.
        /// </summary>
        public void Start()
        {
            IsRunning = true;

            // ������ ���۵ǰ� ���� ������ ����Ǳ� ������ IsRunning�� ���� true�� ����
            // ������ ���� �� ��, ������������ ����� ���� IsRunning�� ���� false�� �־��ش�.
            while (IsRunning)
            {
                // UpdateInterval�и��� ���
                Thread.Sleep(UpdateInterval);

                // ���� ������ ������Ʈ
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