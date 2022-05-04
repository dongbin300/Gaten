namespace Gaten.Net.GameRule.StarCraft.PlayerSystem
{
    [Flags]
    public enum ForceProperties
    {
        None = 0,
        RandomStartLocation = 1,
        Allies = 2,
        AlliedVictory = 4,
        SharedVision = 8
    }

    public class Force
    {
        public ushort NameStringNumbers;
        public ForceProperties Properties;

        public Force()
        {

        }

        public Force(ushort nameStringNumber, ForceProperties properties)
        {
            NameStringNumbers = nameStringNumber;
            Properties = properties;
        }
    }
}
