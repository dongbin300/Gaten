namespace Gaten.Game.NGDG2
{
    /// <summary>
    /// 스킬 슬롯
    /// 
    /// 슬롯 하나에는 한 종류의 스킬만 넣을 수 있다.
    /// </summary>
    public class SkillSlot
    {
        /// <summary>
        /// 스킬
        /// </summary>
        public Skill Skill;

        /// <summary>
        /// 스킬 레벨
        /// </summary>
        public int SkillLevel;

        /// <summary>
        /// 스킬이 비어있는지 확인한다.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Skill == null ? true : false;

        public SkillSlot()
        {
        }

        /// <summary>
        /// 스킬북에 스킬을 추가한다.
        /// </summary>
        /// <param name="skill">스킬</param>
        /// <param name="level">스킬레벨</param>
        public void Fill(Skill skill, int level)
        {
            Skill = skill;
            SkillLevel = level;
        }

        /// <summary>
        /// 스킬북에 있는 스킬을 비운다.
        /// </summary>
        public void Empty()
        {
            Skill = null;
            SkillLevel = 0;
        }
    }
}
