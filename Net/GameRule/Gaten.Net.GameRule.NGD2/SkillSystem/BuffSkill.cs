namespace Gaten.Net.GameRule.NGD2.SkillSystem
{
    public class BuffSkill : Skill
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

        public BuffSkill(string name, string command, int wayType, int minLevel, int incLevel, int mp, int incMp, int perDamage, int incPerDamage)
        {
            Type = SkillType.Buff;

            Name = name;
            Command = command;
            WayType = wayType;
            MinLevel = minLevel;
            IncLevel = incLevel;
            Mp = mp;
            IncMp = incMp;
            PerDamage = perDamage;
            IncPerDamage = incPerDamage;
        }

        public string Activate()
        {
            if (Character.Level < MinLevel)
            {
                return "캐릭터 레벨이 너무 낮음";
            }

            if (Character.Mp < Mp + Level * IncMp)
            {
                return "MP가 부족함";
            }

            Character.Mp -= Mp + Level * IncMp;

            Timer = Level * 20;

            return string.Empty;
        }

        public void Message()
        {
            if (!On)
                return;

            //EasyConsole.SetCursorAndColorAndWrite(5, 18 + WayType, 13, $"[{Name}] 데미지 {(int)(Character.Nm * ((double)(PerDamage + Level * IncPerDamage) / 100))} ");
            EasyConsole.SetColorAndWrite(15, $"{Timer}");
        }

        public void Display()
        {
            if (Character.Level < MinLevel)
                return;

            if (Character.Level == MinLevel)
                EasyConsole.SetColorAndWrite(12, "NEW ");

            EasyConsole.SetColorAndWrite(13, $"{Name}({Command})Lv{MinLevel} / {Level} / 지속시간{Level * 2}초 / 데미지{PerDamage + Level * IncPerDamage}% / MP{Mp + Level * IncMp}", true);
        }
    }
}
