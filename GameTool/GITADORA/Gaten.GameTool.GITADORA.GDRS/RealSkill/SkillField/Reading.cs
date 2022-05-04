namespace Gaten.GameTool.GITADORA.GDRS.RealSkill.SkillField
{
    internal class Reading : SkillField
    {
        public override string Name => "Reading";
        public override string DisplayName => "노트리딩";
        public override string Description => "복잡하게 나오는 노트를 잘 처리함";

        public double TomDensity;
        public double NoteDensity;
        public double NoteInterval;

        public override void AddUp() => Score = TomDensity * 0.6 + NoteDensity * 0.4;
    }
}
