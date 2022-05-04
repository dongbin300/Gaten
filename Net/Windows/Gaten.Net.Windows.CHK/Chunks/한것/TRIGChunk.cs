using Gaten.Net.GameRule.StarCraft.Script;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class TRIGChunk : Chunk
    {
        public TRIGChunk(TriggerSet triggerSet)
        {
            Name = "TRIG";
            Size = 7200;

            Match(triggerSet);
        }

        void Match(TriggerSet triggerSet)
        {
            AddData(triggerSet.MasterCode);
        }
    }
}
