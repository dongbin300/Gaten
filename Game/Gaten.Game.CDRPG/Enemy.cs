namespace Gaten.Game.CDRPG
{
    public class Enemy
    {
        public struct Position
        {
            public int X;
            public int Y;

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public Position position = new();
        private int hp;
        private readonly int hpMax;
        private readonly Card.Tiers tier;
        private readonly Card.Properties property;
        private readonly Card.Species species;

        public Enemy() : this(new Position(), 0, Card.Tiers.None, Card.Properties.None, Card.Species.None)
        {

        }

        public Enemy(Position position, int hpMax, Card.Tiers tier, Card.Properties property, Card.Species species)
        {
            this.position = position;
            this.hpMax = hpMax;
            hp = this.hpMax;
            this.tier = tier;
            this.property = property;
            this.species = species;
        }

        public bool Damage(int num)
        {
            hp -= num;
            return hp <= 0;
        }
    }
}
