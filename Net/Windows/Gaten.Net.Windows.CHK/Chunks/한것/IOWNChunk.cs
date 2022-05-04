using Gaten.Net.GameRule.StarCraft.PlayerSystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class IOWNChunk : Chunk
    {
        public IOWNChunk(Player player)
        {
            Name = "IOWN";
            Size = 12;

            Match(player);
        }

        void Match(Player player)
        {
            foreach(Player.PlayerType type in player.StareditTypes)
            {
                AddData((byte)type);
            }
        }
    }
}
