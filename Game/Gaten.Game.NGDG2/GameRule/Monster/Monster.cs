namespace Gaten.Game.NGDG2
{
    /// <summary>
    /// 몬스터
    /// 
    /// - 몬스터 정보
    /// 힘,체력,지능,정신력,집중력,민첩,EXP,골드,드랍아이템
    /// 
    /// - 드랍아이템 정보
    /// 아이템이름/기대수(N마리를 잡아야 1개가 나오는 확률)
    /// 
    /// 드랍아이템은 몬스터가 생성될 때 이미 정해져있다.
    /// </summary>
    public class Monster
    {
        public string Name;
        public int Level;
        public Ability TotalAbility;
        public List<Skill> Skills;
        public long Exp;
        public long Gold;
        public List<Item> DropItems;
        public string DropItemFormattedInfo;
        public int AttackCool;

        public Monster()
        {

        }

        /// <summary>
        /// [생성자] 몬스터의 능력치를 설정한다.
        /// </summary>
        /// <param name="name">이름</param>
        /// <param name="power">힘</param>
        /// <param name="stamina">체력</param>
        /// <param name="intelli">지능</param>
        /// <param name="willpower">정신력</param>
        /// <param name="concentration">집중력</param>
        /// <param name="agility">민첩</param>
        /// <param name="exp">경험치</param>
        /// <param name="gold">골드</param>
        /// <param name="dropItemFormattedInfo">드롭아이템정보</param>
        public Monster(string name, long power, long stamina, long intelli, long willpower, long concentration, long agility, long exp, long gold, string dropItemFormattedInfo)
        {
            // 이름
            Name = name;

            // 능력치
            TotalAbility = new Ability(power, stamina, intelli, willpower, concentration, agility);

            // 경험치, 골드
            Exp = exp;
            Gold = gold;

            // 드랍아이템
            DropItemFormattedInfo = dropItemFormattedInfo;
        }

        /// <summary>
        /// 몬스터에 관련된 모든 것을 연산한다.
        /// </summary>
        public void Calculate()
        {
            // 공격 쿨타임
            AttackCool = Math.Min(AttackCool + 1, TotalAbility.CoolTick);

            // 몬스터 능력치 재계산
            TotalAbility.Calculate();
        }

        /// <summary>
        /// 몬스터를 만든다.
        /// </summary>
        public Monster Make(Monster frame)
        {
            // 이름
            Name = frame.Name;

            // 능력치
            var basicAbility = new Ability(frame.TotalAbility.Power, frame.TotalAbility.Stamina, frame.TotalAbility.Intelli, frame.TotalAbility.Willpower, frame.TotalAbility.Concentration, frame.TotalAbility.Agility);

            // 경험치, 골드
            var basicExp = frame.Exp;
            var basicGold = frame.Gold;

            // 드랍아이템
            DropItemFormattedInfo = frame.DropItemFormattedInfo;


            /* 돌연변이 */

            SmartRandom r = new SmartRandom();

            // 편차 (+-3%) 구간 100
            Bounds staminaBounds = new Bounds(Convert.ToInt64(basicAbility.Stamina * 0.97), Convert.ToInt64(basicAbility.Stamina * 1.03));
            Bounds expBounds = new Bounds(Convert.ToInt64(basicExp * 0.97), Convert.ToInt64(basicExp * 1.03));
            Bounds goldBounds = new Bounds(Convert.ToInt64(basicGold * 0.97), Convert.ToInt64(basicGold * 1.03));

            int staminaSection = staminaBounds.Range > 100 ? 100 : staminaBounds.Range > 5 ? 5 : 0;
            int expSection = expBounds.Range > 100 ? 100 : expBounds.Range > 5 ? 5 : 0;
            int goldSection = goldBounds.Range > 100 ? 100 : goldBounds.Range > 5 ? 5 : 0;

            long convertedStamina = staminaBounds.Get(staminaSection);
            long convertedExp = expBounds.Get(expSection);
            long convertedGold = goldBounds.Get(goldSection);

            // 능력치 설정
            TotalAbility = new Ability(basicAbility.Power, convertedStamina, basicAbility.Intelli, basicAbility.Willpower, basicAbility.Concentration, basicAbility.Agility);
            TotalAbility.Calculate();

            // HP, MP
            TotalAbility.HP = TotalAbility.HPMax;
            TotalAbility.MP = TotalAbility.MPMax;

            // 경험치, 골드
            Exp = convertedExp;
            Gold = convertedGold;

            // 드랍아이템
            DropItems = new List<Item>();
            string[] dropData = DropItemFormattedInfo.Split('/');
            for (int i = 0; i < dropData.Length / 2; i++)
            {
                Item item = ItemDictionary.MakeItem(dropData[i * 2]);
                int dropNumber = int.Parse(dropData[i * 2 + 1]);

                // 몬스터가 아이템을 가지고 있다!
                if (r.Next(dropNumber) == 0)
                {
                    DropItems.Add(item);
                }
            }

            return this;
        }
    }
}
