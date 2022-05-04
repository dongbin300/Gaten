namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class Scenario
    {
        public static ushort NameStringNumber { get; set; }
        public static ushort DescriptionStringNumber { get; set; }

        public Scenario()
        {
            MakeDefault();
        }

        void MakeDefault()
        {
            NameStringNumber = 1;
            DescriptionStringNumber = 2;
        }
    }
}
