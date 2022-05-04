using System;

namespace Gaten.Game.DeonpaRPG
{
    /* Character
             * -닉네임
             * -직업
             * -레벨
             * -전직
             * -퀘스트진행
             * -인무
             * -경험치
             * -골드
             * -HP
             * -MP
             * -데미지
             * -무기(총/갑옷/목걸이/아바타/팬던트/기타)
             * -능력의돌
             * -공격력/방어력/특방/HPMAX/MPMAX/공속/HP회복/MP회복/돈획/경획/sp획
             * -추가HP+/MP+/공+/방+/공속+
             */

    class State
    {
        public int current;
        public int max;

        public State(int current, int max)
        {
            this.current = current;
            this.max = max;
        }
    }

    class Character
    {
        public string nickname;
        public string profession;
        public int professionLevel;
        public int level;
        public Ability ability;
        public Ability additionalAbility;
        public int questProgress;
        public long requireEXP;
        public long exp;
        public long gold;
        public int sp;
        public SkillDB skilldb;
        public EquipObject gun;
        public EquipObject armor;
        public EquipObject necklace;
        public EquipObject avatar;
        public EquipObject pendant;
        public EquipObject others;
        public EquipObject abilityStone;
        public Skill remainSkill;
        public int remainAttackCount;

        private int BONUS = 0;

        private static Character instance = new Character();

        private Character()
        {
            skilldb = SkillDB.GetInstance();
        }

        public static Character GetInstance()
        {
            return instance;
        }

        public void Equip(EquipObject eo)
        {
            if (level >= eo.level)
            {
                switch (eo.type)
                {
                    case EquipObject.EquipObjectTypes.Gun:
                        gun = eo;
                        Console.WriteLine(">" + eo.name + "을 장착했습니다.");
                        break;
                    case EquipObject.EquipObjectTypes.Armor:
                        armor = eo;
                        Console.WriteLine(">" + eo.name + "을 장착했습니다.");
                        break;
                    case EquipObject.EquipObjectTypes.Necklace:
                        necklace = eo;
                        Console.WriteLine(">" + eo.name + "을 장착했습니다.");
                        break;
                    case EquipObject.EquipObjectTypes.Avatar:
                        avatar = eo;
                        Console.WriteLine(">" + eo.name + "을 장착했습니다.");
                        break;
                    case EquipObject.EquipObjectTypes.Pendant:
                        pendant = eo;
                        Console.WriteLine(">" + eo.name + "을 장착했습니다.");
                        break;
                    case EquipObject.EquipObjectTypes.Others:
                        others = eo;
                        Console.WriteLine(">" + eo.name + "을 장착했습니다.");
                        break;
                    case EquipObject.EquipObjectTypes.AbilityStone:
                        abilityStone = eo;
                        Console.WriteLine(">" + eo.name + "을 장착했습니다.");
                        break;
                    case EquipObject.EquipObjectTypes.Potion:
                        ability.hp.current += eo.effect.hpInstantRecovery;
                        if (ability.hp.current > ability.hp.max) ability.hp.current = ability.hp.max;
                        ability.mp.current += eo.effect.mpInstantRecovery;
                        if (ability.mp.current > ability.mp.max) ability.mp.current = ability.mp.max;
                        Console.WriteLine(">" + eo.name + "을 먹었습니다.");
                        break;
                }
            }
            else
            {
                Console.WriteLine(">레벨이 낮아서 장착할 수 없습니다.");
            }
        }

        public void Buy(EquipObject eo)
        {
            if (gold >= eo.price)
            {
                if (level >= eo.level)
                {
                    gold -= eo.price;
                    Equip(eo);
                    ability.CalculateCharacterAbility();
                }
                else
                {
                    Console.WriteLine(">레벨이 너무 낮습니다.");
                }
            }
            else
            {
                Console.WriteLine(">돈이 부족합니다.");
            }
        }

        public void Learn(Skill skill)
        {
            if (sp >= skill.sp)
            {
                if (level >= skill.level)
                {
                    if (skill.preSkillCheck(skilldb, skill))
                    {
                        if (skill.skillLevel < skill.masterLevel)
                        {
                            sp -= skill.sp;
                            skill.learnedLevel++;
                            ability.CalculateCharacterAbility();
                        }
                        else
                        {
                            Console.WriteLine(">이미 마스터 레벨입니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(">선행스킬이 부족합니다.");
                    }
                }
                else
                {
                    Console.WriteLine(">레벨이 너무 낮습니다.");
                }
            }
            else
            {
                Console.WriteLine(">스킬포인트가 부족합니다.");
            }
        }

        public bool Attack(Monster monster)
        {
            ability.hp.current += ability.hpRecovery;
            ability.CalculateDamage();
            monster.hpCur -= ability.damage;
            Console.WriteLine($">{monster.name} (평타) 피해: {ability.damage}");

            /* 몬스터가 죽음 */
            if (monster.hpCur <= 0)
            {
                monster.Dispose();
                ability.goldBonus += BONUS;
                ability.expBonus += BONUS;
                ability.spBonus += BONUS;
                int getGold = (int)(monster.gold * (1 + (float)ability.goldBonus / 100));
                int getExp = (int)(monster.exp * (1 + (float)ability.expBonus / 100));
                int getSp = (int)(monster.sp * (1 + (float)ability.spBonus / 100));
                gold += getGold;
                exp += getExp;
                sp += getSp;
                LevelUp();
                Console.WriteLine($">{monster.name}를 잡았습니다. 골드+ {getGold}, Exp+ {getExp}, Sp+ {getSp}");

                return false;
            }
            else
            {
                Random random = new Random();
                int specialDefenseOn = random.Next(2);
                int monsterDamage = monster.attack - ability.defense / 10 - ability.specialDefense / 10 * specialDefenseOn;
                /* 몬스터의 공격력이 캐릭터의 방어력보다 낮음 */
                if (monsterDamage < 0)
                {
                    monsterDamage = 0;
                }

                ability.hp.current -= monsterDamage;
                Console.WriteLine($">{nickname} 피해: {monsterDamage}");

                /* 캐릭터가 죽음 */
                if (ability.hp.current <= 0)
                {
                    ability.hp.current = (int)(ability.hp.max / 100.0f);
                    return false;
                }

                return true;
            }
        }

        public bool Attack(Monster monster, Skill skill)
        {
            ability.hp.current += ability.hpRecovery;
            if (skill.code == "aaa")
            {
                ability.CalculateDamage();
                monster.hpCur -= ability.damage;
            }
            else
            {
                if (remainAttackCount <= 0)
                {
                    ability.mp.current -= skill.mp;
                    remainSkill = skill;
                    remainAttackCount += skill.attackCount;
                }
                ability.CalculateDamage(skill);
                monster.hpCur -= ability.damage;
                remainAttackCount--;
            }

            Console.WriteLine($">{monster.name} 피해: ({skill.name}) {ability.damage}");

            /* 몬스터가 죽음 */
            if (monster.hpCur <= 0)
            {
                monster.Dispose();
                ability.goldBonus += BONUS;
                ability.expBonus += BONUS;
                ability.spBonus += BONUS;
                int getGold = (int)(monster.gold * (1 + (float)ability.goldBonus / 100));
                int getExp = (int)(monster.exp * (1 + (float)ability.expBonus / 100));
                int getSp = (int)(monster.sp * (1 + (float)ability.spBonus / 100));
                gold += getGold;
                exp += getExp;
                sp += getSp;
                LevelUp();
                Console.WriteLine($">{monster.name}를 잡았습니다. 골드+ {getGold}, Exp+ {getExp}, Sp+ {getSp}");

                return false;
            }
            else
            {
                Random random = new Random();
                int specialDefenseOn = random.Next(2);
                int monsterDamage = monster.attack - ability.defense / 10 - ability.specialDefense / 10 * specialDefenseOn;
                /* 몬스터의 공격력이 캐릭터의 방어력보다 낮음 */
                if (monsterDamage < 0)
                {
                    monsterDamage = 0;
                }

                ability.hp.current -= monsterDamage;
                Console.WriteLine($">{nickname} 피해: {monsterDamage}");

                /* 캐릭터가 죽음 */
                if (ability.hp.current <= 0)
                {
                    ability.hp.current = (int)(ability.hp.max / 100.0f);
                    return false;
                }

                return true;
            }
        }

        private void LevelUp()
        {
            if (exp >= requireEXP)
            {
                exp -= requireEXP;
                level++;
                requireEXP = ability.requireEXP[level];

                ability.CalculateCharacterAbility();
                ability.hp.current = ability.hp.max;
                ability.mp.current = ability.mp.max;
                Console.WriteLine(">레벨 업!");
            }
        }
    }
}
