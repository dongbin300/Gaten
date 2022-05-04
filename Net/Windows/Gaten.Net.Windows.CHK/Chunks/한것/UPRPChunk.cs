using Gaten.Net.GameRule.StarCraft.Script;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class UPRPChunk : Chunk
    {
        public UPRPChunk(CUWPSet cuwpSet)
        {
            Name = "UPRP";
            Size = 1280;

            Match(cuwpSet);
        }

        void Match(CUWPSet cuwpSet)
        {
            foreach(CUWP cuwp in cuwpSet.CUWPs)
            {
                AddData((ushort)cuwp.SpecialProperties);
                AddData((ushort)cuwp.ChangedProperties);
                AddData(cuwp.Owner);
                AddData(cuwp.HP);
                AddData(cuwp.Shield);
                AddData(cuwp.Energy);
                AddData(cuwp.ResourceAmount);
                AddData(cuwp.Hangar);
                AddData((ushort)cuwp.Status);
                AddData((uint)0);
            }
        }
    }
}
