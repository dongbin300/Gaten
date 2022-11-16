using Gaten.Net.GameRule.RubiksCube;

namespace Gaten.Game.RubiksCube
{
    internal class Program
    {
        public static RubiksCube333 cube = new();

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
                    case ConsoleKey.R: cube.Rotate(FaceRotation.Right); break;
                    case ConsoleKey.L: cube.Rotate(FaceRotation.Left); break;
                    case ConsoleKey.U: cube.Rotate(FaceRotation.Up); break;
                    case ConsoleKey.D: cube.Rotate(FaceRotation.Down); break;
                    case ConsoleKey.F: cube.Rotate(FaceRotation.Front); break;
                    case ConsoleKey.B: cube.Rotate(FaceRotation.Back); break;
                    case ConsoleKey.D1: cube.Rotate(FaceRotation.CounterRight); break;
                    case ConsoleKey.D2: cube.Rotate(FaceRotation.CounterLeft); break;
                    case ConsoleKey.D3: cube.Rotate(FaceRotation.CounterUp); break;
                    case ConsoleKey.D4: cube.Rotate(FaceRotation.CounterDown); break;
                    case ConsoleKey.D5: cube.Rotate(FaceRotation.CounterFront); break;
                    case ConsoleKey.D6: cube.Rotate(FaceRotation.CounterBack); break;
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.S: cube.Scramble(25); break;
                }

                Refresh();
            }
        }

        private static void Refresh()
        {
            cube.DrawSymbol();
            //cube.Draw();
        }
    }
}