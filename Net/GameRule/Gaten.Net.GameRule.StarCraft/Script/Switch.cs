namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class Switch
    {
        public enum State
        {
            Set = 2,
            Cleared = 3
        }

        public uint NameStringNumber { get; set; }

        public Switch()
        {

        }

        public Switch(uint nameStringNumber)
        {
            NameStringNumber = nameStringNumber;
        }
    }
}
