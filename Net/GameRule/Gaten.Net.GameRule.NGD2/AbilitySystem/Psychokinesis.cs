namespace Gaten.Net.GameRule.NGD2.AbilitySystem
{
    public class Psychokinesis : IAbility
    {
        /// <summary>
        /// 능력사용 필요레벨
        /// </summary>
        public static int RequireLevel => 100;

        /// <summary>
        /// 레벨
        /// </summary>
        public static int Level { get; set; }

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

        public Psychokinesis()
        {

        }

        static Effect GetEffect()
        {
            Effect effect = new Effect
            {
                Power = Level * 20,
                MpRegen = Level * 3,
                MpMax = Level * 6000,
                SpiritDrop = Level * 3,
                BoostPower = Level * 2,
                MugongDropMultiple = Level * 4,
                PsychokinesisPower = Level * Value
            };

            return effect;
        }

        public static void DisplayShop()
        {
            EasyConsole.SetCursorAndColorAndWrite(0, 0, 12, "나가기 :: ESC");
            EasyConsole.SetCursorAndColorAndWrite(20, 0, 89, $"염력 :: {Value}, 레벨 :: {Level}");
            EasyConsole.SetCursorAndColorAndWrite(0, 2, 15, $"1. 염력레벨+ (35%) :: 염력 ({Level + 1})");
            EasyConsole.SetCursorAndColorAndWrite(0, 3, 15, $"2. 염력레벨+ (65%) :: 염력 ({(Level + 1) * 2})");
            EasyConsole.SetCursorAndColorAndWrite(0, 4, 15, $"3. 염력레벨+ (95%) :: 염력 ({(Level + 1) * 3})");
            EasyConsole.SetCursorAndColorAndWrite(0, 7, 89, $"공격력+ {Effect.Power}, MP회복+ {Effect.MpRegen}, MP맥스+ {Effect.MpMax}, 근징드롭량+ {Effect.SpiritDrop}, 부스트파워+ {Effect.BoostPower}, 무공획득+ {Effect.MugongDropMultiple}%, 염력데미지 {Effect.PsychokinesisPower}");
            EasyConsole.SetColor(15);
        }

        public static void Activate()
        {
            if(Character.Level < RequireLevel)
            {
                return;
            }

            Character.Xp += Character.Effect.PsychokinesisPower;
        }

        public static void CheckDrop()
        {
            if (Character.Level < RequireLevel)
            {
                return;
            }

            if (Boost.Value < 10000)
            {
                return;
            }

            if (Spirit.Value < 100)
            {
                return;
            }

            Random r = new Random();

            if (r.Next(100) < Character.Effect.PsychokinesisDropRate)
            {
                Boost.Value -= 2500;
                Spirit.Value -= 100;
            }
        }
    }
}
