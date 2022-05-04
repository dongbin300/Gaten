namespace Gaten.Game.IdleUtaite
{
    public class Me
    {
        public int money;
        public int follower;
        public int awareness;

        public Me()
        {
            money = 1000;
            follower = 0;
            awareness = 0;
        }

        public void ReCalculate()
        {
            int incomePs = 100;
            money += incomePs / 5;
            awareness = follower * 3;
        }
    }
}
