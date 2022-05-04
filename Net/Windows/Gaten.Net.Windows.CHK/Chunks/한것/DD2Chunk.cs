using Gaten.Net.GameRule.StarCraft.Region.Map;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class DD2Chunk : Chunk
    {
        public DD2Chunk(List<Doodad> doodads)
        {
            Name = "DD2 ";
            Size = 8 * doodads.Count;

            Match(doodads);
        }

        void Match(List<Doodad> doodads)
        {
            // TODO
        }
    }
}
