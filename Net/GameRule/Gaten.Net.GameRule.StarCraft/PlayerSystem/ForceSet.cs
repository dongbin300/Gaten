namespace Gaten.Net.GameRule.StarCraft.PlayerSystem
{
    public class ForceSet
    {
        public static List<Force> Forces { get; set; } = new();

        public ForceSet()
        {
            MakeDefault();
        }

        static void MakeDefault()
        {
            Forces.Add(new Force(4, ForceProperties.RandomStartLocation | ForceProperties.Allies | ForceProperties.AlliedVictory | ForceProperties.SharedVision));
            Forces.Add(new Force(5, ForceProperties.RandomStartLocation | ForceProperties.Allies | ForceProperties.AlliedVictory | ForceProperties.SharedVision));
            Forces.Add(new Force(6, ForceProperties.RandomStartLocation | ForceProperties.Allies | ForceProperties.AlliedVictory | ForceProperties.SharedVision));
            Forces.Add(new Force(7, ForceProperties.RandomStartLocation | ForceProperties.Allies | ForceProperties.AlliedVictory | ForceProperties.SharedVision));
        }
    }
}
