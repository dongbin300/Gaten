using Gaten.Net.GameRule.StarCraft.PlayerSystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class COLRChunk : Chunk
    {
        public COLRChunk(Player player)
        {
            Name = "COLR";
            Size = 8;

            Match(player);
        }

        void Match(Player player)
        {
            foreach (Player.Color color in player.Colors)
            {
                AddData((byte)color);
            }
        }
    }
}
