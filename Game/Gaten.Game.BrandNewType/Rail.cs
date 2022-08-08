namespace Gaten.Game.BrandNewType
{
    internal class Rail
    {
        public int Position;
        public int ServiceSpeed;

        public const int HitPosition = 200;
        public const int Margin = 10;

        public Rail()
        {
            Position = 0;
            ServiceSpeed = 10;
        }

        public void IncreaseServiceSpeed()
        {
            ServiceSpeed++;
        }

        public void DecreaseServiceSpeed()
        {
            ServiceSpeed--;
        }
    }
}
