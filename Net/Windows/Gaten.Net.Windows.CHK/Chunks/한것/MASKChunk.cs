using Gaten.Net.GameRule.StarCraft.Region;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class MASKChunk : Chunk
    {
        public MASKChunk()
        {
            Name = "MASK";
            Size = FogOfWar._Fogs.Length;

            Match();
        }

        void Match()
        {
            foreach(FogOfWar.Fogs fog in FogOfWar._Fogs)
            {
                AddData((byte)fog);
            }
        }
    }
}
