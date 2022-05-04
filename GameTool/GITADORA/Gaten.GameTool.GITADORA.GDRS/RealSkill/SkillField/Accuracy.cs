namespace Gaten.GameTool.GITADORA.GDRS.RealSkill.SkillField
{
    internal class Accuracy : SkillField
    {
        public override string Name => "Accuracy";
        public override string DisplayName => "정확도";
        public override string Description => "어려운 박자도 잘 처리함";

        public double OffBeatDensity;

        public override void AddUp() => Score = OffBeatDensity;
    }
}
