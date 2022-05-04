using Gaten.Net.GameRule.NGD2;
using Gaten.Net.GameRule.NGD2.AbilitySystem;

namespace NGD2Console
{
    class Program
    {
        enum Screens { Main, Skill, SpiritShop, PsychokinesisShop, KeyBox, Help, Option, Update, GameInfo, DetailStatus }
        static Screens screen = Screens.Main;

        static int[] NT = new int[15]; // Notice Text
        static int[] NTT = new int[15]; // Notice Text Timer
        static string[] NTTT = new string[15]; // Notice Text Timer Text
        static int[] NTTTC = new int[15]; // Notice Text Timer Text Color 

        static int characterIndex = 0;
        static bool restingReward = false;

        static string currentVersion;
        static int hotTimeBonus = 1;
        static int boxBorderColor = 15;

        static Thread keyInputThread;

        // 키 상자
        static int keyBoxNum = 0;
        static int keyX = 0, keyY = 0;

        static void Main(string[] args)
        {
            // 옵션 로드
            Option.Init();

            // 도움말 로드
            Help.Init();

            // 업데이트 로드
            Update.Init();
            currentVersion = Update.Version[Update.Max - 1];

            // 계정별 레벨 가져오기
            var tempLevel = Character.TempLoad();

            EasyConsole.SetCursorAndColorAndWrite(16, 8, 219, "┌────────┐");
            EasyConsole.SetCursorAndColorAndWrite(16, 9, 219, $"│1. SLOT 1 Lv {string.Format("{0,3}", tempLevel[0])}│");
            EasyConsole.SetCursorAndColorAndWrite(16, 10, 219, "├────────┤");
            EasyConsole.SetCursorAndColorAndWrite(16, 11, 219, $"│2. SLOT 2 Lv {string.Format("{0,3}", tempLevel[1])}│");
            EasyConsole.SetCursorAndColorAndWrite(16, 12, 219, "├────────┤");
            EasyConsole.SetCursorAndColorAndWrite(16, 13, 219, $"│3. SLOT 3 Lv {string.Format("{0,3}", tempLevel[2])}│");
            EasyConsole.SetCursorAndColorAndWrite(16, 14, 219, "└────────┘");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    characterIndex = 0;
                    Character.Load(0);
                    break;
                case ConsoleKey.D2:
                    characterIndex = 1;
                    Character.Load(1);
                    break;
                case ConsoleKey.D3:
                    characterIndex = 2;
                    Character.Load(2);
                    break;
            }

            Character.Calculate();

            while (true)
            {
                switch (screen)
                {
                    case Screens.Main:
                        MainScreen();
                        break;
                    case Screens.Skill:
                        SkillDisplay();
                        break;
                    case Screens.SpiritShop:
                        SpiritShop();
                        break;
                    case Screens.PsychokinesisShop:
                        PsychokinesisShop();
                        break;
                    case Screens.KeyBox:
                        KeyBox();
                        break;
                    case Screens.Help:
                        HelpScreen();
                        break;
                    case Screens.Option:
                        OptionScreen();
                        break;
                    case Screens.Update:
                        UpdateScreen();
                        break;
                    case Screens.GameInfo:
                        GameInfo();
                        break;
                    case Screens.DetailStatus:
                        DetailStatus();
                        break;
                }
                Thread.Sleep(50); // 고정 게임속도
            }
        }

        static void MainScreen()
        {
            /* 알림 메시지 타이머 */
            for (int i = 0; i < 15; i++)
            {
                if (NT[i] > 0)
                {
                    NTT[i]--;
                    if (NTT[i] < 0)
                    {
                        NTT[i] = 0;
                        NT[i] = 0;
                        NTTT[i] = "                    ";
                    }
                }
            }

            // 부스트 게이지 주기적으로 감소
            Boost.Value = Boost.Value > Boost.Attenuation ? Boost.Value - Boost.Attenuation : Boost.Value;



            /* 화면 새로 고침 */
            if (Gaten.Net.GameRule.NGD2.Timer.ClearScreen > 30)
            {
                if (Option.AutoSave > 0)
                {
                    Character.Save(characterIndex);
                    RegistText(10, "저장 완료");
                }
                Gaten.Net.GameRule.NGD2.Timer.ClearScreen = 0;
                EasyConsole.Clear();
            }

            /* 휴식 경험치 지급 */
            if (Character.Level >= 100 && !restingReward)
            {
                int restingTime = (int)(DateTime.Now - new DateTime(Character.LastTime[0], Character.LastTime[1], Character.LastTime[2], Character.LastTime[3], Character.LastTime[4], Character.LastTime[5])).TotalSeconds;
                Character.Xp += (long)Character.SkillBook.GetSkill("휴식").Level * 65 * restingTime;
                RegistText(15, $"휴식경험치+ {(long)Character.SkillBook.GetSkill("휴식").Level * 65 * restingTime}");
                restingReward = true;
            }

            EasyConsole.SetCursorAndColorAndWrite(2, 1, 11, $"Version {currentVersion}");
            EasyConsole.SetCursorAndColorAndWrite(18, 1, 15, $"현재시간 :: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            EasyConsole.SetCursorAndColorAndWrite(52, 1, 10, $"Lv {string.Format("{0,6}", Character.Level)}");
            EasyConsole.SetCursorAndColorAndWrite(52, 6, 15, "a 저장");
            EasyConsole.SetCursorAndColorAndWrite(52, 7, 15, "c 스킬");
            EasyConsole.SetCursorAndColorAndWrite(52, 8, 15, "x 업뎃");
            EasyConsole.SetCursorAndColorAndWrite(52, 9, 15, "b 키상자");
            EasyConsole.SetCursorAndColorAndWrite(52, 10, 15, "z 정보");
            EasyConsole.SetCursorAndColorAndWrite(52, 11, 15, "v 근징");
            EasyConsole.SetCursorAndColorAndWrite(52, 12, 15, "n 염력");
            EasyConsole.SetCursorAndColorAndWrite(52, 13, 15, "i 도움말");
            EasyConsole.SetCursorAndColorAndWrite(52, 14, 15, "o 설정");
            EasyConsole.SetCursorAndColorAndWrite(52, 15, 15, "p 상세스탯");

            hotTimeBonus = 1;
            if (DateTime.Now.Minute == 30) // 핫타임
                hotTimeBonus *= 2;

            boxBorderColor = 15;
            if (hotTimeBonus != 1) // 핫타임
                boxBorderColor = 10;

            EasyConsole.DrawBox(0, 0, 7, 1, boxBorderColor);
            EasyConsole.DrawBox(16, 0, 16, 1, boxBorderColor);
            EasyConsole.DrawBox(50, 0, 5, 1, boxBorderColor);
            EasyConsole.DrawBox(50, 5, 5, 10, boxBorderColor);
            EasyConsole.DrawBox(30, 5, 9, 10, boxBorderColor);
            EasyConsole.DrawBox(0, 5, 14, 10, boxBorderColor);
            EasyConsole.DrawBox(0, 16, 30, 12, boxBorderColor);
            EasyConsole.DrawBox(0, 29, 30, 5, boxBorderColor);
            EasyConsole.DrawBox(0, 2, 30, 2, boxBorderColor);

            /* 경험치 바, 마나 바 표시 */
            if (Option.BarDisplay > 0)
            {
                EasyConsole.SetCursorAndColorAndWrite(2, 3, 15, "Exp ");
                double xpStates = (double)Character.Xp / Exp(Character.Level) * 100;
                int xpBar = (int)(xpStates / 2); // 2%=1칸
                EasyConsole.DrawLine(10, 6, 9 + xpBar - (3 + Option.PerDisplay), 3);
                EasyConsole.SetColorAndWrite(169, $"{string.Format("{0:R}%", Math.Round(xpStates, Option.PerDisplay))}  ");
                EasyConsole.SetColor(0);
                for (int i = 0; i < 51 - xpBar; i++)
                    EasyConsole.Write(" ");

                EasyConsole.SetCursorAndColorAndWrite(2, 4, 11, "MP  ");
                double mpStates = (double)Character.Mp / Character.Effect.MpMax * 100;
                int manaBar = (int)(mpStates / 2); // 2%=1칸
                EasyConsole.DrawLine(11, 6, 9 + manaBar - 3, 4);
                EasyConsole.SetColorAndWrite(185, $"{string.Format("{0:R}%", Math.Round(mpStates, Option.PerDisplay))}  ");
                EasyConsole.SetColor(0);
                for (int i = 0; i < 51 - manaBar; i++)
                    EasyConsole.Write(" ");
            }
            /* 숫자로 표시 */
            else
            {
                double xpStates = (double)Character.Xp / Exp(Character.Level) * 100;
                EasyConsole.SetCursorAndColorAndWrite(2, 3, 15, $"Exp {EasyConsole.RegularNumber(Character.Xp)} / {EasyConsole.RegularNumber(Exp(Character.Level))} ({string.Format("{0:R}%", Math.Round(xpStates, Option.PerDisplay))})  ");
                EasyConsole.SetCursorAndColorAndWrite(2, 4, 11, $"MP  {EasyConsole.RegularNumber(Character.Mp)} / {EasyConsole.RegularNumber(Character.Effect.MpMax)}");
            }

            if (Character.Level >= 10)
                EasyConsole.SetCursorAndColorAndWrite(2, 6, 14, $"근성의 징표 {string.Format("{0,16}", Spirit.Value)}");
            if (Character.Level >= 30)
                EasyConsole.SetCursorAndColorAndWrite(2, 7, 14, $"키 {string.Format("{0,25}", Key.Value)}");
            if (Character.Level >= 50)
            {
                EasyConsole.SetColor(Boost.Color);
                EasyConsole.SetCursorAndWrite(2, 8, $"부스트 {string.Format("{0,21}", Boost.Value)}");
            }
            if (Character.Level >= 70)
            {
                EasyConsole.SetCursorAndColorAndWrite(2, 9, 139, $"무공  {string.Format("{0,7:F2}", Mugong.Value)} / {string.Format("{0,7:F2}", Math.Pow(Mugong.Level, 1.6))}({string.Format("{0,3}", Mugong.Level)})");
            }
            if (Character.Level >= 100)
            {
                EasyConsole.SetCursorAndColorAndWrite(2, 10, 89, $"염력 {string.Format("{0,18}", Psychokinesis.Value)}({string.Format("{0,3}", Psychokinesis.Level)})");
            }
            EasyConsole.SetCursorAndColorAndWrite(32, 6, 15, $"공격력 {string.Format("{0,11}", Character.Effect.Power)}");
            EasyConsole.SetCursorAndColorAndWrite(32, 7, 15, $"크리율 {string.Format("{0,10}%", Character.Effect.CriticalRate)}");
            EasyConsole.SetCursorAndColorAndWrite(32, 8, 15, $"크리뎀 {string.Format("{0,10}%", Character.Effect.CriticalDamageMultiple)}");
            EasyConsole.SetCursorAndColorAndWrite(32, 9, 15, $"MP회복 {string.Format("{0,11}", Character.Effect.MpRegen)}");
            EasyConsole.SetCursorAndColorAndWrite(32, 10, 15, $"부스트회복 {string.Format("{0,7}", Boost.Regen)}");
            EasyConsole.SetCursorAndColorAndWrite(32, 15, 15, $"남은평타 {string.Format("{0,9}", (Exp(Character.Level) - Character.Xp) / Character.Effect.Power)}");
            EasyConsole.SetCursor(2, 25);

            /* 스킬 텍스트 표시 */
            //foreach (Skill skill in Character.SkillBook.Skills)
            //{
            //    // 스킬 메시지를 보여줘야 하는 스킬이면
            //    if (skill.Type != 100)
            //    {
            //        skill.Message();
            //    }
            //}MpRegen

            DisplayText();

            keyInputThread = new Thread(new ThreadStart(keyInputWork));
            keyInputThread.Start();


            //t.ClearScreen++;

            foreach (Gaten.Net.GameRule.NGD2.SkillSystem.Skill skill in Character.SkillBook.Skills)
            {
                skill.Timer = skill.Timer > 0 ? skill.Timer - 1 : skill.Timer;
                skill.On = skill.Timer > 0;
            }

            /* 염력 데미지 */
            Character.Xp += Psychokinesis.Effect.Power;

            /* MP 리젠 */
            Character.Effect.MpMax = 400 * Character.Level + Psychokinesis.Effect.MpMax + Key.Effect.MpMax + 600 * Spirit.Effect.MpMax;
            if (Character.Mp < Character.Effect.MpMax)
            {
                Character.Effect.MpRegen = 0;
                if (Key.Value >= 100) Character.Effect.MpRegen += 25;
                if (Key.Value >= 200) Character.Effect.MpRegen += 75;
                if (Character.SkillBook.GetSkill("쇼타임").On) Character.Effect.MpRegen += 2 * Character.SkillBook.GetSkill("쇼타임").Level;
                Character.Effect.MpRegen += 3 + Character.Level / 5;
                Character.Effect.MpRegen += Psychokinesis.Effect.MpRegen;
                Character.Effect.MpRegen += Mugong.Effect.MpRegen;
                Character.Effect.MpRegen += Spirit.Effect.MpRegen;
                Character.Effect.MpRegen += Key.Effect.MpRegen;
                Character.Effect.MpRegen += Character.SkillBook.GetSkill("운기조식").Level * 15;
                Character.Mp += Character.Effect.MpRegen;
            }
            else
                Character.Mp = Character.Effect.MpMax;

            /* 레벨 업 */
            if (Character.Xp >= Exp(Character.Level))
            {
                Character.Xp -= Exp(Character.Level);
                Character.Level++;
                Character.Mp = Character.Effect.MpMax;
                RegistText(11, $"레벨 업({Character.Level - 1} -> {Character.Level})");
                if (Character.Level == 10)
                    RegistText(11, "이제 근성의징표를 사용할 수 있습니다");
                else if (Character.Level == 30)
                    RegistText(11, "이제 키를 사용할 수 있습니다");
                else if (Character.Level == 50)
                    RegistText(11, "이제 부스트를 사용할 수 있습니다");
                else if (Character.Level == 70)
                    RegistText(11, "이제 무공을 사용할 수 있습니다");
                else if (Character.Level == 100)
                    RegistText(11, "이제 염력을 사용할 수 있습니다");
            }

            /* 무공 레벨 업 */
            if (Mugong.Value >= Math.Pow(Mugong.Level, 1.6))
            {
                Mugong.Level++;
                RegistText(11, $"무공 레벨 업({Mugong.Level - 1 } -> {Mugong.Level})");
            }
        }

        static void keyInputWork()
        {
            Random r = new Random();
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (screen)
            {
                case Screens.Main:
                    switch (key)
                    {
                        case ConsoleKey.A:
                            Character.Save(characterIndex);
                            RegistText(10, "저장 완료");
                            break;
                        case ConsoleKey.S:
                            Character.Calculate();
                            Character.Xp += Character.Effect.PowerSum;
                            Character.HitCount++;
                            break;
                        case ConsoleKey.D:
                            break;
                        case ConsoleKey.C:
                            EasyConsole.Clear();
                            screen = Screens.Skill;
                            break;
                        case ConsoleKey.X:
                            EasyConsole.Clear();
                            screen = Screens.Update;
                            break;
                        case ConsoleKey.V:
                            EasyConsole.Clear();
                            screen = Screens.SpiritShop;
                            break;
                        case ConsoleKey.Z:
                            EasyConsole.Clear();
                            screen = Screens.GameInfo;
                            break;
                        case ConsoleKey.B:
                            EasyConsole.Clear();
                            screen = Screens.KeyBox;
                            break;
                        case ConsoleKey.N:
                            EasyConsole.Clear();
                            screen = Screens.PsychokinesisShop;
                            break;
                        case ConsoleKey.I:
                            EasyConsole.Clear();
                            screen = Screens.Help;
                            break;
                        case ConsoleKey.O:
                            EasyConsole.Clear();
                            screen = Screens.Option;
                            break;
                        case ConsoleKey.P:
                            EasyConsole.Clear();
                            screen = Screens.DetailStatus;
                            break;
                        case ConsoleKey.Spacebar:
                            //t.Bar = 1 - t.Bar;
                            break;
                        case ConsoleKey.D1:
                            if (Character.Level >= Character.SkillBook.GetSkill("일격").MinLevel)
                            {
                                Character.SkillBook.Activate("일격");
                            }
                            break;
                        case ConsoleKey.D2:
                            if (Character.Level >= Character.SkillBook.GetSkill("무쌍").MinLevel)
                            {
                                Character.SkillBook.Activate("무쌍");
                            }
                            break;
                        case ConsoleKey.D3:
                            if (Character.Level >= Character.SkillBook.GetSkill("진검").MinLevel)
                            {
                                Character.SkillBook.Activate("진검");
                            }
                            break;
                        case ConsoleKey.D4:
                            if (Character.Level >= Character.SkillBook.GetSkill("패스트푸쉬업").MinLevel)
                            {
                                Character.SkillBook.Activate("패스트푸쉬업");
                            }
                            break;
                        case ConsoleKey.D5:
                            if (Character.Level >= Character.SkillBook.GetSkill("파이어").MinLevel)
                            {
                                Character.SkillBook.Activate("파이어");
                            }
                            break;
                        case ConsoleKey.D6:
                            if (Character.Level >= Character.SkillBook.GetSkill("썬더").MinLevel)
                            {
                                Character.SkillBook.Activate("썬더");
                            }
                            break;
                        case ConsoleKey.Q:
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    if (Character.Level >= Character.SkillBook.GetSkill("더블클러치").MinLevel)
                                    {
                                        Character.SkillBook.Activate("더블클러치");
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    if (Character.Level >= Character.SkillBook.GetSkill("삼단베기").MinLevel)
                                    {
                                        Character.SkillBook.Activate("삼단베기");
                                    }
                                    break;
                                case ConsoleKey.D3:
                                    if (Character.Level >= Character.SkillBook.GetSkill("파열진").MinLevel)
                                    {
                                        Character.SkillBook.Activate("파열진");
                                    }
                                    break;
                                case ConsoleKey.D4:
                                    if (Character.Level >= Character.SkillBook.GetSkill("패스트푸쉬스트레이트").MinLevel)
                                    {
                                        Character.SkillBook.Activate("패스트푸쉬스트레이트");
                                    }
                                    break;
                                case ConsoleKey.D5:
                                    if (Character.Level >= Character.SkillBook.GetSkill("파이어로그").MinLevel)
                                    {
                                        Character.SkillBook.Activate("파이어로그");
                                    }
                                    break;
                                case ConsoleKey.D6:
                                    if (Character.Level >= Character.SkillBook.GetSkill("천지일격").MinLevel)
                                    {
                                        Character.SkillBook.Activate("천지일격");
                                    }
                                    break;
                                case ConsoleKey.W:
                                    if (Character.Level >= Character.SkillBook.GetSkill("쇼타임").MinLevel)
                                    {
                                        Character.SkillBook.Activate("쇼타임");
                                    }
                                    break;
                                case ConsoleKey.E:
                                    if (Character.Level >= Character.SkillBook.GetSkill("악마와의계약").MinLevel)
                                    {
                                        Character.SkillBook.Activate("악마와의계약");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case ConsoleKey.W:
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    if (Character.Level >= Character.SkillBook.GetSkill("파워풀클러치").MinLevel)
                                    {
                                        Character.SkillBook.Activate("파워풀클러치");
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    if (Character.Level >= Character.SkillBook.GetSkill("스타배쉬").MinLevel)
                                    {
                                        Character.SkillBook.Activate("스타배쉬");
                                    }
                                    break;
                                case ConsoleKey.D3:
                                    if (Character.Level >= Character.SkillBook.GetSkill("데스브링어").MinLevel)
                                    {
                                        Character.SkillBook.Activate("데스브링어");
                                    }
                                    break;
                                case ConsoleKey.D4:
                                    if (Character.Level >= Character.SkillBook.GetSkill("패스트푸쉬라이트").MinLevel)
                                    {
                                        Character.SkillBook.Activate("패스트푸쉬라이트");
                                    }
                                    break;
                                case ConsoleKey.D5:
                                    if (Character.Level >= Character.SkillBook.GetSkill("플레임머신").MinLevel)
                                    {
                                        Character.SkillBook.Activate("플레임머신");
                                    }
                                    break;
                                case ConsoleKey.D6:
                                    if (Character.Level >= Character.SkillBook.GetSkill("천지강격").MinLevel)
                                    {
                                        Character.SkillBook.Activate("천지강격");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case ConsoleKey.E:
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    if (Character.Level >= Character.SkillBook.GetSkill("무의극-주작").MinLevel)
                                    {
                                        Character.SkillBook.Activate("무의극-주작");
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    if (Character.Level >= Character.SkillBook.GetSkill("무의극-현무").MinLevel)
                                    {
                                        Character.SkillBook.Activate("무의극-현무");
                                    }
                                    break;
                                case ConsoleKey.D3:
                                    if (Character.Level >= Character.SkillBook.GetSkill("무의극-백호").MinLevel)
                                    {
                                        Character.SkillBook.Activate("무의극-백호");
                                    }
                                    break;
                                case ConsoleKey.D4:
                                    if (Character.Level >= Character.SkillBook.GetSkill("패스트푸쉬레프트").MinLevel)
                                    {
                                        Character.SkillBook.Activate("패스트푸쉬레프트");
                                    }
                                    break;
                                case ConsoleKey.D5:
                                    if (Character.Level >= Character.SkillBook.GetSkill("무의극-청룡").MinLevel)
                                    {
                                        Character.SkillBook.Activate("무의극-청룡");
                                    }
                                    break;
                                case ConsoleKey.D6:
                                    if (Character.Level >= Character.SkillBook.GetSkill("무의극-화신").MinLevel)
                                    {
                                        Character.SkillBook.Activate("무의극-화신");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case ConsoleKey.R:
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    if (Character.Level >= Character.SkillBook.GetSkill("순격").MinLevel)
                                    {
                                        Character.SkillBook.Activate("순격");
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    if (Character.Level >= Character.SkillBook.GetSkill("패러렐쓰러스트").MinLevel)
                                    {
                                        Character.SkillBook.Activate("패러렐쓰러스트");
                                    }
                                    break;
                                case ConsoleKey.D3:
                                    if (Character.Level >= Character.SkillBook.GetSkill("행복열차").MinLevel)
                                    {
                                        Character.SkillBook.Activate("행복열차");
                                    }
                                    break;
                                case ConsoleKey.D4:
                                    if (Character.Level >= Character.SkillBook.GetSkill("패스트푸쉬크로스").MinLevel)
                                    {
                                        Character.SkillBook.Activate("패스트푸쉬크로스");
                                    }
                                    break;
                                case ConsoleKey.D5:
                                    if (Character.Level >= Character.SkillBook.GetSkill("오토마타볼케이노").MinLevel)
                                    {
                                        Character.SkillBook.Activate("오토마타볼케이노");
                                    }
                                    break;
                                case ConsoleKey.D6:
                                    if (Character.Level >= Character.SkillBook.GetSkill("네버썬더").MinLevel)
                                    {
                                        Character.SkillBook.Activate("네버썬더");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                    }
                    break;
                case Screens.Skill:
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            break;
                    }
                    break;
                case Screens.Update:
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            EasyConsole.Clear();
                            if (Update.Index > 0)
                                Update.Index--;
                            break;
                        case ConsoleKey.RightArrow:
                            EasyConsole.Clear();
                            if (Update.Index < Update.Max - 1)
                                Update.Index++;
                            break;
                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            break;
                    }
                    break;
                case Screens.Help:
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            EasyConsole.Clear();
                            if (Help.Index > 0)
                                Help.Index--;
                            break;

                        case ConsoleKey.RightArrow:
                            EasyConsole.Clear();
                            if (Help.Index < Help.Max - 1)
                                Help.Index++;
                            break;

                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            break;
                    }
                    break;
                case Screens.SpiritShop:
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            if (Spirit.Value >= Spirit.Power.Level)
                            {
                                Spirit.Value -= Spirit.Power.Level++;
                            }
                            break;
                        case ConsoleKey.D2:
                            if (Spirit.Value >= Spirit.MpMax.Level * 7)
                            {
                                Spirit.Value -= Spirit.MpMax.Level++ * 7;
                            }
                            break;
                        case ConsoleKey.D3:
                            if (Spirit.Value >= Spirit.MpRegen.Level * 50)
                            {
                                Spirit.Value -= Spirit.MpRegen.Level++ * 50;
                            }
                            break;
                        case ConsoleKey.D6:
                            if (Spirit.Value >= Spirit.CriticalDamage.Level * 77)
                            {
                                Spirit.Value -= Spirit.CriticalDamage.Level++ * 77;
                            }
                            break;
                        case ConsoleKey.D7:
                            if (Spirit.Value >= 80000 - Spirit.CriticalRate.Level * 1000 && Spirit.CriticalRate.Level < 50)
                            {
                                Spirit.Value -= 80000 - Spirit.CriticalRate.Level++ * 1000;
                            }
                            break;
                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            break;
                    }
                    break;
                case Screens.PsychokinesisShop:
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            if (Psychokinesis.Value >= Psychokinesis.Level + 1)
                            {
                                Psychokinesis.Value -= Psychokinesis.Level + 1;
                                if (r.Next(100) < 35)
                                    Psychokinesis.Level++;
                                Character.Save(characterIndex);
                            }
                            break;
                        case ConsoleKey.D2:
                            if (Psychokinesis.Value >= (Psychokinesis.Level + 1) * 2)
                            {
                                Psychokinesis.Value -= (Psychokinesis.Level + 1) * 2;
                                if (r.Next(100) < 65)
                                    Psychokinesis.Level++;
                                Character.Save(characterIndex);
                            }
                            break;
                        case ConsoleKey.D3:
                            if (Psychokinesis.Value >= (Psychokinesis.Level + 1) * 3)
                            {
                                Psychokinesis.Value -= (Psychokinesis.Level + 1) * 3;
                                if (r.Next(100) < 95)
                                    Psychokinesis.Level++;
                                Character.Save(characterIndex);
                            }
                            break;
                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            break;
                    }
                    break;
                case Screens.KeyBox:
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (keyY != 0)
                                keyY--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (keyY != 9)
                                keyY++;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (keyX != 0)
                                keyX--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (keyX != 9)
                                keyX++;
                            break;
                        case ConsoleKey.Spacebar:
                            EasyConsole.Clear();
                            if (Spirit.Value >= Key.Price[keyBoxNum])
                            {
                                Spirit.Value -= Key.Price[keyBoxNum];
                                if (r.Next(100) < Key.SuccessRate[keyBoxNum])
                                {
                                    int keyIndex = r.Next(100);
                                    switch (keyBoxNum)
                                    {
                                        case 0:
                                            if (Key.Normal[keyIndex] > 0)
                                                EasyConsole.Write($"노멀 키 #{keyIndex + 1} 획득!");
                                            else
                                            {
                                                EasyConsole.Write($"NEW! 노멀 키 #{keyIndex + 1} 획득!");
                                                Key.Normal[keyIndex] = 1;
                                            }
                                            break;
                                        case 1:
                                            if (Key.Rare[keyIndex] > 0)
                                                EasyConsole.Write($"레어 키 #{keyIndex + 1} 획득!");
                                            else
                                            {
                                                EasyConsole.Write($"NEW! 레어 키 #{keyIndex + 1} 획득!");
                                                Key.Rare[keyIndex] = 1;
                                            }
                                            break;
                                        case 2:
                                            if (Key.Unique[keyIndex] > 0)
                                                EasyConsole.Write($"유니크 키 #{keyIndex + 1} 획득!");
                                            else
                                            {
                                                EasyConsole.Write($"NEW! 유니크 키 #{keyIndex + 1} 획득!");
                                                Key.Unique[keyIndex] = 1;
                                            }
                                            break;
                                    }
                                    Thread.Sleep(300);
                                }
                                else
                                {
                                    EasyConsole.SetColorAndWrite(12, "실패!");
                                    Thread.Sleep(100);
                                }
                            }
                            else
                            {
                                EasyConsole.SetColorAndWrite(12, "근징이 부족합니다.");
                                Thread.Sleep(700);
                            }
                            EasyConsole.Clear();
                            Character.Save(characterIndex);
                            break;
                        case ConsoleKey.D1:
                            EasyConsole.Clear();
                            keyBoxNum = 0;
                            break;
                        case ConsoleKey.D2:
                            EasyConsole.Clear();
                            keyBoxNum = 1;
                            break;
                        case ConsoleKey.D3:
                            EasyConsole.Clear();
                            keyBoxNum = 2;
                            break;
                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            break;
                    }
                    break;
                case Screens.GameInfo:
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            break;
                    }
                    break;
                case Screens.Option:
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            EasyConsole.Clear();
                            Option.AutoSave = 1 - Option.AutoSave;
                            break;
                        case ConsoleKey.D2:
                            EasyConsole.Clear();
                            Option.BarDisplay = 1 - Option.BarDisplay;
                            break;
                        case ConsoleKey.D3:
                            EasyConsole.Clear();
                            if (++Option.PerDisplay > 10)
                                Option.PerDisplay = 0;
                            break;
                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            Option.Save();
                            break;
                    }
                    break;
                case Screens.DetailStatus:
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            EasyConsole.Clear();
                            screen = Screens.Main;
                            break;
                    }
                    break;
            }
        }

        static void SkillDisplay()
        {
            EasyConsole.SetCursorAndColorAndWrite(0, 0, 12, "나가기 :: ESC");
            EasyConsole.SetCursorAndColorAndWrite(25, 0, 14, "액티브");
            EasyConsole.SetColorAndWrite(10, "패시브");
            EasyConsole.SetColorAndWrite(13, "버프");
            EasyConsole.SetColorAndWrite(11, "특수", true);

            Character.SkillBook.AllDisplay();
        }

        static void SpiritShop()
        {
            //Spirit.DisplayShop();
        }

        static void PsychokinesisShop()
        {
            Psychokinesis.DisplayShop();
        }

        static void KeyBox()
        {
            Key.DisplayShop(keyBoxNum, keyX, keyY);
        }

        static void OptionScreen()
        {
            EasyConsole.SetCursorAndColorAndWrite(0, 0, 12, "나가기 :: ESC");
            EasyConsole.SetCursorAndColorAndWrite(0, 2, 15, "1. 자동저장  ");
            if (Option.AutoSave > 0) EasyConsole.SetColorAndWrite(10, "ON");
            else EasyConsole.SetColorAndWrite(8, "OFF");
            EasyConsole.SetCursorAndColorAndWrite(0, 3, 15, "2. 막대기 표시  ");
            if (Option.BarDisplay > 0) EasyConsole.SetColorAndWrite(10, "ON");
            else EasyConsole.SetColorAndWrite(8, "OFF");
            EasyConsole.SetCursorAndColorAndWrite(0, 4, 15, "3. 소수자리 표시  ");
            EasyConsole.SetColorAndWrite(10, $"{Option.PerDisplay}");
        }

        static void HelpScreen()
        {
            Help.Show(Help.Index);
        }

        static void UpdateScreen()
        {
            Update.Show(Update.Index);
        }

        static void GameInfo()
        {
            EasyConsole.SetCursorAndColorAndWrite(0, 0, 12, "나가기 :: ESC");
            EasyConsole.SetCursorAndColorAndWrite(0, 1, 15, $"Version {currentVersion}");
            EasyConsole.SetCursorAndColorAndWrite(0, 3, 15, "개발자: Gaten");

            //EasyConsole.GTS(0, 5, 10, "이벤트1 :: 언제나 핫타임(경험치 2배)");
            EasyConsole.SetCursorAndColorAndWrite(0, 6, 10, "이벤트1 :: 매일 정확히 30분에만 경험치 2배");
        }

        static void DetailStatus()
        {
            double temp;

            EasyConsole.SetCursorAndColorAndWrite(0, 0, 12, "나가기 :: ESC");
            EasyConsole.SetCursorAndColorAndWrite(0, 1, 11, $"공격력 {Character.Effect.Power}");
            EasyConsole.SetCursorAndColorAndWrite(0, 2, 15, $"기본 {Character.Level}");
            EasyConsole.SetCursorAndColorAndWrite(0, 3, 15, $"근징 {Spirit.Effect.Power}");
            EasyConsole.SetCursorAndColorAndWrite(0, 4, 15, $"기본기 {Character.SkillBook.GetSkill("기본기").Level}");
            EasyConsole.SetCursorAndColorAndWrite(0, 5, 15, $"키 {Key.Effect.Power}");
            EasyConsole.SetCursorAndColorAndWrite(0, 6, 15, $"부스트 {Boost.Value / 100}");
            EasyConsole.SetCursorAndColorAndWrite(0, 7, 15, $"무공 {Mugong.Effect.Power}");
            EasyConsole.SetCursorAndColorAndWrite(0, 8, 15, $"염력 {Psychokinesis.Effect.Power}");
            if (Character.SkillBook.GetSkill("잠재력").Level >= 100) temp = 2.0;
            else temp = 1 + 0.01 * Character.SkillBook.GetSkill("잠재력").Level;
            EasyConsole.SetCursorAndColorAndWrite(0, 9, 14, $"잠재력 x{EasyConsole.DecimalNumber(temp)}");
            if (Character.SkillBook.GetSkill("기력방출").Level >= 50) temp = 2.0;
            else temp = 1 + 0.02 * Character.SkillBook.GetSkill("기력방출").Level;
            EasyConsole.SetCursorAndColorAndWrite(0, 10, 14, $"기력방출 x{EasyConsole.DecimalNumber(temp)}");
            temp = 1;
            if (Character.SkillBook.GetSkill("악마와의계약").On) temp = 1 + 0.8 * Character.SkillBook.GetSkill("악마와의계약").Level;
            EasyConsole.SetCursorAndColorAndWrite(0, 12, 14, $"악마와의계약 x{EasyConsole.DecimalNumber(temp)}");
            EasyConsole.SetCursorAndColorAndWrite(0, 13, 14, $"핫타임 x{EasyConsole.DecimalNumber(hotTimeBonus)}");

            EasyConsole.SetCursorAndColorAndWrite(0, 15, 11, $"크리율 {Character.Effect.CriticalRate}%");
            EasyConsole.SetCursorAndColorAndWrite(0, 16, 15, $"기본 5%");
            EasyConsole.SetCursorAndColorAndWrite(0, 17, 15, $"근징 {Spirit.Effect.CriticalRate}%");

            EasyConsole.SetCursorAndColorAndWrite(0, 19, 11, $"크리뎀 {Character.Effect.CriticalDamageMultiple}%");
            EasyConsole.SetCursorAndColorAndWrite(0, 20, 15, $"기본 50%");
            EasyConsole.SetCursorAndColorAndWrite(0, 21, 15, $"근징 {Spirit.Effect.CriticalDamageMultiple}%");
            EasyConsole.SetCursorAndColorAndWrite(0, 22, 15, $"키 {Key.Effect.CriticalDamageMultiple}%");
            EasyConsole.SetCursorAndColorAndWrite(0, 23, 15, $"크리티컬마인드 {Character.SkillBook.GetSkill("크리티컬마인드").Level * Character.SkillBook.GetSkill("크리티컬마인드").IncLevel}%"); // IncLevel -> IncPerDamage

            EasyConsole.SetCursorAndColorAndWrite(0, 25, 11, $"MP회복 {Character.Effect.MpRegen}");
            EasyConsole.SetCursorAndColorAndWrite(0, 26, 15, $"기본 {3 + Character.Level / 5}");
            EasyConsole.SetCursorAndColorAndWrite(0, 27, 15, $"근징 {Spirit.Effect.MpRegen}");
            temp = Key.Effect.MpRegen;
            if (Key.Value >= 100) temp += 25;
            if (Key.Value >= 200) temp += 75;
            EasyConsole.SetCursorAndColorAndWrite(0, 28, 15, $"키 {temp}");
            if (Boost.Value >= 200) temp = 5 * (Boost.Value / 5000);
            EasyConsole.SetCursorAndColorAndWrite(0, 29, 15, $"부스트 {temp}");
            EasyConsole.SetCursorAndColorAndWrite(0, 30, 15, $"무공 {Mugong.Effect.MpRegen}");
            EasyConsole.SetCursorAndColorAndWrite(0, 31, 15, $"염력 {Psychokinesis.Effect.MpRegen}");
            EasyConsole.SetCursorAndColorAndWrite(0, 32, 15, $"운기조식 {Character.SkillBook.GetSkill("운기조식").Level * 15}");
            temp = 0;
            if (Character.SkillBook.GetSkill("쇼타임").On) temp = 2 * Character.SkillBook.GetSkill("쇼타임").Level;
            EasyConsole.SetCursorAndColorAndWrite(0, 33, 15, $"쇼타임 {temp}");

            EasyConsole.SetCursorAndColorAndWrite(20, 1, 11, $"MP MAX {Character.Effect.MpMax}");
            EasyConsole.SetCursorAndColorAndWrite(20, 2, 15, $"기본 {Character.Level * 400}");
            EasyConsole.SetCursorAndColorAndWrite(20, 3, 15, $"근징 {Spirit.MpMax.Level * 600}");
            EasyConsole.SetCursorAndColorAndWrite(20, 4, 15, $"키 {Key.Effect.MpMax}");
            EasyConsole.SetCursorAndColorAndWrite(20, 5, 15, $"염력 {Psychokinesis.Effect.MpMax}");

            EasyConsole.SetCursorAndColorAndWrite(20, 7, 11, $"부스트파워 {Boost.Effect.BoostPower}");
            EasyConsole.SetCursorAndColorAndWrite(20, 8, 15, $"기본 {Character.Level / 25}");
            EasyConsole.SetCursorAndColorAndWrite(20, 9, 15, $"근징 {Spirit.Effect.BoostPower}");
            EasyConsole.SetCursorAndColorAndWrite(20, 10, 15, $"염력 {Psychokinesis.Effect.BoostPower}");

            EasyConsole.SetCursorAndColorAndWrite(20, 12, 11, $"부스트 MAX {Boost.Effect.BoostMax}");
            EasyConsole.SetCursorAndColorAndWrite(20, 13, 15, $"기본 {Character.Level * 100}");
            EasyConsole.SetCursorAndColorAndWrite(20, 14, 15, $"근징 {Spirit.Effect.BoostMax}");

            EasyConsole.SetCursorAndColorAndWrite(20, 16, 11, $"근징드롭량 {Spirit.Effect.SpiritDropSum}");
            EasyConsole.SetCursorAndColorAndWrite(20, 17, 15, $"기본 {1 + Character.Level / 25}");
            EasyConsole.SetCursorAndColorAndWrite(20, 18, 15, $"염력 {Psychokinesis.Effect.SpiritDrop}");
            EasyConsole.SetCursorAndColorAndWrite(20, 19, 14, $"운기조식 x{EasyConsole.DecimalNumber(1 + Character.SkillBook.GetSkill("운기조식").Level * 0.3)}");

            EasyConsole.SetCursorAndColorAndWrite(20, 21, 11, $"근징드롭율 {Spirit.DropRate}%");
            EasyConsole.SetCursorAndColorAndWrite(20, 22, 15, $"기본 20%");
            EasyConsole.SetCursorAndColorAndWrite(20, 23, 15, $"키 {Key.Effect.SpiritDropRate}%");

            EasyConsole.SetCursorAndColorAndWrite(20, 25, 11, $"염력드롭율 {Psychokinesis.Effect.PsychokinesisDropRate}%");
            EasyConsole.SetCursorAndColorAndWrite(20, 26, 15, $"기본 10%");
            EasyConsole.SetCursorAndColorAndWrite(20, 27, 15, $"부스트 {Boost.Value / 1000}%");

            EasyConsole.SetCursorAndColorAndWrite(20, 29, 11, $"무공획득량 증가 {Mugong.Effect.MugongDropMultiple}%");
            EasyConsole.SetCursorAndColorAndWrite(20, 30, 15, $"키 {Key.Effect.MugongDropMultiple}%");
            EasyConsole.SetCursorAndColorAndWrite(20, 31, 15, $"염력 {Psychokinesis.Effect.MugongDropMultiple}%");

            EasyConsole.SetCursorAndColorAndWrite(40, 1, 11, $"염력공격력 {Psychokinesis.Effect.PsychokinesisPower}");
            EasyConsole.SetCursorAndColorAndWrite(40, 2, 15, $"염력 {Psychokinesis.Level * Psychokinesis.Value}");

            EasyConsole.SetCursorAndColorAndWrite(40, 4, 11, $"스킬MP소모 감소 {Character.MpCostReduction}%");
            if (Character.SkillBook.GetSkill("기력방출").Level >= 30) temp = 30;
            else temp = Character.SkillBook.GetSkill("기력방출").Level;
            EasyConsole.SetCursorAndColorAndWrite(40, 5, 15, $"기력방출 {temp}%");
            temp = 0;
            if (Character.SkillBook.GetSkill("쇼타임").On)
            {
                if (Character.SkillBook.GetSkill("쇼타임").Level >= 30) temp = 30;
                else temp = Character.SkillBook.GetSkill("쇼타임").Level;
            }
            EasyConsole.SetCursorAndColorAndWrite(40, 6, 15, $"쇼타임 {temp}%");
        }

        public static void RegistText(int color, string text)
        {
            for (int i = 0; i < 15; i++)
            {
                if (NT[i] == 0)
                {
                    NT[i] = 1;
                    NTT[i] = 50;
                    NTTT[i] = text;
                    NTTTC[i] = color;
                    break;
                }
            }
        }

        public static void DisplayText()
        {
            int noticeX = 2;
            int noticeX2 = 22;
            int noticeX3 = 42;
            int noticeY = 30;

            for (int i = 0; i < 15; i++)
            {
                if (i < 5) EasyConsole.SetCursor(noticeX, noticeY + i);
                else if (i < 10) EasyConsole.SetCursor(noticeX2, noticeY + i - 5);
                else EasyConsole.SetCursor(noticeX3, noticeY + i - 10);
                EasyConsole.SetColor(NTTTC[i]);
                Console.WriteLine(NTTT[i]);
            }
        }

        public static long Exp(int level)
        {
            return (long)Math.Pow(level, (3.12 + 0.004 * level));
        }
    }
}
