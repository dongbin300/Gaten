namespace Gaten.GameTool.GITADORA.GDRS.RealSkill
{
    internal class RealSkillRule
    {
        public static double StartPhraseTiming = 96.0;
        public static double PhraseLength = 700.0;

        public static double NoteDelay = 10.0;

        public static double NoteCountCoef = 250.0; // 반비례

        public static double LackThreshold = 0.3; // 제외되는 임계점

        public static double SongLengthCoef = 25.0; // 반비례

        public static double NoteIntervalCoef = 2500.0; // 비례
        public static double NoteIntervalMargin = 20;

        public static double OffBeatMargin = 10;
        public static double OffBeatCoef = 2.0; // 반비례
    }
}
