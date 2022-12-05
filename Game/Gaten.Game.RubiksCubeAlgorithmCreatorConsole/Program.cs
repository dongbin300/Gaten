using Gaten.Net.GameRule.RubiksCube;

namespace Gaten.Game.RubiksCubeAlgorithmCreatorConsole
{
    internal class Program
    {
        public static SymbolCube333 cube = new();

        private static void Main()
        {
            Refresh();
            Loop();
        }

        private static void Loop()
        {
            while (true)
            {
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.Q: cube.Rotate(FaceRotation.Front); break;
                    case ConsoleKey.W: cube.Rotate(FaceRotation.Left); break;
                    case ConsoleKey.E: cube.Rotate(FaceRotation.Up); break;
                    case ConsoleKey.R: cube.Rotate(FaceRotation.Right); break;
                    case ConsoleKey.T: cube.Rotate(FaceRotation.Down); break;
                    case ConsoleKey.Y: cube.Rotate(FaceRotation.Back); break;
                    case ConsoleKey.A: cube.Rotate(FaceRotation.CounterFront); break;
                    case ConsoleKey.S: cube.Rotate(FaceRotation.CounterLeft); break;
                    case ConsoleKey.D: cube.Rotate(FaceRotation.CounterUp); break;
                    case ConsoleKey.F: cube.Rotate(FaceRotation.CounterRight); break;
                    case ConsoleKey.G: cube.Rotate(FaceRotation.CounterDown); break;
                    case ConsoleKey.H: cube.Rotate(FaceRotation.CounterBack); break;
                    case ConsoleKey.Z: cube.Rotate(FaceRotation.DoubleFront); break;
                    case ConsoleKey.X: cube.Rotate(FaceRotation.DoubleLeft); break;
                    case ConsoleKey.C: cube.Rotate(FaceRotation.DoubleUp); break;
                    case ConsoleKey.V: cube.Rotate(FaceRotation.DoubleRight); break;
                    case ConsoleKey.B: cube.Rotate(FaceRotation.DoubleDown); break;
                    case ConsoleKey.N: cube.Rotate(FaceRotation.DoubleBack); break;
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.P: cube.Scramble(25); break;
                }

                Refresh();
            }
        }

        private static void Refresh()
        {
            cube.Draw();
        }
    }
}