namespace Gaten.Game.NemoNemoLogic
{
    /* TODO
 * BMP파일 리사이즈, 이진화 변환 및 GUI개선
 */
    public partial class MainForm : Form
    {
        private static bool isClear = false;
        private static bool isDragging = false;
        private static int markType;
        private static int lastXIndex, lastYIndex;
        private static int currentXIndex, currentYIndex;

        private int BOARD_WIDTH;
        private int BOARD_HEIGHT;


        public Board UserBoard, MiniBoard;
        public NumberBoard AnswerBoard;
        public Panel BoardPanel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StateChange(ref int state, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    state = isDragging ? markType : Math.Abs(1 - state);
                    break;
                case MouseButtons.Right:
                    state = isDragging ? markType : state / 2 * (-2) + 2;
                    break;
            }
            markType = state;
        }

        private void DisableMark(Board board)
        {
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    if (board.State[i, j] == 2)
                        board.State[i, j] = 0;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BOARD_WIDTH = 5;
            BOARD_HEIGHT = 5;
            //NNLI nnli = new NNLI();
            //nnli.LoadImage("test.png").ToBinary().ResizeImage(BOARD_WIDTH, BOARD_HEIGHT).SaveImage("123345.png");

            UserBoard = new Board(Board.BoardTypes.User, BOARD_WIDTH, BOARD_HEIGHT);
            AnswerBoard = new NumberBoard(Board.BoardTypes.Answer, BOARD_WIDTH, BOARD_HEIGHT);
            MiniBoard = new Board(Board.BoardTypes.Mini, BOARD_WIDTH, BOARD_HEIGHT);

            BoardPanel = new Panel() { Width = BOARD_WIDTH * UserBoard.WidthPixel + MiniBoard.EndX, Height = BOARD_HEIGHT * UserBoard.HeightPixel + MiniBoard.EndY };
            BoardPanel.Paint += BoardPanel_Paint;
            BoardPanel.MouseDown += BoardPanel_MouseDown;
            BoardPanel.MouseMove += BoardPanel_MouseMove;
            BoardPanel.MouseUp += BoardPanel_MouseUp;

            gamePanel.Controls.Add(BoardPanel);

            AnswerBoard.MakeProblem();
            AnswerBoard.CalculateProblemNumber();
        }

        private void BoardPanel_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                currentXIndex = (int)(((float)e.X - AnswerBoard.StartX) / AnswerBoard.WidthPixel);
                currentYIndex = (int)(((float)e.Y - AnswerBoard.StartY) / AnswerBoard.HeightPixel);
                StateChange(ref UserBoard.State[currentXIndex, currentYIndex], e);
                isDragging = false;
                BoardPanel.Invalidate();
            }
            catch (System.IndexOutOfRangeException)
            {

            }
        }

        private void BoardPanel_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (isDragging)
                {
                    currentXIndex = (int)(((float)e.X - AnswerBoard.StartX) / AnswerBoard.WidthPixel);
                    currentYIndex = (int)(((float)e.Y - AnswerBoard.StartY) / AnswerBoard.HeightPixel);
                    if (!(currentXIndex == lastXIndex && currentYIndex == lastYIndex))
                    {
                        StateChange(ref UserBoard.State[currentXIndex, currentYIndex], e);
                        lastXIndex = currentXIndex;
                        lastYIndex = currentYIndex;
                        BoardPanel.Invalidate();
                    }
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
        }

        private void BoardPanel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                lastXIndex = (int)(((float)e.X - AnswerBoard.StartX) / AnswerBoard.WidthPixel);
                lastYIndex = (int)(((float)e.Y - AnswerBoard.StartY) / AnswerBoard.HeightPixel);
                StateChange(ref UserBoard.State[lastXIndex, lastYIndex], e);
                isDragging = true;
                BoardPanel.Invalidate();
            }
            catch (System.IndexOutOfRangeException)
            {

            }
        }

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            AnswerBoard.PaintLine(e);
            AnswerBoard.NumberInit(e);

            UserBoard.Paint(e);
            MiniBoard.State = UserBoard.State;
            MiniBoard.Paint(e);
            if (!isClear && UserBoard.CheckCompletion(AnswerBoard))
            {
                isClear = true;
                MessageBox.Show("완성.");
                DisableMark(UserBoard);
                //MiniBoard.state = MainBoard.state;
            }
        }
    }
}