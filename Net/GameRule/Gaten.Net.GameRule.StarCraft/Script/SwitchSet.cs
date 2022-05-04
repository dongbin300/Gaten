namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class SwitchSet
    {
        public List<Switch> Switches { get; set; }

        public SwitchSet()
        {
            Switches = new List<Switch>();

            MakeDefault();
        }

        void MakeDefault()
        {
            for (int i = 0; i < 256; i++)
            {
                Switches.Add(new Switch(0));
            }
        }
    }
}
