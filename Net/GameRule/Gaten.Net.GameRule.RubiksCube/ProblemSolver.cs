namespace Gaten.Net.GameRule.RubiksCube
{
    public class ProblemSolver
    {
        //public static List<CubeSymbol> AllBottom = new
        //{
        //    //new CubeSymbol();
        //}

        public static SymbolCube333 RotateNew(SymbolCube333 cube, FaceRotation faceRotation)
        {
            switch (faceRotation)
            {
                case FaceRotation.Right:
                    General.SymbolRotate(RotateDirection.Left, cube, 31, 33, 39, 37);
                    General.SymbolRotate(RotateDirection.Left, cube, 32, 36, 38, 34);
                    General.SymbolRotate(RotateDirection.Left, cube, 43, 3, 23, 59);
                    General.SymbolRotate(RotateDirection.Left, cube, 46, 6, 26, 56);
                    General.SymbolRotate(RotateDirection.Left, cube, 49, 9, 29, 53);
                    break;
                case FaceRotation.CounterRight:
                    General.SymbolRotate(RotateDirection.Right, cube, 31, 33, 39, 37);
                    General.SymbolRotate(RotateDirection.Right, cube, 32, 36, 38, 34);
                    General.SymbolRotate(RotateDirection.Right, cube, 43, 3, 23, 59);
                    General.SymbolRotate(RotateDirection.Right, cube, 46, 6, 26, 56);
                    General.SymbolRotate(RotateDirection.Right, cube, 49, 9, 29, 53);
                    break;
                case FaceRotation.Left:
                    General.SymbolRotate(RotateDirection.Left, cube, 11, 13, 19, 17);
                    General.SymbolRotate(RotateDirection.Left, cube, 12, 16, 18, 14);
                    General.SymbolRotate(RotateDirection.Left, cube, 21, 1, 41, 57);
                    General.SymbolRotate(RotateDirection.Left, cube, 24, 4, 44, 54);
                    General.SymbolRotate(RotateDirection.Left, cube, 27, 7, 47, 51);
                    break;
                case FaceRotation.CounterLeft:
                    General.SymbolRotate(RotateDirection.Right, cube, 11, 13, 19, 17);
                    General.SymbolRotate(RotateDirection.Right, cube, 12, 16, 18, 14);
                    General.SymbolRotate(RotateDirection.Right, cube, 21, 1, 41, 57);
                    General.SymbolRotate(RotateDirection.Right, cube, 24, 4, 44, 54);
                    General.SymbolRotate(RotateDirection.Right, cube, 27, 7, 47, 51);
                    break;
                case FaceRotation.Up:
                    General.SymbolRotate(RotateDirection.Left, cube, 21, 23, 29, 27);
                    General.SymbolRotate(RotateDirection.Left, cube, 22, 26, 28, 24);
                    General.SymbolRotate(RotateDirection.Left, cube, 51, 33, 3, 13);
                    General.SymbolRotate(RotateDirection.Left, cube, 52, 32, 2, 12);
                    General.SymbolRotate(RotateDirection.Left, cube, 53, 31, 1, 11);
                    break;
                case FaceRotation.CounterUp:
                    General.SymbolRotate(RotateDirection.Right, cube, 21, 23, 29, 27);
                    General.SymbolRotate(RotateDirection.Right, cube, 22, 26, 28, 24);
                    General.SymbolRotate(RotateDirection.Right, cube, 51, 33, 3, 13);
                    General.SymbolRotate(RotateDirection.Right, cube, 52, 32, 2, 12);
                    General.SymbolRotate(RotateDirection.Right, cube, 53, 31, 1, 11);
                    break;
                case FaceRotation.Down:
                    General.SymbolRotate(RotateDirection.Left, cube, 41, 43, 49, 47);
                    General.SymbolRotate(RotateDirection.Left, cube, 42, 46, 48, 44);
                    General.SymbolRotate(RotateDirection.Left, cube, 17, 7, 37, 59);
                    General.SymbolRotate(RotateDirection.Left, cube, 18, 8, 38, 58);
                    General.SymbolRotate(RotateDirection.Left, cube, 19, 9, 39, 57);
                    break;
                case FaceRotation.CounterDown:
                    General.SymbolRotate(RotateDirection.Right, cube, 41, 43, 49, 47);
                    General.SymbolRotate(RotateDirection.Right, cube, 42, 46, 48, 44);
                    General.SymbolRotate(RotateDirection.Right, cube, 17, 7, 37, 59);
                    General.SymbolRotate(RotateDirection.Right, cube, 18, 8, 38, 58);
                    General.SymbolRotate(RotateDirection.Right, cube, 19, 9, 39, 57);
                    break;
                case FaceRotation.Front:
                    General.SymbolRotate(RotateDirection.Left, cube, 1, 3, 9, 7);
                    General.SymbolRotate(RotateDirection.Left, cube, 2, 6, 8, 4);
                    General.SymbolRotate(RotateDirection.Left, cube, 27, 31, 43, 19);
                    General.SymbolRotate(RotateDirection.Left, cube, 28, 34, 42, 16);
                    General.SymbolRotate(RotateDirection.Left, cube, 29, 37, 41, 13);
                    break;
                case FaceRotation.CounterFront:
                    General.SymbolRotate(RotateDirection.Right, cube, 1, 3, 9, 7);
                    General.SymbolRotate(RotateDirection.Right, cube, 2, 6, 8, 4);
                    General.SymbolRotate(RotateDirection.Right, cube, 27, 31, 43, 19);
                    General.SymbolRotate(RotateDirection.Right, cube, 28, 34, 42, 16);
                    General.SymbolRotate(RotateDirection.Right, cube, 29, 37, 41, 13);
                    break;
                case FaceRotation.Back:
                    General.SymbolRotate(RotateDirection.Left, cube, 51, 57, 59, 53);
                    General.SymbolRotate(RotateDirection.Left, cube, 52, 54, 58, 56);
                    General.SymbolRotate(RotateDirection.Left, cube, 33, 21, 17, 49);
                    General.SymbolRotate(RotateDirection.Left, cube, 36, 22, 14, 48);
                    General.SymbolRotate(RotateDirection.Left, cube, 39, 23, 11, 47);
                    break;
                case FaceRotation.CounterBack:
                    General.SymbolRotate(RotateDirection.Right, cube, 51, 57, 59, 53);
                    General.SymbolRotate(RotateDirection.Right, cube, 52, 54, 58, 56);
                    General.SymbolRotate(RotateDirection.Right, cube, 33, 21, 17, 49);
                    General.SymbolRotate(RotateDirection.Right, cube, 36, 22, 14, 48);
                    General.SymbolRotate(RotateDirection.Right, cube, 39, 23, 11, 47);
                    break;
                case FaceRotation.DoubleRight:
                    RotateNew(cube, FaceRotation.Right);
                    RotateNew(cube, FaceRotation.Right);
                    break;
                case FaceRotation.DoubleLeft:
                    RotateNew(cube, FaceRotation.Left);
                    RotateNew(cube, FaceRotation.Left);
                    break;
                case FaceRotation.DoubleUp:
                    RotateNew(cube, FaceRotation.Up);
                    RotateNew(cube, FaceRotation.Up);
                    break;
                case FaceRotation.DoubleDown:
                    RotateNew(cube, FaceRotation.Down);
                    RotateNew(cube, FaceRotation.Down);
                    break;
                case FaceRotation.DoubleFront:
                    RotateNew(cube, FaceRotation.Front);
                    RotateNew(cube, FaceRotation.Front);
                    break;
                case FaceRotation.DoubleBack:
                    RotateNew(cube, FaceRotation.Back);
                    RotateNew(cube, FaceRotation.Back);
                    break;
            }

            return cube;
        }

        public static string FindRU(SymbolCube333 cube, List<CubeSymbol> goalSymbols)
        {
            string result = string.Empty;
            FaceRotation[] rotations = new FaceRotation[]
            {
                FaceRotation.Right,
                FaceRotation.CounterRight,
                FaceRotation.DoubleRight,
                FaceRotation.Up,
                FaceRotation.CounterUp,
                FaceRotation.DoubleUp
            };
            string[] rotationStrings = new string[] { "R", "R'", "R2", "U", "U'", "U2" };

            for (int i = 0; i < rotations.Length; i++)
            {
                cube = RotateNew(cube, rotations[i]);
                result += rotationStrings[i];

                if (CheckGoal(cube, goalSymbols))
                {
                    return result;
                }
                else
                {
                    return FindRU(cube, goalSymbols);
                }
            }

            return string.Empty;
        }

        public static bool CheckGoal(SymbolCube333 cube, List<CubeSymbol> goalSymbols)
        {
            foreach (var symbol in goalSymbols)
            {
                if (!cube.Symbols[symbol.Index].Equals(symbol.Symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
