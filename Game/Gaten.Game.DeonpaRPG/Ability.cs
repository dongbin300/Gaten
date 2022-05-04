using System;
using System.Collections.Generic;

namespace Gaten.Game.DeonpaRPG
{
    class Ability
    {
        #region 필요 경험치
        public long[] requireEXP = { 0, 200, 500, 700, 850, 1200, 1350, 1680, 2150, 2380, 2670, 3060, 3500, 3690, 4200, 4540, 4910, 5500, 6000, 6250, 6600, 6880, 7250, 8080, 8260, 8890, 9600, 10500, 12000, 13850, 14320, 14860, 16280, 18000, 20500, 20880, 22860, 23540, 26840, 35000, 38840, 43840, 52170, 58500, 62000, 68460, 70520, 75360, 80580, 85000, 90050, 92880, 96540, 101780, 106240, 115380, 120600, 131800, 134720, 136850, 140450, 142830, 146540, 160260, 175850, 192760, 198540, 205000, 217080, 238440, 252470, 278320, 304000, 325000, 352000, 387250, 405830, 428540, 452750, 484680, 514320, 538720, 565440, 588820, 607730, 625890, 648790, 682770, 705270, 723850, 728500, 765420, 785430, 824320, 858450, 897650, 940000, 987200, 1010720, 1038550, 1085200, 1098880, 1107250, 1135000, 1284000, 1285720, 1286880, 1295420, 1308330, 1315000, 1330000, 1345000, 1360000, 1378200, 1390800, 1400000, 1425000, 1455000, 1480000, 1520000, 1538000, 1562000, 1600000, 1685000, 1738000, 1807000, 1888000, 1971000, 2074000, 2206000, 2349000, 2529000, 2684000, 2821000, 3000000, 3200000, 3425000, 3656000, 3867000, 3958000, 4259000, 4600000, 4952000, 5101000, 5323000, 5564000, 5785000, 5924000, 6253000, 6507000, 6841000, 7125000, 7400000, 7685000, 8000000, 8356000, 8652000, 8981000, 9255000, 9564000, 9827000, 10127000, 10268000, 10546000, 11126000, 11837000, 12642000, 13527000, 15001000, 16802000, 19254000, 21689000, 23889000, 26509000, 30172000, 33652000, 36832000, 40150000, 45000000, 48250000, 51750000, 53850000, 58250000, 62500000, 65750000, 68000000, 72050000, 76800000, 79200000, 83400000, 87200000, 92500000, 98600000, 105100000, 112500000, 118400000, 125000000, 132800000, 140900000, 150000000, 160000000, 165000000, 178000000, 195000000, 210000000, 225000000, 245000000, 280000000, 320000000, 355000000, 385000000, 420000000, 465000000, 520000000, 550000000, 580000000, 620000000, 685000000, 750000000, 785000000, 835000000, 920000000, 985000000, 1035000000, 1200000000, 1250000000, 1300000000, 1325000000, 1380000000, 1425000000, 1460000000, 1550000000, 1578000000, 1655000000, 1785000000, 1840000000, 1920000000, 2000000000, 2250000000, 2800000000, 3500000000, 3850000000, 4520000000, 4850000000, 5120000000, 5650000000, 6180000000, 6520000000, 6830000000, 7200000000, 7500000000, 7800000000, 8250000000, 8620000000, 9130000000, 9850000000, 10120000000, 10840000000, 11640000000, 12680000000, 14050000000, 15200000000, 15850000000, 16200000000, 16430000000, 17080000000, 18050000000, 19020000000, 20842000000, 21750000000, 22500000000, 23200000000, 23350000000, 23600000000, 23800000000, 24520000000, 25830000000, 26550000000, 27220000000, 28340000000, 29200000000, 30000000000, 30800000000, 31200000000, 31850000000, 32200000000, 32500000000, 32850000000, 33000000000, 34100000000, 34300000000, 34500000000, 34800000000, 35200000000, 35600000000, 35800000000, 36200000000, 36800000000, 37500000000, 38200000000, 39000000000, 39400000000, 39600000000, 39800000000, 40000000000, 40400000000, 40800000000, 41200000000, 41600000000, 42000000000, 42800000000, 43500000000, 44000000000, 44300000000, 44700000000, 45200000000, 45500000000, 45800000000, 47100000000, 47300000000, 47500000000, 47700000000, 48100000000, 48500000000, 49300000000, 50800000000, 51200000000, 51400000000, 51600000000, 51800000000, 52300000000, 52700000000, 53500000000, 54100000000, 54400000000, 54800000000, 56100000000, 56400000000, 56600000000, 57600000000, 58200000000, 59100000000, 60000000000, 60800000000, 61600000000, 62400000000, 63500000000, 64200000000, 65000000000, 66400000000, 68200000000, 70500000000, 72200000000, 73600000000, 75100000000, 76500000000, 76800000000, 78200000000, 79500000000, 80800000000, 81100000000, 81700000000, 82700000000, 83700000000, 85000000000, 86100000000, 86800000000, 87100000000, 87700000000, 88900000000, 90900000000, 91900000000, 92900000000, 94900000000, 96900000000, 98000000000, 99400000000, 99600000000, 101200000000, 102400000000, 103600000000, 104800000000, 106200000000, 107500000000, 108500000000, 110200000000, 112200000000, 113600000000, 114400000000, 116600000000, 118800000000, 120200000000, 121600000000, 123200000000, 126000000000, 126800000000, 127600000000, 127800000000, 128000000000, 130000000000, 132500000000, 135000000000, 137500000000, 140000000000, 142500000000, 145000000000, 147500000000, 150000000000, 180000000000, 182500000000, 197500000000, 212500000000, 227500000000, 252500000000, 277500000000, 285000000000, 300000000000, 315000000000, 340000000000, 367500000000, 392500000000, 450000000000, 480000000000, 525000000000, 567500000000, 625000000000, 687500000000, 722500000000, 780000000000, 797500000000, 880000000000, 897500000000, 922500000000, 975000000000, 1000000000000, 1125500000000, 1186500000000, 1254200000000, 1284400000000, 1352600000000, 1424300000000, 1486500000000, 1542400000000, 1682800000000, 1764200000000, 1842100000000, 1926500000000, 2000000000000, 2010200000000, 2080400000000, 2126500000000, 2164200000000, 2254300000000, 2620000000000, 2850000000000, 3027500000000, 3266400000000, 3428500000000, 3652100000000, 3824800000000, 3956500000000, 4174200000000, 4384500000000, 4624800000000, 5042500000000, 5862400000000, 6542600000000, 7082800000000, 7826500000000, 8682500000000, 9011100000000, 9842100000000, 10425500000000, 11254300000000, 12000000000000, 15000000000000, 18000000000000, 20000000000000, 26000000000000, 30000000000000, 38000000000000, 41000000000000, 48000000000000, 55000000000000, 68000000000000, 87000000000000, 98000000000000, 99000000000000, 100000000000000, 300000000000000, 400000000000000, 800000000000000, 1200000000000000, 2000000000000000, 2800000000000000, 3800000000000000, 6500000000000000, 9800000000000000, 19200000000000000, 30000000000000000, 5000000000000000000 };
        #endregion
        public int[] profStageLevel = { 0, 18, 48, 68, 88, 128, 158, 228, 308, 408, 448 };
        public int[] profAttack = { 1, 2, 5, 10, 20, 30, 50, 120, 300, 800, 2500 };
        public int[] profWeight = { 0, 20, 20, 20, 10, 10, 10, 30, 20, 50, 100 };
        public int[] profHP = { 30, 50, 80, 90, 120, 180, 250, 380, 900, 2000, 8000 };
        public int[] profMP = { 20, 40, 60, 70, 80, 120, 180, 260, 600, 1500, 6000 };
        public State inventoryWeight = new State(0, 0);
        public State hp = new State(0, 0);
        public State mp = new State(0, 0);
        public int attack;
        public int defense;
        public int specialDefense;
        public int damage;
        public int attackSpeed;
        public int hpRecovery;
        public int mpRecovery;
        public int expBonus;
        public int goldBonus;
        public int spBonus;
        public int hpInstantRecovery;
        public int mpInstantRecovery;

        public Dictionary<string, int> effectDict = new Dictionary<string, int>();

        public Ability(string effect = "")
        {
            effectDict = FormatString.ParseInt(effect);

            foreach (KeyValuePair<string, int> temp in effectDict)
            {
                switch (temp.Key)
                {
                    case "a": attack = temp.Value; break;
                    case "d": defense = temp.Value; break;
                    case "c": specialDefense = temp.Value; break;
                    case "t": attackSpeed = temp.Value; break;
                    case "h": hp.max = temp.Value; break;
                    case "m": mp.max = temp.Value; break;
                    case "r": hpRecovery = temp.Value; break;
                    case "v": mpRecovery = temp.Value; break;
                    case "w": inventoryWeight.max = temp.Value; break;
                    case "e": expBonus = temp.Value; break;
                    case "g": goldBonus = temp.Value; break;
                    case "s": spBonus = temp.Value; break;
                    case "hr": hpInstantRecovery = temp.Value; break;
                    case "mr": mpInstantRecovery = temp.Value; break;
                    default: break;
                }
            }
        }

        public void CalculateProfession()
        {
            int size = profStageLevel.Length;
            Character character = Character.GetInstance();
            while (character.level < profStageLevel[--size]) ;
            character.professionLevel = size;
        }

        public void CalculateEXP()
        {
            Character character = Character.GetInstance();
            character.requireEXP = requireEXP[character.level + 1];
        }

        public void CalculateDamage()
        {
            damage = attack;

            Random rnd = new Random();

            int range = (int)((float)damage * (0.25 - (float)attackSpeed * 0.001));
            if (rnd.Next(2) == 0)
                damage -= rnd.Next(range) + 1;
            else
                damage += rnd.Next(range) + 1;
        }

        public void CalculateDamage(Skill skill)
        {
            damage = 0;
            if (skill.damageP != 0)
                damage += (int)(attack * ((skill.damageP + skill.damageUp * skill.skillLevel) / 100.0f));
            damage += skill.damage + skill.damageUp * skill.skillLevel;

            Random rnd = new Random();

            int range = (int)((float)damage * (0.25 - (float)attackSpeed * 0.001));
            if (rnd.Next(2) == 0)
                damage -= rnd.Next(range) + 1;
            else
                damage += rnd.Next(range) + 1;
        }

        // 가장 먼저 호출해야 함.
        public void CalculateDefault()
        {
            attack = 5;
            defense = 30;
            specialDefense = 0;
            attackSpeed = 0;
            hp.max = 250;
            mp.max = 100;
            hpRecovery = 0;
            mpRecovery = 0;
            inventoryWeight.current = 0;
            inventoryWeight.max = 20;
            expBonus = 0;
            goldBonus = 0;
            spBonus = 0;
        }

        public void CalculateLevel()
        {
            Character character = Character.GetInstance();

            int levelAttack = 0;
            for (int i = 1, idx = 0; i <= character.level; i++)
            {
                if (i >= profStageLevel[idx + 1])
                {
                    idx++;
                }
                levelAttack += profAttack[idx];
            }
            attack += levelAttack;

            int levelDefense = 0;
            defense += levelDefense;

            int levelSpecialDefense = 0;
            specialDefense += levelSpecialDefense;

            int levelAttackSpeed = 0;
            attackSpeed += levelAttackSpeed;

            int levelHP = 0;
            for (int i = 1, idx = 0; i <= character.level; i++)
            {
                if (i >= profStageLevel[idx + 1])
                {
                    idx++;
                }
                levelHP += profHP[idx];
            }
            hp.max += levelHP;

            int levelMP = 0;
            for (int i = 1, idx = 0; i <= character.level; i++)
            {
                if (i >= profStageLevel[idx + 1])
                {
                    idx++;
                }
                levelMP += profMP[idx];
            }
            mp.max += levelMP;

            int levelHPRecovery = 0;
            hpRecovery += levelHPRecovery;

            int levelMPRecovery = 0;
            mpRecovery += levelMPRecovery;

            int levelInventoryWeight = 0;
            inventoryWeight.current += levelInventoryWeight;

            int levelInventoryWeightBonus = 0;
            for (int i = 0; i <= character.professionLevel; i++)
            {
                levelInventoryWeightBonus += profWeight[i];
            }
            inventoryWeight.max += levelInventoryWeightBonus;

            int levelExpBonus = 0;
            expBonus += levelExpBonus;

            int levelGoldBonus = 0;
            goldBonus += levelGoldBonus;

            int levelSpBonus = 0;
            spBonus += levelSpBonus;
        }

        public void CalculateEquipObject(EquipObject eo)
        {
            Character character = Character.GetInstance();

            int eoAttack = eo.effect.attack;
            attack += eoAttack;

            int eoDefense = eo.effect.defense;
            defense += eoDefense;

            int eoSpecialDefense = eo.effect.specialDefense;
            specialDefense += eoSpecialDefense;

            int eoAttackSpeed = eo.effect.attackSpeed;
            attackSpeed += eoAttackSpeed;

            int eoHP = eo.effect.hp.max;
            hp.max += eoHP;

            int eoMP = eo.effect.mp.max;
            mp.max += eoMP;

            int eoHPRecovery = eo.effect.hpRecovery;
            hpRecovery += eoHPRecovery;

            int eoMPRecovery = eo.effect.mpRecovery;
            mpRecovery += eoMPRecovery;

            int eoInventoryWeight = eo.weight;
            inventoryWeight.current += eoInventoryWeight;

            int eoInventoryWeightBonus = eo.effect.inventoryWeight.max;
            inventoryWeight.max += eoInventoryWeightBonus;

            int eoExpBonus = eo.effect.expBonus;
            expBonus += eoExpBonus;

            int eoGoldBonus = eo.effect.goldBonus;
            goldBonus += eoGoldBonus;

            int eoSpBonus = eo.effect.spBonus;
            spBonus += eoSpBonus;

            // 스킬레벨+ 무기 효과
            foreach (KeyValuePair<string, int> temp in eo.effect.effectDict)
            {
                if (temp.Key.Length == 2)
                    character.skilldb.GetSkill(temp.Key).bonusLevel += temp.Value;
            }
        }

        public void CalculateSkill(SkillDB skilldb, Skill skill)
        {
            if (skill.learnedLevel > 0)
            {
                switch (skill.type)
                {
                    // 패시브스킬 효과
                    case Skill.SkillTypes.Passive:
                        attack += skill.passiveEffect.attack * skill.skillLevel;
                        attackSpeed += skill.passiveEffect.attackSpeed * skill.skillLevel;
                        defense += skill.passiveEffect.defense * skill.skillLevel;
                        specialDefense += skill.passiveEffect.specialDefense * skill.skillLevel;
                        hp.max += skill.passiveEffect.hp.max * skill.skillLevel;
                        mp.max += skill.passiveEffect.mp.max * skill.skillLevel;
                        hpRecovery += skill.passiveEffect.hpRecovery * skill.skillLevel;
                        mpRecovery += skill.passiveEffect.mpRecovery * skill.skillLevel;
                        inventoryWeight.max += skill.passiveEffect.inventoryWeight.max * skill.skillLevel;
                        expBonus += skill.passiveEffect.expBonus * skill.skillLevel;
                        goldBonus += skill.passiveEffect.goldBonus * skill.skillLevel;
                        spBonus += skill.passiveEffect.spBonus * skill.skillLevel;
                        break;
                    // 스킬레벨+ 스킬 효과
                    case Skill.SkillTypes.SkillBonus:
                        foreach (KeyValuePair<string, int> temp in skill.skillBonusDict)
                        {
                            skilldb.GetSkill(temp.Key).bonusLevel += temp.Value * skill.learnedLevel;
                        }
                        break;
                }
            }

            // 스킬 전체, 스킬 레벨 계산
            for (int i = 0; i < skilldb.skillCount; i++)
            {
                skilldb.skills[i].skillLevel = skilldb.skills[i].learnedLevel + skilldb.skills[i].bonusLevel;
            }
        }

        public void ResetSkillBonus(SkillDB skilldb)
        {
            // 스킬 전체, 스킬 보너스 초기화
            for (int i = 0; i < skilldb.skillCount; i++)
            {
                skilldb.skills[i].bonusLevel = 0;
            }
        }

        public void CalculateCharacterAbility()
        {
            Character character = Character.GetInstance();

            CalculateProfession();
            CalculateEXP();

            CalculateDefault();
            CalculateLevel();
            ResetSkillBonus(character.skilldb);
            CalculateEquipObject(character.gun);
            CalculateEquipObject(character.armor);
            CalculateEquipObject(character.necklace);
            CalculateEquipObject(character.avatar);
            CalculateEquipObject(character.pendant);
            for (int i = 0; i < character.skilldb.skillCount; i++)
            {
                if (character.skilldb.skills[i].type != Skill.SkillTypes.Active)
                {
                    character.ability.CalculateSkill(character.skilldb, character.skilldb.skills[i]);
                }
            }
        }
    }
}
