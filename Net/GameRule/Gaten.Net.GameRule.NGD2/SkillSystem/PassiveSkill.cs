using Gaten.Net.GameRule.NGD2.AbilitySystem;

namespace Gaten.Net.GameRule.NGD2.SkillSystem
{
    /// <summary>
    /// 패시브 스킬
    /// </summary>
    public class PassiveSkill : Skill
    {
        /// <summary>
        /// 방식 타입(스킬 번호 타입)
        /// </summary>
        public int WayType { get; set; }

        /// <summary>
        /// 데미지(%)
        /// </summary>
        public int PerDamage { get; set; }

        /// <summary>
        /// 데미지(%)+
        /// </summary>
        public int IncPerDamage { get; set; }

        public PassiveSkill(string name, int wayType, int minLevel, int incLevel, int perDamage, int incPerDamage)
        {
            Type = SkillType.Passive;

            Name = name;
            WayType = wayType;
            MinLevel = minLevel;
            IncLevel = incLevel;
            PerDamage = perDamage;
            IncPerDamage = incPerDamage;
        }

        public string Activate()
        {
            if (Character.Level < MinLevel)
            {
                return "캐릭터 레벨이 너무 낮음";
            }

            switch (WayType)
            {
                case 7: // 보너스
                    Random r = new Random();
                    bool atari = false;

                    switch (Name)
                    {
                        case "보너스펀치":
                            if (Level >= 20 && Level < 55 && r.Next(100) < 10)
                            {
                                atari = true;
                            }
                            else
                            {
                                return "꽝";
                            }
                            break;

                        case "보너스킥":
                            if (Level >= 55 && Level < 90 && r.Next(100) < 11)
                            {
                                atari = true;
                            }
                            else
                            {
                                return "꽝";
                            }
                            break;

                        case "보너스어퍼":
                            if (Level >= 90 && Level < 155 && r.Next(100) < 12)
                            {
                                atari = true;
                            }
                            else
                            {
                                return "꽝";
                            }
                            break;

                        case "보너스슬래쉬":
                            if (Level >= 155 && Level < 215 && r.Next(100) < 13)
                            {
                                atari = true;
                            }
                            else
                            {
                                return "꽝";
                            }
                            break;

                        case "보너스스트라이크":
                            if (Level >= 215 && r.Next(100) < 14)
                            {
                                atari = true;
                            }
                            else
                            {
                                return "꽝";
                            }
                            break;

                    }

                    if (atari)
                    {
                        //Character.Xp += (long)(Character.Nm * ((PerDamage + Level * IncPerDamage) / (double)100));

                        // 무공
                        if (Level >= 70)
                        {
                            Mugong.Value += (1 + (double)Mugong.Drop / 100) * (PerDamage + Level * IncPerDamage) / 100 / 50000;
                        }

                        Timer = 30;
                    }

                    break;

                case 100: // MP회복
                    if (Name == "극MP회복" || Name == "슈퍼MP회복" || Name == "울트라MP회복")
                        Character.Mp += PerDamage + Level * IncPerDamage;

                    break;
            }

            return string.Empty;
        }

        public void Message()
        {
            if (!On)
                return;

            EasyConsole.SetCursorAndColorAndWrite(5, 18 + WayType, 10, $"[{Name}] 데미지 {(int)(Character.Effect.PowerSum * ((double)(PerDamage + Level * IncPerDamage) / 100))} ");

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

            EasyConsole.SetColorAndWrite(10, $"{Name}Lv{MinLevel} / {Level} / 데미지{PerDamage + Level * IncPerDamage}%", true);
        }

        public void Display(string str, int color = 10)
        {
            if (Character.Level < MinLevel)
                return;

            if (Character.Level == MinLevel)
                EasyConsole.SetColorAndWrite(12, "NEW ");

            EasyConsole.SetColorAndWrite(color, $"{Name}Lv{MinLevel} / {Level} / ");
            EasyConsole.SetColorAndWrite(color, str, true);
        }

        public void Display(string str1, string str2, int color1 = 10, int color2 = 12)
        {
            if (Character.Level < MinLevel)
                return;

            if (Character.Level == MinLevel)
                EasyConsole.SetColorAndWrite(12, "NEW ");

            EasyConsole.SetColorAndWrite(color1, $"{Name}Lv{MinLevel} / {Level} / ");
            EasyConsole.SetColorAndWrite(color1, str1);
            EasyConsole.SetColorAndWrite(color2, str2, true);
        }
    }
}