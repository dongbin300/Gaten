using Gaten.Net.GameRule.StarCraft.Script;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class SWNMChunk : Chunk
    {
        public SWNMChunk(SwitchSet switchSet)
        {
            Name = "SWNM";
            Size = 1024;

            Match(switchSet);
        }

        void Match(SwitchSet switchSet)
        {
            foreach(Switch @switch in switchSet.Switches)
            {
                AddData(@switch.NameStringNumber);
            }
        }
    }
}
