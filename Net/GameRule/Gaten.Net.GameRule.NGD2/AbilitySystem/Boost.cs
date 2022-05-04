namespace Gaten.Net.GameRule.NGD2.AbilitySystem
{
    public class Boost : IAbility
    {
        /// <summary>
        /// 능력사용 필요레벨
        /// </summary>
        public static int RequireLevel => 50;

        /// <summary>
        /// 주기적 감소량
        /// </summary>
        public static int Attenuation => 2;

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
        /// 리젠량
        /// </summary>
        public static double Regen { get; set; }

        /// <summary>
        /// 어빌리티로 얻는 효과
        /// </summary>
        public static Effect Effect => GetEffect();

        public static int Color => GetColor();

        public Boost()
        {

        }

        static Effect GetEffect()
        {
            Effect effect = new Effect();

            effect.Power = (int)Value / 100;

            if (Value >= 200)
            {
                effect.MpRegen = (int)(5 * (Value / 5000));
            }

            if (Value > 50000)
            {
                effect.GameSpeed = 20;
            }
            else if (Value > 20000)
            {
                effect.GameSpeed = (int)((Value - 20000) / 15);
            }
            
            return effect;
        }

        static int GetColor()
        {
            if (Value < 200) return 8;
            else if (Value < 1000) return 15;
            else if (Value < 2500) return 14;
            else if (Value < 5000) return 10;
            else if (Value < 10000) return 11;
            else if (Value < 20000) return 13;
            else return 12;
        }

        public static void Activate()
        {
            if(Character.Level < RequireLevel)
            {
                return;
            }

            Max = Character.Effect.BoostMax;
            if (Value < Max)
                Value += Character.Effect.BoostPower;
            else
                Value = Max;
        }
    }
}
