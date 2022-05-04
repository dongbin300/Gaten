using Gaten.Net.GameRule.StarCraft.Region.Map;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class MTXMChunk : Chunk
    {
        public MTXMChunk()
        {
            Name = "MTXM";
            Size = 2 * Terrain.Tiles.Length;

            Match();
        }

        void Match()
        {
            foreach (ushort tile in Terrain.Tiles)
            {
                AddData(tile);
            }
        }
    }
}
