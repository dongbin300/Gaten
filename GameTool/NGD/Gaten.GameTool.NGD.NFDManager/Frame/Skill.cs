namespace Gaten.GameTool.NGD.NFDManager.Frame
{
    public class Skill
    {
        public enum SkillType
        {
            Active,
            Passive,
            Buff
        }

        public string Name;
        public SkillType Type;
        public string Level;
        public int MasterLevel;
        public int AcquisitionPoint;
        public int CostEXP;
        public int CostGold;
        public int CostHP;
        public int CostMP;
        public int TargetCount;
        public int Damage;
        public int Cool;
    }
}
