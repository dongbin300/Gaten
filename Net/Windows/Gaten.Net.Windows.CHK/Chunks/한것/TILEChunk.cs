using Gaten.Net.GameRule.StarCraft.Region.Map;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class TILEChunk : Chunk
    {
        public TILEChunk()
        {
            Name = "TILE";
            Size = 2 * StareditTerrain.Tiles.Length;

            Match();
        }

        void Match()
        {
            foreach (ushort tile in StareditTerrain.Tiles)
            {
                AddData(tile);
            }
        }
    }
}
