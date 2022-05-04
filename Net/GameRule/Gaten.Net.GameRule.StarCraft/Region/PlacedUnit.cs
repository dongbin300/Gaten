using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.GameRule.StarCraft.Region
{
    public class PlacedUnit
    {
        public uint ClassInstance { get; set; }
        public ushort X { get; set; }
        public ushort Y { get; set; }
        public ushort ID { get; set; }
        public BuildingRelation BuildingRelation { get; set; }
        public SpecialProperties SpecialProperties { get; set; }
        public ChangedProperties ChangedProperties { get; set; }
        public byte Owner { get; set; }
        public byte HP { get; set; }
        public byte Shield { get; set; }
        public byte Energy { get; set; }
        public uint Resource { get; set; }
        public ushort Hangar { get; set; }
        public UnitStatus Status { get; set; }
        public uint Unused { get; set; }
        public uint LinkedClassInstance { get; set; }
    }
}
