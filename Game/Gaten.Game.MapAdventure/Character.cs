namespace Gaten.Game.MapAdventure
{
    public class Character
    {
        public int X;
        public int Y;
        public Size Size;
        readonly int temporaryMoveDistance = 12;
        readonly int jumpInterval = 100;

        public Character(int x = 100, int y = 200, int width = 20, int height = 20)
        {
            X = x;
            Y = y;
            Size = new Size(width, height);
        }

        public void MoveUp()
        {
            Y -= temporaryMoveDistance;
        }

        public void MoveDown()
        {
            Y += temporaryMoveDistance;
        }

        public void MoveLeft()
        {
            X -= temporaryMoveDistance;
        }

        public void MoveRight()
        {
            X += temporaryMoveDistance;
        }

        public async void Jump()
        {
            await Task.Factory.StartNew(() =>
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
            });
        }
    }
}
