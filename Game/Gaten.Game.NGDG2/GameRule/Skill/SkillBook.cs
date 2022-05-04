namespace Gaten.Game.NGDG2
{
    public class SkillBook
    {
        public List<SkillSlot> Slots;

        public SkillBook(int slotMaxCount)
        {
            Slots = new List<SkillSlot>();

            for (int i = 0; i < slotMaxCount; i++)
            {
                Slots.Add(new SkillSlot());
            }
        }

        /// <summary>
        /// 스킬북에 스킬을 추가한다.
        /// 이 메서드는 캐릭터를 로드하거나 스킬을 배울 때 호출한다.
        /// </summary>
        /// <param name="skill">스킬</param>
        /// <param name="level">레벨+ 수치</param>
        public void Add(Skill skill, int level)
        {
            // 해당 스킬이 스킬북에 있는지 확인
            SkillSlot skillSlot = Slots.FindAll(s => !s.IsEmpty()).Find(s => s.Skill.Name.Equals(skill.Name));

            // 이미 있으면 스킬레벨만 더함
            if (skillSlot != null)
            {
                skillSlot.SkillLevel += level;
            }
            // 없으면 스킬을 추가함
            else
            {
                Slots.Find(s => s.IsEmpty()).Fill(skill, level);
            }
        }

        /// <summary>
        /// 스킬의 레벨을 추가로 올린다.
        /// 스킬을 가지고 있지 않으면 레벨이 오르지 않는다.
        /// 이 메서드는 장비나 스킬, 아이템에 의하여 스킬레벨이 오를 때 호출한다.
        /// </summary>
        /// <param name="skill">스킬</param>
        /// <param name="level">레벨+ 수치</param>
        public void AddBonus(Skill skill, int level)
        {
            // 해당 스킬이 스킬북에 있는지 확인
            SkillSlot slot = Slots.Find(s => s.Skill.Name.Equals(skill.Name));

            // 있으면 더함
            if (slot != null)
            {
                slot.SkillLevel += level;
            }
        }
    }
}
