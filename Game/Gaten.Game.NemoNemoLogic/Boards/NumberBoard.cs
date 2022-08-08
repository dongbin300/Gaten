namespace Gaten.Game.NemoNemoLogic.Boards
{
    public class NumberBoard : Board
    {
        // 문제 숫자 X, Y
        private readonly List<BoardNumberList> xNumberLists = new();
        private readonly List<BoardNumberList> yNumberLists = new();

        public NumberBoard(BoardTypes type, int w, int h) : base(type, w, h)
        {
        }

        /// <summary>
        /// 문제 만들기 (Answer보드용)
        /// </summary>
        /// <param name="bmp"></param>
        public void MakeProblem()
        {
            Random rnd = new();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    //answer[j, i] = bmp.colorData[(boardHeight - i - 1) * boardWidth + j].r == 0 ? 1 : 0;
                    if (rnd.Next(10) <= 6)
                    {
                        State[j, i] = 1;
                    }
                    //State[j, i] = rnd.Next(2);
                }
            }
        }

        //public void ImageToProblem(Bitmap bitmap)
        //{
        //    for (int i = 0; i < Height; i++)
        //    {
        //        for (int j = 0; j < Width; j++)
        //        {
        //            answer[j, i] = bitmap.GetPixel(j, i) == Color.White ? 0 : 1;
        //        }
        //    }
        //}

        /// <summary>
        /// 최초 문제 숫자 계산 (Answer보드용)
        /// </summary>
        public void CalculateProblemNumber()
        {
            if (type != BoardTypes.Answer)
            {
                return;
            }

            int constantCount;

            for (int i = 0; i < Height; i++)
            {
                constantCount = 0;
                xNumberLists.Add(new BoardNumberList());
                for (int j = 0; j < Width; j++)
                {
                    if (State[i, j] > 0)
                    {
                        constantCount++;
                    }
                    else if (constantCount > 0)
                    {
                        xNumberLists[i].numbers.Add(constantCount);
                        constantCount = 0;
                    }
                    if (j == Width - 1 && constantCount != 0)
                    {
                        xNumberLists[i].numbers.Add(constantCount);
                    }
                }
            }

            for (int i = 0; i < Width; i++)
            {
                constantCount = 0;
                yNumberLists.Add(new BoardNumberList());
                for (int j = 0; j < Height; j++)
                {
                    if (State[j, i] > 0)
                    {
                        constantCount++;
                    }
                    else if (constantCount > 0)
                    {
                        yNumberLists[i].numbers.Add(constantCount);
                        constantCount = 0;
                    }
                    if (j == Height - 1 && constantCount != 0)
                    {
                        yNumberLists[i].numbers.Add(constantCount);
                    }
                }
            }
        }

        /// <summary>
        /// 문제 숫자 그리기 (Answer보드용)
        /// </summary>
        /// <param name="e"></param>
        public void NumberInit(PaintEventArgs e)
        {
            Font font = new(FontFamily.GenericSansSerif, 10);
            int temp;

            /* 가로줄 숫자 표시 */
            for (int i = 0; i < xNumberLists.Count; i++)
            {
                temp = 0;
                for (int j = xNumberLists[i].numbers.Count - 1; j >= 0; j--)
                {
                    e.Graphics.DrawString("" + xNumberLists[i].numbers[j], font, Brushes.Black,
                        new Point(StartY - 5 - (17 * ++temp), 200 + (HeightPixel * i)));
                }
            }

            /* 세로줄 숫자 표시 */
            for (int i = 0; i < yNumberLists.Count; i++)
            {
                temp = 0;
                for (int j = yNumberLists[i].numbers.Count - 1; j >= 0; j--)
                {
                    e.Graphics.DrawString("" + yNumberLists[i].numbers[j], font, Brushes.Black,
                        new Point(200 + (WidthPixel * i), StartX - 5 - (13 * ++temp)));
                }
            }
        }

        /// <summary>
        /// 문제 선 그리기 (Answer보드용)
        /// </summary>
        /// <param name="e"></param>
        public void PaintLine(PaintEventArgs e)
        {
            Pen p = new(Color.Black, 1);

            for (int i = 0; i <= Width; i++)
            {
                e.Graphics.DrawLine(p,
                    new Point(10, StartY + (HeightPixel * i)),
                    new Point(EndY, StartY + (HeightPixel * i)));
                e.Graphics.DrawLine(p,
                    new Point(StartX + (WidthPixel * i), 10),
                    new Point(StartX + (WidthPixel * i), EndX));
            }
        }
    }
}
