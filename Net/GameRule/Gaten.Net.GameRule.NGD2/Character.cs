using Gaten.Net.GameRule.NGD2.AbilitySystem;
using Gaten.Net.GameRule.NGD2.Format;
using Gaten.Net.GameRule.NGD2.SkillSystem;
using Gaten.Net.GameRule.NGD2.UISystem;

namespace Gaten.Net.GameRule.NGD2
{
    public class Character
    {
        // 테스트 전용
        static readonly int TEST_BONUS = 200; // 공격력, 근징, 무공, 염력

        static readonly List<string> characterFileNames = new List<string> { "stats1.txt", "stats2.txt", "stats3.txt" };

        public static int[] LastTime = new int[6];

        public static int Level; // 레벨
        public static long Xp; // 경험치
        public static int Mp; // 현재MP

        public static int CriticalStack = 0;
        public static int MpCostReduction = 0; // MP소모 감소, 1당 1%감소
        public static double HotTime = 1.0; // 핫타임(이벤트용)
        public static int HitCount = 0; // 히트카운트
        public static int ShowTimePunchTimer = 0; // 쇼타임 펀치 타이머

        public static Effect Effect { get; set; }

        public static SkillBook SkillBook = new SkillBook();

        public static long RequireXp => Exp(Level);
        public static double XpPercent => (double)Xp / RequireXp * 100;
        public static double MpPercent => (double)Mp / Effect.MpMax * 100;

        public Character()
        {

        }

        public static void Init()
        {

        }

        public static void Save(int index)
        {
        }

        public static void Load(int index)
        {
        }

        public static List<int> TempLoad()
        {
            return null;
        }

        public static long Exp(int level)
        {
            return (long)Math.Pow(level, 3.12 + (0.004 * level));
        }

        public static void Calculate()
        {
            /* 기본값 */
            Effect = new Effect();
            Effect.Power = Level;
            Effect.AttackSpeed = 0;
            Effect.CriticalRate = 10;
            Effect.CriticalDamageMultiple = 50;
            Effect.MpMax = 1000 + Level * 5;
            Effect.MpRegen = 10;
            Effect.SpiritDrop = 1;
            Effect.SpiritDropRate = 500;
            Effect.SkillCardDropRate = 25;
            //Effect.PsychokinesisDropRate = 1;

            Effect += Spirit.Effect;
            //Effect += SkillBook.Effect;
            //Effect += Key.Effect;
            //Effect += Boost.Effect;
            //Effect += Mugong.Effect;
            //Effect += Psychokinesis.Effect;

            //Effect.Power *= (int)HotTime;
            //Effect.Power *= (int)TEST_BONUS;

        }

        public static void Attack()
        {
            Random r = new Random();

            ///* 크리티컬 (추후수정) */
            //if (r.Next(100) < Effect.CriticalRate)
            //{
            //    CriticalStack++;
            //    Dm += (long)(Nm * (double)Effect.CriticalDamageMultiple / 100);
            //    Program.RegistText(12, "크리티컬!");
            //}

            ///* 파워 크리티컬 발동 (추후수정) */
            //var pcs = SkillBook.GetSkill("파워크리티컬") as PassiveSkill;
            //if (pcs.Level > 0 && CriticalStack >= 10)
            //{
            //    CriticalStack -= 10;
            //    Dm += Nm * (pcs.PerDamage + pcs.Level * pcs.IncPerDamage) / 100;
            //    Program.RegistText(12, "파워 크리티컬!!");
            //}

            

            /* 염력 드롭 - 부스트 게이지 2500 소모, 근징 100개 소모*/
            //Psychokinesis.CheckDrop();

            /* 공격력에 의한 경험치 증가 */
            if(r.Next(10000) < Effect.CriticalRateIM * 100) // 크리티컬
            {
                Xp += IMConverter.GetMultipleValue(Effect.PowerSum, Effect.CriticalDamageMultiple);
            }
            else // 일반공격
            {
                Xp += Effect.PowerSum;
            }
            

            /* 레벨업 체크 */
            if (Xp >= Exp(Level))
            {
                Xp -= Exp(Level);
                Level++;
                Mp = Effect.MpMax;
                
                LogQueue.Set($"캐릭터 Lv {Level - 1} -> Lv {Level}");
                if(Level == Spirit.RequireLevel)
                {
                    LogQueue.Set("근성의징표 컨텐츠 해금!");
                }
                if (Level == Key.RequireLevel)
                {
                    LogQueue.Set("키 컨텐츠 해금!");
                }
                if (Level == Mugong.RequireLevel)
                {
                    LogQueue.Set("무공 컨텐츠 해금!");
                }
                if (Level == Psychokinesis.RequireLevel)
                {
                    LogQueue.Set("염력 컨텐츠 해금!");
                }
            }

            /* 마나 리젠 */
            Mp = Math.Min(Mp + Effect.MpRegen, Effect.MpMax);

            /* 근징 드롭 */
            Spirit.CheckDrop();
        }
    }
}
