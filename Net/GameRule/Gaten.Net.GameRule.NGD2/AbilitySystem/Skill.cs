namespace Gaten.Net.GameRule.NGD2.AbilitySystem
{
    public class Skill : IAbility
    {
        /// <summary>
        /// 능력사용 필요레벨
        /// </summary>
        public static int RequireLevel => 30;

        public static SkillUpgradeContent Blow { get; set; }
        public static SkillUpgradeContent EnergyRelease { get; set; }
        public static SkillUpgradeContent ExtremeMpRegen { get; set; }
        public static SkillUpgradeContent CriticalMind { get; set; }
        public static SkillUpgradeContent PowerCritical { get; set; }
        public static SkillUpgradeContent FastPush { get; set; }
        public static SkillUpgradeContent BonusPunch { get; set; }
        public static SkillUpgradeContent Showtime { get; set; }
        public static SkillUpgradeContent Ungijosik { get; set; }
        public static SkillUpgradeContent Psychokinesis { get; set; }

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

        public Skill()
        {

        }

        public static void Init()
        {
            Blow = new SkillUpgradeContent("일격", 1, 50, 10, 20, 1000);
            EnergyRelease = new SkillUpgradeContent("기력방출", 1, 50, 1000, 25, 1000);
            ExtremeMpRegen = new SkillUpgradeContent("극MP회복", 1, 50, 1, 0, 1000);
            CriticalMind = new SkillUpgradeContent("크리티컬마인드", 1, 50, 10, 500, 1000);
            PowerCritical = new SkillUpgradeContent("파워크리티컬", 1, 50, 1, 250, 1000);
            FastPush = new SkillUpgradeContent("패스트푸쉬", 1, 50, 3, 30, 1000);
            BonusPunch = new SkillUpgradeContent("보너스펀치", 1, 50, 50, 1, 150, 1000);
            Showtime = new SkillUpgradeContent("쇼타임", 1, 50, 100, 125, 1000);
            Ungijosik = new SkillUpgradeContent("운기조식", 1, 50, 1, 1500, 1000);
            Psychokinesis = new SkillUpgradeContent("사이코키네시스", 1, 50, 1, 0, 1000);
        }

        static Effect GetEffect()
        {
            Effect effect = new Effect
            {
                Power = Blow.On ? Blow.TotalValue : 0,
                MpMax = EnergyRelease.On ? EnergyRelease.TotalValue : 0,
                MpRegen = ExtremeMpRegen.On ? ExtremeMpRegen.TotalValue : 0,
                CriticalRate = CriticalMind.On ? CriticalMind.TotalValue : 0,
                CriticalDamageMultiple = PowerCritical.On ? PowerCritical.TotalValue : 0,
                AttackSpeed = FastPush.On ? FastPush.TotalValue : 0,
                SpiritDropRate = BonusPunch.On ? BonusPunch.TotalValue : 0,
                SpiritDrop = BonusPunch.On ? BonusPunch.TotalValue : 0,
                KeyPieceDropRate = Showtime.On ? Showtime.TotalValue : 0,
                MugongDropMultiple = Ungijosik.On ? Ungijosik.TotalValue : 0,
                PsychokinesisPriceSale = Psychokinesis.On ? Psychokinesis.TotalValue : 0
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

            if (r.Next(10000) < Character.Effect.SkillCardDropRateIM * 100)
            {
                int n = r.Next(100);

                if(n < 15)
                {
                    Blow.CardValue++;
                }
                else if (n < 30)
                {
                    EnergyRelease.CardValue++;
                }
                else if (n < 45)
                {
                    ExtremeMpRegen.CardValue++;
                }
                else if (n < 52)
                {
                    CriticalMind.CardValue++;
                }
                else if (n < 62)
                {
                    PowerCritical.CardValue++;
                }
                else if (n < 77)
                {
                    FastPush.CardValue++;
                }
                //else 
            }
        }
    }
}
