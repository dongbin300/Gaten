namespace Gaten.Net.GameRule.NGD2.SkillSystem
{
    public class Skill : ISkill
    {
        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 타입
        /// </summary>
        public SkillType Type { get; set; }

        /// <summary>
        /// 스킬 레벨
        /// </summary>
        public int Level => Character.Level < MinLevel ? 0 : (Character.Level - MinLevel) / IncLevel + 1;

        /// <summary>
        /// 스킬 최초 습득 캐릭터 레벨
        /// </summary>
        public int MinLevel { get; set; }

        /// <summary>
        /// 습득 레벨 간격
        /// </summary>
        public int IncLevel { get; set; }

        /// <summary>
        /// 활성화 체크
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        /// 활성화 시간
        /// </summary>
        public int Timer { get; set; }

        /// <summary>
        /// 무공 증가량
        /// </summary>
        public double MugongDrop { get; set; }

        public Skill() { }
    }
}
