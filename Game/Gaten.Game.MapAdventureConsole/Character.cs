using System.Drawing;

namespace Gaten.Game.MapAdventureConsole
{
    public class Character
    {
        public static int X;
        public static int Y;
        public static Size Size;
        private static readonly int temporaryMoveDistance = 12;
        private static readonly int jumpInterval = 100;

        public Character(int x = 100, int y = 200, int width = 20, int height = 20)
        {
            X = x;
            Y = y;
            Size = new Size(width, height);
        }

        public static void Initialize()
        {
            X = 100;
            Y = 200;
            Size = new Size(20, 20);
        }

        public static void MoveUp()
        {
            Y -= temporaryMoveDistance;
        }

        public static void MoveDown()
        {
            Y += temporaryMoveDistance;
        }

        public static void MoveLeft()
        {
            X -= temporaryMoveDistance;
        }

        public static void MoveRight()
        {
            X += temporaryMoveDistance;
        }

        public static void Jump()
        {
            Y -= temporaryMoveDistance;
            Thread.Sleep(jumpInterval);
            Y -= temporaryMoveDistance;
            Thread.Sleep(jumpInterval);
            Y -= temporaryMoveDistance;
            Thread.Sleep(jumpInterval);
            Y += temporaryMoveDistance;
            Thread.Sleep(jumpInterval);
            Y += temporaryMoveDistance;
            Thread.Sleep(jumpInterval);
            Y += temporaryMoveDistance;
        }
    }
}
