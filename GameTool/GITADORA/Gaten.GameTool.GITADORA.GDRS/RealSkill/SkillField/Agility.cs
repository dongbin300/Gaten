namespace Gaten.GameTool.GITADORA.GDRS.RealSkill.SkillField
{
    internal class Agility : SkillField
    {
        public override string Name => "Agility";
        public override string DisplayName => "민첩";
        public override string Description => "빠르게 처리해야하는 노트를 잘 처리함(순간적으로 빠른 노트)";

        public double NoteInterval;

        public override void AddUp() => Score = NoteInterval;
    }
}
