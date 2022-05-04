namespace Gaten.GameTool.GITADORA.GDRS.RealSkill.SkillField
{
    internal class Stamina : SkillField
    {
        public override string Name => "Stamina";
        public override string DisplayName => "체력";
        public override string Description => "체력이 많이 필요한 노트를 잘 처리함(지속적으로 빠른 노트)";

        public double PedalDensity;
        public double SongLength;
        public double NoteCount;

        public override void AddUp() => Score = PedalDensity * 0.7 + SongLength * 0.15 + NoteCount * 0.15;
    }
}
