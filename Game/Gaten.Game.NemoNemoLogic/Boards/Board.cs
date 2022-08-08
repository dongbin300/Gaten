namespace Gaten.Game.NemoNemoLogic.Boards
{
    public class Board
    {
        public enum BoardTypes
        {
            User,
            Answer,
            Mini
        };

        // 보드 타입
        protected BoardTypes type;

        // 보드 픽셀 넓이, 높이
        public int Width, Height;

        // 보드 상태
        public int[,] State;

        // 화면 시작 좌표
        public int StartX, StartY;

        // 화면 끝 좌표
        public int EndX, EndY;

        // 픽셀 하나의 크기
        public int WidthPixel, HeightPixel;

        public Board(BoardTypes type, int w, int h)
        {
            this.type = type;
            Width = w;
            Height = h;
            State = new int[Height, Width];

            switch (type)
            {
                case BoardTypes.User:
                case BoardTypes.Answer:
                    StartX = StartY = 200;
                    WidthPixel = HeightPixel = 20;
                    EndX = StartX + (w * WidthPixel);
                    EndY = StartY + (h * HeightPixel);
                    break;
                case BoardTypes.Mini:
                    StartX = StartY = 10;
                    EndX = EndY = 200;
                    WidthPixel = (EndX - StartX) / w;
                    HeightPixel = (EndY - StartY) / h;
                    break;
            }
        }

        /// <summary>
        /// 완성했는지 확인 (User보드용)
        /// </summary>
        /// <param name="answerBoard">정답 보드</param>
        /// <returns></returns>
        public bool CheckCompletion(Board answerBoard)
        {
            int[,] tempState = new int[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    tempState[j, i] = State[j, i] == 2 ? 0 : State[j, i];
                    if (tempState[j, i] != answerBoard.State[j, i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Paint(PaintEventArgs e)
        {
            Pen paintPen = new(Color.Black, WidthPixel);
            Pen markPen = new(Color.Black, 1);

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    switch (State[i, j])
                    {
                        case 1: // 색칠
                            e.Graphics.DrawLine(paintPen,
                            new Point(StartX + (WidthPixel * i), StartY + (HeightPixel * j) + (HeightPixel / 2)),
                            new Point(StartX + (WidthPixel * (i + 1)), StartY + (HeightPixel * j) + (HeightPixel / 2)));
                            break;
                        case 2: // X 표시
                            e.Graphics.DrawLine(markPen,
                            new Point(StartX + (WidthPixel * i), StartY + (HeightPixel * j)),
                            new Point(StartX + (WidthPixel * (i + 1)), StartY + (HeightPixel * (j + 1))));
                            e.Graphics.DrawLine(markPen,
                                new Point(StartX + (WidthPixel * (i + 1)), StartY + (HeightPixel * j)),
                                new Point(StartX + (WidthPixel * i), StartY + (HeightPixel * (j + 1))));
                            break;
                    }
                }
            }
        }
    }
}
