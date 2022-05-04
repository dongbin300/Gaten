using Gaten.Net.GameRule.StarCraft.PlayerSystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class OWNRChunk : Chunk
    {
        public OWNRChunk(Player player)
        {
            Name = "OWNR";
            Size = 12;

            Match(player);
        }

        void Match(Player player)
        {
            foreach (Player.PlayerType type in player.StarcraftTypes)
            {
                AddData((byte)type);
            }
        }
    }
}
