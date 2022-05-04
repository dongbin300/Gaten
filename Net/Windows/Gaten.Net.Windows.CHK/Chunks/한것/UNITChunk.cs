using Gaten.Net.GameRule.StarCraft.Region;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class UNITChunk : Chunk
    {
        public UNITChunk(List<PlacedUnit> placedUnits)
        {
            Name = "UNIT";
            Size = 36 * placedUnits.Count;

            foreach(PlacedUnit u in placedUnits)
            {
                AddData(u.ClassInstance);
                AddData(u.X);
                AddData(u.Y);
                AddData(u.ID);
                AddData((ushort)u.BuildingRelation);
                AddData((ushort)u.SpecialProperties);
                AddData((ushort)u.ChangedProperties);
                AddData(u.Owner);
                AddData(u.HP);
                AddData(u.Shield);
                AddData(u.Energy);
                AddData(u.Resource);
                AddData(u.Hangar);
                AddData((ushort)u.Status);
                AddData(u.Unused);
                AddData(u.LinkedClassInstance);
            }
        }
    }
}