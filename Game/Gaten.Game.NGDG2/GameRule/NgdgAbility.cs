using Gaten.Game.NGDG2.GameRule.Character;
using Gaten.Game.NGDG2.GameRule.Item;
using Gaten.Game.NGDG2.Util.Math;

namespace Gaten.Game.NGDG2.GameRule
{
    /// <summary>
    /// 능력치
    /// </summary>
    public class NgdgAbility
    {
        /// <summary>
        /// 계산 방식
        /// </summary>
        public enum CalculateRule
        {
            Character,
            Monster,
            Equipment
        }

        /// <summary>
        /// 계산 방식
        /// 캐릭터는 직업에 따라 기본 스탯이 다르며
        /// 몬스터는 정해진 스탯에 따라 계산된다.
        /// </summary>
        public CalculateRule _CalculateRule;

        /// <summary>
        /// 힘 : HP, 공격력, 공격속도
        /// 힘 수치가 n일 때
        /// HP + 6n, + (5+0.01n)%
        /// 공격력 + 4n, + (5+0.004n)%
        /// 공격속도 + 5n, + (5+0.005n)%
        /// </summary>
        public long Power;

        /// <summary>
        /// 체력 : HP, HP회복, 방어력, 공격력
        /// 체력 수치가 n일 때
        /// HP + 15n, + (5+0.03n)%
        /// HP회복 + 0.05n
        /// 방어력 + 5n, + (5+0.1n)%
        /// 공격력 + 2n, + (5+0.001n)%
        /// </summary>
        public long Stamina;

        /// <summary>
        /// 지능 : MP, 스킬계수
        /// 지능 수치가 n일 때
        /// MP + 5n, + (5+0.01n)%
        /// 스킬계수 + 1n%
        /// </summary>
        public long Intelli;

        /// <summary>
        /// 정신력 : MP, MP회복, 스킬계수
        /// 정신력 수치가 n일 때
        /// MP + 14n, + (5+0.03n)%
        /// MP회복 + 0.07n
        /// 스킬계수 + 0.5n%
        /// </summary>
        public long Willpower;

        /// <summary>
        /// 집중력 : 명중률, HP회복, MP회복
        /// 집중력 수치가 n일 때
        /// 명중률 : 50.0 + n^0.6
        /// HP회복 + 0.15n
        /// MP회복 + 0.2n
        /// </summary>
        public long Concentration;

        /// <summary>
        /// 민첩 : 공격속도, 회피율
        /// 민첩 수치가 n일 때
        /// 공격속도 + 12n, + (5+0.01n)%
        /// 회피율 : n^0.57
        /// </summary>
        public long Agility;

        /// <summary>
        /// HP
        /// 현재 HP
        /// </summary>
        public long HP;

        /// <summary>
        /// HP MAX
        /// 최대 HP
        /// </summary>
        public long HPMax;

        /// <summary>
        /// HP 회복
        /// 1틱당 HP가 회복되는 수치
        /// HP MAX 이후로는 회복되지 않음
        /// </summary>
        public long HPRec;

        /// <summary>
        /// MP
        /// 현재 MP
        /// </summary>
        public long MP;

        /// <summary>
        /// MP MAX
        /// 최대 MP
        /// </summary>
        public long MPMax;

        /// <summary>
        /// MP 회복
        /// 1틱당 MP가 회복되는 수치
        /// MP MAX 이후로는 회복되지 않음
        /// </summary>
        public long MPRec;

        /// <summary>
        /// 공격력
        /// 공격력 1당 적에게 주는 데미지가 1 증가
        /// 기본적으로 적의 방어력만큼 감소된 값으로 데미지가 들어간다.
        /// ex) 나의 공격력: 385, 적의 방어력: 110 = 데미지: 275
        /// </summary>
        public long Attack;

        /// <summary>
        /// 방어력
        /// 방어력 1당 적에게 받는 데미지가 1 감소
        /// 기본적으로 적의 공격력을 나의 방어력만큼 감소된 값으로 데미지를 받는다.
        /// ex) 나의 방어력: 120, 적의 공격력: 270 = 데미지: 150
        /// </summary>
        public long Defense;

        /// <summary>
        /// 공격속도 : 공격쿨타임
        /// 공격속도 수치가 n일 때
        /// 공격쿨타임 : 50 - n^0.4
        /// </summary>
        public long AttackSpeed; // 나중에 바꿔야함

        /// <summary>
        /// 명중률
        /// 공격이 성공할 확률
        /// 기본적으로 적의 회피율만큼 감소된 값이 실제 명중률이다.
        /// ex) 나의 명중률: 92%, 적의 회피율: 24% = 실제 명중률: 68%
        /// </summary>
        public double Accuracy;

        /// <summary>
        /// 회피율
        /// 적의 공격을 회피할 확률
        /// 기본적으로 (1 - 적의 실제 명중률)이 실제 회피율이다.
        /// ex) 나의 회피율: 32%, 적의 명중률: 70% = 적의 실제 명중률: 38%, 실제 회피율: 62%
        /// </summary>
        public double EvasionRate;

        /// <summary>
        /// 공격 쿨타임
        /// 수치가 n일 때 재공격하려면 n틱만큼 기다려야 한다.
        /// </summary>
        public int CoolTick;

        public NgdgAbility()
        {

        }

        public NgdgAbility(CalculateRule calculateRule)
        {
            _CalculateRule = calculateRule;
        }

        /// <summary>
        /// 능력치를 리셋한다.
        /// </summary>
        /// <param name="calculateRule">계산 방식</param>
        public void Reset()
        {
            switch (_CalculateRule)
            {
                case CalculateRule.Character:
                    Power = Stamina = Intelli = Willpower = Concentration = Agility = HPMax = HPRec = MPMax = MPRec = Attack = Defense = AttackSpeed = 0;
                    Accuracy = EvasionRate = 0;
                    break;
                case CalculateRule.Equipment:
                    Power = Stamina = Intelli = Willpower = Concentration = Agility = HPMax = HPRec = MPMax = MPRec = Attack = Defense = AttackSpeed = 0;
                    break;
                case CalculateRule.Monster:
                    HPMax = HPRec = MPMax = MPRec = Attack = Defense = AttackSpeed = 0;
                    Accuracy = EvasionRate = 0;
                    break;
            }
        }

        /// <summary>
        /// 몬스터 생성 전용
        /// 몬스터를 생성할 때 스탯을 설정한다.
        /// </summary>
        /// <param name="power">힘</param>
        /// <param name="stamina">체력</param>
        /// <param name="intelli">지능</param>
        /// <param name="willpower">정신력</param>
        /// <param name="concentration">집중력</param>
        /// <param name="agility">민첩</param>
        public NgdgAbility(long power, long stamina, long intelli, long willpower, long concentration, long agility)
        {
            _CalculateRule = CalculateRule.Monster;

            Power = power;
            Stamina = stamina;
            Intelli = intelli;
            Willpower = willpower;
            Concentration = concentration;
            Agility = agility;
        }

        /// <summary>
        /// 몬스터 생성 전용
        /// 몬스터 생성할 때 스탯 수치로 정해주는 것이 원칙이지만
        /// 특별한 경우 직접 능력치를 설정해서 생성할 수 있다.
        /// </summary>
        /// <param name="hpMax">HP MAX</param>
        /// <param name="mpMax">MP MAX</param>
        /// <param name="hpRec">HP회복</param>
        /// <param name="mpRec">MP회복</param>
        /// <param name="attack">공격력</param>
        /// <param name="defense">방어력</param>
        /// <param name="attackSpeed">공격속도</param>
        /// <param name="accuracy">명중률</param>
        /// <param name="evasionRate">회피율</param>
        public NgdgAbility(long hpMax, long mpMax, long hpRec, long mpRec, long attack, long defense, int attackSpeed, float accuracy, float evasionRate)
        {
            _CalculateRule = CalculateRule.Monster;

            HPMax = hpMax;
            MPMax = mpMax;
            HPRec = hpRec;
            MPRec = mpRec;
            Attack = attack;
            Defense = defense;
            AttackSpeed = attackSpeed;
            Accuracy = accuracy;
            EvasionRate = evasionRate;
        }

        /// <summary>
        /// 능력치를 계산한다.
        /// </summary>
        public void Calculate()
        {
            Reset();

            // 캐릭터는 직업에 따라 스탯이 다르기 때문에 따로 스탯계산이 필요하다.
            if (_CalculateRule == CalculateRule.Character)
            {
                CalculateStats();
            }

            HPMax += (6 * Power) + (15 * Stamina);
            HPMax = MathUtil.Percentage(HPMax, 5.0 + (0.01 * Power) + 5.0 + (0.03 * Stamina));

            HPRec += (long)((0.05 * Stamina) + (0.15 * Concentration));

            MPMax += (5 * Intelli) + (14 * Willpower);
            MPMax = MathUtil.Percentage(MPMax, 5.0 + (0.01 * Intelli) + 5.0 + (0.03 * Willpower));

            MPRec += (long)((0.07 * Willpower) + (0.2 * Concentration));

            Attack += (4 * Power) + (2 * Stamina);
            Attack = MathUtil.Percentage(Attack, 5.0 + (0.004 * Power) + 5.0 + (0.001 * Stamina));

            Defense += 5 * Stamina;
            Defense = MathUtil.Percentage(Defense, 5.0 + (0.1 * Stamina));

            AttackSpeed += (5 * Power) + (12 * Agility);
            AttackSpeed = MathUtil.Percentage(AttackSpeed, 5.0 + (0.005 * Power) + 5.0 + (0.01 * Agility));

            Accuracy += 50.0 + Math.Pow(Concentration, 0.6);

            EvasionRate += Math.Pow(Agility, 0.57);

            CoolTick = (int)(50.0 - Math.Pow(AttackSpeed, 0.4));
        }

        /// <summary>
        /// 스탯을 계산한다. (캐릭터 전용)
        /// 힘, 체력, 지능, 정신력, 집중력, 민첩
        /// </summary>
        public void CalculateStats()
        {
            // 가장 기본이 되는 직업과 레벨
            switch (NgdgCharacter.Class.ClassType)
            {
                case NgdgClass.Type.Warrior:
                    Power += 60 + (6 * NgdgCharacter.Level);
                    Stamina += 40 + (4 * NgdgCharacter.Level);
                    Intelli += 30 + (3 * NgdgCharacter.Level);
                    Willpower += 20;
                    Concentration += 20;
                    Agility += 10;
                    break;

                case NgdgClass.Type.Magician:
                    Power += 20;
                    Stamina += 10;
                    Intelli += 50 + (5 * NgdgCharacter.Level);
                    Willpower += 30 + (3 * NgdgCharacter.Level);
                    Concentration += 40 + (4 * NgdgCharacter.Level);
                    Agility += 30;
                    break;

                case NgdgClass.Type.Gunner:
                    Power += 30 + (3 * NgdgCharacter.Level);
                    Stamina += 20;
                    Intelli += 20;
                    Willpower += 20;
                    Concentration += 30 + (3 * NgdgCharacter.Level);
                    Agility += 60 + (6 * NgdgCharacter.Level);
                    break;

                default:
                    break;
            }

            // 장비 효과
            foreach (NgdgItem equipment in NgdgCharacter.MountEquipments.equipments)
            {
                Power += equipment.Effect.Power;
                Stamina += equipment.Effect.Stamina;
                Intelli += equipment.Effect.Intelli;
                Willpower += equipment.Effect.Willpower;
                Concentration += equipment.Effect.Concentration;
                Agility += equipment.Effect.Agility;
                HPMax += equipment.Effect.HPMax;
                HPRec += equipment.Effect.HPRec;
                MPMax += equipment.Effect.MPMax;
                MPRec += equipment.Effect.MPRec;
                Attack += equipment.Effect.Attack;
                Defense += equipment.Effect.Defense;
                AttackSpeed += equipment.Effect.AttackSpeed;
            }
        }
    }
}
