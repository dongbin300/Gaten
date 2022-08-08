using Gaten.Net.GameRule.NGD2.AbilitySystem;

namespace Gaten.Net.GameRule.NGD2.SkillSystem
{
    public class SpecialSkill : Skill
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

        public SpecialSkill(string name, string command, int wayType, int minLevel, int incLevel, int mp, int incMp)
        {
            Type = SkillType.Special;

            Name = name;
            Command = command;
            WayType = wayType;
            MinLevel = minLevel;
            IncLevel = incLevel;
            Mp = mp;
            IncMp = incMp;
        }

        public string Activate()
        {
            if (Character.Level < MinLevel)
            {
                return "캐릭터 레벨이 너무 낮음";
            }

            switch (WayType)
            {
                case 8: // 쇼타임
                    if (Character.Mp < Mp + Level * IncMp && Character.Xp >= 60000 * Level)
                    {
                        return "MP가 부족함";
                    }

                    Character.Mp -= Mp + Level * IncMp;
                    Character.Xp -= 60000 * Level;

                    Timer = Level * 50;

                    On = true;

                    break;

                case 9: // 악계
                    if (Character.Xp < (long)(System.Math.Pow(Level, 4.0) * 10000))
                    {
                        return "XP가 부족함";
                    }

                    if (Psychokinesis.Value < Level)
                    {
                        return "염력이 부족함";
                    }

                    Character.Xp -= (long)(System.Math.Pow(Level, 4.0) * 10000);
                    Psychokinesis.Value -= Level;

                    Timer = Level * 150;

                    On = true;

                    break;
            }

            return string.Empty;
        }

        public void Message()
        {
            if (!On)
                return;

            switch (WayType)
            {
                case 8:
                    EasyConsole.SetCursorAndColorAndWrite(5, 18 + WayType, 11, $"[{Name}] 지속시간 {Level * 5}초 ");
                    EasyConsole.SetColorAndWrite(15, $"{Timer}");
                    break;

                case 9:
                    EasyConsole.SetCursorAndColorAndWrite(5, 18 + WayType, 11, $"[{Name}] 지속시간 {Level * 15}초 ");
                    EasyConsole.SetColorAndWrite(15, $"{Timer}");
                    break;
            }
        }

        public void Display()
        {
            if (Character.Level < MinLevel)
                return;

            if (Character.Level == MinLevel)
                EasyConsole.SetColorAndWrite(12, "NEW ");

            switch (WayType)
            {
                case 8:
                    EasyConsole.SetColorAndWrite(11, $"쇼타임(qw)Lv100 / {Level} / 지속시간{Level * 5}초 / 공격력+{Level * 5} / MP회복{Level * 3} / 부스트파워리젠량{Level} / 액티브스킬MP소모 -{Level}% / 시전시EXP감소{Level * 60000} / MP%{Level * IncMp}");
                    EasyConsole.SetColorAndWrite(12, "(액티브스킬MP소모 MAX: 30％)", true);
                    break;
                case 9:
                    EasyConsole.SetColorAndWrite(11, $"악마와의계약(qe)Lv145 / {Level} / 지속시간{Level * 15}초 / Exp감소량{System.Math.Pow(Level, 4.0) * 10000} / Exp획득량+{Level * 80}% / 시전시염력감소{Level}");
                    break;
            }
        }
    }
}
