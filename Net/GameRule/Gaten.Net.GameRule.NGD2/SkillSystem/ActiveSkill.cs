using Gaten.Net.GameRule.NGD2.AbilitySystem;

namespace Gaten.Net.GameRule.NGD2.SkillSystem
{
    /// <summary>
    /// 액티브 스킬
    /// </summary>
    public class ActiveSkill : Skill
    {
        /// <summary>
        /// 커맨드
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// 방식 타입(스킬 번호 타입)
        /// </summary>
        public int WayType { get; set; }

        /// <summary>
        /// 소모 MP
        /// </summary>
        public int Mp { get; set; }

        /// <summary>
        /// 소모 MP+
        /// </summary>
        public int IncMp { get; set; }

        /// <summary>
        /// 데미지(%)
        /// </summary>
        public int PerDamage { get; set; }

        /// <summary>
        /// 데미지(%)+
        /// </summary>
        public int IncPerDamage { get; set; }

        /// <summary>
        /// 고정데미지
        /// </summary>
        public int FixDamage { get; set; }

        /// <summary>
        /// 고정데미지+
        /// </summary>
        public int IncFixDamage { get; set; }


        public ActiveSkill(string name, string command, int wayType, int minLevel, int incLevel, int mp, int incMp, int perDamage, int incPerDamage, int fixDamage, int incFixDamage)
        {
            Type = SkillType.Active;

            Name = name;
            Command = command;
            WayType = wayType;
            MinLevel = minLevel;
            IncLevel = incLevel;
            Mp = mp;
            IncMp = incMp;
            PerDamage = perDamage;
            IncPerDamage = incPerDamage;
            FixDamage = fixDamage;
            IncFixDamage = incFixDamage;
        }

        public string Activate()
        {
            if(Character.Level < MinLevel)
            {
                return "캐릭터 레벨이 너무 낮음";
            }

            if (Character.Mp < (int)((Mp + Level * IncMp) * (1 - (double)Character.MpCostReduction / 100)))
            {
                return "MP가 부족함";
            }

            // 스킬 발동
            Character.Mp -= (int)((Mp + Level * IncMp) * (1 - (double)Character.MpCostReduction / 100));
            Character.Xp += (long)(Character.Effect.PowerSum * (double)(PerDamage + Level * IncPerDamage) / 100);
            Character.Xp += FixDamage + Level * IncFixDamage;

            // 무공
            if (Character.Level >= 70)
            {
                Mugong.Value += (1 + Mugong.Drop / 100) * (PerDamage + Level * IncPerDamage) / 100 / 50000;
            }

            Timer = 30;

            return string.Empty;
        }

        public void Message()
        {
            if (!On)
                return;

            //EasyConsole.SetCursorAndColorAndWrite(5, 18 + WayType, 14, $"[{Name}] 데미지 {(int)(Character.Nm * ((double)(PerDamage + Level * IncPerDamage) / 100))} ");

            // 더클, 파클만 퍼뎀+고뎀, 나머지 퍼뎀
            if (Name == "더블클러치" || Name == "파워풀클러치")
            {
                EasyConsole.Write($"+{FixDamage + Level * IncFixDamage} ");
            }

            if (Character.Level >= 70)
            {
                EasyConsole.SetColorAndWrite(11, $"무공 +{string.Format("{0:0.0000}", (1 + (double)Key.Effect.MugongDropMultiple / 100) * (1 + (double)Psychokinesis.Effect.MugongDropMultiple / 100) * (PerDamage + Level * IncPerDamage) / 100 / 50000)}");
            }
        }

        public void Display()
        {
            if (Character.Level < MinLevel)
                return;

            if (Character.Level == MinLevel)
                EasyConsole.SetColorAndWrite(12, "NEW ");

            if (Name == "더블클러치" || Name == "트리플클러치")
            {
                EasyConsole.SetColorAndWrite(14, $"{Name}({Command})Lv{MinLevel} / {Level} / 데미지{PerDamage + Level * IncPerDamage}%+{FixDamage + Level * IncFixDamage} / MP{(int)((Mp + Level * IncMp) * (1 - (double)Character.MpCostReduction / 100))}");
            }
            else
            {
                EasyConsole.SetColorAndWrite(14, $"{Name}({Command})Lv{MinLevel} / {Level} / 데미지{PerDamage + Level * IncPerDamage}% / MP{(int)((Mp + Level * IncMp) * (1 - (double)Character.MpCostReduction / 100))}");
            }
            EasyConsole.SetColorAndWrite(10, $"({Mp + Level * IncMp}-{(Mp + Level * IncMp) - (int)((Mp + Level * IncMp) * (1 - (double)Character.MpCostReduction / 100))})", true);
        }
    }
}
