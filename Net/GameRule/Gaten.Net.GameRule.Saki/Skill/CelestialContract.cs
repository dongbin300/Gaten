using Gaten.Net.GameRule.Saki.Skill.Content;

namespace Gaten.Net.GameRule.Saki.Skill
{
    public class CelestialContract : SakiSkill
    {
        public static AwakeningContent Awakening { get; set; } = new();
        public static ReleaseContent Release { get; set; } = new();

        public CelestialContract()
        {
            Name = "천계의 계약";

            // 4각, 각성 한단계에 신1 128개
            Awakening.Max = 4;
            Awakening.Cost = 128;
            Awakening.Benchmark = 1;
            Awakening.Power = new List<int>
            {
                150, 300, 540, 900, 1350, 1920
            };

            // 15해방, 해방 한단계에 신1 64개
            Release.Max = 15;
            Release.Cost = 64;
            Release.Benchmark = 2;
            Release.Power = new List<int>
            {
                0, 50, 100, 150, 200, 280, 360, 480, 600, 750, 900, 1200, 1550, 1950, 2400, 3000, 3700, 4500
            };
        }

        public static int GetPower(int awakeningLevel, int releaseLevel) =>
            (int)Math.Round(Awakening.GetPower(awakeningLevel) * (1 + Release.GetPower(releaseLevel) / 100.0), 0);

        public static string ToString(int awakeningLevel, int releaseLevel)
        {
            return $"천계의 계약 {(awakeningLevel == 0 ? "명함" : awakeningLevel + "각")} {releaseLevel}해방";
        }
    }
}
