using Gaten.Net.GameRule.StarCraft.Region.Map;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class ERAChunk : Chunk
    {
        public ERAChunk()
        {
            Name = "ERA ";
            Size = 2;

            Match();
        }

        void Match()
        {
            AddData((ushort)Base.TileSet);
        }
    }
}
