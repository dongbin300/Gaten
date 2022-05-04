using System;
using System.Collections.Generic;

namespace Gaten.Game.DeonpaRPG
{
    class Skill
    {
        public enum SkillTypes { Active, Passive, SkillBonus };
        public SkillTypes type;
        public string code;
        public string name;
        public int level; // 스킬 습득 필요 레벨
        public int sp;
        public int mp;
        public int masterLevel; // 스킬 마스터 레벨
        public int damage; // 데미지
        public int damageP; // 데미지%
        public int damageUp; // 데미지+
        public int attackCount; // 공격 수
        public string preSkill; // 선행스킬목록

        public int skillLevel; // 스킬 레벨
        public int learnedLevel; // SP로 배운 스킬 레벨
        public int bonusLevel; // 스킬, 아이템, 장비를 통한 보너스 스킬 레벨

        public Dictionary<string, int> effectDict = new Dictionary<string, int>();
        public Dictionary<string, int> preSkillDict = new Dictionary<string, int>();
        public Dictionary<string, int> skillBonusDict = new Dictionary<string, int>();
        public Ability passiveEffect = new Ability();

        public Skill()
        {

        }

        // 액티브 스킬
        public Skill(string code, string name, int level, int sp, int mp, string effect, string preSkill)
        {
            type = SkillTypes.Active;
            this.code = code;
            this.name = name;
            this.level = level;
            this.preSkill = preSkill;
            this.sp = sp;
            this.mp = mp;
            masterLevel = 999;

            effectDict = FormatString.ParseInt(effect);

            foreach (KeyValuePair<string, int> temp in effectDict)
            {
                switch (temp.Key)
                {
                    case "s": damage = temp.Value; break;
                    case "p": damageP = temp.Value; break;
                    case "c": attackCount = temp.Value; break;
                    case "+": damageUp = temp.Value; break;
                    case "l": masterLevel = temp.Value; break;
                }
            }
        }

        // 스킬 레벨+ 스킬
        public Skill(string code, string name, int level, string effect, string preSkill, int sp, int ml)
        {
            type = SkillTypes.SkillBonus;
            this.code = code;
            this.name = name;
            this.level = level;
            this.preSkill = preSkill;
            this.sp = sp;
            masterLevel = ml;

            effectDict = FormatString.ParseInt(effect);

            foreach (KeyValuePair<string, int> temp in effectDict)
            {
                skillBonusDict.Add(temp.Key, temp.Value);
            }
        }

        // 패시브 스킬
        public Skill(string code, string name, int level, int sp, string effect, string preSkill)
        {
            type = SkillTypes.Passive;
            this.code = code;
            this.name = name;
            this.level = level;
            this.preSkill = preSkill;
            this.sp = sp;
            masterLevel = 999;

            effectDict = FormatString.ParseInt(effect);

            foreach (KeyValuePair<string, int> temp in effectDict)
            {
                switch (temp.Key)
                {
                    case "a": passiveEffect.attack = temp.Value; break;
                    case "d": passiveEffect.defense = temp.Value; break;
                    case "c": passiveEffect.specialDefense = temp.Value; break;
                    case "t": passiveEffect.attackSpeed = temp.Value; break;
                    case "h": passiveEffect.hp.max = temp.Value; break;
                    case "m": passiveEffect.mp.max = temp.Value; break;
                    case "r": passiveEffect.hpRecovery = temp.Value; break;
                    case "v": passiveEffect.mpRecovery = temp.Value; break;
                    case "w": passiveEffect.inventoryWeight.max = temp.Value; break;
                    case "e": passiveEffect.expBonus = temp.Value; break;
                    case "g": passiveEffect.goldBonus = temp.Value; break;
                    case "s": passiveEffect.spBonus = temp.Value; break;
                    case "l": masterLevel = temp.Value; break;
                }
            }
        }

        public bool preSkillCheck(SkillDB skilldb, Skill skill)
        {
            preSkillDict = FormatString.ParseInt(preSkill);

            foreach (KeyValuePair<string, int> temp in preSkillDict)
            {
                if (skilldb.GetSkill(temp.Key).skillLevel < temp.Value)
                    return false;
            }
            return true;
        }

        public void ShowDescription()
        {
            SkillDB skilldb = SkillDB.GetInstance();

            Console.WriteLine($"==={name}===");
            Console.WriteLine($"-필요");
            Console.WriteLine($"캐릭터레벨 {level}");
            preSkillCheck(skilldb, this);
            if (preSkillDict.Count > 0)
                foreach (KeyValuePair<string, int> temp in preSkillDict)
                    Console.WriteLine($"{skilldb.GetSkill(temp.Key).name} Lv{temp.Value}");
            Console.WriteLine($"스킬레벨 {skillLevel}({learnedLevel}+{bonusLevel}) / {masterLevel}");
            Console.WriteLine($"MP {mp}");
            Console.WriteLine();
            if (damage != 0)
                Console.WriteLine($"공격력 {damage + damageUp * skillLevel} + {damageUp}");
            if (damageP != 0)
                Console.WriteLine($"공격력 {damageP + damageUp * skillLevel}% + {damageUp}%");
            if (attackCount != 0)
                Console.WriteLine($"공격회수 {attackCount}");
            if (type == SkillTypes.Passive)
            {
                foreach (KeyValuePair<string, int> temp in effectDict)
                {
                    switch (temp.Key)
                    {
                        case "a": Console.WriteLine($"(패시브)공격력 +{temp.Value * skillLevel} +{temp.Value}"); break;
                        case "t": Console.WriteLine($"(패시브)공격속도 +{temp.Value * skillLevel} +{temp.Value}"); break;
                        case "d": Console.WriteLine($"(패시브)방어력 +{temp.Value * skillLevel} +{temp.Value}"); break;
                        case "c": Console.WriteLine($"(패시브)특수방어력 +{temp.Value * skillLevel} +{temp.Value}"); break;
                        case "h": Console.WriteLine($"(패시브)HP +{temp.Value * skillLevel} +{temp.Value}"); break;
                        case "m": Console.WriteLine($"(패시브)MP +{temp.Value * skillLevel} +{temp.Value}"); break;
                        case "r": Console.WriteLine($"(패시브)HP회복 +{temp.Value * skillLevel} +{temp.Value}"); break;
                        case "v": Console.WriteLine($"(패시브)MP회복 +{temp.Value * skillLevel} +{temp.Value}"); break;
                        case "w": Console.WriteLine($"(패시브)인무 +{temp.Value * skillLevel} +{temp.Value}kg"); break;
                        case "e": Console.WriteLine($"(패시브)Exp +{temp.Value * skillLevel} +{temp.Value}%"); break;
                        case "g": Console.WriteLine($"(패시브)골드 +{temp.Value * skillLevel} +{temp.Value}%"); break;
                        case "s": Console.WriteLine($"(패시브)Sp획득 +{temp.Value * skillLevel} +{temp.Value}%"); break;
                    }
                }
            }
            if (type == SkillTypes.SkillBonus)
            {
                foreach (KeyValuePair<string, int> temp in skillBonusDict)
                {
                    Console.WriteLine($"{skilldb.GetSkill(temp.Key).name} Lv +{temp.Value}");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{sp}SP (현재SP {Character.GetInstance().sp})");
        }
    }

    class SkillDB
    {
        public Skill[] skills = new Skill[200];
        public int skillCount = 0;

        private static SkillDB instance = new SkillDB();

        private SkillDB()
        {
            //s:고정뎀 p:퍼뎀 c:공격회수 +:스킬레벨+ 증가치
            AddSkill("aaa", "평타", 0, 0, 0, "c1l1");
            AddSkill("aa", "라이징샷", 3, 20, 16, "p100+25c1");
            AddSkill("ab", "잭스파이크", 5, 20, 18, "p135+5c1");
            AddSkill("ac", "개틀링건 M-20", 5, 20, 23, "s85+8c10");
            AddSkill("ad", "퍼니셔", 7, 25, 21, "s92+17c5");
            AddSkill("ae", "윈드밀", 18, 20, 28, "s185+35c1");
            AddSkill("af", "화염방사기 F-70", 20, 25, 35, "s132+18c8");
            AddSkill("ag", "바베큐", 25, 30, 35, "s177+31c10", "ab5ac3");
            AddSkill("ah", "슈타이어", 30, 30, 36, "s1330+86c1");
            AddSkill("ai", "마하킥", 35, 30, 32, "s520+104c1");

            AddSkill("aj", "슈타이어 마스터", 40, "ac1af1ag1ah1ai1");
            AddSkill("ak", "핸드캐넌 마스터리", 48, 30, "t3l33");
            AddSkill("al", "레이저 라이플", 50, 35, 48, "s278+57c12");
            AddSkill("am", "라이징 윈드밀", 55, 30, 36, "s725+65c1");
            AddSkill("an", "하이퍼바디", 60, 35, "h5");
            AddSkill("ao", "라마건 M-17", 65, 40, 60, "s788+184c1");
            AddSkill("ap", "양자폭탄", 68, 50, 200, "s5576+370c1");
            AddSkill("aq", "스피드스타", 75, 65, 88, "s725+210c2");
            AddSkill("ar", "세블", 85, 70, 65, "s2060+205c5");
            AddSkill("as", "양자폭탄 2", 90, 60, 300, "s7400+400c1", "ap5");

            AddSkill("at", "라마건 M-18", 95, 70, 115, "s805+1425c1", "ah3ao10ap1aq1ar3");
            AddSkill("au", "레어 슈타이어", 100, 80, 120, "s1900+3660c1", "aa5ag3ah7ai3ar5at3");
            AddSkill("av", "중화기 다루기", 105, "ac2af2ag1ah1ak1al1ao3ar2at3au1");
            AddSkill("aw", "플리전트", 115, 100, 180, "s4438+3939c4", "ar10as5at10au5");
            AddSkill("ax", "헤드샷", 120, 100, 85, "s7258+11255c1");
            AddSkill("ay", "새크리파이스", 128, 100, 150, "s7258+11255c1");
            AddSkill("az", "중화기 다루기2", 130, "ap5ar7as4at8au5aw3ax3");
            AddSkill("ba", "라마건 M-19", 138, 120, 140, "s1686+2156c1", "ao100at50");
            AddSkill("bb", "스틸 바베큐", 145, 100, 180, "s2452+407c10");
            AddSkill("bc", "순간중화기", 153, "ac1af1ag1ah1al1ao1ap1as1at1au1ba1bb1", "", 5000, 100);

            AddSkill("bd", "레시피 갠틀 M-28", 158, 700, 160, "s8324+1338c10","ac100");
            AddSkill("be", "레일 L-1", 160, 500, 88, "s4575+765c1");
            AddSkill("bf", "레일 L-2", 178, 600, 98, "s12625+1825c1", "be10");
            AddSkill("bg", "레일 L-3", 188, 700, 128, "s22840+4200", "bf30");
            AddSkill("bh", "파스", 195, 2000, 30, "p200+200c1l20");
            AddSkill("bi", "중화기 스틸러스", 195, 1000, "m250");
            AddSkill("bj", "중화기 다루기3", 198, "ay20ba15bb20bc20bd3be4bf4bg3bh1bi2");
            AddSkill("bk", "라마건 M-20", 205, 500, 180, "s15000+10000c1");
            AddSkill("bl", "파워슬로우", 218, 5000, "e10l30");
            AddSkill("bm", "어밴져", 228, 100, 120, "s42766+6652c1");

            AddSkill("bn", "어썰터", 245, 1000, 250, "s60000+5500c2");
            AddSkill("bo", "블레스", 255, 1000, "a2000d2000c2000");
            AddSkill("bp", "홀리심볼", 268, 2000, "e1g1s1l200");
            AddSkill("bq", "중화기 다루기4", 288, "bd7be10bf8bg7bh2bi5bk10bl1bm5bn5bo5bp3");
            AddSkill("br", "충전 레이저 라이플", 308, 1000, 480, "s22800+12000c1", "bm10");
            AddSkill("bs", "새틀라이트 빔", 338, 2000, 850, "s200000+25000c5","bh5");
            AddSkill("bt", "중화기 서컴스탠스", 388, 5000, "a20000", "bs3");
            AddSkill("bu", "중화기 다루기5", 408, "bh3bli10bk20bl2bm10bn10bo10bp5br10bs5bt2");
            AddSkill("bv", "헌드레드", 425, 4000, "s5l50");
            /*
            AddSkill("bw", "레인져 마스터리", 448, 100, 85, "s7258+11255c1");
            AddSkill("bx", "할리우드", 458, 100, 85, "s7258+11255c1");
            AddSkill("by", "퓨전 크로스", 468, 100, 85, "s7258+11255c1");
            AddSkill("bz", "스틸슈타건 MSTZ-8753", 488, 100, 85, "s7258+11255c1");
            AddSkill("ca", "하이퍼바디2", 495, 100, 85, "s7258+11255c1");*/
        }

        public static SkillDB GetInstance()
        {
            return instance;
        }

        public void AddSkill(string code, string name, int level, int sp, int mp, string effect, string preSkill = "")
        {
            skills[skillCount++] = new Skill(code, name, level, sp, mp, effect, preSkill);
        }

        public void AddSkill(string code, string name, int level, string effect, string preSkill = "", int sp = 0, int ml = 1)
        {
            skills[skillCount++] = new Skill(code, name, level, effect, preSkill, sp, ml);
        }

        public void AddSkill(string code, string name, int level, int sp, string effect, string preSkill = "")
        {
            skills[skillCount++] = new Skill(code, name, level, sp, effect, preSkill);
        }

        public void Learn(string code)
        {
            GetSkill(code).level++;
        }

        public Skill GetSkill(string code)
        {
            for (int i = 0; i < skillCount; i++)
                if (code == skills[i].code)
                    return skills[i];
            return null;
        }
    }
}
