namespace Gaten.Game.IdleUtaite
{
    public class Effector
    {
        public string name;
        public int price;
        public int hitBoost;

        public Effector() { }

        public Effector(string name, int price, int hitBoost)
        {
            this.name = name;
            this.price = price;
            this.hitBoost = hitBoost;
        }
    }
}
