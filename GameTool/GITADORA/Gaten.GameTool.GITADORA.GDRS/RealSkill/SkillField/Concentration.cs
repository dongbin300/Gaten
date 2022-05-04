namespace Gaten.GameTool.GITADORA.GDRS.RealSkill.SkillField
{
    internal class Concentration : SkillField
    {
        public override string Name => "Concentration";
        public override string DisplayName => "집중";
        public override string Description => "흐름을 잃지 않고 꾸준히 잘 처리함";

        public double SongLength;
        public double NoteInterval;
        public double OffBeatDensity;

        public override void AddUp() => Score = SongLength * 0.4 + NoteInterval * 0.4 + OffBeatDensity * 0.2;
    }
}
