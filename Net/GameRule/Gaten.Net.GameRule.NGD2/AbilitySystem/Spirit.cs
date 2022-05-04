namespace Gaten.Net.GameRule.NGD2.AbilitySystem
{
    public class Spirit : IAbility
    {
        /// <summary>
        /// 능력사용 필요레벨
        /// </summary>
        public static int RequireLevel => 10;

        public static UpgradeContent Power { get; set; }
        public static UpgradeContent MpMax { get; set; }
        public static UpgradeContent MpRegen { get; set; }
        public static UpgradeContent CriticalRate { get; set; }
        public static UpgradeContent CriticalDamage { get; set; }

        /// <summary>
        /// 소지 개수
        /// </summary>
        public static int Value { get; set; }

        /// <summary>
        /// 소지 최대 개수
        /// </summary>
        public static int Max { get; set; }

        /// <summary>
        /// 드롭량
        /// </summary>
        public static int Drop { get; set; }

        /// <summary>
        /// 드롭률
        /// </summary>
        public static int DropRate { get; set; }

        /// <summary>
        /// 어빌리티로 얻는 효과
        /// </summary>
        public static Effect Effect => GetEffect();

        public Spirit()
        {

        }

        public static void Init()
        {
            Power = new UpgradeContent("공격력 증가", 1, 1, 10000);
            MpMax = new UpgradeContent("MP MAX 증가", 7, 600, 10000);
            MpRegen = new UpgradeContent("MP회복 증가", 50, 1, 1000);
            CriticalRate = new UpgradeContent("크리율 증가", 2222, 100, 100);
            CriticalDamage = new UpgradeContent("크리뎀 증가", 77, 1, 1000);
        }

        static Effect GetEffect()
        {
            Effect effect = new Effect
            {
                Power = Power.TotalValue,
                MpMax = MpMax.TotalValue,
                MpRegen = MpRegen.TotalValue,
                CriticalRate = CriticalRate.TotalValue,
                CriticalDamageMultiple = CriticalDamage.TotalValue
            };

            return effect;
        }

        public static void CheckDrop()
        {
            if(Character.Level < RequireLevel)
            {
                return;
            }

            Random r = new Random();

            if (r.Next(10000) < Character.Effect.SpiritDropRateIM * 100)
            {
                if (r.Next(100) == 77)
                { // 대박 근징 드롭
                    Value += Character.Effect.SpiritDropSum * 4;
                }
                else
                { // 일반 근징 드롭
                    Value += Character.Effect.SpiritDropSum;
                }
            }
        }
    }
}
