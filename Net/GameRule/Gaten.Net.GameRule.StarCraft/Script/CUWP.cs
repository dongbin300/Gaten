namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class CUWP
    {
        public PlaySystem.SpecialProperties SpecialProperties { get; set; }
        public PlaySystem.ChangedProperties ChangedProperties { get; set; }
        public byte Owner { get; set; }
        public byte HP { get; set; }
        public byte Shield { get; set; }
        public byte Energy { get; set; }
        public uint ResourceAmount { get; set; } // resource only
        public ushort Hangar { get; set; }
        public PlaySystem.UnitStatus Status { get; set; }

        public CUWP()
        {

        }

        public CUWP(PlaySystem.SpecialProperties specialProperties, PlaySystem.ChangedProperties changedProperties, byte owner, byte hp, byte shield, byte energy, uint resourceAmount, ushort hangar, PlaySystem.UnitStatus status)
        {
            SpecialProperties = specialProperties;
            ChangedProperties = changedProperties;
            Owner = owner;
            HP = hp;
            Shield = shield;
            Energy = energy;
            ResourceAmount = resourceAmount;
            Hangar = hangar;
            Status = status;
        }
    }
}
