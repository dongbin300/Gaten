namespace Gaten.Net.GameRule.NGD2.AbilitySystem
{
    public class Key : IAbility
    {
        /// <summary>
        /// 능력사용 필요레벨
        /// </summary>
        public static int RequireLevel => 30;

        /// <summary>
        /// 레벨
        /// </summary>
        public static int Level { get; set; }

        /// <summary>
        /// 소지 개수
        /// </summary>
        public static int Value => Normal.Where(p => p != 0).Count() + Rare.Where(p => p != 0).Count() + Unique.Where(p => p != 0).Count();

        /// <summary>
        /// 소지 최대 개수
        /// </summary>
        public static int Max => 3 * 100;

        /// <summary>
        /// 키 수집율
        /// </summary>
        public static int CollectionRate => Value / 3;

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

        /// <summary>
        /// 노말 키
        /// </summary>
        public static int[] Normal = new int[100];

        /// <summary>
        /// 레어 키
        /// </summary>
        public static int[] Rare = new int[100];

        /// <summary>
        /// 유니크 키
        /// </summary>
        public static int[] Unique = new int[100];

        /// <summary>
        /// 키 등급 문자열
        /// </summary>
        public static string[] Grade => new string[] { "노멀", "레어", "유니크" };

        /// <summary>
        /// 키 얻기 1회 시도 필요 근징 개수
        /// </summary>
        public static int[] Price => new int[] { 50, 500, 1500 };

        /// <summary>
        /// 키를 얻을 확률
        /// </summary>
        public static int[] SuccessRate => new int[] { 10, 10, 1 };

        /// <summary>
        /// 키 콘솔 색깔
        /// </summary>
        public static int[] Color => new int[] { 15, 11, 13 };

        /// <summary>
        /// 등급별 배수 적용
        /// </summary>
        public static int[] Multiple => new int[] { 1, 3, 15 };


        public Key()
        {

        }

        static Effect GetEffect()
        {
            Effect effect = new Effect();

            for (int i = 0; i < 10; i++)
            {
                effect.Power = Normal[0 + i] * 3 + Rare[0 + i] * 9 + Unique[0 + i] * 45;
                effect.MpMax = Normal[10 + i] * 1500 + Rare[10 + i] * 4500 + Unique[10 + i] * 22500;
                effect.MpRegen = Normal[20 + i] * 1 + Rare[20 + i] * 3 + Unique[20 + i] * 15;
                effect.SpiritDropRate = Normal[30 + i] * 5 + Rare[30 + i] * 15 + Unique[30 + i] * 75;
                effect.PsychokinesisDropRate = Normal[40 + i] * 1 + Rare[40 + i] * 3 + Unique[40 + i] * 15;
                effect.BoostPower = Normal[50 + i] * 1 + Rare[50 + i] * 3 + Unique[50 + i] * 15;
                effect.BoostMax = Normal[60 + i] * 300 + Rare[60 + i] * 900 + Unique[60 + i] * 4500;
                effect.SpiritDrop = Normal[70 + i] * 1 + Rare[70 + i] * 3 + Unique[70 + i] * 15;
                effect.MugongDropMultiple = Normal[80 + i] * 2 + Rare[80 + i] * 6 + Unique[80 + i] * 30;
                effect.PsychokinesisDropRate += Normal[90 + i] * 1 + Rare[90 + i] * 3 + Unique[90 + i] * 15;
            }
            effect.CriticalDamageMultiple = Value; // 보유 키 1개당 크뎀+ 1%

            return effect;
        }

        public static void DisplayShop(int keyBoxNum, int keyX, int keyY)
        {
            EasyConsole.SetCursorAndColorAndWrite(0, 0, 12,
                "나가기 :: ESC");
            EasyConsole.SetCursorAndColorAndWrite(0, 1, 12,
                "제작하기 :: Space bar");
            EasyConsole.SetCursorAndColorAndWrite(0, 2, 14,
                $"근성의 징표 :: {Spirit.Value}");
            EasyConsole.SetCursorAndColorAndWrite(15, 4, 12,
                $"제작: 근징 {Price[keyBoxNum]}개, 성공률 {SuccessRate[keyBoxNum]}%");
            EasyConsole.SetCursorAndColorAndWrite(25, 5, Color[keyBoxNum],
                $"KEY ITEM ({Grade[keyBoxNum]})");
            EasyConsole.SetCursorAndColorAndWrite(45, 5, 10,
                $"{Value} / {Max} ({CollectionRate}%)");
            EasyConsole.SetColor(14);

            for (int i = 0; i < 100; i++)
            {
                EasyConsole.SetCursor(15 + 3 * (i % 10), 7 + i / 10);
                switch (keyBoxNum)
                {
                    case 0:
                        if (Normal[i] > 0) EasyConsole.SetColor(Color[keyBoxNum]);
                        if (Normal[i] == 0) EasyConsole.SetColor(8);
                        if (keyY == i / 10 && keyX == i % 10) EasyConsole.SetColor(250);
                        if (Normal[i] > 0) EasyConsole.Write("‡");
                        else EasyConsole.Write("  ");
                        break;
                    case 1:
                        if (Normal[i] > 0) EasyConsole.SetColor(Color[keyBoxNum]);
                        if (Normal[i] == 0) EasyConsole.SetColor(8);
                        if (keyY == i / 10 && keyX == i % 10) EasyConsole.SetColor(250);
                        if (Normal[i] > 0) EasyConsole.Write("ρ");
                        else EasyConsole.Write("  ");
                        break;
                    case 2:
                        if (Normal[i] > 0) EasyConsole.SetColor(Color[keyBoxNum]);
                        if (Normal[i] == 0) EasyConsole.SetColor(8);
                        if (keyY == i / 10 && keyX == i % 10) EasyConsole.SetColor(250);
                        if (Normal[i] > 0) EasyConsole.Write("§");
                        else EasyConsole.Write("  ");
                        break;
                }
            }

            EasyConsole.SetCursorAndColorAndWrite(15, 19, 12,
                "기본옵션 : 크리티컬데미지+ 1%");
            EasyConsole.SetCursorAndColor(15, 20, 14);

            switch (keyY)
            {
                case 0: EasyConsole.Write($"00옵션 : 공격력+ {3 * Multiple[keyBoxNum]}                    "); break;
                case 1: EasyConsole.Write($"10옵션 : MP MAX+ {1500 * Multiple[keyBoxNum]}            "); break;
                case 2: EasyConsole.Write($"20옵션 : MP 리젠+ {1 * Multiple[keyBoxNum]}                 "); break;
                case 3: EasyConsole.Write($"30옵션 : 근징드롭율+ {1 * Multiple[keyBoxNum]}%          "); break;
                case 4: EasyConsole.Write($"40옵션 : 염력드롭율+ {0.01 * Multiple[keyBoxNum]}%        "); break;
                case 5: EasyConsole.Write($"50옵션 : 부스트파워+ {1 * Multiple[keyBoxNum]}       "); break;
                case 6: EasyConsole.Write($"60옵션 : 부스트MAX+ {3 * Multiple[keyBoxNum]}             "); break;
                case 7: EasyConsole.Write($"70옵션 : 근징드롭량+ {1 * Multiple[keyBoxNum]}             "); break;
                case 8: EasyConsole.Write($"80옵션 : 무공획득량+ {2 * Multiple[keyBoxNum]}%         "); break;
                case 9: EasyConsole.Write($"90옵션 : 염력드롭율+ {0.01 * Multiple[keyBoxNum]}%        "); break;
            }
        }
    }
}
