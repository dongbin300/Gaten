using Gaten.Net.GameRule.StarCraft.Script;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class UPUSChunk : Chunk
    {
        public UPUSChunk(CUWPSet cuwpSet)
        {
            Name = "UPUS";
            Size = 64;

            Match(cuwpSet);
        }

        void Match(CUWPSet cuwpSet)
        {
            foreach(byte usePropertySlot in cuwpSet.UsePropertySlots)
            {
                AddData(usePropertySlot);
            }
        }
    }
}
