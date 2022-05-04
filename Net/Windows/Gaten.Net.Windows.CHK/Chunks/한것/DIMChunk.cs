using Gaten.Net.GameRule.StarCraft.Region.Map;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class DIMChunk : Chunk
    {
        public DIMChunk()
        {
            Name = "DIM ";
            Size = 4;

            Match();
        }

        void Match()
        {
            AddData((ushort)Base.HorizontalDimension);
            AddData((ushort)Base.VerticalDimension);
        }
    }
}
