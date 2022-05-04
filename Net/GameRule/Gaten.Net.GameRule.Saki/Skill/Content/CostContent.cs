namespace Gaten.Net.GameRule.Saki.Skill.Content
{
    public class CostContent
    {
        public int Cost { get; set; }
        public int Max { get; set; }
        public int Benchmark { get; set; }
        public List<int> Power { get; set; } = new();

        public int GetPower(int level) => Power[level];
    }
}
