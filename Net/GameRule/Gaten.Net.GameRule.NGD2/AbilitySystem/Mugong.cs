namespace Gaten.Net.GameRule.NGD2.AbilitySystem
{
    public class Mugong : IAbility
    {
        /// <summary>
        /// 능력사용 필요레벨
        /// </summary>
        public static int RequireLevel => 70;

        /// <summary>
        /// 레벨
        /// </summary>
        public static int Level { get; set; }

        /// <summary>
        /// 소지 개수
        /// </summary>
        public static double Value { get; set; }

        /// <summary>
        /// 소지 최대 개수
        /// </summary>
        public static double Max { get; set; }

        /// <summary>
        /// 드롭량
        /// </summary>
        public static double Drop { get; set; }

        /// <summary>
        /// 드롭률
        /// </summary>
        public static int DropRate { get; set; }

        /// <summary>
        /// 어빌리티로 얻는 효과
        /// </summary>
        public static Effect Effect => GetEffect();

        public Mugong()
        {

        }

        static Effect GetEffect()
        {
            Effect effect = new Effect
            {
                Power = Level * 12,
                MpRegen = Level * 2
            };

            return effect;
        }

        public static void DisplayShop()
        {

        }
    }
}
