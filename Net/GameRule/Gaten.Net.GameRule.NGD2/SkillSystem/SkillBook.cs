using System.Text;

namespace Gaten.Net.GameRule.NGD2.SkillSystem
{
    /// <summary>
    /// 스킬 북
    /// 최초 생성 시 자동으로 스킬 목록을 불러옴
    /// </summary>
    public class SkillBook : IStream
    {
        string fileName = "skill_data.dat";

        public List<Skill> Skills { get; set; }
        public List<ActiveSkill> ActiveSkills => Skills.Where(s => s.Type == SkillType.Active).Cast<ActiveSkill>().ToList();
        public List<PassiveSkill> PassiveSkills => Skills.Where(s => s.Type == SkillType.Passive).Cast<PassiveSkill>().ToList();
        public List<BuffSkill> BuffSkills => Skills.Where(s => s.Type == SkillType.Buff).Cast<BuffSkill>().ToList();
        public List<SpecialSkill> SpecialSkills => Skills.Where(s => s.Type == SkillType.Special).Cast<SpecialSkill>().ToList();

        /// <summary>
        /// 패시브&버프로 인한 효과
        /// </summary>
        public Effect Effect => GetEffect();

        /// <summary>
        /// 켜져있는 스킬 개수
        /// </summary>
        public int OnSkillCount => Skills.Count(s => s.On);

        public SkillBook()
        {
            Skills = new List<Skill>();
            Load();
        }

        public Skill GetSkill(string name)
        {
            return Skills.Find(s => s.Name.Equals(name));
        }

        Effect GetEffect()
        {
            Effect effect = new Effect();

            // 패시브
            var s = GetSkill("기본기") as PassiveSkill;
            effect.Power += s.Level;
            s = GetSkill("잠재력") as PassiveSkill;
            effect.PowerMultiple += Math.Min(s.Level, 100);
            s = GetSkill("극MP회복") as PassiveSkill;
            effect.AttackMpRegen += s.PerDamage + s.Level * s.IncPerDamage;
            s = GetSkill("콤보어택") as PassiveSkill;
            effect.PowerMultiple += Math.Min(s.PerDamage + s.Level * s.IncPerDamage, 25) * OnSkillCount;
            s = GetSkill("운기조식") as PassiveSkill;
            effect.SpiritDropMultiple += s.Level * 30;
            effect.MpRegen += s.Level * 15;
            s = GetSkill("슈퍼MP회복") as PassiveSkill;
            effect.AttackMpRegen += s.PerDamage + s.Level * s.IncPerDamage;
            s = GetSkill("기력방출") as PassiveSkill;
            effect.PowerMultiple += Math.Min(s.Level * 2, 100);
            effect.MpReductionMultiple += Math.Min(s.Level, 30);
            s = GetSkill("파워크리티컬") as PassiveSkill;
            effect.PowerCriticalDamageMultiple += s.PerDamage + s.Level * s.IncPerDamage;
            s = GetSkill("크리티컬마인드") as PassiveSkill;
            effect.CriticalDamageMultiple += s.PerDamage + s.Level * s.IncPerDamage;
            s = GetSkill("스피릿찬스") as PassiveSkill;
            effect.CriticalSpiritDrop += s.Level * 2;
            s = GetSkill("울트라MP회복") as PassiveSkill;
            effect.AttackMpRegen += s.PerDamage + s.Level * s.IncPerDamage;
            

            // 버프
            var bs = GetSkill("패스트푸쉬업") as BuffSkill;
            if (bs.On)
            {
                effect.PowerMultiple += bs.PerDamage + bs.Level * bs.IncPerDamage;
            }
            bs = GetSkill("패스트푸쉬스트레이트") as BuffSkill;
            if (bs.On)
            {
                effect.PowerMultiple += bs.PerDamage + bs.Level * bs.IncPerDamage;
            }
            bs = GetSkill("패스트푸쉬라이트") as BuffSkill;
            if (bs.On)
            {
                effect.PowerMultiple += bs.PerDamage + bs.Level * bs.IncPerDamage;
            }
            bs = GetSkill("패스트푸쉬레프트") as BuffSkill;
            if (bs.On)
            {
                effect.PowerMultiple += bs.PerDamage + bs.Level * bs.IncPerDamage;
            }

            // 스페셜 버프
            var ss = GetSkill("휴식") as SpecialSkill;
            effect.RestXp += s.Level * 65;

            ss = GetSkill("쇼타임") as SpecialSkill;
            if (ss.On)
            {
                effect.Power += ss.Level * 5;
                effect.MpRegen += ss.Level * 3;
                effect.MpReductionMultiple += Math.Min(ss.Level, 30);
            }
            ss = GetSkill("악마와의계약") as SpecialSkill;
            if (ss.On)
            {
                effect.PowerMultiple += 100 + 80 * ss.Level;
            }
            return effect;
        }

        public void Load()
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(fileName), Encoding.UTF8))
            {
                for (int i = 0; sr.Peek() >= 0; i++)
                {
                    string[] data = sr.ReadLine().Split(' ');

                    var name = data[0];
                    var command = data[1];
                    var type = (SkillType)int.Parse(data[2]);
                    var wayType = int.Parse(data[3]);
                    var minLevel = int.Parse(data[4]);
                    var incLevel = int.Parse(data[5]);
                    var mp = int.Parse(data[6]);
                    var incMp = int.Parse(data[7]);
                    var perDamage = int.Parse(data[8]);
                    var incPerDamage = int.Parse(data[9]);
                    var fixDamage = int.Parse(data[10]);
                    var incFixDamage = int.Parse(data[11]);

                    switch (type)
                    {
                        case SkillType.Active:
                            Skills.Add(new ActiveSkill(name, command, wayType, minLevel, incLevel, mp, incMp, perDamage, incPerDamage, fixDamage, incFixDamage));
                                break;

                        case SkillType.Passive:
                            Skills.Add(new PassiveSkill(name, wayType, minLevel, incLevel, perDamage, incPerDamage));
                            break;

                        case SkillType.Buff:
                            Skills.Add(new BuffSkill(name, command, wayType, minLevel, incLevel, mp, incMp, perDamage, incPerDamage));
                            break;

                        case SkillType.Special:
                            Skills.Add(new SpecialSkill(name, command, wayType, minLevel, incLevel, mp, incMp));
                            break;
                    }
                }
            }

            // 쇼타임 펀치 추가해야함
            //Skills.Add(new Skill());
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public string Activate(string skillName)
        {
            Skill skill = GetSkill(skillName);
            return Activate(skill);
        }

        public string Activate(Skill skill)
        {
            string result = string.Empty;

            switch (skill.Type)
            {
                case SkillType.Active:
                    var activeSkill = skill as ActiveSkill;

                    result = activeSkill.Activate();
                    if (result != string.Empty)
                        return result;

                    // 같은 계열의 스킬은 중복 적용 불가능(하나만 발동 가능)
                    var sameWayTypeActiveSkills = ActiveSkills.Where(s => s.WayType.Equals(activeSkill.WayType)).ToList();
                    foreach (ActiveSkill sk in sameWayTypeActiveSkills)
                    {
                        sk.On = false;
                    }
                    skill.On = true;
                    break;

                case SkillType.Passive:
                    var passiveSkill = skill as PassiveSkill;

                    result = passiveSkill.Activate();
                    if (result != string.Empty)
                        return result;

                    // 같은 계열의 스킬은 중복 적용 불가능(하나만 발동 가능)
                    var sameWayTypePassiveSkills = PassiveSkills.Where(s => s.WayType.Equals(passiveSkill.WayType)).ToList();
                    foreach (PassiveSkill sk in sameWayTypePassiveSkills)
                    {
                        sk.On = false;
                    }
                    skill.On = true;
                    break;

                case SkillType.Buff:
                    var buffSkill = skill as BuffSkill;

                    result = buffSkill.Activate();
                    if (result != string.Empty)
                        return result;

                    // 같은 계열의 스킬은 중복 적용 불가능(하나만 발동 가능)
                    var sameWayTypeBuffSkills = BuffSkills.Where(s => s.WayType.Equals(buffSkill.WayType)).ToList();
                    foreach (BuffSkill sk in sameWayTypeBuffSkills)
                    {
                        sk.On = false;
                    }
                    skill.On = true;
                    break;

                case SkillType.Special:
                    var specialSkill = skill as SpecialSkill;

                    result = specialSkill.Activate();
                    if (result != string.Empty)
                        return result;
                    break;
            }

            return string.Empty;
        }

        public void Message(Skill skill)
        {
            switch (skill.Type)
            {
                case SkillType.Active:
                    var activeSkill = skill as ActiveSkill;
                    activeSkill.Message();
                    break;

                case SkillType.Passive:
                    var passiveSkill = skill as PassiveSkill;
                    passiveSkill.Message();
                    break;

                case SkillType.Buff:
                    var buffSkill = skill as BuffSkill;
                    buffSkill.Message();
                    break;

                case SkillType.Special:
                    var specialSkill = skill as SpecialSkill;
                    specialSkill.Message();
                    break;
            }
        }

        public void Display(Skill skill)
        {
            switch (skill.Type)
            {
                case SkillType.Active:
                    var activeSkill = skill as ActiveSkill;
                    activeSkill.Display();
                    break;

                case SkillType.Passive:
                    var passiveSkill = skill as PassiveSkill;

                    switch (passiveSkill.Name)
                    {
                        case "기본기":
                            passiveSkill.Display("공격력+{passiveSkill.Level}");
                            break;

                        case "잠재력":
                            passiveSkill.Display("공격력+{passiveSkill.Level}% ", "(MAX: 100 %)");
                            break;

                        case "극MP회복":
                            passiveSkill.Display("공격시MP회복{passiveSkill.PerDamage + passiveSkill.Level * passiveSkill.IncPerDamage}");
                            break;

                        case "콤보어택":
                            passiveSkill.Display("발동스킬1개당 공격력+{passiveSkill.PerDamage + passiveSkill.Level * passiveSkill.IncPerDamage}%", "(MAX: 25%)");
                            break;

                        case "운기조식":
                            passiveSkill.Display("근성의징표 드롭량+{passiveSkill.Level * 30}% / MP회복{passiveSkill.Level * 15}");
                            break;

                        case "슈퍼MP회복":
                            passiveSkill.Display("공격시MP회복{passiveSkill.PerDamage + passiveSkill.Level * passiveSkill.IncPerDamage}");
                            break;

                        case "기력방출":
                            passiveSkill.Display("공격력+{passiveSkill.Level * 2}% / 액티브스킬MP소모 -{passiveSkill.Level}%", "(공격력 MAX: 100% / 액티브스킬MP소모 MAX: 30%)");
                            break;

                        case "파워크리티컬":
                            passiveSkill.Display("10번째 크리티컬 데미지{passiveSkill.PerDamage + passiveSkill.Level * passiveSkill.IncPerDamage}%");
                            break;

                        case "크리티컬마인드":
                            passiveSkill.Display("크리티컬데미지+{passiveSkill.PerDamage + passiveSkill.Level * passiveSkill.IncPerDamage}%");
                            break;

                        case "스피릿찬스":
                            passiveSkill.Display("크리티컬시 근징드롭 {passiveSkill.Level * 2}");
                            break;

                        case "울트라MP회복":
                            passiveSkill.Display("공격시MP회복{passiveSkill.PerDamage + passiveSkill.Level * passiveSkill.IncPerDamage}");
                            break;

                        case "휴식":
                            passiveSkill.Display("휴식경험치 {passiveSkill.Level * 65}");
                            break;

                        default:
                            passiveSkill.Display();
                            break;
                    }

                    break;

                case SkillType.Buff:
                    var buffSkill = skill as BuffSkill;
                    buffSkill.Display();
                    break;

                case SkillType.Special:
                    var specialSkill = skill as SpecialSkill;
                    specialSkill.Display();
                    break;
            }
        }

        public void AllDisplay()
        {
            foreach(Skill skill in Skills)
            {
                Display(skill);
            }
        }
    }
}
