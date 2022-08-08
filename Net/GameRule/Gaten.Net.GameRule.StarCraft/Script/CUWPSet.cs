using Gaten.Net.Extensions;

namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class CUWPSet
    {
        public List<CUWP> CUWPs { get; set; }
        public byte[] UsePropertySlots { get; set; }

        public CUWPSet()
        {
            CUWPs = new List<CUWP>();
            UsePropertySlots = new byte[64];

            MakeDefault();
        }

        void MakeDefault()
        {
            for (int i = 0; i < 64; i++)
            {
                CUWPs.Add(new CUWP(PlaySystem.SpecialProperties.None, PlaySystem.ChangedProperties.Owner | PlaySystem.ChangedProperties.HP | PlaySystem.ChangedProperties.Shield | PlaySystem.ChangedProperties.Energy | PlaySystem.ChangedProperties.Resource | PlaySystem.ChangedProperties.Hangar, 0, 100, 100, 100, 0, 0, PlaySystem.UnitStatus.None));
            }

            UsePropertySlots.Fill((byte)0);
        }
    }
}
