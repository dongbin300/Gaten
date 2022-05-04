using Gaten.Net.GameRule.StarCraft.Script;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class SPRPChunk : Chunk
    {
        public SPRPChunk()
        {
            Name = "SPRP";
            Size = 4;

            Match();
        }

        void Match()
        {
            AddData(Scenario.NameStringNumber);
            AddData(Scenario.DescriptionStringNumber);
        }
    }
}
