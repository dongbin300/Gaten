using Gaten.Net.Data.Math;

namespace Gaten.Game.FiveDice
{
    public class Dice
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int IntValue => int.Parse(Value);
        public bool Fixed { get; set; }

        public Dice()
        {

        }

        public void Roll()
        {
            SmartRandom r = new SmartRandom();

            Value = (r.Next(6) + 1).ToString();
        }
    }
}
