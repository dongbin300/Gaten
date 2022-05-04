namespace Gaten.Net.GameRule.RubiksCube
{
    public enum PieceColor
    {
        Red = 1,
        Green = 2,
        Yellow = 3,
        Cyan = 4,
        White = 5,
        Magenta = 6
    }

    public enum FaceRotation
    {
        None,
        Front, CounterFront, DoubleFront,
        Right, CounterRight, DoubleRight,
        Up, CounterUp, DoubleUp,
        Left, CounterLeft, DoubleLeft,
        Back, CounterBack, DoubleBack,
        Down, CounterDown, DoubleDown
    }

    public enum RotateDirection
    {
        None,
        Left,
        Right
    }

    public class General
    {
        public static ConsoleColor GetConsoleColor(PieceColor pieceColor)
        {
            return pieceColor switch
            {
                PieceColor.Red => ConsoleColor.Red,
                PieceColor.Magenta => ConsoleColor.Magenta,
                PieceColor.Yellow => ConsoleColor.Yellow,
                PieceColor.Green => ConsoleColor.Green,
                PieceColor.Cyan => ConsoleColor.Cyan,
                PieceColor.White => ConsoleColor.White,
                _ => ConsoleColor.Black,
            };
        }

        public static void PieceColorRotate(RotateDirection d, RubiksCube333 cube, int s1, int c1, int s2, int c2, int s3, int c3, int s4, int c4)
        {
            switch (d)
            {
                case RotateDirection.Left:
                    PieceColor temp1 = cube.Sides[s1].PieceColors[c1];
                    cube.Sides[s1].PieceColors[c1] = cube.Sides[s2].PieceColors[c2];
                    cube.Sides[s2].PieceColors[c2] = cube.Sides[s3].PieceColors[c3];
                    cube.Sides[s3].PieceColors[c3] = cube.Sides[s4].PieceColors[c4];
                    cube.Sides[s4].PieceColors[c4] = temp1;
                    break;
                case RotateDirection.Right:
                    PieceColor temp2 = cube.Sides[s4].PieceColors[c4];
                    cube.Sides[s4].PieceColors[c4] = cube.Sides[s3].PieceColors[c3];
                    cube.Sides[s3].PieceColors[c3] = cube.Sides[s2].PieceColors[c2];
                    cube.Sides[s2].PieceColors[c2] = cube.Sides[s1].PieceColors[c1];
                    cube.Sides[s1].PieceColors[c1] = temp2;
                    break;
            }
        }
    }
}
