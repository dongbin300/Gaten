using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class TECSChunk : Chunk
    {
        public TECSChunk(string name, int size, Tech technology)
        {
            Name = name;
            Size = size;

            AddData((byte)technology.SettingRule);
            AddData(technology.Mineral);
            AddData(technology.Gas);
            AddData(technology.Time);
            AddData(technology.Energy);
        }
    }
}
