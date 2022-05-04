using Gaten.Net.GameRule.StarCraft.PlayerSystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class SIDEChunk : Chunk
    {
        public SIDEChunk(Player player)
        {
            Name = "SIDE";
            Size = 12;

            Match(player);
        }

        void Match(Player player)
        {
            foreach (Player.Species species in player.Races)
            {
                AddData((byte)species);
            }
        }
    }
}
