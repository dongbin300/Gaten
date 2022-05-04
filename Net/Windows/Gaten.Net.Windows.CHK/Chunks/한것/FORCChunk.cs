using Gaten.Net.GameRule.StarCraft.PlayerSystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class FORCChunk : Chunk
    {
        public FORCChunk(Player player)
        {
            Name = "FORC";
            Size = 20;

            Match(player);
        }

        void Match(Player player)
        {
            foreach (byte forceNumber in player.ForceNumbers)
            {
                AddData(forceNumber);
            }
            
            foreach(Force force in ForceSet.Forces)
            {
                AddData(force.NameStringNumbers);
            }

            foreach (Force force in ForceSet.Forces)
            {
                AddData((byte)force.Properties);
            }
        }
    }
}
