using Gaten.Net.GameRule.Saki.Skill.Content;

namespace Gaten.Net.GameRule.Saki.Skill
{
    public class DarkHolyBoom : SakiSkill
    {
        public static AwakeningContent Awakening { get; set; } = new();
        public static ReleaseContent Release { get; set; } = new();

        public DarkHolyBoom()
        {
            Name = "다크 홀리 붐";

            // 4각, 각성 한단계에 신1 32개
            Awakening.Max = 4;
            Awakening.Cost = 32;
            Awakening.Benchmark = 4;
            Awakening.Power = new List<int>
            {
                1950, 2750, 3600, 4600, 5750, 7100, 8650, 10450
            };

            // 15해방, 해방 한단계에 신1 16개
            Release.Max = 15;
            Release.Cost = 16;
            Release.Benchmark = 8;
            Release.Power = new List<int>
            {
                0, 25, 50, 63, 75, 98, 120, 150, 180, 240, 300, 370, 450, 540, 640, 750, 870, 1000, 1140, 1290, 1450, 1620, 1800, 1990
            };
        }

        public static int GetPower(int awakeningLevel, int releaseLevel) =>
            (int)Math.Round(Awakening.GetPower(awakeningLevel) * (1 + Release.GetPower(releaseLevel) / 100.0), 0);

        public static string ToString(int awakeningLevel, int releaseLevel)
        {
            return $"다크 홀리 붐 {(awakeningLevel == 0 ? "명함" : awakeningLevel + "각")} {releaseLevel}해방";
        }
    }
}
