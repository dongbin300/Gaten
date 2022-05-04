namespace Gaten.Game.NGDG2
{
    /// <summary>
    /// 스킬
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// 스킬 타입 분류
        /// 액티브 - 캐릭터가 직접 발동하는 스킬
        /// 패시브 - 항상 지속되거나 특정한 조건에 자동으로 발동되는 스킬
        /// 버프 - 일정 시간동안 캐릭터를 강화시켜주는 스킬
        /// </summary>
        public enum SkillType
        {
            Active,
            Passive,
            Buff
        }

        /// <summary>
        /// 스킬 이름(ID)
        /// </summary>
        public string Name;

        /// <summary>
        /// 스킬 타입
        /// </summary>
        public SkillType Type;

        /// <summary>
        /// 스킬 습득 최소 캐릭터 레벨
        /// </summary>
        public string Level;

        /// <summary>
        /// 스킬 마스터 레벨
        /// </summary>
        public int MasterLevel;

        /// <summary>
        /// 스킬 습득 필요 포인트
        /// </summary>
        public int AcquisitionPoint;

        /// <summary>
        /// 스킬 시전 소모 경험치
        /// </summary>
        public int CostEXP;

        /// <summary>
        /// 스킬 시전 소모 골드
        /// </summary>
        public int CostGold;

        /// <summary>
        /// 스킬 시전 소모 HP
        /// </summary>
        public int CostHP;

        /// <summary>
        /// 스킬 시전 소모 MP
        /// </summary>
        public int CostMP;

        /// <summary>
        /// 목표 몬스터 수
        /// </summary>
        public int TargetCount;

        /// <summary>
        /// 스킬 계수(%)
        /// 스킬 데미지는 스킬 계수와 현재 캐릭터 공격력에 비례해서 계산된다. 
        /// </summary>
        public int Damage;

        /// <summary>
        /// 스킬 쿨타임(틱)
        /// </summary>
        public int Cool;

        public Skill()
        {

        }

        public Skill(string name)
        {
            Name = name;

            // TODO
        }
    }
}
