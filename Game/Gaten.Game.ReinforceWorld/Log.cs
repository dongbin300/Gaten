namespace Gaten.Game.ReinforceWorld
{
    public class Log
    {
        public static List<int> SuccessCount { get; set; } = new();
        public static List<int> FailureCount { get; set; } = new();
        public static int MaxReinforcementValue;
        public static long MaxMoneyValue;
        public static long GainMoney;
    }
}
