using Gaten.Net.GameRule.StarCraft.Region;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class MRGNChunk : Chunk
    {
        public MRGNChunk(LocationSet locationSet)
        {
            Name = "MRGN";
            Size = 5100;

            Match(locationSet);
        }

        void Match(LocationSet locationSet)
        {
            foreach(Location location in locationSet.Locations)
            {
                AddData(location.Left);
                AddData(location.Top);
                AddData(location.Right);
                AddData(location.Bottom);
                AddData(location.StringNumber);
                AddData((ushort)location._Elevations);
            }
        }
    }
}
