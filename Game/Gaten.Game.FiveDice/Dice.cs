using Gaten.Net.Math;

namespace Gaten.Game.FiveDice
{
    public class Dice
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int IntValue => int.Parse(Value);
        public bool Fixed { get; set; }

        public Dice()
        {
        }

        public void Roll()
        {
            SmartRandom? r = new();

            Value = (r.Next(6) + 1).ToString();
        }
    }
}
